using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment3.Data;
using Assignment3.Models;

namespace Assignment3.Pages.Restauranten
{
    public class DetailsModel : PageModel
    {
        private readonly Assignment3.Data.ApplicationDbContext _context;

        public DetailsModel(Assignment3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public CheckInd CheckInd { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CheckInd == null)
            {
                return NotFound();
            }

            var checkind = await _context.CheckInd.FirstOrDefaultAsync(m => m.CheckIndId == id);
            if (checkind == null)
            {
                return NotFound();
            }
            else 
            {
                CheckInd = checkind;
            }
            return Page();
        }
    }
}
