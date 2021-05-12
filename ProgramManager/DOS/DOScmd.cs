using ProgramManager.Graphics;
using Cosmos.System.Graphics;
using System.Drawing;
using System.Collections.Generic;
using ProgramManager.FileSystem;
using ProgramManager.Krnl.AppKernel;

namespace ProgramManager.DOS
{
    public static class DOScmd
    {
        public static void CheckCommand(string command)
        {
            if (command == "info")
            {
                HResConsole.WriteLine("pmdos v" + Kernel.version);
                HResConsole.WriteLine($"Available disk space {DiskManager.GetSpace(0)} Bytes");
                HResConsole.WriteLine($"Filesystem: {DiskManager.GetFileSystem(0)}");
            }
            else if(command.StartsWith("format"))
            {
                int id = int.Parse(command.Substring(7));

                DiskManager.Format(id);
            }
            else if(command.StartsWith("run "))
            {
                string file = command.Substring(4);
                CompilerService.RunApplication(file);
            }
            else if(command.StartsWith("touch "))
            {
                string file = command.Substring(6);
                Filesystem.CreateFile(file);
            }
            else if(command.StartsWith("write "))
            {
                string file = command.Substring(6);
                string content = HResConsole.ReadLine();

                Filesystem.WriteToFile(file, content);
            }
            else if (command == "video -lm")
            {
                List<Mode> modes = Screen.canvas.AvailableModes;
                HResConsole.WriteLine("Available modes: ");

                foreach(Mode mode in modes)
                {
                    HResConsole.WriteLine(mode.Columns + "x" + mode.Rows);
                }
            }
            else if(command == "video svga")
            {
                HResConsole.WriteLine("Experimental feature. Do you want to enable VMWare SVGAII? (Y/N)");
                if(System.Console.ReadKey(true).Key == System.ConsoleKey.Y)
                {
                    Screen.canvas = new SVGAIICanvas();
                    HResConsole.Clear();
                }
            }
            else if(command == "gtest")
            {
                Screen.DrawFilledRectangle(Color.White, 0, 0, Screen.Width - 1, Screen.Height - 1);
                System.Console.ReadKey(true);
                HResConsole.Clear();
            } 
            else if (command.StartsWith("video"))
            {
                string mode = command.Substring(6);

                int width = int.Parse(mode.Substring(0, mode.IndexOf("x")));
                int height = int.Parse(mode.Substring(mode.IndexOf('x') + 1));

                Screen.UpdateResolution(width, height);
            }
            #region Basic needed commands
            else if (command == "shutdown")
            {
                SystemManager.Shutdown();
            }
            else if(command == "reboot")
            {
                SystemManager.Reboot();
            }
            else if(command == "clear")
            {
                HResConsole.Clear();
            }
            else if(command == "help")
            {
                HResConsole.WriteLine("List of available commands: ");
                HResConsole.WriteLine("video - change your video mode");
                HResConsole.WriteLine("video -lm - list available video modes");
                HResConsole.WriteLine("gtest - screen resolution test");
                HResConsole.WriteLine("shutdown - shutdowns your computer");
                HResConsole.WriteLine("reboot - reboots your computer");
                HResConsole.WriteLine("help - prints this menu");
                HResConsole.WriteLine("info - displays info about your computer and the operating system.");
                HResConsole.WriteLine("");
                HResConsole.WriteLine("Enter /? after any command to see its description.");
            }
            else if(string.IsNullOrWhiteSpace(command))
            {

            }
            #endregion
            else
            {
                HResConsole.WriteLine($"\"{command}\" is not a executable file or a valid command name.");
            }
        }
    }
}
