using System;
using System.Windows.Forms;
using ExtremeStudio.DockPanelForms.MainFormDocks;
using ExtremeStudio.DockPanelForms.MainFormDocks.EditorDock.EditorFunctions;
using ExtremeStudio.DockPanelForms.MainFormDocks.ObjectExplorerDock;
using ExtremeStudio.FunctionsForms;

namespace ExtremeStudio
{
    public static class Program
    {
        public static GotoForm GotoForm;
        public static SearchReplaceForm SearchReplaceForm;
        public static MainForm MainForm;
        public static StartupForm StartupForm;
        public static ProjExplorerDock ProjExplorerDock;
        public static ObjectExplorerDock ObjectExplorerDock;
        public static ErrorsDock ErrorsDock;
        public static SettingsForm SettingsForm;
        public static LanguagesForm LanguagesForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GotoForm = new GotoForm();
            SearchReplaceForm = new SearchReplaceForm();
            MainForm = new MainForm();
            StartupForm = new StartupForm();
            LanguagesForm = new LanguagesForm();
            ProjExplorerDock = new ProjExplorerDock();
            ObjectExplorerDock = new ObjectExplorerDock();
            ErrorsDock = new ErrorsDock();
            SettingsForm = new SettingsForm();

            if (args.Length == 1)
            {
                StartupForm.ProjectToOpen = args[0];
            }
            LanguagesForm.Show();
            Application.Run();
        }
    }
}
