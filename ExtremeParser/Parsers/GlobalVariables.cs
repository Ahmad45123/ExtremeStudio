using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ExtremeParser.Types;

namespace ExtremeParser.Parsers
{
    public class GlobalVariables
    {
        public static void Parse(string code, string fileName, CodeParts parts, bool add = true)
        {
            foreach (Match match in Regex.Matches(code, "(?:\\s?stock\\s+static|\\s?static\\s+stock|\\s?new\\s+stock|\\s?new|\\s?static|\\s?stock)\\s*([\\s\\S]*?);", RegexOptions.Multiline))
            {
                string varName = Convert.ToString(match.Groups[1].Value);
			
                //Remove all whitespace.
                varName = varName.Replace(" ", "");
                varName = varName.Replace(Convert.ToString("\t"), "");
			
                //Now if there is multiple variables in one.. Split it.
                string[] allVars;
			
                if (varName.Contains(","))
                {
                    allVars = varName.Split(",".ToCharArray());
                }
                else
                {
                    allVars = new[] {varName};
                }
			
                //Loop through all.
                foreach (string strtmp in allVars)
                {
                    string str = strtmp;
                    //Get tag and remove.
                    string tag = "";
                    if (str.Contains(":"))
                    {
                        tag = str.Substring(0, str.IndexOf(":") + 1);
                        str = str.Remove(0, str.IndexOf(":") + 1);
                    }
				
                    //Get and Remove all arrays.
                    List<string> arrays = (from Match mtch in Regex.Matches(str, "(?<=\\[)(?>[^\\[\\]]+|\\[(?<DEPTH>)|\\](?<-DEPTH>))*(?(DEPTH)(?!))(?=\\])") select mtch.Value).ToList();
                    str = Convert.ToString(Regex.Replace(str, "\\[(?<=\\[)(?>[^\\[\\]]+|\\[(?<DEPTH>)|\\](?<-DEPTH>))*(?(DEPTH)(?!))(?=\\])\\]", ""));
				
                    //Get then Remove default
                    string def = "";
                    if (str.Contains("="))
                    {
                        def = str.Substring(str.IndexOf("="), str.Length - str.IndexOf("="));
                        str = str.Remove(str.IndexOf("="), str.Length - str.IndexOf("="));
                    }
				
                    //Add
                    if (add)
                    {
                        parts.PublicVariables.Add(new VarStruct(str, tag, def, arrays));
                    }
                    else
                    {
                        parts.PublicVariables.RemoveAll(x => x.VarName == str);
                    }
                }
            }
        }
    }
}
