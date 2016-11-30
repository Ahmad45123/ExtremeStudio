
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.ComponentModel.Composition;
using ExtremeStudio.Core;

namespace ExtremeStudio.Classes
{
    public class PluginBootstrapper
    {
        [ImportMany()] public IEnumerable<IExtremePlugin> Plugins;
    }
}