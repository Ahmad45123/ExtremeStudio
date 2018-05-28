using System;
using System.Collections.Generic;
using AutocompleteMenuNS;
using ExtremeParser.Global;
using ExtremeParser.Types;
using Resources;

namespace ExtremeStudio.DockPanelForms.MainFormDocks.EditorDock.AutoComplete
{
    public class AutoCompleteItemEx : AutocompleteItem
    {

        private FunctionParameters _pFuncPars;

        public FunctionParameters Parameters
        {
            get { return _pFuncPars; }
        }

        private AutoCompeleteTypes _pType;

        public AutoCompeleteTypes Type
        {
            get { return _pType; }
        }

        public enum AutoCompeleteTypes
        {
            TypeFunction, //It equals ZERO which means that it will be the functions icon in the image index.
            TypeDefine //It equals ONE which means that it will be the define icon in the image index.
        }

        public AutoCompleteItemEx(AutoCompeleteTypes type, string funcName, string toolTip)
        {
            //First of all set the the main stuff like text and icon.
            Text = funcName;
            ImageIndex = (int)type;

            //Setup the tooltip.
            ToolTipTitle = translations.AutoCompleteItemEx_New_PawnDocHelp;
            ToolTipText = toolTip;

            //Save the type.
            _pType = type;
        }

        public string AutoTab(string str)
        {
            string returnValue = "";
            if (ReferenceEquals(str, null))
            {
                return null;
            }

            returnValue = Convert.ToString("\t");
            returnValue += str.Replace("\r\n", Convert.ToString("\r\n" + "\t"));
            return returnValue;
        }

        public AutoCompleteItemEx(AutoCompeleteTypes type, FunctionsStruct func)
        {
            //First of all set the the main stuff like text and icon.
            Text = func.FuncName;
            ImageIndex = (int)type;

            //Setup the tooltip.
            ToolTipTitle = translations.AutoCompleteItemEx_New_PawnDocHelp;

            //If there is pawnDoc, use it.
            if (func.FuncPawnDoc != null)
            {
                string allText = "";

                //Do the remarks
                allText += Convert.ToString(translations.AutoCompleteItemEx_New_Remarks + "\r\n" +
                                                   AutoTab(Convert.ToString(func.FuncPawnDoc.Remarks)) + "\r\n" +
                                                   "\r\n");

                //Do the Parameters. (HARDEST ONE)
                allText += Convert.ToString(translations.AutoCompleteItemEx_New_Parameters + "\r\n");

                foreach (KeyValuePair<string, string> itm in func.FuncPawnDoc.Parameters)
                {
                    string par = Convert.ToString(itm.Key);
                    string desc = Convert.ToString(itm.Value);

                    string parType =
                        Convert.ToString(
                            func.FuncParameters.GetParameterType(par, FunctionParameters.ReturnType.AsString));

                    allText += Convert.ToString("\t" + "(" + parType + ") " + par + ": " + desc + "\r\n");
                }

                allText += "\r\n";

                //Do the returns.
                allText += Convert.ToString(translations.AutoCompleteItemEx_New_Returns + "\r\n" +
                                                   AutoTab(Convert.ToString(func.FuncPawnDoc.Returns)) + "\r\n" +
                                                   "\r\n");

                //Then simply set it.
                ToolTipText = allText;

                //Save the stuff.
                _pType = type;
                _pFuncPars = func.FuncParameters;
            }
            else
            {
                //there is no PawnDoc.. Setup our own.
                string allText =
                    Convert.ToString(translations.AutoCompleteItemEx_New_FunctionName + func.FuncName + "\r\n");
                allText += Convert.ToString(translations.AutoCompleteItemEx_New_Parameters +
                                                   func.FuncParameters.ParamsText + "\r\n");
                allText += Convert.ToString(translations.AutoCompleteItemEx_New_ReturnTag + func.ReturnTag +
                                                   "\r\n");

                ToolTipText = allText;

                //Save the stuff.
                _pType = type;
                _pFuncPars = func.FuncParameters;
            }
        }
    }
}