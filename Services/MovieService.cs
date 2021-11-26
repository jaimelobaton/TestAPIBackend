using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestAPIBackend.Authentication;
using TestAPIBackend.Data;
using TestAPIBackend.Utill;

namespace TestAPIBackend.Services
{
    public class MovieService : IMovieService
    {
        private readonly TestDbContext _db;
        private readonly IHttpContextAccessor _userManager;
        private string user;

        public MovieService(TestDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _userManager = httpContextAccessor;
        }

        /// <summary>
        /// Get All the Public Elements prefilled, if CreatorUser is null , it means that the list is public
        /// </summary>
        /// <returns></returns>
        public List<Movie> getAllPublicMovies(Pagination pagination)
        {
            var publicMovies = _db.Movies
                .Include(mov => mov.Director)
                .Include(mov => mov.Genrer)
                .Include(mov => mov.Studio)
                .Where(x => x.CreatorUser == null)
                .OrderBy(on => on.Title)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToList();

            return publicMovies;
        }

        /// <summary>
        ///  Create a new Movie
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void CreateMovie(Movie model)
        {
            user = _userManager.HttpContext.User.Identity.Name;
            model.CreatorUser = user;
            using (_db)
            {
                _db.Movies.Add(model);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// Get All the Movies By User Logged
        /// </summary>
        /// <returns></returns>
        public List<Movie> getAllMoviesByUser(Pagination pagination)
        {
            user = _userManager.HttpContext.User.Identity.Name;
            var publicMovies = _db.Movies
               .Include(mov => mov.Director)
               .Include(mov => mov.Genrer)
               .Include(mov => mov.Studio)
               .Where(x => x.CreatorUser == user)
               .OrderBy(on => on.Title)
               .Skip((pagination.PageNumber - 1) * pagination.PageSize)
               .Take(pagination.PageSize)
               .ToList();

            return publicMovies;
        }

        /// <summary>
        /// Edit a movie By id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditMovie(Movie model)
        {
            user = _userManager.HttpContext.User.Identity.Name;
            var data = _db.Movies.FirstOrDefault(x => x.Id == model.Id);
            bool OwnMovie = (data.CreatorUser == user) ? true : false;
            //Validate that users are trying to read, update or delete their own private elements, otherwise send a meaningful response.
            if (!OwnMovie)
                return 1;
            //
            if (data == null)
                return 2;
            //Map data
            data.Title = model.Title;
            data.ReleaseDate = model.ReleaseDate;
            data.DirectorId = data.DirectorId;
            data.GenrerId = model.GenrerId;
            data.Duration = model.Duration;
            data.StudioId = model.StudioId;
            model.CreatorUser = user;
            _db.SaveChanges();
            return 3;
        }

        /// <summary>
        /// Method that allows to delete one element By Id or All at once
        /// </summary>
        /// <param name="id">Id element to delete</param>
        /// <returns></returns>
        public int DeleteMovie(int id)
        {
            user = _userManager.HttpContext.User.Identity.Name;
            if (id != 0)
            {
                var data = _db.Movies.FirstOrDefault(x => x.Id == id);
                //Validate that users are trying to read, update or delete their own private elements, otherwise send a meaningful response.
                bool OwnMovie = (data.CreatorUser == user) ? true : false;
                if (!OwnMovie)
                    return 1;
                //
                if (data == null)
                    return 2;

                using (_db)
                {
                    _db.Movies.Remove(data);
                    _db.SaveChanges();
                }
                return 3;
            }
            else
            {
                //Delete All the movies at once.
                var moviesUser = _db.Movies.Where(m => m.CreatorUser == user);
                if (moviesUser.Count() == 0)
                    return 4;
                using (_db)
                {
                    _db.Movies.RemoveRange(moviesUser);
                    _db.SaveChanges();
                }
                return 5;
            }
        }

        /// <summary>
        ///  Adding a Movie that you like
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int LikePublicMovies(LikedMoviesUsers model)
        {
            user = _userManager.HttpContext.User.Identity.Name;
            var moviesUser = _db.LikedMoviesUserss.Where(m => m.User == user && m.MovieId == model.MovieId).FirstOrDefault();
            //validates that the film exists and is a public element
            var data = _db.Movies.FirstOrDefault(x => x.Id == model.MovieId && x.CreatorUser == null);
            if (data == null)
                return 1;

            model.User = user;
            if (moviesUser == null)
            {
                using (_db)
                {
                    _db.LikedMoviesUserss.Add(model);
                    _db.SaveChanges();
                }
                return 2;
            }
            else
            {
                moviesUser.MovieId = model.MovieId;
                moviesUser.Liked = model.Liked;
                moviesUser.User = model.User;
                _db.SaveChanges();
                return 3;
            }
        }

        /// <summary>
        /// Get All the Public Elements prefilled, if CreatorUser is null , it means that the list is public
        /// </summary>
        /// <returns></returns>
        public List<Movie> getAllLikedMoviesByUser(Pagination pagination)
        {
            var likedMovies = (from m in _db.Movies
                               join l in _db.LikedMoviesUserss
                               on m.Id equals l.MovieId
                               select new Movie
                               {
                                   Id = m.Id,
                                   Title = m.Title,
                                   Duration = m.Duration,
                                   ReleaseDate = m.ReleaseDate,
                                   Genrer = m.Genrer,
                                   Studio = m.Studio,
                                   Director = m.Director
                               })
                               .OrderBy(on => on.Title)
                                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                                .Take(pagination.PageSize)
                               .ToList();

            return likedMovies;
        }
    }
}
