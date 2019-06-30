using System.ComponentModel.Composition;

namespace Kadr.PluginManager
{
    public delegate void dlgMessage(object sender, string msg, int progress);

    [InheritedExport("Reports", typeof (IPlugin))]
    public interface IPlugin
    {
        string Version { get; }
        string Description { get; }
        object Initialize(object MainContainer, string conStr);
        void Dispose();
    }

    [InheritedExport("ServerReports", typeof (IServerPlugin))]
    public interface IServerPlugin
    {
        string Version { get; }
        string Description { get; }
        string Name { get; }
        object Initialize(object MainContainer, string conStr);
        event dlgMessage OnMessage;
        void Dispose();
    }
}