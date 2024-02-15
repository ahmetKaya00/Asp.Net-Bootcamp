using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models
{
    public static class IdentitySeedData{
        private const string adminUser = "admin";
        private const string adminPassword = "admin123";

        public static async void IdentityTestUser(IApplicationBuilder app){

            var context = app.ApplicationServices.CreateAsyncScope().ServiceProvider.GetRequiredService<IdentityContext>();

            if(context.Database.GetAppliedMigrations().Any()){
                context.Database.Migrate();
            }

            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            var user = await userManager.FindByNameAsync(adminUser);

            if(user == null){
                user = new AppUser{
                    FullName = "Ahmet Kaya",
                    UserName = adminUser,
                    Email = "admin@ahmetkaya.com",
                    PhoneNumber = "44554455445"
                };
            
            await userManager.CreateAsync(user,adminPassword);
            }
        }
    }
}