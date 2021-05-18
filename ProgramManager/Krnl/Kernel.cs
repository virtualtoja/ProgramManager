using System;
using ProgramManager.DOS;
using ProgramManager.Graphics;
using Sys = Cosmos.System;
using ProgramManager.FileSystem;
using ProgramManager.Graphics.WindowManager;

namespace ProgramManager
{
    public class Kernel : Sys.Kernel
    {
        public const string version = "1.0";

        protected override void BeforeRun()
        {
            Console.WriteLine("Initializing filesystem...");
            Screen.InitScreen();
            ErrorLog.WriteLineOK("Started graphical console");
            try
            {
                DiskManager.Initialize();
                ErrorLog.WriteLineOK("Initialized filesystem");
            }
            catch
            {
                ErrorLog.WriteLineError("Failed to initialize filesystem");
            }
            ErrorLog.WriteLineOK("Starting console");
            ErrorLog.WriteLineOK("Set resolution to " + $"{Screen.canvas.Mode.Columns}x{Screen.canvas.Mode.Rows}");
            ErrorLog.WriteLineInfo("Welcome to pmdos " + version);
        }

        protected override void Run()
        {
            try
            {
                HResConsole.Write(DOScmd.path + ">");
                DOScmd.CheckCommand(HResConsole.ReadLine());
                WinManager.Update();
            }
            catch(Exception e)
            {
                SystemManager.Crash(e.Message);
            }
        }
    }
}
