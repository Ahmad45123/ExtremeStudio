// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using ExtremeStudio.Parser.Parsers;

// End of VB project level imports


namespace ExtremeStudio.Parser.Global
{
	public class FunctionParameters
	{
		
        public string ParamsText
		{
			get
			{
				return _paramText;
			}
		}
		
		public Dictionary<string, string> Integers = new Dictionary<string, string>();
		public Dictionary<string, string> Arrays = new Dictionary<string, string>();
		public Dictionary<string, string> Floats = new Dictionary<string, string>();
		public PawnDocParser PawnDoc;
		
		private Dictionary<string, string> _othersVar = new Dictionary<string, string>(); //A function is created to handle this.
		private string _paramText;
		
		public enum VarTypes
		{
			TypeFloat,
			TypeInteger,
			TypeArray,
			TypeOther,
			TypeTagged
		}
		public static VarTypes GetVarType(string var)
		{
			if (var.StartsWith("Float:"))
			{
				return VarTypes.TypeFloat;
			}
			else if (var.EndsWith("]") && var.Contains("["))
			{
				return VarTypes.TypeArray;
			}
			else if (var.Contains(":"))
			{
				return VarTypes.TypeTagged;
			}
			else
			{
				return VarTypes.TypeInteger;
			}
		}
		
		public FunctionParameters(string @params)
		{
			var trimmedParams = @params.Replace(" ", "");
			_paramText = trimmedParams;
			string[] prms = trimmedParams.Split(",".ToCharArray());
			foreach (string str in prms)
			{
				if (string.IsNullOrEmpty(str)|| string.IsNullOrEmpty(str))
				{
					continue;
				}
				
				string def = "";
				if (str.Contains("="))
				{
					def = System.Convert.ToString(str.Substring(str.IndexOf("=")).Trim());
				}
				
				if (GetVarType(str) == VarTypes.TypeFloat)
				{
					// str = str.Remove(0, 6); VBConversions Warning: A foreach variable can't be assigned to in C#.
					Floats.Add(str, def);
				}
				else if (GetVarType(str) == VarTypes.TypeArray)
				{
					
					bool done = false;
					while (done == false)
					{
						if (str.Contains("[") && str.Contains("]"))
						{
							// str = str.Remove(str.IndexOf("["), (str.IndexOf("]") - str.IndexOf("[")) + 1); VBConversions Warning: A foreach variable can't be assigned to in C#.
						}
						else
						{
							done = true;
						}
					}
					
					Arrays.Add(str, def);
				}
				else if (GetVarType(str) == VarTypes.TypeTagged)
				{
					_othersVar.Add(str, def);
				}
				else //Its an integer obv..
				{
					Integers.Add(str, def);
				}
			}
		}
		
		public List<string> Others(string tag)
		{
			return ((from str in _othersVar.Keys let vars = _othersVar[str].Split(':', '2', System.Convert.ToChar(StringSplitOptions.None)) select vars).Where(vars => vars[0] == tag).Select(vars => vars[1])).ToList();
		}
		
		public enum ReturnType
		{
			AsEnum,
			AsString
		}
		public dynamic GetParameterType(string paramName, ReturnType returnType)
		{
			VarTypes ret = GetVarType(paramName);
			
			if (returnType == ReturnType.AsEnum)
			{
				return ret;
			}
			else
			{
				if (ret == VarTypes.TypeArray)
				{
					return "Array";
				}
				else if (ret == VarTypes.TypeFloat)
				{
					return "Float";
				}
				else if (ret == VarTypes.TypeInteger)
				{
					return "Integer";
				}
				else if (ret == VarTypes.TypeOther)
				{
					return "Other";
				}
				else if (ret == VarTypes.TypeTagged)
				{
					return "Tagged";
				}
			}
			return null;
		}
	}
	
}
