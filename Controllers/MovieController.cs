using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPIBackend.Authentication;
using Microsoft.EntityFrameworkCore;
using TestAPIBackend.Data;
using Microsoft.AspNetCore.Identity;
using Castle.Core.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using TestAPIBackend.Services;
using TestAPIBackend.Utill;

namespace TestAPIBackend.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movies;

        public MovieController(IMovieService movies)
        {
            _movies = movies;
        }

        /// <summary>
        /// Get All the Public Elements prefilled, if CreatorUser is null , it means that the list is public
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllPublicMovies")]
        public IEnumerable<Movie> getAllPublicMovies([FromQuery] Pagination pagination)
        {

            try
            {
                return _movies.getAllPublicMovies(pagination);
            }
            catch (Exception)
            {
                throw;
            }
          

        }

        /// <summary>
        ///  Create a new Movie
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateMovie")]
        public IActionResult CreateMovie([FromBody] Movie model)
        {
            //Get
            try
            {
                _movies.CreateMovie(model);
                return Ok(new Response { Status = "Success", Message = "Movie created successfully!" });
            }
            catch (Exception)
            {
                return BadRequest(new Response { Status = "Error", Message = "Error creating the Movie!!" });
            }

        }

        /// <summary>
        /// Get All the Movies By User Logged
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllMoviesByUser")]
        public IEnumerable<Movie> getAllMoviesByUser([FromQuery] Pagination pagination)
        {
            //Get 
            try
            {
                return _movies.getAllMoviesByUser(pagination);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Edit a movie By id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("EditMovie")]
        public IActionResult EditMovie([FromBody] Movie model)
        {
            try
            {
                var response = _movies.EditMovie(model);
                if (response ==1)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "This Movie doesn´t belong to you!" });
                else if(response == 2)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "This Movie doesn´t exist!" });
                else
                    return Ok(new Response { Status = "Success", Message = "Movie Edited successfully!" });
            }
            catch (Exception)
            {
                return BadRequest(new Response { Status = "Error", Message = "Error editing the Movie!!" });
            }
        }

        /// <summary>
        /// Method that allows to delete one element By Id or All at once
        /// </summary>
        /// <param name="id">Id element to delete</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteMovie/{id:int?}")]
        public IActionResult DeleteMovie(int id = 0)
        {
            try
            {
                var response = _movies.DeleteMovie(id);
                if (response == 1)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "This Movie doesn´t belong to you!" });
                else if (response == 2)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "This Movie doesn´t exist!" });
                else if (response == 3)
                    return Ok(new Response { Status = "Success", Message = "Movie deleted successfully!" });
                else if (response == 4)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "You don't have movies yet!!" });
                else
                    return Ok(new Response { Status = "Success", Message = " All Movies deleted successfully!" });
            }
            catch (Exception)
            {
                return BadRequest(new Response { Status = "Error",  Message = "Error deleting the Movie!!" });
            }

        }

        /// <summary>
        ///  Adding a Movie that you like
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("LikePublicMovies")]
        public IActionResult LikePublicMovies([FromBody] LikedMoviesUsers model)
        {
            try
            {

                var response = _movies.LikePublicMovies(model);
                if (response == 1)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "This Movie doesn´t exist or is not a Public Element!" });
                else if (response == 2)
                    return Ok(new Response { Status = "Success", Message = "You added a movie that you like!" });
                else 
                    return Ok(new Response { Status = "Success", Message = "you updated the liked status of the movie!" });
            }
            catch (Exception)
            {
                return BadRequest(new Response { Status = "Error", Message = "Error creating the Movie!!" });
            }

        }
        /// <summary>
        /// Get All the Public Elements prefilled, if CreatorUser is null , it means that the list is public
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllLikedMoviesByUser")]
        public IEnumerable<Movie> getAllLikedMoviesByUser([FromQuery] Pagination pagination)
        {
            //Get 
            try
            {
                return _movies.getAllLikedMoviesByUser(pagination);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
