using System;
using System.Collections.Generic;

namespace ExtremeParser.Exceptions
{
    public class ExceptionsList : Exception
    {
        public ExceptionsList()
        {
            // VBConversions Note: Non-static class variable initialization is below.  Class variables cannot be initially assigned non-static values in C#.
            ExceptionsList_Renamed =  new List<Exception>();
		
        }
        public List<Exception> ExceptionsList_Renamed {get; set;} = new List<Exception>();
    }
}
