using System.Text.RegularExpressions;

namespace ExtremeStudio.Parser.Parsers
{
	public class Cleaner
	{
		public static void Parse(ref string code, bool sComments = true, bool mComments = true, bool braces = true, bool strings = true)
		{
			//Remove singleline comments from code.
			if (sComments)
			{
				code = Regex.Replace(code, "//.*", "");
			}
			
			//Remove multiline comments.
			if (mComments)
			{
				code = Regex.Replace(code, "\\/\\*([^*]*(?:\\*(?!\\/)[^*]*)*)\\*\\/", "", RegexOptions.Multiline);
			}
			
			//Remove child codes.
			if (braces)
			{
				code = Regex.Replace(code, "(?<=\\{)(?>[^{}]+|\\{(?<DEPTH>)|\\}(?<-DEPTH>))*(?(DEPTH)(?!))(?=\\})", "");
			}
			
			//Strings
			if (strings)
			{
				code = Regex.Replace(code, "\'[^\'\\\\]*(?:\\\\[^\\n\\r\\x85\\u2028\\u2029][^\'\\\\]*)*\'", "");
				code = Regex.Replace(code, '\u0022' + "[^" + '\u0022' + "\\\\]*(?:\\\\[^\\n\\r\\x85\\u2028\\u2029][^" + '\u0022' + "\\\\]*)*" + '\u0022', "");
			}
		}
	}
	
}
