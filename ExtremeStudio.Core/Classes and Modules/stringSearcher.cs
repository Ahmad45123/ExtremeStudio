using System.Linq;

namespace ExtremeStudio.Core.Modules
{
	public class StringSearcher
	{
		public static int CountChar(string src, char chr)
		{
			return System.Convert.ToInt32(src.Count(fChr => fChr == chr));
		}
	}
	
}
