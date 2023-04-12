﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment3.Data;
using Assignment3.Models;

namespace Assignment3.Pages.Restauranten
{
    public class CreateModel : PageModel
    {
        private readonly Assignment3.Data.ApplicationDbContext _context;

        public CreateModel(Assignment3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CheckInd CheckInd { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CheckInd == null || CheckInd == null)
            {
                return Page();
            }

            _context.CheckInd.Add(CheckInd);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
