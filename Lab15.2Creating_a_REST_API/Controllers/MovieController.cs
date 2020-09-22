using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab15._2Creating_a_REST_API.Controllers
{
    [Route("Movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet]
        public List<Movie> Movies()
        {
            List<Movie> movies = DAL.Read();
            return movies;
        }

        [HttpGet("Category/{category}")]
        public List<Movie> Movies(string category)
        {
            List<Movie> movies = DAL.Read(category);
            return movies;
        }

        [HttpGet("Random")]
        public List<Movie> RandomMovie(long id)
        {
            Random rand = new Random();
            List<Movie> movies = DAL.Read();
            int randChoice = rand.Next(0, movies.Count);
            long movieID = movies[randChoice].id;
            List<Movie> movie = DAL.Read(movieID);
            return movie;
        }

        [HttpGet("Random/{category}")]
        public List<Movie> RandomCategory(string category)
        {
            Random rand = new Random();
            List<Movie> movies = DAL.Read(category);
            Movie movie = null;
            if(movies.Count != 0)
            {
                int randChoice = rand.Next(0, movies.Count);
                long movieID = movies[randChoice].id;
                movies = DAL.Read(movieID);
            }
            return movies;
        }
    }
}
