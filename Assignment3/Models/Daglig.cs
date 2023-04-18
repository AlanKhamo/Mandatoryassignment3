namespace Assignment3.Models
{
    public class Daglig
    {
        //public int Day { get; set; }
        //public int Month { get; set; }
        public DateTime Date { get; set; }
        public Reservation Reservation { get; set; } = new Reservation()
        {
            NumberOfAdults = 0,
            NumberOfChildren = 0,
        };
        public List<CheckInd> checkInds { get; set; } = new();
    }
}
