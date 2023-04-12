using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment3.Data;
using Assignment3.Models;

namespace Assignment3.Pages.Restauranten
{
    public class EditModel : PageModel
    {
        private readonly Assignment3.Data.ApplicationDbContext _context;

        public EditModel(Assignment3.Data.ApplicationDbContext context)
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

            var checkind =  await _context.CheckInd.FirstOrDefaultAsync(m => m.CheckIndId == id);
            if (checkind == null)
            {
                return NotFound();
            }
            CheckInd = checkind;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CheckInd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckIndExists(CheckInd.CheckIndId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CheckIndExists(int id)
        {
          return (_context.CheckInd?.Any(e => e.CheckIndId == id)).GetValueOrDefault();
        }
    }
}
