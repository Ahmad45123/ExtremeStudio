using System;

namespace ExtremeStudio.Parser.Exceptions
{
	public class ParserException : Exception
	{
		
		public string Iden;
		
		public ParserException(string message, string idenB) : base(message)
		{
			Iden = idenB;
		}
	}
	
}
