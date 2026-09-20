using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Cinema2026.Repo.Models
{

    // Public, Private, Internel, 
    public class Person
    {
        [Key]
        public int PersonId { get; set; } // Variable / Property <---- Primary
        public required string name { get; set; }
        public int age { get; set; } 
        public required string role { get; set; }
    }

    public class MovieHall
    {
        [Key]
        public int MovieHallId { get; set; } // <---- Primary
        public required List<Person> PersonId { get; set; }
        public List<Movies>? MovieId { get; set; }
        public int SeatAmount { get; set; }
        public bool occupied { get; set; }
    }


    public class HallSeats
    {
        public int HallSeatsId { get; set; }
        public required List<Person> PersonId { get; set; }
        public required List<MovieHall> MovieHallId { get; set; }
        public required int SeatAmount { get; set; }
        public required string SeatType { get; set; }
    }

    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        public required string MovieName { get; set; }
        public int MovieDuration { get; set; }

    }


    public class AdminUser
    {
        [Key]
        public int AdminId { get; set; }
        public required string username { get; set; }
        public required string password { get; set; }
        // AdminLevel: 0 = Adgang til alt
        // AdminLevel: 1 = Adgang til at oprette nye MovieHalls og and hvad Admin level to har adgang til
        // AdminLevel: 2 = adgang til at tilføje personer til film og oprette film
        public required int AdminLevel { get; set; }
    }
}