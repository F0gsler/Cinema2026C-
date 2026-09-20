using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinema2026.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieHallController : ControllerBase
    {
        public IGenericRepository<MovieHall> _repo;
        public MovieHallController(IGenericRepository<MovieHall> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public Task<MovieHall> CreateMovieHall(MovieHall movieHall)
        {
            var created = _repo.Add(movieHall);
            return created;
        }

        [HttpDelete("{moviehallid}")]
        public async Task<MovieHall> DeleteMovieHall(int moviehallid)
        {
            var movieHall = await _repo.GetById(moviehallid);
            if (movieHall == null)
                return null!;

            await _repo.Delete(moviehallid);
            return null!;
        }
        [HttpGet("{moviehallid}")]
        public Task<MovieHall?> GetMovieHallList(int moviehallid) => _repo.GetById(moviehallid);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieHall>>> GetAllMovieHalls()
        {
            var halls = await _repo.GetAll();
            return Ok(halls);
        }

    }
}
