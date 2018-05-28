using System;

namespace ExtremeParser.Exceptions
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
