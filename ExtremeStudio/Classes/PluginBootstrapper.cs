using System.Collections.Generic;
using System.ComponentModel.Composition;
using ExtremeCore;

namespace ExtremeStudio.Classes
{
    public class PluginBootstrapper
    {
        [ImportMany]
        public IEnumerable<IExtremePlugin> Plugins;
    }
}