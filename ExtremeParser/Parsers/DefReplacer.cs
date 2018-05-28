using ExtremeParser.Global;

namespace ExtremeParser.Parsers
{
    public class DefReplacer
    {
        public static void Parse(string code, string fileName, CodeParts parts, bool add = true)
        {
            foreach (var part in parts.FlattenIncludes())
            {
                for (int i = 0; i <= part.Defines.Count - 1; i++)
                {
                    DefineReplacer.Replace(ref code, part.Defines[i].DefineName, part.Defines[i].DefineValue, false);
                }
                for (int i = 0; i <= part.Macros.Count - 1; i++)
                {
                    DefineReplacer.Replace(ref code, part.Macros[i].DefineName, part.Macros[i].DefineValue, true);
                }
            }
        }
    }
}
