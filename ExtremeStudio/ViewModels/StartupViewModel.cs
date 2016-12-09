using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace ExtremeStudio.ViewModels
{
    [Export(typeof(StartupViewModel))]
    public class StartupViewModel : PropertyChangedBase
    {
        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public StartupViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

    }
}
