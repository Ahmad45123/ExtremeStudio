namespace ExtremeStudio.Classes
{
    public class VersionHandler
    {
        public string CurrentVersion {get; set;} = "1.0.0";
	
        public void DoIfUpdateNeeded(CurrentProjectClass project)
        {
            project.ProjectVersion = CurrentVersion;
        }
    }
}
