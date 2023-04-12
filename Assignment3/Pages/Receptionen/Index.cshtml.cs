using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment3.Data;
using Assignment3.Models;

namespace Assignment3.Pages.Receptionen
{
    public class IndexModel : PageModel
    {
        private readonly Assignment3.Data.ApplicationDbContext _context;

        public IndexModel(Assignment3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; } = default!;

        public DateTime Time { get; set; } = DateTime.Today;
        public async Task OnGetAsync()
        {
            if (_context.Reservation != null)
            {
                Reservation = await _context.Reservation.Where(bb => (bb.NumberOfAdults > 0 || bb.NumberOfChildren > 0) && bb.Date == DateTime.Today)
                .Select(bb => new Reservation
                {
                    ReservationId = bb.ReservationId,
                    RoomNumber = bb.RoomNumber,
                    NumberOfChildren = bb.NumberOfChildren,
                    NumberOfAdults = bb.NumberOfAdults,
                }).ToListAsync();

                Console.WriteLine(Reservation);

            }
        }
    }
}
