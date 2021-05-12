using System.Drawing;

namespace ProgramManager.DOS
{
    public class ErrorLog
    {
        public static void WriteLineError(string message)
        {
            HResConsole.Write("[");
            HResConsole.ForegroundColor = Color.Red;
            HResConsole.Write("ERROR");
            HResConsole.ForegroundColor = Color.White;
            HResConsole.WriteLine("] " + message);
        }

        public static void WriteLineOK(string message)
        {
            HResConsole.Write("[");
            HResConsole.ForegroundColor = Color.Green;
            HResConsole.Write("OK");
            HResConsole.ForegroundColor = Color.White;
            HResConsole.WriteLine("] " + message);
        }

        public static void WriteLineInfo(string message)
        {
            HResConsole.Write("[");
            HResConsole.ForegroundColor = Color.Blue;
            HResConsole.Write("INFO");
            HResConsole.ForegroundColor = Color.White;
            HResConsole.WriteLine("] " + message);
        }
    }
}
