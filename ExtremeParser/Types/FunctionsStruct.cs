using System.Collections.Generic;
using ExtremeParser.Global;
using ExtremeParser.Parsers;

namespace ExtremeParser.Types
{
    public struct FunctionsStruct
    {
        public string FuncName;
        public FunctionParameters FuncParameters;
        public PawnDocParser FuncPawnDoc;
        public string ReturnTag;

        public FunctionsStruct(string funcNam, string funcPars, string ret, PawnDocParser pwnDoc)
        {
            FuncName = funcNam;
            FuncParameters = new FunctionParameters(funcPars);
            FuncPawnDoc = pwnDoc;
            ReturnTag = ret;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is FunctionsStruct))
            {
                return false;
            }

            var @struct = (FunctionsStruct)obj;
            return FuncName == @struct.FuncName &&
                   EqualityComparer<FunctionParameters>.Default.Equals(FuncParameters, @struct.FuncParameters) &&
                   EqualityComparer<PawnDocParser>.Default.Equals(FuncPawnDoc, @struct.FuncPawnDoc) &&
                   ReturnTag == @struct.ReturnTag;
        }

        public bool Equals(FunctionsStruct other)
        {
            return string.Equals(FuncName, other.FuncName) && Equals(FuncParameters, other.FuncParameters) && Equals(FuncPawnDoc, other.FuncPawnDoc) && string.Equals(ReturnTag, other.ReturnTag);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (FuncName != null ? FuncName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FuncParameters != null ? FuncParameters.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FuncPawnDoc != null ? FuncPawnDoc.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ReturnTag != null ? ReturnTag.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(FunctionsStruct first, FunctionsStruct second)
        {
            return first.FuncName == second.FuncName &&
                   first.FuncParameters.ParamsText == second.FuncParameters.ParamsText;
        }

        public static bool operator !=(FunctionsStruct first, FunctionsStruct second)
        {
            return !(first == second);
        }
    }
}