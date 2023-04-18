namespace Assignment3.Models
{
    public class CheckInd 
    {
        public int CheckIndId { get; set; } 
        public int RoomNumber { get; set; }

        public int NumberOfAdults { get; set;}

        public int NumberOfChildren { get;set;}

        public DateTime Date { get; set; }

        public Daglig Daglig { get; set; } = default!;

    }
}
