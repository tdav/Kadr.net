using System.ComponentModel.Composition;

namespace Kadr.Interfaces
{
    [InheritedExport("UpdaterPlgs", typeof (IUpdaterPlg))]
    public interface IUpdaterPlg
    {
        string Install(string fileExt);
    }
}