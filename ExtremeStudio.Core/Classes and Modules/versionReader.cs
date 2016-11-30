using System;
using System.Text.RegularExpressions;

namespace ExtremeStudio.Core.Modules
{
	
	public class VersionReader
	{
		public int PMajor;
		public int PMinor;
		public int PPatch;
		public VersionReader(string versionText)
		{
			Match mtch = Regex.Match(versionText, "([0-9]+)\\.([0-9]+)\\.([0-9]+)");
			PMajor = Convert.ToInt16(mtch.Groups[1].Value);
			PMinor = Convert.ToInt16(mtch.Groups[2].Value);
			PPatch = Convert.ToInt16(mtch.Groups[3].Value);
		}
		
		
		public enum CompareVersionResult
		{
			VersionNew,
			VersionOld,
			VersionSame
		}
		public static CompareVersionResult CompareVersions(string mainV, string newV)
		{
			VersionReader mainVc = new VersionReader(mainV);
			VersionReader newVc = new VersionReader(newV);
			
			if (newVc.PMajor > mainVc.PMajor)
			{
				return CompareVersionResult.VersionNew;
			}
			else if (newVc.PMinor > mainVc.PMinor)
			{
				return CompareVersionResult.VersionNew;
			}
			else if (newVc.PPatch > mainVc.PPatch)
			{
				return CompareVersionResult.VersionNew;
			}
			else
			{
				if (newVc.PMajor == mainVc.PMajor & newVc.PMinor == mainVc.PMinor & newVc.PPatch == mainVc.PPatch)
				{
					return CompareVersionResult.VersionSame;
				}
				else
				{
					return CompareVersionResult.VersionOld;
				}
			}
		}
	}
	
}
