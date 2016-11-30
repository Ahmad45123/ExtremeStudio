using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using ExtremeStudio.Parser;
using ExtremeStudio.Parser.Global;
using ExtremeStudio.Parser.Types;

namespace ExtremeStudio.Parser.Parsers
{
	public class Enums
	{
		public static void Parse(string code, string fileName, CodeParts parts, bool add = true)
		{
			foreach (Match match in Regex.Matches(code, "enum\\s+([^\\n;\\(\\)\\{\\}\\s]*)\\s+(?:(?:[{])([^}]+)(?:[}]))"))
			{
				string[] enumds = match.Groups[2].Value.Split(",".ToCharArray());
				
				//Variable to store the enums contents.
				List<EnumsContentsClass> enumStuff = new List<EnumsContentsClass>();
				
				foreach (string enuma in enumds)
				{
					//Check if empty
					if (enuma == null || enuma.Trim() == "")
					{
						continue;
					}
					
					int length = enuma.Length + 1;
					var newEnuma = enuma.Trim(); 
					var type = FunctionParameters.GetVarType(newEnuma);
					
					//Do what needs to be changed
					if (type == FunctionParameters.VarTypes.TypeFloat)
					{
                         newEnuma = newEnuma.Remove(0, 6);
                    }
                    else if (type == FunctionParameters.VarTypes.TypeArray)
					{
                        newEnuma = newEnuma.Remove(newEnuma.IndexOf("["), (newEnuma.IndexOf("]") - newEnuma.IndexOf("[")) + 1);
                    }
                    else if (type == FunctionParameters.VarTypes.TypeTagged)
					{
                        newEnuma = newEnuma.Remove(0, newEnuma.IndexOf(":") + 1);
                    }

                    try
					{
						enumStuff.Add(new EnumsContentsClass(newEnuma, type));
					}
					catch (Exception)
					{
					}
				}
				
				//Now add it to the actual list.
				if (add)
				{
					parts.Enums.Add(new EnumsStruct(match.Groups[1].Value.Trim(), enumStuff));
				}
				else
				{
					parts.Enums.RemoveAll(x => x.EnumName == match.Groups[1].Value.Trim());
				}
			}
		}
	}
	
}
