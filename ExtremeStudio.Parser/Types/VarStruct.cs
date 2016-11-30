using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeStudio.Parser.Types
{
    public struct VarStruct
    {

        public string VarName;
        public string VarTag;
        public List<string> VarArrays;
        public string DefaultValue;

        public VarStruct(string name, string tag, string def, List<string> arrays)
        {
            VarName = name;
            VarTag = tag;
            VarArrays = arrays;
            DefaultValue = def;
        }

        public static object operator ==(VarStruct first, VarStruct second)
        {
            if (first.VarName == second.VarName && first.VarTag == second.VarTag && first.DefaultValue == second.DefaultValue)
            {
                return true;
            }
            return false;
        }
        public static object operator !=(VarStruct first, VarStruct second)
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
