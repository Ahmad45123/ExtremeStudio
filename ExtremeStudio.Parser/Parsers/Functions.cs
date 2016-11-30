using System;
using System.Text.RegularExpressions;
using ExtremeParser;
using ExtremeStudio.Parser;
using ExtremeStudio.Parser.Types;

namespace ExtremeStudio.Parser.Parsers
{
	public class Functions
	{
	    public static string FuncLikeKeywords { get; set; } = "do|for|switch|while|if|foreach|else";

	    public static void Parse(string code, string fileName, CodeParts parts, bool add = true)
		{
			//Publics.
			foreach (Match match in Regex.Matches(code, "public[ \\t]+([a-zA-Z1-3_@: \\t]+)[ \\t]*\\((.*)\\)\\s*{", RegexOptions.Multiline))
			{
				string funcName = Regex.Replace(match.Groups[1].Value, "\\s", "");
				string funcParams = Regex.Replace(match.Groups[2].Value, "\\s", "");
				try
				{
					//Get the tag if exists.
					string tag = "";
					if (funcName.Contains(":"))
					{
						tag = funcName.Substring(0, funcName.IndexOf(":", StringComparison.Ordinal) + 1);
						funcName = funcName.Remove(0, funcName.IndexOf(":") + 1);
					}
					
					//Get the PawnDoc for it.
					PawnDocParser pwndoc = null;
					if (parts.PawnDocs != null)
					{
						pwndoc = parts.PawnDocs.Find(x => x.Summary == funcName);
					}
					
					if (add)
					{
						parts.Publics.Add(new FunctionsStruct(funcName, funcParams, tag, pwndoc));
					}
					else
					{
						parts.Publics.RemoveAll(x => x.FuncName == funcName);
					}
				}
				catch (Exception)
				{
				}
			}
			
			//Stocks
			foreach (Match match in Regex.Matches(code, "stock[ \\t]+([a-zA-Z1-3_@: \\t]+)[ \\t]*\\((.*)\\)\\s*{", RegexOptions.Multiline))
			{
				string funcName = Regex.Replace(match.Groups[1].Value, "\\s", "");
				string funcParams = Regex.Replace(match.Groups[2].Value, "\\s", "");
				try
				{
					//Get the tag if exists.
					string tag = "";
					if (funcName.Contains(":"))
					{
						tag = funcName.Substring(0, funcName.IndexOf(":") + 1);
						funcName = funcName.Remove(0, funcName.IndexOf(":") + 1);
					}
					
					//Get the PawnDoc for it.
					PawnDocParser pwndoc = null;
					if (parts.PawnDocs != null)
					{
						pwndoc = parts.PawnDocs.Find(x => x.Summary == funcName);
					}
					
					if (add)
					{
						parts.Stocks.Add(new FunctionsStruct(funcName, funcParams, tag, pwndoc));
					}
					else
					{
						parts.Stocks.RemoveAll(x => x.FuncName == funcName);
					}
				}
				catch (Exception)
				{
				}
			}
			
			//Functions in General.
			foreach (Match match in Regex.Matches(code, "^[ \\t]*(?!" + FuncLikeKeywords + ")(?:\\sstatic\\s+stock\\s+|\\sstock\\s+static\\s+|\\sstatic\\s+)?([a-zA-Z1-3_@:]+)\\((.*)\\)(?!;)\\s*{", RegexOptions.Multiline))
			{
				string funcName = Regex.Replace(match.Groups[1].Value, "\\s", "");
				string funcParams = Regex.Replace(match.Groups[2].Value, "\\s", "");
				try
				{
					//Get the tag if exists.
					string tag = "";
					if (funcName.Contains(":"))
					{
						tag = funcName.Substring(0, funcName.IndexOf(":") + 1);
						funcName = funcName.Remove(0, funcName.IndexOf(":") + 1);
					}
					
					//Get the PawnDoc for it.
					PawnDocParser pwndoc = null;
					if (parts.PawnDocs != null)
					{
						pwndoc = parts.PawnDocs.Find(x => x.Summary == funcName);
					}
					
					if (add)
					{
						parts.Functions.Add(new FunctionsStruct(funcName, funcParams, tag, pwndoc));
					}
					else
					{
						parts.Functions.RemoveAll(x => x.FuncName == funcName);
					}
				}
				catch (Exception)
				{
				}
			}
			
			//Natives
			foreach (Match match in Regex.Matches(code, "native[ \\t]+([a-zA-Z1-3_@: \\t]+)[ \\t]*?\\((.*)\\);", RegexOptions.Multiline))
			{
				string funcName = Regex.Replace(match.Groups[1].Value, "\\s", "");
				string funcParams = Regex.Replace(match.Groups[2].Value, "\\s", "");
				try
				{
					//Get the tag if exists.
					string tag = "";
					if (funcName.Contains(":"))
					{
						tag = funcName.Substring(0, funcName.IndexOf(":") + 1);
						funcName = funcName.Remove(0, funcName.IndexOf(":") + 1);
					}
					
					//Get the PawnDoc for it.
					PawnDocParser pwndoc = null;
					if (parts.PawnDocs != null)
					{
						pwndoc = parts.PawnDocs.Find(x => x.Summary == funcName);
					}
					
					if (add)
					{
						parts.Natives.Add(new FunctionsStruct(funcName, funcParams, tag, pwndoc));
					}
					else
					{
						parts.Natives.RemoveAll(x => x.FuncName == funcName);
					}
				}
				catch (Exception)
				{
				}
			}
		}
	}
	
}
