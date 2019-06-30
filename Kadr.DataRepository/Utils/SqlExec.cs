using Kadr.DataModels.Utils;
using Kadr.Models;
using System.Data;
using System.Linq;

namespace Kadr.DataModels.Reports
{
    public class SqlExec
    {
        public static DataTable Run(string sql, params object[] args)
        {
            using (var db = new KadrDbContext())
            {
                sql = string.Format(sql, args);
                return db.Database.Connection.Select(sql);
            }
        }
    }
}
