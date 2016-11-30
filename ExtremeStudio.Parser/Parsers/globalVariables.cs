using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ExtremeStudio.Parser;
using ExtremeStudio.Parser.Types;

namespace ExtremeStudio.Parser.Parsers
{
	public class GlobalVariables
	{
		public static void Parse(string code, string fileName, CodeParts parts, bool add = true)
		{
			foreach (Match match in Regex.Matches(code, "(?:\\s?stock\\s+static|\\s?static\\s+stock|\\s?new\\s+stock|\\s?new|\\s?static|\\s?stock)\\s*([\\s\\S]*?);", RegexOptions.Multiline))
			{
				string varName = match.Groups[1].Value;
				
				//Remove all whitespace.
				varName = varName.Replace(" ", "");
				varName = varName.Replace(System.Convert.ToString("\t"), "");
				
				//Now if there is multiple variables in one.. Split it.
				string[] allVars = null;
				
				if (varName.Contains(","))
				{
					allVars = varName.Split(",".ToCharArray());
				}
				else
				{
					allVars = new[] {varName};
				}
				
				//Loop through all.
				foreach (string str in allVars)
				{
				    string editStr = str;

					//Get tag and remove.
					string tag = "";
					if (editStr.Contains(":"))
					{
						tag = editStr.Substring(0, editStr.IndexOf(":") + 1);
						editStr = editStr.Remove(0, editStr.IndexOf(":") + 1);
					}
					
					//Get and Remove all arrays.
					List<string> arrays = (from Match mtch in Regex.Matches(editStr, "(?<=\\[)(?>[^\\[\\]]+|\\[(?<DEPTH>)|\\](?<-DEPTH>))*(?(DEPTH)(?!))(?=\\])") select mtch.Value).ToList();
					editStr = Regex.Replace(editStr, "\\[(?<=\\[)(?>[^\\[\\]]+|\\[(?<DEPTH>)|\\](?<-DEPTH>))*(?(DEPTH)(?!))(?=\\])\\]", "");
					
					//Get then Remove default
					string def = "";
					if (editStr.Contains("="))
					{
						def = editStr.Substring(editStr.IndexOf("="), editStr.Length - editStr.IndexOf("="));
						editStr = editStr.Remove(editStr.IndexOf("="), editStr.Length - editStr.IndexOf("="));
					}
					
					//Add
					if (add)
					{
						parts.PublicVariables.Add(new VarStruct(editStr, tag, def, arrays));
					}
					else
					{
						parts.PublicVariables.RemoveAll(x => x.VarName == editStr);
					}
				}
			}
		}
	}
	
}
