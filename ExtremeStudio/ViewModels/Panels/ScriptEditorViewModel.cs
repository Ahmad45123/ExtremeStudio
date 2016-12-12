using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;
using Caliburn.Micro;
using ScintillaNET;

namespace ExtremeStudio.ViewModels.Panels
{
    class ScriptEditorViewModel : Screen, IPanelViewModel
    {
        //Get the WFH control.
        private interface IWindowsFormsHostSource
        {
            WindowsFormsHost windowsHost { get; }
        }
        private WindowsFormsHost WindowsHost => (this.GetView() as IWindowsFormsHostSource).windowsHost;

        //Property for getting the Scintilla easily.
        public Scintilla Editor => WindowsHost.Child as Scintilla;

        public ScriptEditorViewModel(string fileContent)
        {
            //First of all, setup the scintilla control.
            Scintilla editor = new Scintilla();

            //TODO: setup it.
            
            //Assign it in the Windows Host.
            WindowsHost.Child = editor;
        }
    }
}
