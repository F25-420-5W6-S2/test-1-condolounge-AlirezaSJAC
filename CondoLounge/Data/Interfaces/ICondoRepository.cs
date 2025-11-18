using CondoLounge.Data.Entities;

namespace CondoLounge.Data.Interfaces
{
    public interface ICondoRepository : ICondoLoungeGenericRepository<Condo>
    {
        public List<Condo> GetCondosForBuilding(Building building);
    }
}
