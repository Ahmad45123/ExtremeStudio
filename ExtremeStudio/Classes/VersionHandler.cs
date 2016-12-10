using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeStudio.Classes
{
    class VersionHandler
    {
        public static string CurrentVersion = "1.0.0";
        public static void DoIfUpdateNeeded(CurrentProjectClass project)
        {
            project.ProjectVersion = CurrentVersion;
        }
    }
}
