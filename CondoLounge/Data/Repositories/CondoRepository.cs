using CondoLounge.Data.Entities;

namespace CondoLounge.Data.Repositories
{
    public class CondoRepository : CondoLoungeGenericGenericRepository<Condo>
    {
        public CondoRepository(ApplicationDbContext db, ILogger<CondoLoungeGenericGenericRepository<Condo>> logger) : base(db, logger)
        {
        }
    }
}
