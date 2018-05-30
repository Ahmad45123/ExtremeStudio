using System;
using System.IO;
using System.Text.RegularExpressions;
using ExtremeCore.Classes;
using ExtremeParser.Exceptions;

namespace ExtremeParser.Parsers
{
    public class Includes
    {

        private static void AddExtension(ref string pth)
        {
            if (Path.GetExtension(pth) == "")
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
                string text = Convert.ToString(match.Groups[1].Value);
                string fullPath = "";

                var type = text.Substring(0, 1);

                if (char.Parse(type) == (char) 34)
                {
                    //Remove the quotes.
                    try
                    {
                        text = text.Remove(text.IndexOf((char) 34), 1);
                        text = text.Remove(text.IndexOf((char) 34), 1);
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

                    foreach (var dir in Directory.GetDirectories(prjPath + "\\dependencies"))
                    {
                        string pth = Path.Combine(dir, text);
                        AddExtension(ref pth);
                        if (File.Exists(pth))
                        {
                            fullPath = pth;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var dir in Directory.GetDirectories(prjPath + "\\dependencies"))
                    {
                        string pth = Path.Combine(dir, text);
                        AddExtension(ref pth);
                        if (File.Exists(pth))
                        {
                            fullPath = pth;
                            break;
                        }
                    }
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
                            CodeParts part = new CodeParts
                            {

                                //Setup and add to list.
                                FilePath = fullPath
                            };
                            parts.AddInclude(part);

                            Parser prs = new Parser(part, File.ReadAllText(fullPath), fullPath, prjPath, true);
                            errors.ExceptionsList_Renamed.AddRange(prs.Errors.ExceptionsList_Renamed);
                        }
                        else
                        {
                            errors.ExceptionsList_Renamed.Add(
                                new IncludeNotFoundException(Path.GetFileNameWithoutExtension(fullPath)));
                        }
                    }
                    else
                    {
                        try
                        {
                            //Here if the include is REMOVED, There is no need to parse it all again cause we already know that we just need to remove the whole include.
                            parts.RemoveIncludeByHash(GeneralFunctions.GetFileHash(fullPath));
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }

                    //Exceptions.
                }
                catch (DirectoryNotFoundException)
                {
                    errors.ExceptionsList_Renamed.Add(new IncludeNotFoundException(Path.GetFileNameWithoutExtension(fullPath)));
                }
                catch (FileNotFoundException)
                {
                    errors.ExceptionsList_Renamed.Add(new IncludeNotFoundException(Path.GetFileNameWithoutExtension(fullPath)));
                }
            }
        }
    }
}