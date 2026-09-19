using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class MovieHallsController : ControllerBase
{
    private readonly IGenericRepository<MovieHall> _repo;
    public MovieHallsController(IGenericRepository<MovieHall> repo)
    {
        _repo = repo;
    }

    // GET: api/MovieHall
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieHall>>> GetMovieHall()
    {
        var all = await _repo.GetAll();
        return Ok(all);
    }

    // GET: api/MovieHall/5
    [HttpGet("{moviehallid}")]
    public async Task<ActionResult<MovieHall>> GetMovieHall(int moviehallid)
    {
        var moviehall = await _repo.GetById(moviehallid);

        if (moviehall == null)
        {
            return NotFound();
        }

        return Ok(moviehall);
    }
    [HttpPost]
    public async Task<MovieHall> CreateHall([FromBody] MovieHall movieHall)
    {
        var created = await _repo.Add(movieHall);
        return created;
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

        // Use generic repository to update
        await _repo.Update(moviehall);

        return NoContent();

        

        
    }

    // DELETE: api/MovieHall/5
    [HttpDelete("{moviehallid}")]
    public async Task<IActionResult> DeleteMovieHall(int? moviehallid)
    {
        if (moviehallid == null) return BadRequest();
        var moviehall = await _repo.GetById(moviehallid.Value);
        if (moviehall == null) return NotFound();
        await _repo.Delete(moviehallid.Value);
        return NoContent();
    }

}
