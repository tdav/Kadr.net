using Dapper;
using Kadr.Database.Views;
using System.Collections.Generic;
using System.Linq;

namespace Kadr.Models.Entity
{
    public class AccessListRepository : Repository<spAccessList>, IAccessListRepository
    {
        public AccessListRepository(KadrDbContext context) : base(context)
        {
        }

        public List<viSpList> GetList(string s)
        {
            string sql = $"SELECT Id,Name  FROM spAccessLists  WHERE id IN ({s})";
            return Context.Database.Connection.Query<viSpList>(sql).ToList();
        }

        public List<viSpList> GetSp()
        {
            const string sql = "SELECT Id,Name  FROM spAccessLists ";
            return Context.Database.Connection.Query<viSpList>(sql).ToList();
        }
    }
}
