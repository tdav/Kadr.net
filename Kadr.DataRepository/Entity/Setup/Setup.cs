using System.Data.Entity;
using System.Threading.Tasks;

namespace Kadr.Models.Entity
{
    public class SetupRepository : Repository<tbSetup>, ISetupRepository
    {
        public SetupRepository(KadrDbContext context) : base(context)
        {
        }

        public async Task<tbSetup> FirstOrDefaultAsync()
        {
            return await Context.tbSetups
                             //.Include(c => c.DrugStore.Region)
                             //.Include(c => c.DrugStore.District)
                             .FirstOrDefaultAsync();

        }
    }
}
