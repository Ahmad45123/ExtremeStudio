using System;
using System.Collections.Generic;
using System.Linq;
using ExtremeParser.Global;

namespace ExtremeParser.Types
{
    public struct EnumsStruct
    {
        public bool Equals(EnumsStruct other)
        {
            return string.Equals(EnumName, other.EnumName) && Equals(EnumContents, other.EnumContents);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is EnumsStruct && Equals((EnumsStruct) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((EnumName != null ? EnumName.GetHashCode() : 0) * 397) ^ (EnumContents != null ? EnumContents.GetHashCode() : 0);
            }
        }

        public string EnumName;
        public List<EnumsContentsClass> EnumContents;

        public EnumsStruct(string name, List<EnumsContentsClass> contents)
        {
            EnumName = name;
            EnumContents = contents;
        }

        public static bool operator ==(EnumsStruct first, EnumsStruct second)
        {
            if (first.EnumName == second.EnumName)
            {
                return !(from enm in first.EnumContents
                    from enma in second.EnumContents
                    where Convert.ToDouble(enm) != Convert.ToDouble(enma)
                    select new {enm, enma}).Any();
            }

            return false;
        }

        public static bool operator !=(EnumsStruct first, EnumsStruct second)
        {
            return !(first == second);
        }

    }

    public class EnumsContentsClass
    {
        protected bool Equals(EnumsContentsClass other)
        {
            return string.Equals(_content, other._content) && _type == other._type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((EnumsContentsClass) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_content != null ? _content.GetHashCode() : 0) * 397) ^ (int) _type;
            }
        }

        private string _content;
        public string Content => _content;

        private FunctionParameters.VarTypes _type;
        public FunctionParameters.VarTypes Type => _type;

        public EnumsContentsClass(string cntn, FunctionParameters.VarTypes tpe)
        {
            _content = cntn;
            _type = tpe;
        }

        public static bool operator ==(EnumsContentsClass first, EnumsContentsClass second)
        {
            return first.Content == second.Content && first.Type == second.Type;
        }

        public static bool operator !=(EnumsContentsClass first, EnumsContentsClass second)
        {
            return !(first == second);
        }
    }
}