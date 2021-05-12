using Cosmos.System;
using ProgramManager.DOS;
using System.Drawing;

namespace ProgramManager
{
    public static class SystemManager
    {
        public static void Shutdown()
        {
            Power.Shutdown();
        }

        public static void Reboot()
        {
            Power.Reboot();
        }

        public static void Crash(string message)
        {
            HResConsole.BackgroundColor = Color.Blue;
            HResConsole.Clear();
            HResConsole.WriteLine("An unexpected kernel excepion occured. Crash information are located at 0:/crashdump.txt. Crash info:");
            HResConsole.WriteLine("");
            HResConsole.WriteLine(message);
            HResConsole.WriteLine("");
            HResConsole.WriteLine("Press any key to reboot.");
            System.Console.ReadKey(true);
            Power.Reboot();
        } 

    }
}
