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
using System.IO;

namespace ExtremeStudio.ViewModels
{
    class MainViewModel : Conductor<Screen>.Collection.OneActive
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
 
        public BindableCollection<ScriptEditorViewModel> Scripts { get; set; } = new BindableCollection<ScriptEditorViewModel>();
        public BindableCollection<IPanelViewModel> Tools { get; set; } = new BindableCollection<IPanelViewModel>();

        #region Functions
        public void OpenFile(string path)
        {
            //TODO: fix openining files encoding.
            Scripts.Add(new ScriptEditorViewModel(File.ReadAllText(path)));
        }
        #endregion

        public MainViewModel()
        {
        }

        public void DocumentClosing(ScriptEditorViewModel document, DocumentClosingEventArgs e)
        {
           //TODO: handle script closing.
        }
        public void DocumentClosed(ScriptEditorViewModel document)
        {
            //TODO: handle script closed.
        }

        public void OnExitClick()
        {
            Scripts.Add(new ScriptEditorViewModel("No EXIT!!!! Muhahahahahahhaha") {Title = "Test File"});
        }
    }
}
