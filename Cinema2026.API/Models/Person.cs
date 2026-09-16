namespace Cinema2026.Api.Models
{

    // Public, Private, Internel, 
    public class Person
    {
        public int PersonId { get; set; } // Variable / Property <---- Primary
        public required string name { get; set; }
        public int age { get; set; }
    }

    public class MovieHall
    {
        public int MovieHallId { get; set; } // <---- Primary
        public required List<Person> PersonId { get; set; }
        public int SeatAmount { get; set; }
        public bool occupied { get; set; }
    }


    public class HallSeats
    {
        public int HallSeatsId { get; set; }
        public required List<Person> PersonId { get; set; }
        public required List<MovieHall> MovieHallId { get; set; }
        public required string SeatType { get; set; }
    }
    
    public class Movies
    {
        public int MovieId { get; set; }
        public required string MovieName { get; set; }
        
    }
}