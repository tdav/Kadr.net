using Dapper;
using Kadr.Database.Views;
using System.Collections.Generic;
using System.Linq;

namespace Kadr.Models.Entity
{
    public class RoleRepository : Repository<spRole>, IRoleRepository
    {
        public RoleRepository(KadrDbContext context) : base(context)
        {
        }

     

        public List<viSpList> GetSp()
        {
            string sql = "SELECT Id, LastName+' '+FirstName+' '+FatherName AS Name FROM tbUsers order by LastName";
            return Context.Database.Connection.Query<viSpList>(sql).ToList();
        }
    }
}
