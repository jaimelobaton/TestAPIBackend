using System.Collections.Generic;
using TestAPIBackend.Data;
using TestAPIBackend.Utill;

namespace TestAPIBackend.Services
{
    public interface IMovieService
    {
        List<Movie> getAllPublicMovies(Pagination pagination);

        void CreateMovie(Movie model);
        List<Movie> getAllMoviesByUser(Pagination pagination);
        int EditMovie(Movie model);
        int DeleteMovie(int id);
        int LikePublicMovies(LikedMoviesUsers model);
        List<Movie> getAllLikedMoviesByUser(Pagination pagination);
    }
}