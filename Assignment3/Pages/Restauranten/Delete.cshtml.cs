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
    public class DeleteModel : PageModel
    {
        private readonly Assignment3.Data.ApplicationDbContext _context;

        public DeleteModel(Assignment3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CheckInd == null)
            {
                return NotFound();
            }
            var checkind = await _context.CheckInd.FindAsync(id);

            if (checkind != null)
            {
                CheckInd = checkind;
                _context.CheckInd.Remove(CheckInd);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
