using System;
using System.Text.RegularExpressions;

namespace ExtremeParser.Parsers
{
    public class Cleaner
    {
        public static void Parse(ref string code, bool sComments = true, bool mComments = true, bool braces = true, bool strings = true)
        {
            //Remove singleline comments from code.
            if (sComments)
            {
                code = Convert.ToString(Regex.Replace(code, "//.*", ""));
            }
		
            //Remove multiline comments.
            if (mComments)
            {
                code = Convert.ToString(Regex.Replace(code, "\\/\\*([^*]*(?:\\*(?!\\/)[^*]*)*)\\*\\/", "", RegexOptions.Multiline));
            }
		
            //Remove child codes.
            if (braces)
            {
                code = Convert.ToString(Regex.Replace(code, "(?<=\\{)(?>[^{}]+|\\{(?<DEPTH>)|\\}(?<-DEPTH>))*(?(DEPTH)(?!))(?=\\})", ""));
            }
		
            //Strings
            if (strings)
            {
                code = Convert.ToString(Regex.Replace(code, "'[^'\\\\]*(?:\\\\[^\\n\\r\\x85\\u2028\\u2029][^'\\\\]*)*'", ""));
                code = Convert.ToString(Regex.Replace(code, (char)34 + "[^" + (char)34 + "\\\\]*(?:\\\\[^\\n\\r\\x85\\u2028\\u2029][^" + (char)34 + "\\\\]*)*" + (char)34, ""));
            }
        }
    }
}
