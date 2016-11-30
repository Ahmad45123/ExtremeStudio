using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtremeStudio.Parser.Global;
using ExtremeStudio.Parser.Parsers;

namespace ExtremeStudio.Parser.Types
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

        public static object operator ==(FunctionsStruct first, FunctionsStruct second)
        {
            if (first.FuncName == second.FuncName && first.FuncParameters.ParamsText == second.FuncParameters.ParamsText)
            {
                return true;
            }
            return false;
        }
        public static object operator !=(FunctionsStruct first, FunctionsStruct second)
        {
            if ((bool)(first == second))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override bool Equals(object o)
        {
            throw new NotImplementedException();
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
