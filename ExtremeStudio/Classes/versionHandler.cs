using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using ExtremeStudio.Classes;

namespace ExtremeStudio.Classes
{
    public class VersionHandler
    {
        public string CurrentVersion { get; set; }

        public void DoIfUpdateNeeded(CurrentProjectClass project)
        {
            project.ProjectVersion = CurrentVersion;
        }
    }
}