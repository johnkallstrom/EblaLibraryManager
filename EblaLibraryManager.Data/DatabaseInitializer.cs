using EblaLibraryManager.Data.Enumerations;
using EblaLibraryManager.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EblaLibraryManager.Data
{
    public class DatabaseInitializer
    {
        private const string DefaultUsername = "elm-admin";
        private const string DefaultEmail = "elm-admin@mail.com";
        private const string DefaultPassword = "password123";

        public void Seed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager).Wait();
            SeedDefaultUser(userManager).Wait();
        }

        private async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(CustomRoleTypes.Member))
            {
                await roleManager.CreateAsync(new IdentityRole(CustomRoleTypes.Member));
            }

            if (!await roleManager.RoleExistsAsync(CustomRoleTypes.Librarian))
            {
                await roleManager.CreateAsync(new IdentityRole(CustomRoleTypes.Librarian));
            }
        }

        private async Task SeedDefaultUser(UserManager<ApplicationUser> userManager)
        {
            if (await userManager.FindByNameAsync(DefaultUsername) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = DefaultUsername,
                    Email = DefaultEmail
                };

                var result = await userManager.CreateAsync(user, DefaultPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, CustomRoleTypes.Librarian);
                }
            }
        }
    }
}
