using Assignment3.Data;
using Assignment3.Hub;
using Assignment3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.SignalR;

namespace Assignment3.Pages
{

   // [Authorize]
    public class ReceptionModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        private readonly IHubContext<KitchenHub, IKitchenHub> _KitchenHub;

        [BindProperty]
        public Reservation reservation { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }

        public CheckInd checkInd { get; set; }
        public IEnumerable<CheckInd> CheckInds { get; set; }

        public ReceptionModel(ApplicationDbContext context, IHubContext<KitchenHub, IKitchenHub> KitchenHub) 
        { 
            _context = context;
            _KitchenHub = KitchenHub;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            _KitchenHub.Clients.All.KitchenUpdate();

            return RedirectToPage("./Reception");
        }

        public void OnGet()
        {
            CheckInds = _context.CheckInd;
        }
    }
}
