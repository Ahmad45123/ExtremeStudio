using System;
using System.Text.RegularExpressions;
using ExtremeParser.Exceptions;

namespace ExtremeParser.Parsers
{
    public class PawnDoc
    {
        public static void Parse(string code, string fileName, CodeParts parts, bool add = true)
        {
            foreach (Match match in Regex.Matches(code, "\\/\\*\\*([^*]*(?:\\*(?!\\/)[^*]*)*)\\*\\/"))
            {
                string val = Convert.ToString(match.Groups[1].Value); //Group 0 which contains only the internal text without the start and the end.
			
                if (!val.Contains("<summary>") || !val.Contains("</summary>"))
                {
                    continue;
                }
			
                try
                {
                    var pwn = new PawnDocParser(val);
                    if (add)
                    {
                        parts.PawnDocs.Add(pwn);
                    }
                    else
                    {
                        parts.PawnDocs.RemoveAll(x => x.Summary == pwn.Summary);
                    }
                }
                catch (ParserException ex)
                {
                    throw (new ParserException(ex.Message, ""));
                }
            }
        }
    }
}
