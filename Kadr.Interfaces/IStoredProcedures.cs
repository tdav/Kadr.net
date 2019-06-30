using System.ComponentModel.Composition;
using System.Data;

namespace Kadr.PluginManager
{
    [InheritedExport("ImExDataBase", typeof (IStoredProcedures))]
    public interface IStoredProcedures
    {
        string Description { get; }
        string[] Values { get; set; }
        string Tablename { get; set; }
        DataSet DoSingleCursorExecProcedure();
        object ExecProcedure(bool IsGetResult);
        DataTable GetProcedureParam(string proname);
        DataTable GetPrimaryKey(string table);
        void GetFieldNames(string tablename, ref string[] fieldnames, ref string[] fieldtype);
        DataTable GetColumns();
        DataTable GetTables();
        DataTable GetList();
        DataTable GetProcedureList();
        string ExecuteNonQuery(string s);
        DataTable SqlExec(string sql);
        void AddFileToDb(string filename, string Sqn, byte[] filedata);
    }
}