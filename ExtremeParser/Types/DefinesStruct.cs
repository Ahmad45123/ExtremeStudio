namespace ExtremeParser.Types
{
    public struct DefinesStruct
    {
        public bool Equals(DefinesStruct other)
        {
            return string.Equals(DefineName, other.DefineName) && string.Equals(DefineValue, other.DefineValue);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is DefinesStruct && Equals((DefinesStruct) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((DefineName != null ? DefineName.GetHashCode() : 0) * 397) ^ (DefineValue != null ? DefineValue.GetHashCode() : 0);
            }
        }

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
            return first.DefineName == second.DefineName && first.DefineValue == second.DefineValue;
        }

        public static object operator !=(DefinesStruct first, DefinesStruct second)
        {
            return first.DefineName != second.DefineName || first.DefineValue != second.DefineValue;
        }
    }
}