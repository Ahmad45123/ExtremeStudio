using System;
using System.Text.RegularExpressions;

namespace ExtremeCore.Classes
{
    public class VersionReader
    {
        public int pMajor;
        public int pMinor;
        public int pPatch;

        public VersionReader(string versionText)
        {
            Match mtch = Regex.Match(versionText, @"([0-9]+)\.([0-9]+)\.([0-9]+)");
            pMajor = Convert.ToInt16(mtch.Groups[1].Value);
            pMinor = Convert.ToInt16(mtch.Groups[2].Value);
            pPatch = Convert.ToInt16(mtch.Groups[3].Value);
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

            if (newVc.pMajor > mainVc.pMajor)
                return CompareVersionResult.VersionNew;
            if (newVc.pMinor > mainVc.pMinor)
                return CompareVersionResult.VersionNew;
            if (newVc.pPatch > mainVc.pPatch)
                return CompareVersionResult.VersionNew;
            if (newVc.pMajor == mainVc.pMajor & newVc.pMinor == mainVc.pMinor & newVc.pPatch == mainVc.pPatch)
                return CompareVersionResult.VersionSame;
            return CompareVersionResult.VersionOld;
        }
    }
}