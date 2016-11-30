using ExtremeStudio.Parser.Global;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeStudio.Parser.Types
{
    public struct EnumsStruct
    {
        public string EnumName;
        public List<EnumsContentsClass> EnumContents;

        public EnumsStruct(string name, List<EnumsContentsClass> contents)
        {
            EnumName = name;
            EnumContents = contents;
        }

        public static object operator ==(EnumsStruct first, EnumsStruct second)
        {
            if (first.EnumName == second.EnumName)
            {
                return !(from enm in first.EnumContents from enma in second.EnumContents where System.Convert.ToBoolean((enm)) != System.Convert.ToBoolean(enma) select new { enm, enma }).Any();
            }
            return false;
        }
        public static object operator !=(EnumsStruct first, EnumsStruct second)
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

    public class EnumsContentsClass
    {
        private string _content;
        public string Content
        {
            get
            {
                return _content;
            }
        }

        private FunctionParameters.VarTypes _type;
        public FunctionParameters.VarTypes Type
        {
            get
            {
                return _type;
            }
        }

        public EnumsContentsClass(string cntn, FunctionParameters.VarTypes tpe)
        {
            _content = cntn;
            _type = tpe;
        }

        public static object operator ==(EnumsContentsClass first, EnumsContentsClass second)
        {
            if (first.Content == second.Content && first.Type == second.Type)
            {
                return true;
            }
            return false;
        }
        public static object operator !=(EnumsContentsClass first, EnumsContentsClass second)
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
