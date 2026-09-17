using Cinema2026.Repo.Data;
using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;

namespace Cinema2026.Repo.Repositiories
{
    public class MovieHallRepositories : IMovieHallRepositories
    {
        private readonly DatabaseContext _context;

        public MovieHallRepositories(DatabaseContext d)
        {
            _context = d;
        }

        //create
        //get
        List<MovieHall> MovieHalls = new List<MovieHall>()
        { };

        public List<MovieHall> GetMovieHall()
        {
            return _context.MovieHalls.ToList();
        }

        public async Task<MovieHall> CreateMoviehall(MovieHall movieHall)
        {
            // _context.Persons.Add(new Person { age = 20, name = "Marius", Id = 4 });
            _context.Add(movieHall);
            await _context.SaveChangesAsync();
            return movieHall;
        }
    }
}
