using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace ExtremeCore.Classes
{
    public static class SampCtl
    {
        public static void EnsureInstalled()
        {
            WebClient client = new WebClient();
            string latestInfo = client.DownloadString(new Uri("https://api.github.com/repos/Southclaws/sampctl/releases/latest"));
            var mtch = Regex.Match(latestInfo, "\"tag_name\": \"(?<version>.+)\",");
            string version = mtch.Groups["version"].Value;

            
        }
    }
}
