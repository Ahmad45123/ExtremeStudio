using System;
using System.Linq;
using System.Text.RegularExpressions;
using ExtremeParser.Types;

namespace ExtremeParser.Parsers
{
    public class Defines
    {
        public static void Parse(string code, string fileName, CodeParts parts, bool add = true)
        {
            foreach (Match match in Regex.Matches(code, "^[ \\t]*[#]define[ \\t]+(?<name>[^\\s\\\\;]+)[ \\t]*(?:\\\\\\s+)?(?>(?<value>[^\\\\\\n\\r]+)[ \\t]*(?:\\\\\\s+)?)*", RegexOptions.Multiline))
            {
                string defineName = Convert.ToString(match.Groups[1].Value);
                string defineValue = match.Groups[2].Captures.Cast<Capture>().Aggregate("", (current, capt) => current + (capt.Value.Trim() + "\r\n"));
			
                try
                {
                    if (defineName.Contains("%"))
                    {
                        if (add)
                        {
                            parts.Macros.Insert(0, new DefinesStruct(defineName.Trim(), defineValue.Trim()));
                        }
                        else
                        {
                            parts.Macros.RemoveAll(x => x.DefineName == defineName);
                        }
                    }
                    else
                    {
                        if (add)
                        {
                            parts.Defines.Insert(0, new DefinesStruct(defineName.Trim(), defineValue.Trim()));
                        }
                        else
                        {
                            parts.Defines.RemoveAll(x => x.DefineName == defineName);
                        }
                    }
				
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
