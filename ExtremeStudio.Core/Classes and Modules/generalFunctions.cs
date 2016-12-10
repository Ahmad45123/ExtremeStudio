using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using ScintillaNET;
using Ionic.Zip;
using System.Windows.Media;

namespace ExtremeStudio.Core.Modules
{
	public sealed class GeneralFunctions
	{
        public static string GetExecutionFolder()
	    {
	        return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
	    }

		public static bool FilenameIsOk(string fileName, bool allowPathDefinition, int firstCharIndex)
		{
			
		string file = string.Empty;
		string directory = string.Empty;
			
		if (allowPathDefinition)
		{
			file = Path.GetFileName(fileName);
			directory = Path.GetDirectoryName(fileName);
		}
		else
		{
			file = fileName;
		}
			
		if (firstCharIndex != 0)
		{
			IEnumerable<char> f = default(IEnumerable<char>);
			f = file?.Intersect(Path.GetInvalidFileNameChars());
			if (f.Any())
			{
				firstCharIndex = directory.Length + file.IndexOf(f.First());
				return false;
			}
				
			f = directory.Intersect(Path.GetInvalidPathChars());
			if (f.Any())
			{
				firstCharIndex = directory.IndexOf(f.First());
				return false;
			}
			else
			{
				return true;
			}
		}
		else
		{
			return !(file.Intersect(Path.GetInvalidFileNameChars()).Any() 
				||
				directory.Intersect(Path.GetInvalidPathChars()).Any());
		}
	}
		
		public static bool IsNetAvailable()
		{
			WebClient webClient = new WebClient();
			try
			{
				string fileText = webClient.DownloadString("http://johnymac.github.io/esfiles/serverPackages.xml");
				return true;
			}
			catch (WebException)
			{
				return false;
			}
		}
		
		public static string[] GetAllFolders(string directory)
		{
			System.IO.DirectoryInfo fi = new System.IO.DirectoryInfo(directory);
			string[] path = new string[] {};
			foreach (System.IO.DirectoryInfo subfolder in fi.GetDirectories())
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
		
		static TreeNode _getAllFilesTreeNode;
		public static TreeNode GetAllFilesInFolders(string dir, string extension, TreeNode parentNode)
		{
			TreeNode currentDir = default(TreeNode);
			
			if (parentNode == null)
			{
				_getAllFilesTreeNode = new TreeNode();
			}
			
			string[] dirs = Directory.GetDirectories(dir);
			
			foreach (string str in dirs)
			{
				if (parentNode == null)
				{
					currentDir = _getAllFilesTreeNode.Nodes.Add(str.Remove(0, str.LastIndexOf("\\") + 1));
					currentDir.Tag = "Folder";
				}
				else
				{
					currentDir = parentNode.Nodes.Add(str.Remove(0, str.LastIndexOf("\\") + 1));
					currentDir.Tag = "Folder";
				}
				
				//Get all directories.
				foreach (string strb in Directory.GetDirectories(str))
				{
					TreeNode tmpDir = currentDir.Nodes.Add(strb.Remove(0, strb.LastIndexOf("\\") + 1));
					tmpDir.Tag = "Folder";
					
					foreach (string stra in Directory.GetFiles(strb))
					{
						if (!(extension == ""))
						{
							if (!stra.EndsWith(extension))
							{
								continue;
							}
						}
						
						var node = tmpDir.Nodes.Add(Path.GetFileName(stra));
						node.ImageIndex = 1;
						node.Tag = "File";
					}
					GetAllFilesInFolders(strb, extension, tmpDir);
				}
				
				//Get files.
				foreach (string stra in Directory.GetFiles(str))
				{
					if (!(extension == ""))
					{
						if (!stra.EndsWith(extension))
						{
							continue;
						}
					}
					
					var node = currentDir.Nodes.Add(Path.GetFileName(stra));
					node.ImageIndex = 1;
					node.Tag = "File";
				}
				
			}
			return _getAllFilesTreeNode;
		}
		
		public static dynamic IsValidExtremeProject(string path)
		{
			if (!IsValidSAMPFolder(path))
			{
				return false;
			}
			if (!File.Exists(path + "/extremeStudio.config"))
			{
				return false;
			}
			if (!Directory.Exists(path + "/configs"))
			{
				return false;
			}
			
			//If everything's correct, Create folders that ES requires if not already exists.
			if (!Directory.Exists(path + "/gamemodes"))
			{
				Directory.CreateDirectory(path + "/gamemodes");
			}
			if (!Directory.Exists(path + "/pawno"))
			{
				Directory.CreateDirectory(path + "/pawno");
			}
			if (!Directory.Exists(path + "/pawno/include"))
			{
				Directory.CreateDirectory(path + "/pawno/include");
			}
			if (!Directory.Exists(path + "/plugins"))
			{
				Directory.CreateDirectory(path + "/plugins");
			}
			return true;
		}
		
		public static dynamic IsValidSAMPFolder(string path)
		{
			if (!Directory.Exists(path))
			{
				return false;
			}
			if (!File.Exists(path + "/announce.exe"))
			{
				return false;
			}
			if (!File.Exists(path + "/samp-npc.exe"))
			{
				return false;
			}
			if (!File.Exists(path + "/samp-server.exe"))
			{
				return false;
			}
			if (!File.Exists(path + "/server.cfg"))
			{
				return false;
			}
			if (!File.Exists(path + "/pawno/libpawnc.dll"))
			{
				return false;
			}
			if (!File.Exists(path + "/pawno/pawnc.dll"))
			{
				return false;
			}
			if (!File.Exists(path + "/pawno/pawncc.exe"))
			{
				return false;
			}
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
				{
					break;
				}
			}
			
			return lines;
		}
		
		public static void GetFilesInZip(string pathtoZip, List<string> files, List<string> folders)
		{
			//Make the temp folder ready.
			string tmpPath = Path.GetTempPath() + "/" + Path.GetFileNameWithoutExtension(pathtoZip);
			Directory.CreateDirectory(tmpPath);
			
			//Extract the files.
			FastZipUnpack(pathtoZip, tmpPath);
			
			//Get all files and folders and put them in the lists.
			files.AddRange(from filePath in Directory.GetFiles(tmpPath) select Path.GetFileName(System.Convert.ToString(filePath)));
			folders.AddRange(from folderPath in Directory.GetDirectories(tmpPath) select Path.GetDirectoryName(System.Convert.ToString(folderPath)));
			
			//Clean.
			Directory.Delete(tmpPath, true);
		}
		
		public static void FastZipUnpack(string zipToUnpack, string targetDir)
		{
			using (ZipFile zip1 = ZipFile.Read(zipToUnpack))
			{
				ZipEntry e = default(ZipEntry);
				foreach (ZipEntry tempLoopVar in zip1)
				{
					e = tempLoopVar;
					e.Extract(targetDir, ExtractExistingFileAction.OverwriteSilently);
				}
			}
			
		}
		
		public static string ColorToHex(Color color)
		{
			return Convert.ToString(
			    $"0x{((color.A.ToString("X").Length == 1) ? ($"0{color.A.ToString("X")}") : (color.A.ToString("X")))}{((color.R.ToString("X").Length == 1) ? ($"0{color.R.ToString("X")}") : (color.R.ToString("X")))}{((color.G.ToString("X").Length == 1) ? ($"0{color.G.ToString("X")}") : (color.G.ToString("X")))}{((color.B.ToString("X").Length == 1) ? ($"0{color.B.ToString("X")}") : (color.B.ToString("X")))}");
		}
	}
	
}
