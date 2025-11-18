using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CondoLounge.Data.Repositories
{
    public class CondoRepository : CondoLoungeGenericGenericRepository<Condo>, ICondoRepository
    {
        public CondoRepository(ApplicationDbContext db, ILogger<CondoLoungeGenericGenericRepository<Condo>> logger) : base(db, logger)
        {
        }

        public List<Condo> GetCondosForABuilding(Building building)
        {
            return building.Condos;
        }
    }
}
