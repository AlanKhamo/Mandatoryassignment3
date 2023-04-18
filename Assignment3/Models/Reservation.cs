namespace Assignment3.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public int RoomNumber { get; set; }

        public int NumberOfAdults { get; set; }

        public int NumberOfChildren { get; set; }
        public DateTime Date { get; set; }

        //public int Day { get; set; }
        //public int Month { get; set; }
        public Daglig Daglig { get; set; } = default!;
    }
}
