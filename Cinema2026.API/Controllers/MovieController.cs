using Cinema2026.Repo.Data;
using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Cinema2026.Repo.Repositiories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinema2026.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IGenericRepository<Movies> _repo;
        public MovieController(IGenericRepository<Movies> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public Task<Movies> CreatMovie([FromBody] Movies movies)
        {
            var created = _repo.Add(movies);
            return created;
        }
    }
}
