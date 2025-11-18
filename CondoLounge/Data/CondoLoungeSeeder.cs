using CondoLounge.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace CondoLounge.Data
{
    public class CondoLoungeSeeder
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hosting;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public CondoLoungeSeeder(ApplicationDbContext context,
                IWebHostEnvironment hosting,
                UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole<int>> roleManager)
        {
            _db = context;
            _hosting = hosting;     //will be used to find the full path of the project 
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            //Verify that the database exists. Hover over the method and read the documentation. 
            _db.Database.EnsureCreated();

            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Normal"));
                await _roleManager.CreateAsync(new IdentityRole<int>("BuildingOwner"));
            }

            Building build1 = new Building() { Condos = new List<Condo>(), Address = "building 1" };
            Building build2 = new Building() { Condos = new List<Condo>(), Address = "building 2" };

            if (!_db.Buildings.Any())
            {
                _db.Buildings.Add(build1);
                _db.Buildings.Add(build2);
            }

            if(_db.Condos.Any())
            {
                Condo condo1 = new Condo() { Building = _db.Buildings.Where(b => b.Address == "building 1").FirstOrDefault() };
                Condo condo2 = new Condo() { Building = _db.Buildings.Where(b => b.Address == "building 1").FirstOrDefault() };
                Condo condo3 = new Condo() { Building = _db.Buildings.Where(b => b.Address == "building 2").FirstOrDefault() };
                Condo condo4 = new Condo() { Building = _db.Buildings.Where(b => b.Address == "building 2").FirstOrDefault() };
                _db.Condos.Add(condo1);
                _db.Condos.Add(condo2);
                _db.Condos.Add(condo3);
                _db.Condos.Add(condo4);
            }

            if (!_userManager.Users.Any())
            {
                var adminUser = new ApplicationUser() { UserName = "admin@email.com", Email = "admin@email.com" };
                await _userManager.CreateAsync(adminUser, "VerySecureAdmin45%");
                await _userManager.AddToRoleAsync(adminUser, "Admin");

                var user = new ApplicationUser() { UserName = "normal@email.com", Email = "normal@email.com" };
                await _userManager.CreateAsync(user, "VerySecurenormal45%");
                await _userManager.AddToRoleAsync(user, "normal");
            }

            _db.SaveChanges();
        }
    }
}
