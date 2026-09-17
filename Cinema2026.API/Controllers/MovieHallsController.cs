using Cinema2026.Repo.Data;
using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Cinema2026.Repo.Repositiories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;


[Route("api/[controller]")]
[ApiController]
public class MovieHallsController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly IMovieHallRepositories _movieHallRepo;
    public MovieHallsController(DatabaseContext context, IMovieHallRepositories movieHallRepo)
    {
        _context = context;
        _movieHallRepo = movieHallRepo;
    }

    // GET: api/MovieHall
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieHall>>> GetMovieHall()
    {
        return await _context.MovieHalls.ToListAsync();
    }

    // GET: api/MovieHall/5
    [HttpGet("{moviehallid}")]
    public async Task<ActionResult<MovieHall>> GetMovieHall(int moviehallid)
    {
        var moviehall = await _context.MovieHalls.FindAsync(moviehallid);

        if (moviehall == null)
        {
            return NotFound();
        }

        return moviehall;
    }
    [HttpPost]
    public async Task<MovieHall> CreateHall([FromBody] MovieHall movieHall)
    {
        return await _movieHallRepo.CreateMoviehall(movieHall);
    }



    // PUT: api/MovieHall/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{moviehallid}")]
    public async Task<IActionResult> PutMovieHall(int? moviehallid, MovieHall moviehall)
    {
        if (moviehallid != moviehall.MovieHallId)
        {
            return BadRequest();
        }

        _context.Entry(moviehall).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MovieHallExists(moviehallid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();

        

        
    }

    // DELETE: api/MovieHall/5
    [HttpDelete("{moviehallid}")]
    public async Task<IActionResult> DeleteMovieHall(int? moviehallid)
    {
        var moviehall = await _context.MovieHalls.FindAsync(moviehallid);
        if (moviehall == null)
        {
            return NotFound();
        }

        _context.MovieHalls.Remove(moviehall);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    private bool MovieHallExists(int? moviehallid)
    {
        return _context.MovieHalls.Any(e => e.MovieHallId == moviehallid);
    }
}
