using System.Data;
using System.Data.Common;

namespace Kadr.DataModels.Utils
{
    public static class RunSqlToDataTable
    {
        public static DataTable Select(this DbConnection db, string sql)
        {
            DbCommand cmd = db.CreateCommand();
            cmd.CommandText = sql;

            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            };

            DbDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dt = new DataTable();
            dt.Load(dr);

            return dt;
        }
    }
}