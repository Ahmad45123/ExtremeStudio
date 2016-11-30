using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtremeParser;
using ExtremeStudio.Core.Modules;
using ExtremeStudio.Parser.Exceptions;
using ExtremeStudio.Parser.Parsers;

namespace ExtremeStudio.Parser
{
    public class Parser
    {
        public ExceptionsList Errors { get; set; } = new ExceptionsList();

        public Parser(ref CodeParts codeParts, string code, string filePath, string projectPath, bool add, bool isIfDefine = false)
        {
            //Make sure then code is not nothing.
            if (code == null)
            {
                return;
            }

            //Get the name
            string name = Path.GetFileNameWithoutExtension(filePath);

            //Debug.
            if (isIfDefine == false)
            {
                Debug.WriteLine("Started Parser on the file: \'" + name + "\' Status: " + add.ToString());
            }

            //Remove singline comments.
            Cleaner.Parse(ref code, true, false, false, false);

            //Parse for pawndocs.
            PawnDoc.Parse(code, name, codeParts, add);

            //Remove multiline comments.
            Cleaner.Parse(ref code, false, true, false, false);

            //Parse for Enums.
            Enums.Parse(code, name, codeParts, add);

            //Now remove braces.
            Cleaner.Parse(ref code, false, false, true, false);

            if (add == false)
            {
                //Replace defines and macros.
                DefReplacer.Parse(ref code, name, codeParts, add);
            }

            //Parse for includes. (BEFORE REMOVING STRINGS)
            Includes.Parse(code, filePath, projectPath, codeParts, Errors, add);

            //Remove strings
            Cleaner.Parse(ref code, false, false, false, true);

            //Parse defines and macros.
            Defines.Parse(code, name, codeParts, add);

            if (add == true)
            {
                //Replace defines and macros.
                DefReplacer.Parse(ref code, name, codeParts, add);
            }

            //Now parse funcs.
            Functions.Parse(code, name, codeParts, add);

            //Parse global vars.
            GlobalVariables.Parse(code, name, codeParts, add);

            //Parse if defines.
            IfDefines.Parse(code, filePath, projectPath, ref codeParts, add);
        }

        public static dynamic IsParsed(CodeParts parts, string filePath)
        {
            return (from part in parts.FlattenIncludes() where part.FileHash != null select part).Any(part => part.FileHash == FileHashGenerator.GetFileHash(filePath));
        }
    }
}
