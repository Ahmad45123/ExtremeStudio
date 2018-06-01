using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtremeCore.Classes
{
    public static class SampCtl
    {
        public static async Task<bool> EnsureLatestInstalled(string path)
        {
            WebClient client = new WebClient();
            client.Headers["User-Agent"] = "ExtremeStudio";
            string latestInfo = client.DownloadString("http://api.github.com/repos/Southclaws/sampctl/releases/latest");
            var mtch = Regex.Match(latestInfo, "\"tag_name\":\"(?<version>.+?)\",");
            string version = mtch.Groups["version"].Value;

            //If exists and different version, download, else keep.
            if (File.Exists(Path.Combine(path, "sampctl.exe")) == false || (File.Exists(Path.Combine(path, "sampctl.exe")) && await GetCurrentVersion(Path.Combine(path, "sampctl.exe")) != version))
            {
                string arch = Environment.Is64BitOperatingSystem ? "amd64" : "386";
                string fileToDownload =
                    $@"https://github.com/Southclaws/sampctl/releases/download/{version}/sampctl_{version}_windows_{arch}.tar.gz";
                client.DownloadFile(fileToDownload, Path.Combine(path, "archive.tar.gz"));
                GeneralFunctions.FastZipUnpack(Path.Combine(path, "archive.tar.gz"), path, "sampctl.exe");
                File.Delete(Path.Combine(path, "archive.tar.gz"));
            }

            return true;
        }

        public static async Task<string> SendCommand(string sampctl, string workingDir, string cmd, bool createnowindow = true)
        {
            return await Task.Run(() =>
            {
                Process compiler = new Process
                {
                    StartInfo =
                    {
                        FileName = sampctl,
                        WorkingDirectory = workingDir,
                        Arguments = cmd,
                        CreateNoWindow = createnowindow,
                        RedirectStandardError = createnowindow,
                        RedirectStandardOutput = createnowindow,
                        UseShellExecute = false,
                        Verb = "runas"
                    }
                };
                compiler.Start();
                compiler.WaitForExit();
                try
                {
                    Debug.WriteLine(compiler.StandardError.ReadToEnd());
                    return compiler.StandardOutput.ReadToEnd();
                }
                catch (Exception)
                {
                    return "success";
                }
            });
        }

        public static async Task<string> GetCurrentVersion(string sampctl)
        {
            string v = await SendCommand(sampctl, Path.GetDirectoryName(sampctl), "version");
            var p = v.Split(' ')[2].Trim();
            return p;
        }
    }
}
