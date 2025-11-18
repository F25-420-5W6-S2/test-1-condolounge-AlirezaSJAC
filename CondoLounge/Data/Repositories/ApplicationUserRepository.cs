using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CondoLounge.Data.Repositories
{
    public class ApplicationUserRepository : CondoLoungeGenericGenericRepository<ApplicationUser>, IUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext db, ILogger<CondoLoungeGenericGenericRepository<ApplicationUser>> logger) : base(db, logger)
        {
        }

        public List<ApplicationUser> GetUsersForACondo(Condo condo)
        {
            return _dbSet.Include(u => u.Condos).Where(u => u.Condos.Contains(condo)).ToList();
        }
    }
}
