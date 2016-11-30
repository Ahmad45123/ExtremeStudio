using System.Collections.Generic;
using ExtremeStudio.Parser.Exceptions;

namespace ExtremeStudio.Parser.Parsers
{
	public class PawnDocParser
	{
		
#region Public Properties
public string Summary
		{
			get
			{
				return _pSummary;
			}
		}
public List<KeyValuePair<string, string>> Parameters
		{
			get
			{
				return _pParams;
			}
		}
public string Returns
		{
			get
			{
				return _pReturns;
			}
		}
public string Remarks
		{
			get
			{
				return _pRemarks;
			}
		}
#endregion
		
		private string _pSummary;
		private List<KeyValuePair<string, string>> _pParams = new List<KeyValuePair<string, string>>();
		private string _pReturns;
		private string _pRemarks;
		
		public PawnDocParser(string text)
		{
			//Prepare the text for parsing.
			string[] lines = text.Split('\n'); //Cut it into multiple lines.
			
			//Check for posible errors.
			if (text.Contains("<summary>") && !text.Contains("</summary>"))
			{
				throw (new ParserException("The summary closing tag is missing.", ""));
			}
			if (text.Contains("<returns>") && !text.Contains("</returns>"))
			{
				throw (new ParserException("The returns closing tag is missing.", ""));
			}
			if (text.Contains("<remarks>") && !text.Contains("</remarks>"))
			{
				throw (new ParserException("The remarks closing tag is missing.", ""));
			}
			
			//Configs.
			bool isInSummary = false;
			string currentSummary = null;
			bool isInAParam = false;
			string currentParamName = null;
			string currentParam = null;
			string currentParamDesc = null;
			bool isInReturn = false;
			string currentReturn = null;
			bool isInRemarks = false;
			string currentRemark = null;
			
			foreach (string line in lines)
			{
				var newline = line.Trim(); //Remove the whitespace.
				
				if (isInSummary)
				{
					currentSummary = System.Convert.ToString(currentSummary + (string.IsNullOrEmpty(newline) ? "" : newline + "\r\n")); //Add the old one.
					if (currentSummary.EndsWith(System.Convert.ToString("</summary>" + "\r\n")))
					{
						currentSummary = currentSummary.Replace(System.Convert.ToString("</summary>" + "\r\n"), "");
						_pSummary = currentSummary.Trim();
						isInSummary = false;
					}
					continue;
				}
				else if (isInAParam)
				{
					currentParam = System.Convert.ToString(currentParam + (string.IsNullOrEmpty(newline) ? "" : newline + "\r\n")); //Add the old one.
					if (currentParam.EndsWith(System.Convert.ToString("</param>" + "\r\n")))
					{
						currentParam = currentParam.Replace(System.Convert.ToString("</param>" + "\r\n"), "");
						currentParamDesc = currentParam.Trim();
						isInAParam = false;
						
						//Create the key
						Parameters.Add(new KeyValuePair<string, string>(currentParamName, currentParamDesc));
					}
					continue;
				}
				else if (isInReturn)
				{
					currentReturn = System.Convert.ToString(currentReturn + (string.IsNullOrEmpty(newline) ? "" : newline + "\r\n")); //Add the old one.
					if (currentReturn.EndsWith(System.Convert.ToString("</returns>" + "\r\n")))
					{
						currentReturn = currentReturn.Replace(System.Convert.ToString("</returns>" + "\r\n"), "");
						_pReturns = currentReturn.Trim();
						isInReturn = false;
					}
					continue;
				}
				else if (isInRemarks)
				{
					currentRemark = System.Convert.ToString(currentRemark + (string.IsNullOrEmpty(newline) ? "" : newline + "\r\n")); //Add the old one.
					if (currentRemark.EndsWith(System.Convert.ToString("</remarks>" + "\r\n")))
					{
						currentRemark = currentRemark.Replace(System.Convert.ToString("</remarks>" + "\r\n"), "");
						_pRemarks = currentRemark.Trim();
						isInRemarks = false;
					}
					continue;
				}
				
				if (newline.StartsWith("<summary>"))
				{
					newline = newline.Replace("<summary>", ""); 
					currentSummary = newline + "\r\n";
					
					if (newline.EndsWith("</summary>"))
					{
						newline = newline.Replace("</summary>", ""); 
						_pSummary = newline.Trim();
					}
					else
					{
						isInSummary = true;
					}
					continue;
				}
				else if (newline.StartsWith("<param name=" + '\u0022'))
				{
					newline = newline.Replace("<param name=" + '\u0022', ""); 
					currentParamName = newline.Substring(0, newline.IndexOf('\u0022'));
					newline = newline.Remove(0, newline.IndexOf(">") + 1); 
					
					currentParam = newline + "\r\n";
					if (newline.EndsWith("</param>"))
					{
						newline = newline.Replace("</param>", ""); 
						currentParamDesc = newline.Trim();
						
						//Create the key
						Parameters.Add(new KeyValuePair<string, string>(currentParamName, currentParamDesc));
					}
					else
					{
						isInAParam = true;
					}
				}
				else if (newline.StartsWith("<returns>"))
				{
					newline = newline.Replace("<returns>", ""); 
					currentReturn = newline + "\r\n";
					
					if (newline.EndsWith("</returns>"))
					{
						newline = newline.Replace("</rturns>", ""); 
						_pReturns = newline.Trim();
					}
					else
					{
						isInReturn = true;
					}
					continue;
				}
				else if (newline.StartsWith("<remarks>"))
				{
					newline = newline.Replace("<remarks>", ""); 
					currentRemark = newline + "\r\n";
					
					if (newline.EndsWith("</remarks>"))
					{
						newline = newline.Replace("</remarks>", ""); 
						_pRemarks = newline.Trim();
					}
					else
					{
						isInRemarks = true;
					}
					continue;
				}
			}
		}
	}
	
}
