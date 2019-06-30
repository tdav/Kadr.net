using Dapper;
using Kadr.Database.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kadr.Models.Entity
{
    public class SpListRepository : Repository<viSpList>, ISpListRepository
    {
        public SpListRepository(KadrDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<viSpList>> GetSpAsync(string name, string lang)
        {
            string sql = $"SELECT Id, Name{lang}  FROM {name}";
            return await Context.Database.Connection.QueryAsync<viSpList>(sql);
        }
    }
}
