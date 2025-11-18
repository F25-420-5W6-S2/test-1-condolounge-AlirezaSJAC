using CondoLounge.Data.Entities;

namespace CondoLounge.Data.Interfaces
{
    public interface IUserRepository : ICondoLoungeGenericRepository<ApplicationUser>
    {
        public List<ApplicationUser> GetUsersForACondo(Condo condo);
    }
}
