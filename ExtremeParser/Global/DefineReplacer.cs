using System;
using System.Text.RegularExpressions;

namespace ExtremeParser.Global
{
    public class DefineReplacer
    {
        public static void Replace(ref string code, string defineName, string defineReplace, bool isMacro)
        {
            //First start building the regex for the find.
            string findRegex = Convert.ToString(Regex.Escape(defineName));
		
            //Setup find regex.
            findRegex = Convert.ToString(Regex.Replace(findRegex, "%([0-9])", "(.*)"));
            findRegex = "(?<!#.*)\\b" + findRegex;
            if (isMacro == false)
            {
                findRegex += "\\b";
            }
		
            //Setup replace regex.
            string replaceRegex = defineReplace;
            if (replaceRegex.Contains("%0"))
            {
                for (int i = 0; i <= 9; i++)
                {
                    replaceRegex = replaceRegex.Replace("%" + i, "$" + (i + 1));
                }
            }
            else
            {
                for (int i = 1; i <= 9; i++)
                {
                    replaceRegex = replaceRegex.Replace("%" + i, "$" + i);
                }
            }
		
            code = Convert.ToString(Regex.Replace(code, findRegex, replaceRegex));
        }
    }
}
