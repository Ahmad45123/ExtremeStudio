using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ExtremeParser.Global;
using ExtremeParser.Types;

namespace ExtremeParser.Parsers
{
    public class Enums
    {
        public static void Parse(string code, string fileName, CodeParts parts, bool add = true)
        {
            foreach (Match match in Regex.Matches(code, "enum\\s+([^\\n;\\(\\)\\{\\}\\s]*)\\s+(?:(?:[{])([^}]+)(?:[}]))"))
            {
                string[] enumds = match.Groups[2].Value.Split(',');
			
                //Variable to store the enums contents.
                List<EnumsContentsClass> enumStuff = new List<EnumsContentsClass>();
			
                foreach (string enumatmp in enumds)
                {
                    string enuma = enumatmp;
                    //Check if empty
                    if (ReferenceEquals(enuma, null) || enuma.Trim() == "")
                    {
                        continue;
                    }
				
                    int length = enuma.Length + 1;
                    enuma = enuma.Trim();
                    var type = FunctionParameters.GetVarType(enuma);
				
                    //Do what needs to be changed
                    if (type == FunctionParameters.VarTypes.TypeFloat)
                    {
                        enuma = enuma.Remove(0, 6);
                    }
                    else if (type == FunctionParameters.VarTypes.TypeArray)
                    {
                        enuma = enuma.Remove(enuma.IndexOf("["), (enuma.IndexOf("]") - enuma.IndexOf("[")) + 1);
                    }
                    else if (type == FunctionParameters.VarTypes.TypeTagged)
                    {
                        enuma = enuma.Remove(0, enuma.IndexOf(":") + 1);
                    }
				
                    try
                    {
                        enumStuff.Add(new EnumsContentsClass(enuma, type));
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
