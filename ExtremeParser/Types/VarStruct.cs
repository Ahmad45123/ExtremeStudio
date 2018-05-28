using System.Collections.Generic;

namespace ExtremeParser.Types
{
    public struct VarStruct
    {
        public bool Equals(VarStruct other)
        {
            return string.Equals(VarName, other.VarName) && string.Equals(VarTag, other.VarTag) && Equals(VarArrays, other.VarArrays) && string.Equals(DefaultValue, other.DefaultValue);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is VarStruct && Equals((VarStruct) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (VarName != null ? VarName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VarTag != null ? VarTag.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VarArrays != null ? VarArrays.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DefaultValue != null ? DefaultValue.GetHashCode() : 0);
                return hashCode;
            }
        }

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
	
        public static bool operator ==(VarStruct first, VarStruct second)
        {
            return first.VarName == second.VarName && first.VarTag == second.VarTag && first.DefaultValue == second.DefaultValue;
        }
        public static bool operator !=(VarStruct first, VarStruct second)
        {
            return !(first == second);
        }
	
    }
}
