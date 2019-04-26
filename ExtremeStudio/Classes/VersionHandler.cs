using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ExtremeCore.Classes;
using ExtremeStudio.FunctionsForms;
using Resources;

namespace ExtremeStudio.Classes
{
    public class VersionHandler
    {
        public string CurrentVersion {get;} = "2.0.0";
	
        public async void DoIfUpdateNeeded(CurrentProjectClass project)
        {
            if (project.ProjectVersion == "1.0.0")
            {
                if (!Directory.Exists(project.ProjectPath + "/dependencies"))
                {
                    //Setup sampctl for it
                    project.SampCtlData = new PawnJson()
                    {
                        entry = "gamemodes\\" + project.ProjectName + ".pwn",
                        output = "gamemodes\\" + project.ProjectName + ".amx",
                        user = Environment.UserName,
                        repo = project.ProjectName,
                        dependencies = new List<string>() {"sampctl/samp-stdlib"},
                        builds = new List<BuildInfo>()
                        {
                            new BuildInfo()
                            {
                                name = "main",
                                args = Program.SettingsForm.GetCompilerArgs().Split(' ').ToList()
                            }
                        },
                        runtime = new RuntimeInfo() {version = "latest"},
                    };
                    project.SaveInfo();
                    project.LoadSampCtlData(); //to make sure pawno/includes is also supported.
                    DownloadForm frm = new DownloadForm
                    {
                        progressBar1 = { Style = ProgressBarStyle.Marquee },
                        descLabel = { Text = translations.StartupForm_CreateProjectBtn_Click_Ensuring_packages }
                    };
                    frm.Show();
                    await SampCtl.SendCommand(Path.Combine(Application.StartupPath, "sampctl.exe"), project.ProjectPath, "p ensure");
                    frm.Close();
                }
            }
            project.ProjectVersion = CurrentVersion;
        }
    }
}
