using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;
using Caliburn.Micro;
using ExtremeStudio.Views.Panels;
using ScintillaNET;

namespace ExtremeStudio.ViewModels.Panels
{
    class ScriptEditorViewModel : Screen, IPanelViewModel
    {
#region Variables related to window.
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (value == _title) return;
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }
        private string _icon;
        public string Icon
        {
            get { return _icon; }
            set
            {
                if (value == _icon) return;
                _icon = value;
                NotifyOfPropertyChange(() => Icon);
            }
        }
        private string _contentId;
        public string ContentId
        {
            get { return _contentId; }
            set
            {
                if (value == _contentId) return;
                _contentId = value;
                NotifyOfPropertyChange(() => ContentId);
            }
        }
        private bool _Visibility;
        public bool Visibility
        {
            get { return _Visibility; }
            set
            {
                if (value == _Visibility) return;
                _Visibility = value;
                NotifyOfPropertyChange(() => Visibility);
            }
        }
        #endregion

        //Get the WFH control.
        private object _windowsHostControl;
        public object WindowsHostControl
        {
            get { return _windowsHostControl; }
            set { _windowsHostControl = value; NotifyOfPropertyChange(() => WindowsHostControl); }
        }

        //Property for getting the Scintilla easily.
        public Scintilla Editor => WindowsHostControl as Scintilla;
        
        public ScriptEditorViewModel(string fileContent)
        {
            //First of all, setup the scintilla control.
            Scintilla editor = new Scintilla();

            //TODO: setup it.

            //Assign it in the Windows Host.
            WindowsHostControl = editor;
        }
    }
}
