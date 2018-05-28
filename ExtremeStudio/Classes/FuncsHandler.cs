using ScintillaNET;

namespace ExtremeStudio.Classes
{
    public class FuncsHandler : IPluginContext
    {
        public Scintilla CurrentEditor => Program.MainForm.CurrentScintilla;
    }
}
