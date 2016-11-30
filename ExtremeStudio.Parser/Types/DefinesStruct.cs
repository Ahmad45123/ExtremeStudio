using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeStudio.Parser.Types
{
    public struct DefinesStruct
    {

        //No properties for speed.
        public string DefineName;
        public string DefineValue;

        public DefinesStruct(string defName, string defValue)
        {
            DefineName = defName;
            DefineValue = defValue;
        }

        public static object operator ==(DefinesStruct first, DefinesStruct second)
        {
            if (first.DefineName == second.DefineName && first.DefineValue == second.DefineValue)
            {
                return true;
            }
            return false;
        }
        public static object operator !=(DefinesStruct first, DefinesStruct second)
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
