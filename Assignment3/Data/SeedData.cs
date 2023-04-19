using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Assignment3.Data
{
    public class SeedData
    {
        public static void SeedMedarbejder(UserManager<IdentityUser> userManager)
        {
            const string Email_Medarbejder = "Medarbejder2@localhost";
            const string Password_Medarbekder = "Password1.";

            if (userManager == null)
            {
                throw new ArgumentNullException(nameof(userManager));
            }

            if (userManager.FindByNameAsync(Email_Medarbejder).Result == null)
            {
                var user = new IdentityUser();
                user.UserName = Email_Medarbejder;
                user.Email = Email_Medarbejder;
                user.EmailConfirmed = true;
                IdentityResult result = userManager.CreateAsync(user, Password_Medarbekder).Result;

                if (result.Succeeded)
                {
                    
                    var userMedarbejder = userManager.FindByNameAsync(Email_Medarbejder).Result;
                    var claim = new Claim("Role", "Medabejder");
                    var addClaim = userManager.AddClaimAsync(userMedarbejder, claim).Result;
                }
            }
        }

        public static void SeedTjener(UserManager<IdentityUser> userManager)
        {

            const string TjenerEmail = "Tjener2@localhost";
            const string TjenerPassword = "Password2.";
            if (userManager == null)
            {
                throw new ArgumentNullException(nameof(userManager));
            }

            if (userManager.FindByNameAsync(TjenerEmail).Result == null)
            {
                var user = new IdentityUser();
                user.UserName = TjenerEmail;
                user.Email = TjenerEmail;
                user.EmailConfirmed = true;
                IdentityResult result = userManager.CreateAsync(user, TjenerPassword).Result;

                if (result.Succeeded)
                {
                    var Usertjener = userManager.FindByNameAsync(TjenerEmail).Result;
                    var claim = new Claim("Role", "Tjener");
                    var addclaim = userManager.AddClaimAsync(Usertjener, claim).Result;
                }

            }
        }

        public static void SeedAdmin(UserManager<IdentityUser> userManager)
        {
            const string AdminEmail = "Admin@admin3";
            const string AdminPassword = "Admin3.";
            if (userManager == null)
            {
                throw new ArgumentNullException(nameof(userManager));
            }

            if (userManager.FindByNameAsync(AdminEmail).Result == null)
            {
                var user = new IdentityUser();
                user.UserName = AdminEmail;
                user.Email = AdminPassword;
                user.EmailConfirmed = true;
                IdentityResult result = userManager.CreateAsync(user, AdminPassword).Result;
                if (result.Succeeded)
                {
                    var adminUser = userManager.FindByNameAsync(AdminEmail).Result;
                    var claim = new Claim("Role", "Admin");
                    var claimAdded = userManager.AddClaimAsync(adminUser, claim).Result;
                }
            }
        }
    }
}
