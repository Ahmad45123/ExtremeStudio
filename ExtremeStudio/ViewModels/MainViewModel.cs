using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using ExtremeStudio.ViewModels.Panels;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout.Serialization;

namespace ExtremeStudio.ViewModels
{
    class MainViewModel : Screen
    {
        private interface IDockingManagerSource
        {
            DockingManager DockingManager { get; }
        }
        private DockingManager DockingManager => (this.GetView() as IDockingManagerSource).DockingManager;

        private ScriptEditorViewModel activeDocument;
        public ScriptEditorViewModel ActiveDocument
        {
            get { return activeDocument; }
            set
            {
                activeDocument = value;
                NotifyOfPropertyChange(() => ActiveDocument);
            }
        }
 
        public BindableCollection<ScriptEditorViewModel> Scripts { get; set; }
        public BindableCollection<IPanelViewModel> Tools { get; set; }


        public MainViewModel()
        {
            Scripts = new BindableCollection<ScriptEditorViewModel>();
            Tools = new BindableCollection<IPanelViewModel>();
        }

        public void DocumentClosing(ScriptEditorViewModel document, DocumentClosingEventArgs e)
        {
           //TODO: handle script closing.
        }

        public void DocumentClosed(ScriptEditorViewModel document)
        {
            Scripts.Remove(document);
        }


    }
}
