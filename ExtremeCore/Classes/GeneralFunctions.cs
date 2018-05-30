using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Ionic.Zip;
using Ionic.Zlib;
using ScintillaNET;
using SharpCompress.Common;
using SharpCompress.Readers;

namespace ExtremeCore.Classes
{
    public static class GeneralFunctions
    {
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
        
            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        public static int CountChar(string src, char chr)
        {
            return src.Count(fChr => fChr == chr);
        }

        public static bool IsValidFileName(this string expression, bool platformIndependent = false)
        {
            string sPattern = @"^(?!^(PRN|AUX|CLOCK\$|NUL|CON|COM\d|LPT\d|\..*)(\..+)?$)[^\x00-\x1f\\?*:\"";|/]+$";
            if (platformIndependent)
            {
                sPattern =
                    @"^(([a-zA-Z]:|\\)\\)?(((\.)|(\.\.)|([^\\/:\*\?""\|<>\. ](([^\\/:\*\?""\|<>\. ])|([^\\/:\*\?""\|<>]*[^\\/:\*\?""\|<>\. ]))?))\\)*[^\\/:\*\?""\|<>\. ](([^\\/:\*\?""\|<>\. ])|([^\\/:\*\?""\|<>]*[^\\/:\*\?""\|<>\. ]))?$";
            }

            return (Regex.IsMatch(expression, sPattern, RegexOptions.CultureInvariant));
        }

        public static bool IsNetAvailable() // Custom function due to a bug in my.computer.network.isavailable.
        {
            WebClient webClient = new WebClient();
            try
            {
                string fileText = webClient.DownloadString("http://ahmad45123.github.io/esfiles/serverPackages.xml");
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }

        public static string[] GetAllFolders(string directory)
        {
            DirectoryInfo fi = new DirectoryInfo(directory);
            string[] path = { };
            foreach (DirectoryInfo subfolder in fi.GetDirectories())
            {
                Array.Resize(ref path, path.Length + 1);
                path[path.Length - 1] = subfolder.FullName;
                foreach (string s in GetAllFolders(subfolder.FullName))
                {
                    Array.Resize(ref path, path.Length + 1);
                    path[path.Length - 1] = s;
                }
            }

            return path;
        }

        //TODO: make sure this is correct, ref
        private static TreeNode _getAllFilesTreeNode;

        public static TreeNode GetAllFilesInFolders(string dir, string extension = "", TreeNode parentNode = null)
        {
            TreeNode currentDir;

            if (parentNode == null)
                _getAllFilesTreeNode = new TreeNode();

            string[] dirs = Directory.GetDirectories(dir);

            foreach (string str in dirs)
            {
                if (parentNode == null)
                {
                    currentDir = _getAllFilesTreeNode.Nodes.Add(str.Remove(0, str.LastIndexOf(@"\") + 1));
                    currentDir.Tag = "Folder";
                }
                else
                {
                    currentDir = parentNode.Nodes.Add(str.Remove(0, str.LastIndexOf(@"\") + 1));
                    currentDir.Tag = "Folder";
                }

                // Get all directories.
                foreach (string strb in Directory.GetDirectories(str))
                {
                    TreeNode tmpDir = currentDir.Nodes.Add(strb.Remove(0, strb.LastIndexOf(@"\") + 1));
                    tmpDir.Tag = "Folder";

                    foreach (string stra in Directory.GetFiles(strb))
                    {
                        if (extension != "")
                        {
                            if (!stra.EndsWith(extension))
                                continue;
                        }

                        var node = tmpDir.Nodes.Add(Path.GetFileName(stra));
                        node.ImageIndex = 1;
                        node.Tag = "File";
                    }

                    GetAllFilesInFolders(strb, extension, tmpDir);
                }

                // Get files.
                foreach (string stra in Directory.GetFiles(str))
                {
                    if (extension != "")
                    {
                        if (!stra.EndsWith(extension))
                            continue;
                    }

                    var node = currentDir.Nodes.Add(Path.GetFileName(stra));
                    node.ImageIndex = 1;
                    node.Tag = "File";
                }
            }

            return _getAllFilesTreeNode;
        }

        public static bool IsValidExtremeProject(string path)
        {
            if (!IsValidSAMPFolder(path))
                return false;
            if (!File.Exists(path + "/extremeStudio.config"))
                return false;
            if (!Directory.Exists(path + "/configs"))
                return false;

            // If everything's correct, Create folders that ES requires if not already exists.
            if (!Directory.Exists(path + "/gamemodes"))
                Directory.CreateDirectory(path + "/gamemodes");
            if (!Directory.Exists(path + "/pawno"))
                Directory.CreateDirectory(path + "/pawno");
            if (!Directory.Exists(path + "/pawno/include"))
                Directory.CreateDirectory(path + "/pawno/include");
            if (!Directory.Exists(path + "/plugins"))
                Directory.CreateDirectory(path + "/plugins");
            return true;
        }

        public static bool IsValidSAMPFolder(string path)
        {
            if (!Directory.Exists(path))
                return false;
            if (!File.Exists(path + "/announce.exe"))
                return false;
            if (!File.Exists(path + "/samp-npc.exe"))
                return false;
            if (!File.Exists(path + "/samp-server.exe"))
                return false;
            if (!File.Exists(path + "/server.cfg"))
                return false;
            if (!File.Exists(path + "/pawno/libpawnc.dll"))
                return false;
            if (!File.Exists(path + "/pawno/pawnc.dll"))
                return false;
            if (!File.Exists(path + "/pawno/pawncc.exe"))
                return false;
            return true;
        }

        public static List<int> GetLinesFromRange(Scintilla scin, int startPos, int endPos)
        {
            List<int> lines = new List<int>();

            for (var i = 0; i <= 1; i += 0)
            {
                int lne = scin.LineFromPosition(startPos);
                lines.Add(lne);
                startPos += scin.Lines[lne].Length;

                if (startPos == endPos | startPos >= scin.CurrentPosition)
                    break;
            }

            return lines;
        }

        public static void GetFilesInZip(string pathtoZip, ref List<string> files, ref List<string> folders)
        {
            // Make the temp folder ready.
            string tmpPath = Path.GetTempPath() + "/" + Path.GetFileNameWithoutExtension(pathtoZip);
            Directory.CreateDirectory(tmpPath);

            // Extract the files.
            FastZipUnpack(pathtoZip, tmpPath);

            // Get all files and folders and put them in the lists.
            files.AddRange(from filePath in Directory.GetFiles(tmpPath)
                select Path.GetFileName(filePath));
            folders.AddRange(from folderPath in Directory.GetDirectories(tmpPath)
                select Path.GetDirectoryName(folderPath));

            // Clean.
            Directory.Delete(tmpPath, true);
        }

        public static void FastZipUnpack(string zipToUnpack, string targetDir, string file = "")
        {
            using (Stream stream = File.OpenRead(zipToUnpack))
            {
                var reader = ReaderFactory.Open(stream);
                while (reader.MoveToNextEntry())
                {
                    if(file != "" && file != reader.Entry.Key)
                        continue;
                    
                    if (!reader.Entry.IsDirectory)
                    {
                        reader.WriteEntryToDirectory(targetDir, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                    }
                }
            }
        }

        public static string ColorToHex(Color color)
        {
            return String.Format("0x{0}{1}{2}{3}",
                color.A.ToString("X").Length == 1
                    ? String.Format("0{0}", color.A.ToString("X"))
                    : color.A.ToString("X"),
                color.R.ToString("X").Length == 1
                    ? String.Format("0{0}", color.R.ToString("X"))
                    : color.R.ToString("X"),
                color.G.ToString("X").Length == 1
                    ? String.Format("0{0}", color.G.ToString("X"))
                    : color.G.ToString("X"),
                color.B.ToString("X").Length == 1
                    ? String.Format("0{0}", color.B.ToString("X"))
                    : color.B.ToString("X"));
        }

        public static string GetFileHash(string fileName)
        {
            var sha = SHA1.Create();

            if (File.Exists(fileName) == false)
                return "";

            // To skipe file being used shit.
            byte[] fle = File.ReadAllBytes(fileName);
            return Convert.ToBase64String(sha.ComputeHash(fle));
        }

    }
}
