using Assignment3.Data;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Assignment3.Models;

namespace Assignment3.Pages
{
    //[Authorize] // Alle kan komme ind på Kitchen page.
    public class KitchenModel : PageModel
    {
        private readonly ApplicationDbContext _context;


        public int ExpectedAdults { get; set; }
        public int ExpectedKids { get; set; }
        public int ExpectedTotal { get; set; }
        public int CheckedInAdults { get; set; }
        public int CheckedInKids { get; set; }
		public int CheckedinTotal { get; set; }
        public int MissingAdults { get; set; }
        public int MissingKids { get; set; }


        [BindProperty] public Intput _input { get; set; }
		

		public class Intput
        {
            [DataType(DataType.Date)]
            public DateTime Date { get; set; } = DateTime.Now;
        }

        public KitchenModel(ApplicationDbContext context)
        {
            _context = context;
            _input = new Intput();
        }



        public async Task OnGetAsync()
        {
            var expected = await _context.Reservation
                .Where(b => b.Date.Day == _input.Date.Day && b.Date.Month == _input.Date.Month)
                .ToListAsync();


            foreach (var item in expected)
            {
                ExpectedAdults = item.NumberOfAdults;
                ExpectedKids = item.NumberOfAdults;
                ExpectedTotal = ExpectedAdults + ExpectedKids;

            }

            var check = await _context.CheckInd
               .Where(b => b.Date.Day == _input.Date.Day && b.Date.Month == _input.Date.Month)
               .ToListAsync();

            foreach (var item in check)
            {
                CheckedInAdults += item.NumberOfAdults;
                CheckedInKids += item.NumberOfChildren;
            }

            MissingAdults = ExpectedAdults - CheckedInAdults;
            MissingKids = ExpectedKids - CheckedInKids;

        }

        public async Task OnPost()
        {
            var expected = await _context.Reservation
               .Where(b => b.Date.Day == _input.Date.Day && b.Date.Month == _input.Date.Month)
               .ToListAsync();


            foreach (var item in expected)
            {
                ExpectedAdults = item.NumberOfAdults;
                ExpectedKids = item.NumberOfChildren;
                ExpectedTotal = ExpectedAdults + ExpectedKids;

            }


            
            var check = await _context.CheckInd
               .Where(b => b.Date.Day == _input.Date.Day && b.Date.Month == _input.Date.Month)
               .ToListAsync();

            foreach (var item in check)
            {
                CheckedInAdults += item.NumberOfAdults;
                CheckedInKids += item.NumberOfChildren;
            }

            Kitchen Kitchen = new Kitchen();
            MissingAdults = ExpectedAdults - CheckedInAdults;
            MissingKids = ExpectedKids - CheckedInKids; 

        }


    }
}
