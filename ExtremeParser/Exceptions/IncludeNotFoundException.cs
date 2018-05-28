using System;

namespace ExtremeParser.Exceptions
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
