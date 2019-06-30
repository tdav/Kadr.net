using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Kadr.PluginManager
{
    [InheritedExport("SqlCreate", typeof (IGenSql))]
    public interface IGenSql
    {
        string Description { get; }

        string Select(string table, List<string> colnames, List<string> typenames, List<string> sizenames,
            List<int> numnames);

        string Insert(string table, List<string> colnames, List<string> typenames, List<string> sizenames);
        string Update(string table, List<string> colnames, List<string> typenames, List<string> sizenames);
        string Delete(string table, List<string> colnames, List<string> typenames, List<string> sizenames);

        string UpdateInsert(string table, List<string> colnames, List<string> typenames, List<string> sizenames,
            List<int> numnames);
    }
}