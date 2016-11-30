using System.Collections.Generic;
using System;


namespace ExtremeStudio.Parser.Exceptions
{
	public class ExceptionsList : Exception
	{
		public ExceptionsList()
		{
			EcsList = new List<Exception>();
			
		}
		public List<Exception> EcsList {get; set;}
	}
	
}
