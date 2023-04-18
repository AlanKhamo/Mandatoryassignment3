using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;
using Assignment3.Data;
using Assignment3.Hub;
using Assignment3.Models;

namespace Assignment3.Pages
{
    //[Authorize("CanEnterRestaurant")]
    public class RestaurantModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<KitchenHub, IKitchenHub> _kitchenHub;

        [BindProperty]
        public CheckInd checkInd { get; set; }
        public IEnumerable<CheckInd> CheckInds { get; set; }

        public RestaurantModel(ApplicationDbContext context, IHubContext<KitchenHub, IKitchenHub> kitchenHub)
        {
            _context = context;
            _kitchenHub = kitchenHub; 
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            checkInd.Date = DateTime.Now;

            _context.CheckInd.Add(checkInd);
            await _context.SaveChangesAsync();
            _kitchenHub.Clients.All.KitchenUpdate();

            return RedirectToPage("./Index");
        }
    }
}
