using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtremeStudio.Parser.Parsers;
using ExtremeStudio.Parser.Types;
using ExtremeStudio.Core.Modules;

namespace ExtremeStudio.Parser
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
            CodeParts ret = new CodeParts();
            ret.FileName = FileName;
            ret.FilePath = FilePath;
            ret.FileHash = FileHash;
            ret.Defines = Defines.ToList();
            ret.Macros = Macros.ToList();
            ret.Functions = Functions.ToList();
            ret.Stocks = Stocks.ToList();
            ret.Publics = Publics.ToList();
            ret.Natives = Natives.ToList();
            ret.Enums = Enums.ToList();
            ret.PublicVariables = PublicVariables.ToList();
            ret.PawnDocs = PawnDocs.ToList();

            return ret;
        }

        #region Includes Codes
        //Properties.
        public CodeParts ParentInclude { get; set; }
        public CodeParts RootInclude { get; set; }
        public ICollection<CodeParts> Includes { get; set; }

        public CodeParts()
        {
            this.Includes = new LinkedList<CodeParts>();
            RootInclude = this;
        }

        public void AddInclude(CodeParts child)
        {
            //Set its info.
            child.ParentInclude = this;
            child.RootInclude = this.RootInclude;
            child.FileName = Path.GetFileNameWithoutExtension(child.FilePath);
            child.FileHash = System.Convert.ToString(FileHashGenerator.GetFileHash(child.FilePath));

            this.Includes.Add(child);
        }

        public IEnumerable<CodeParts> FlattenIncludes()
        {
            return new[] { this }.Union(Includes.SelectMany(x => x.FlattenIncludes()));
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
