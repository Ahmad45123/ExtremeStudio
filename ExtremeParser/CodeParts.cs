using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExtremeCore.Classes;
using ExtremeParser.Parsers;
using ExtremeParser.Types;

namespace ExtremeParser
{
    public class CodeParts
    {
        public string FileName;
        public string FilePath;
        public string FileHash;

        //The Object Itself:
        public List<DefinesStruct> Defines = new List<DefinesStruct>();
        public List<DefinesStruct> Macros = new List<DefinesStruct>();
        public List<FunctionsStruct> Functions = new List<FunctionsStruct>();
        public List<FunctionsStruct> Stocks = new List<FunctionsStruct>();
        public List<FunctionsStruct> Publics = new List<FunctionsStruct>();
        public List<FunctionsStruct> Natives = new List<FunctionsStruct>();
        public List<EnumsStruct> Enums = new List<EnumsStruct>();
        public List<VarStruct> PublicVariables = new List<VarStruct>();
        public List<PawnDocParser> PawnDocs = new List<PawnDocParser>();

        public CodeParts Clone()
        {
            CodeParts ret = new CodeParts
            {
                FileName = FileName,
                FilePath = FilePath,
                FileHash = FileHash,
                Defines = Defines.ToList(),
                Macros = Macros.ToList(),
                Functions = Functions.ToList(),
                Stocks = Stocks.ToList(),
                Publics = Publics.ToList(),
                Natives = Natives.ToList(),
                Enums = Enums.ToList(),
                PublicVariables = PublicVariables.ToList(),
                PawnDocs = PawnDocs.ToList()
            };

            return ret;
        }

        #region Includes Codes

        //Properties.
        public CodeParts ParentInclude { get; set; }
        public CodeParts RootInclude { get; set; }
        public ICollection<CodeParts> Includes { get; set; }

        public CodeParts()
        {
            Includes = new LinkedList<CodeParts>();
            RootInclude = this;
        }

        public void AddInclude(CodeParts child)
        {
            //Set its info.
            child.ParentInclude = this;
            child.RootInclude = RootInclude;
            child.FileName = Path.GetFileNameWithoutExtension(child.FilePath);
            child.FileHash = Convert.ToString(GeneralFunctions.GetFileHash(child.FilePath));

            Includes.Add(child);
        }

        public IEnumerable<CodeParts> FlattenIncludes()
        {
            return new[] {this}.Union(Includes.SelectMany(x => x.FlattenIncludes()));
        }

        public void RemoveIncludeByHash(string incHash)
        {
            foreach (CodeParts part in FlattenIncludes())
            {
                if (part.FileHash == incHash)
                {
                    Includes.Remove(part);
                    break;
                }
            }
        }

        #endregion
    }
}