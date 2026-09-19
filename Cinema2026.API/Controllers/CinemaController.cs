using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinema2026.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly IGenericRepository<MovieHall> _hallRepo;
        private readonly IGenericRepository<Movies> _movieRepo;
        public CinemaController(IGenericRepository<MovieHall> hallRepo,IGenericRepository<Movies> movieRepo)
        {
            _hallRepo = hallRepo;
            _movieRepo = movieRepo;
        }

        //[HttpPost]
        //public Task<MovieHall> AssignMovie([FromBody] int hallId, int movieId)
        //{

        //}
    }
}
