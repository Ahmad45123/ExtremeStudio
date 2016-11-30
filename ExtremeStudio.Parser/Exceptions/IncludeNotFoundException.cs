using System;

namespace ExtremeStudio.Parser.Exceptions
{
	public class IncludeNotFoundException : Exception
	{
		public IncludeNotFoundException(string name)
		{
			IncludeName = name;
		}
		
		public string IncludeName {get; set;}
	}
	
}
