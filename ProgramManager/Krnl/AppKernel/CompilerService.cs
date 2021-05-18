using System;
using ProgramManager.FileSystem;
using System.Collections.Generic;

namespace ProgramManager.Krnl.AppKernel
{
    public static class CompilerService
    {
        public static string Decompile(string filename)
        {
            string text = Filesystem.ReadFile(filename);

            string result = "";
            for (int i = 0; i < text.Length / 2; i++)
            {
                try
                {
                    string block = text.Substring(i * 2, 2);
                    char character = char.Parse(block.Substring(0, 1));
                    int add = int.Parse(block.Substring(1, 1));
                    char final = (char)(character - add);
                    result += final.ToString();
                }
                catch
                {
                    return "";
                }
            }

            return result;
        }

        public static void RunDecompiled(string code)
        { 
            string[] txt = code.Split(';');
            string lb = "";
            string[] libs = new string[0];

            string type = "null";
            if (txt[0].ToLower().StartsWith(":kernel"))
                type = "kernel";
            else if (txt[0].ToLower().StartsWith(":console"))
                type = "console";
            else if (txt[0].ToLower().StartsWith(":window"))
                type = "window";

            string libDefinition = "";

            for (int i = 0; i < txt.Length; i++)
            {
                string line = txt[i];

                if (line.StartsWith(":"))
                {
                    continue;
                }
                if (line.StartsWith("#"))
                {
                    if (line.StartsWith("#include "))
                    {
                        string lib = line.Substring(8);
                        lb += lib + ",";
                        libs = lb.Split(',');
                    }
                    else if (line.StartsWith("#define "))
                    {
                        //libDefinition = line.Substring(line.IndexOf(" ") + 1);
                    }
                }
                else if (type == "console" && Contains(libs, "system") && line.StartsWith("writeline("))
                {
                    string text = line.Substring(11, line.IndexOf(");"));
                    DOS.HResConsole.WriteLine(text);
                }
            }
        }

        static bool Contains(string[] vs, string key)
        {
            for (int i = 0; i < vs.Length; i++)
            {
                string v = vs[i];

                if (v == key)
                {
                    return true;
                }
            }
            return false;
        }

        public static void RunApplication(string path)
        {
            string code = Decompile(path);
            RunDecompiled(code);
        }

        public static string Compile(string code)
        {
            string text = code;
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                char newch = ' ';
                int add = new Random().Next(1, 5);
                char ch = char.Parse(text.Substring(i, 1));
                newch = (char)(ch + add);
                result += newch.ToString() + add.ToString();
            }

            return result;
        }
    }
}
