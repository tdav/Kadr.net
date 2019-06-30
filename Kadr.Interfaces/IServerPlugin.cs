using System.ComponentModel.Composition;

namespace Kadr.PluginManager
{
    [InheritedExport("WcfServerPlugin", typeof (IWcfServerPlugin))]
    public interface IWcfServerPlugin
    {
        string Name { get; }
        byte[] Run(byte[] Param);
    }
}