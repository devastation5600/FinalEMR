using FinalEMR.DataAccess.Data;
using FinalEMR.Models;
using FinalEMR.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FinalEMR.DataAccess.Initiliazer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

            }
            if (_db.Roles.Any(r => r.Name == SD.Role_Admin)) return;

            _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Doctor)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Nurse)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Privi_Nurse)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "devastation5600@gmail.com",
                Email = "devastation5600@gmail.com",
                EmailConfirmed = true,
                Name = "System Admin"
            }, "Password1!").GetAwaiter().GetResult();

            ApplicationUser user = _db.ApplicationUsers.Where(u => u.Email == "devastation5600@gmail.com ").FirstOrDefault();

            _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
        }
    }
}
