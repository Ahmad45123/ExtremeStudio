using System;
using System.IO;
using System.Text.RegularExpressions;
using ExtremeStudio.Core.Modules;
using ExtremeStudio.Parser;
using ExtremeStudio.Parser.Exceptions;

namespace ExtremeStudio.Parser.Parsers
{
    public class Includes
    {

        private static void AddExtension(ref string pth)
        {
            if (Path.GetExtension(pth) == null)
            {
                if (File.Exists(pth + ".pwn"))
                {
                    pth += ".pwn";
                }
                else if (File.Exists(pth + ".inc"))
                {
                    pth += ".inc";
                }
            }
        }

        public static void Parse(string code, string filePath, string prjPath, CodeParts parts, ExceptionsList errors,
            bool add = true)
        {
            foreach (Match match in Regex.Matches(code, "\\#include[ \\t]+([^\\s]+)", RegexOptions.Multiline))
            {
                string text = match.Groups[1].Value;
                string fullPath = "";

                var type = text.Substring(0, 1);

                if (char.Parse(type) == '\u0022')
                {
                    //Remove the quotes.
                    try
                    {
                        text = text.Remove(text.IndexOf('\u0022'), 1);
                        text = text.Remove(text.IndexOf('\u0022'), 1);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    fullPath = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(filePath)), text);
                    AddExtension(ref fullPath);
                }
                else if (type == "<")
                {
                    //Remove the brackets.
                    try
                    {
                        text = text.Remove(text.IndexOf("<"), 1);
                        text = text.Remove(text.IndexOf(">"), 1);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    fullPath = prjPath + "\\pawno\\include\\" + text;
                    AddExtension(ref fullPath);
                }
                else
                {
                    fullPath = prjPath + "\\pawno\\include\\" + text;
                    AddExtension(ref fullPath);
                }
                try
                {

                    //Create a new codeparts object for the includes cause they are needed.
                    if (add)
                    {
                        //Check if was already parsed or not.
                        if (Parser.IsParsed(parts.RootInclude, fullPath))
                        {
                            continue;
                        }

                        //Else:
                        //Check if exists or not:
                        if (File.Exists(fullPath))
                        {
                            CodeParts part = new CodeParts();

                            //Setup and add to list.
                            part.FilePath = fullPath;
                            parts.AddInclude(part);

                            Parser prs = new Parser(ref part, File.ReadAllText(fullPath), fullPath, prjPath, true);
                            errors.EcsList.AddRange(prs.Errors.EcsList);
                        }
                        else
                        {
                            errors.EcsList.Add(new IncludeNotFoundException(Path.GetFileNameWithoutExtension(fullPath)));
                        }

                    }
                    else
                    {
                        try
                        {
                            //Here if the include is REMOVED, There is no need to parse it all again cause we already know that we just need to remove the whole include.
                            parts.RemoveIncludeByHash(System.Convert.ToString(FileHashGenerator.GetFileHash(fullPath)));
                        }
                        catch (Exception)
                        {
                        }
                    }

                    //Exceptions.
                }
                catch (DirectoryNotFoundException)
                {
                    errors.EcsList.Add(new IncludeNotFoundException(Path.GetFileNameWithoutExtension(fullPath)));
                }
                catch (FileNotFoundException)
                {
                    errors.EcsList.Add(new IncludeNotFoundException(Path.GetFileNameWithoutExtension(fullPath)));
                }
            }
        }
    }
}
