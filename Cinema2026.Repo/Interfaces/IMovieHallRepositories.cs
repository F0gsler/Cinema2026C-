using Cinema2026.Repo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema2026.Repo.Interfaces
{
    public interface IMovieHallRepositories
    {
        public List<MovieHall> GetMovieHall();
    }
}
