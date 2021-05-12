using System;
using ProgramManager.FileSystem;

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
            string[] lines = code.Split(";");
            AppHelper.RunSystemCodes(lines);
        }

        public static void RunApplication(string path)
        {
            string code = Decompile(path);
            RunDecompiled(code);
        }

        public static void Compile(string code)
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

            RunDecompiled(result);
        }
    }
}
