using ProgramManager.Graphics;
using Cosmos.System.Graphics;
using System.Drawing;

namespace ProgramManager.DOS
{
    public static class HResConsole
    {
        public static int posY = 0;
        public static int posX = 0;
        public static int wordOffset = 0;

        public static Color BackgroundColor = Color.Black;
        public static Color ForegroundColor = Color.White;

        public static void WriteLine(object obj)
        {
            if (posY >= Screen.Height)
            {
                Clear();
            }

            for (int i = 0; i < obj.ToString().Length; i++)
            {
                Write(obj.ToString().Substring(i, 1));
            }
            posY += Screen.defaultFont.Height + 2;
            posX = 0;
        }

        public static void Write(string str)
        {
            if (posX >= Screen.Width)
            {
                posY += Screen.defaultFont.Height + 2;
                posX = 0;
            }

            Screen.DrawString(str, Screen.defaultFont, new Pen(ForegroundColor), posX, posY);
            posX += Screen.defaultFont.Width * str.Length;
            posX += wordOffset;
        }

        public static string ReadLine()
        {
            string text = "";
            bool entered = false;
            while (!entered)
            {
                if (posY >= Screen.Height)
                {
                    Clear();
                }

                System.ConsoleKeyInfo e = System.Console.ReadKey(true);

                if (e.Key == System.ConsoleKey.Enter)
                {
                    entered = true;
                }
                else if (e.Key == System.ConsoleKey.Backspace)
                {
                    try
                    {
                        text = text.Substring(0, text.Length - 1);
                        Screen.DrawFilledRectangle(BackgroundColor, posX - Screen.defaultFont.Width, posY, Screen.defaultFont.Width, Screen.defaultFont.Height);
                        posX -= Screen.defaultFont.Width;
                    }
                    catch
                    {

                    }
                }
                else
                {
                    text += e.KeyChar.ToString();
                    Write(e.KeyChar.ToString());
                }
            }
            posY += Screen.defaultFont.Height + 2;
            posX = 0;
            return text;
        }

        public static void Clear()
        {
            posX = 0;
            posY = 0;

            Screen.Clear(BackgroundColor);
        }

    }
}
