using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using ExtremeStudio.Core;
using ScintillaNET;

namespace ExtremeStudio.Classes
{
    public class FuncsHandler : IPluginContext
    {
        public Scintilla CurrentEditor
        {
            get { return MainForm.CurrentScintilla; }
        }
    }
}