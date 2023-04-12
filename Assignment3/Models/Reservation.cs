namespace Assignment3.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public int RoomNumber { get; set; }

        public int NumberOfAdults { get; set; }

        public int NumberOfChildren { get; set; }

        public DateTime Date { get; set; }
    }
}
