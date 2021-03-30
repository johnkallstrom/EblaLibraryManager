using EblaLibraryManager.Data.Enumerations;
using EblaLibraryManager.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EblaLibraryManager.Data
{
    public class DatabaseInitializer
    {
        private const string DefaultLibrarianUser = "elm-librarian";
        private const string DefaultMemberUser = "elm-member";
        private const string DefaultPassword = "password123";

        public void Seed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager).Wait();
            SeedDefaultUser(userManager, DefaultLibrarianUser, DefaultPassword, CustomRoleTypes.Librarian).Wait();
            SeedDefaultUser(userManager, DefaultMemberUser, DefaultPassword, CustomRoleTypes.Member).Wait();
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

        private async Task SeedDefaultUser(UserManager<ApplicationUser> userManager, string username, string password, string role)
        {
            if (await userManager.FindByNameAsync(username) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = username,
                };

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
