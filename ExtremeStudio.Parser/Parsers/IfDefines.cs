using System;
using System.Text.RegularExpressions;
using ExtremeStudio.Parser;

namespace ExtremeStudio.Parser.Parsers
{
	public class IfDefines
	{
		public static void Parse(string code, string filePath, string prjPath, ref CodeParts parts, bool add = true)
		{
			foreach (Match match in Regex.Matches(code, "\\#if[ \\t]+(!)?defined[ \\t]+(.+)([\\s\\S]*?)\\#endif", RegexOptions.Multiline))
			{
				bool isNt = (match.Groups[1].Value != "");
				string condition = "";
				string mainCode = "";
				string elseClode = " ";
				
				//Start filling the vars.
				condition = match.Groups[2].Value.Trim();
				
				if (match.Groups[3].Value.Contains("#else"))
				{
					string[] s = match.Groups[3].Value.Split(new [] { "#else" }, StringSplitOptions.RemoveEmptyEntries);
					mainCode = s[0].Trim();
					elseClode = s[1].Trim();
				}
				else
				{
					mainCode = match.Groups[3].Value.Trim();
				}
				
				//The result of the parse will be saved here for deletion.
				Parser result = null;
				
				//Now check which part needs to be parsed by seeing isNt and the else.
				if (isNt == false)
				{
					//Here the thing should BE defined
					if (IsDefined(parts, condition) == false)
					{
						//Parse the main.
						result = new Parser(ref parts, mainCode, filePath, prjPath, false, true);
					}
					else
					{
						//Parse the else.
						result = new Parser(ref parts, elseClode, filePath, prjPath, false, true);
					}
				}
				else
				{
					//It should NOT be defined.
					if (IsDefined(parts, condition) == true)
					{
						//Parse the main.
						result = new Parser(ref parts, mainCode, filePath, prjPath, false, true);
					}
					else
					{
						//Parse the else.
						result = new Parser(ref parts, elseClode, filePath, prjPath, false, true);
					}
				}
			}
		}
		
		private static dynamic IsDefined(CodeParts parts, string str)
		{
			if (parts.Defines.FindIndex(x => x.DefineName == str) != -1)
			{
				return true;
			}
			if (parts.Macros.FindIndex(x => x.DefineName == str) != -1)
			{
				return true;
			}
			if (parts.Enums.FindIndex(x => x.EnumName == str) != -1)
			{
				return true;
			}
			if (parts.Publics.FindIndex(x => x.FuncName == str) != -1)
			{
				return true;
			}
			if (parts.Stocks.FindIndex(x => x.FuncName == str) != -1)
			{
				return true;
			}
			if (parts.Functions.FindIndex(x => x.FuncName == str) != -1)
			{
				return true;
			}
			if (parts.Natives.FindIndex(x => x.FuncName == str) != -1)
			{
				return true;
			}
			if (parts.PublicVariables.FindIndex(x => x.VarName == str) != -1)
			{
				return true;
			}
			
			return false;
		}
	}
	
}
