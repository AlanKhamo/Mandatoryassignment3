using Assignment3.Data;
using Assignment3.Hub;
using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace Assignment3.Pages.Receptionen
{
    public class ShowCustomersModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<Kitchen, IKitchen> _kitchen;

        [BindProperty]
        public Reservation reservation { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }

        public ShowCustomersModel(ApplicationDbContext context, IHubContext<Kitchen, IKitchen> kitchen)
        {
            _kitchen = kitchen;
            _context = context;

        }

        public void OnGet()
        {
            Reservations = _context.Reservations;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            _kitchen.Clients.All.KitchenUpdate();

            return RedirectToPage("./Receptionen");
        }
    }
}
