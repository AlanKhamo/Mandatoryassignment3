using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Assignment3.Data
{
    public class SeedData
    {
        public static void SeedMedarbejder(UserManager<IdentityUser> userManger)
        {
            const string Email_Medarbejder = "Medarbejder@localhost";
            const string Password_Medarbekder = "Password1";

            if (userManger == null)
            {
                throw new ArgumentNullException(nameof(userManger));
            }

            if (userManger.FindByNameAsync(Email_Medarbejder).Result == null)
            {
                var user = new IdentityUser();
                user.UserName = Email_Medarbejder;
                user.Email = Email_Medarbejder;
                user.EmailConfirmed = true;
                IdentityResult result = userManger.CreateAsync(user, Password_Medarbekder).Result;

                if (result.Succeeded)
                {
                    var userMedarbejder = userManger.FindByNameAsync(Email_Medarbejder).Result;
                    var claim = new Claim("Kasper", "Medabejder");
                    var addClaim = userManger.AddClaimAsync(userMedarbejder, claim).Result;
                }
            }
        }

        public static void SeedTjener(UserManager<IdentityUser> userManager)
        {

            const string TjenerEmail = "Tjener@localhost";
            const string TjenerPassword = "Password2";
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
    }
}
