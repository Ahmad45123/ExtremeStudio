using ExtremeStudio.Parser;
using ExtremeStudio.Parser.Global;


namespace ExtremeStudio.Parser.Parsers
{
	public class DefReplacer
	{
		public static void Parse(ref string code, string fileName, CodeParts parts, bool add = true)
		{
			foreach (var part in parts.FlattenIncludes())
			{
				for (int i = 0; i <= part.Defines.Count - 1; i++)
				{
					DefineReplacer.Replace(ref code, System.Convert.ToString(part.Defines[i].DefineName), System.Convert.ToString(part.Defines[i].DefineValue), false);
				}
				for (int i = 0; i <= part.Macros.Count - 1; i++)
				{
					DefineReplacer.Replace(ref code, System.Convert.ToString(part.Macros[i].DefineName), System.Convert.ToString(part.Macros[i].DefineValue), true);
				}
			}
		}
	}
	
}
