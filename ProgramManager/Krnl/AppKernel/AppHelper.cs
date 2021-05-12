using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramManager.Krnl.AppKernel
{
    public static class AppHelper
    {
        public enum AppType { Console, Window, KernelMode, NULL }

        public static void RunSystemCodes(string[] code)
        {
            List<string> librarys = new List<string>();
            string libDefinition = "null";

            AppType type = AppType.NULL;
            if (code[0].ToLower().StartsWith(":kernel"))
                type = AppType.KernelMode;
            else if (code[0].ToLower().StartsWith(":console"))
                type = AppType.Console;
            else if(code[0].ToLower().StartsWith(":window"))
                type = AppType.Window;
            

            foreach(string line in code)
            {
                if(line.StartsWith(":"))
                {
                    continue;
                }
                if (line.StartsWith("#"))
                {
                    if (line.StartsWith("#include <"))
                    {
                        librarys.Add(line.Substring(line.IndexOf("<") + 1, line.IndexOf(">")));
                    }
                    else if (line.StartsWith("#define "))
                    {
                        libDefinition = line.Substring(line.IndexOf(" ") + 1);
                    }
                }
                else if (type == AppType.Console && librarys.Contains("system") && line.StartsWith("writeline("))
                {
                    string text = line.Substring(11, line.IndexOf(");"));
                    DOS.HResConsole.WriteLine(text);
                }
            }
        }
    }
}
