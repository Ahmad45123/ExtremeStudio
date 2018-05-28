using System;
using System.Collections.Generic;
using ExtremeParser.Exceptions;

namespace ExtremeParser.Parsers
{
    public class PawnDocParser
    {

        #region Public Properties

        public string Summary
        {
            get { return _pSummary; }
        }

        public List<KeyValuePair<string, string>> Parameters
        {
            get { return _pParams; }
        }

        public string Returns
        {
            get { return _pReturns; }
        }

        public string Remarks
        {
            get { return _pRemarks; }
        }

        #endregion

        private string _pSummary;
        private List<KeyValuePair<string, string>> _pParams = new List<KeyValuePair<string, string>>();
        private string _pReturns;
        private string _pRemarks;

        public PawnDocParser(string text)
        {
            //Prepare the text for parsing.
            string[] lines = text.Split('\r', '\n'); //Cut it into multiple lines.

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

            foreach (string tmpline in lines)
            {
                string line = tmpline;
                line = line.Trim(); //Remove the whitespace.

                if (isInSummary)
                {
                    currentSummary =
                        Convert.ToString(currentSummary +
                                                (string.IsNullOrEmpty(line) ? "" : line + "\r\n")); //Add the old one.
                    if (currentSummary.EndsWith(Convert.ToString("</summary>" + "\r\n")))
                    {
                        currentSummary = currentSummary.Replace(Convert.ToString("</summary>" + "\r\n"), "");
                        _pSummary = currentSummary.Trim();
                        isInSummary = false;
                    }

                    continue;
                }

                if (isInAParam)
                {
                    currentParam =
                        Convert.ToString(currentParam +
                                         (string.IsNullOrEmpty(line) ? "" : line + "\r\n")); //Add the old one.
                    if (currentParam.EndsWith(Convert.ToString("</param>" + "\r\n")))
                    {
                        currentParam = currentParam.Replace(Convert.ToString("</param>" + "\r\n"), "");
                        currentParamDesc = currentParam.Trim();
                        isInAParam = false;

                        //Create the key
                        Parameters.Add(new KeyValuePair<string, string>(currentParamName, currentParamDesc));
                    }

                    continue;
                }

                if (isInReturn)
                {
                    currentReturn =
                        Convert.ToString(currentReturn +
                                         (string.IsNullOrEmpty(line) ? "" : line + "\r\n")); //Add the old one.
                    if (currentReturn.EndsWith(Convert.ToString("</returns>" + "\r\n")))
                    {
                        currentReturn = currentReturn.Replace(Convert.ToString("</returns>" + "\r\n"), "");
                        _pReturns = currentReturn.Trim();
                        isInReturn = false;
                    }

                    continue;
                }

                if (isInRemarks)
                {
                    currentRemark =
                        Convert.ToString(currentRemark +
                                         (string.IsNullOrEmpty(line) ? "" : line + "\r\n")); //Add the old one.
                    if (currentRemark.EndsWith(Convert.ToString("</remarks>" + "\r\n")))
                    {
                        currentRemark = currentRemark.Replace(Convert.ToString("</remarks>" + "\r\n"), "");
                        _pRemarks = currentRemark.Trim();
                        isInRemarks = false;
                    }

                    continue;
                }

                if (line.StartsWith("<summary>"))
                {
                    line = line.Replace("<summary>", "");
                    currentSummary = line + "\r\n";

                    if (line.EndsWith("</summary>"))
                    {
                        line = line.Replace("</summary>", "");
                        _pSummary = line.Trim();
                    }
                    else
                    {
                        isInSummary = true;
                    }
                }
                else if (line.StartsWith("<param name=" + (char) 34))
                {
                    line = line.Replace("<param name=" + (char) 34, "");
                    currentParamName = line.Substring(0, line.IndexOf((char) 34));
                    line = line.Remove(0, line.IndexOf(">") + 1);

                    currentParam = line + "\r\n";
                    if (line.EndsWith("</param>"))
                    {
                        line = line.Replace("</param>", "");
                        currentParamDesc = line.Trim();

                        //Create the key
                        Parameters.Add(new KeyValuePair<string, string>(currentParamName, currentParamDesc));
                    }
                    else
                    {
                        isInAParam = true;
                    }
                }
                else if (line.StartsWith("<returns>"))
                {
                    line = line.Replace("<returns>", "");
                    currentReturn = line + "\r\n";

                    if (line.EndsWith("</returns>"))
                    {
                        line = line.Replace("</rturns>", "");
                        _pReturns = line.Trim();
                    }
                    else
                    {
                        isInReturn = true;
                    }
                }
                else if (line.StartsWith("<remarks>"))
                {
                    line = line.Replace("<remarks>", "");
                    currentRemark = line + "\r\n";

                    if (line.EndsWith("</remarks>"))
                    {
                        line = line.Replace("</remarks>", "");
                        _pRemarks = line.Trim();
                    }
                    else
                    {
                        isInRemarks = true;
                    }
                }
            }
        }
    }
}