using System.Threading.Tasks;

namespace Kadr.Models.Entity
{
    public interface ISetupRepository : IRepositoy<tbSetup>
    {
        Task<tbSetup> FirstOrDefaultAsync();
    }
}
