using Cosmos.System.Graphics;
using System;
using System.Drawing;

namespace ProgramManager.Graphics
{
    public class Screen
    {
        public static Canvas canvas;

        public static int Width;
        public static int Height;

        public static Font defaultFont;

        public static void InitScreen()
        {
            canvas = FullScreenCanvas.GetFullScreenCanvas();

            //UpdateResolution(canvas.AvailableModes[canvas.AvailableModes.Count - 1].Columns, canvas.AvailableModes[canvas.AvailableModes.Count - 1].Rows);

            Width = canvas.Mode.Columns;
            Height = canvas.Mode.Rows;

            PCScreenFont f = new PCScreenFont();
            defaultFont = new Font(f.CharWidth, f.CharHeight, f.CreateVGAFont());
        }

        public static void DrawString(string str, Font aFont, Pen pen, int x, int y)
        {
            foreach (char c in str)
            {
                DrawChar(c, aFont, pen, x, y); ;
                x += aFont.Width;
            }
        }

        public static void DrawChar(char c, Font aFont, Pen pen, int x, int y)
        {
            int p = aFont.Height * (byte)c;

            for (int cy = 0; cy < aFont.Height; cy++)
            {
                for (byte cx = 0; cx < aFont.Width; cx++)
                {
                    if (aFont.ConvertByteToBitAddres(aFont.Data[p + cy], cx + 1))
                    {
                        canvas.DrawPoint(pen, (ushort)((x) + (aFont.Width - cx)), (ushort)((y) + cy));
                    }
                }
            }
        }

        public static void DrawFilledRectangle(Color backgroundColor, int posX, int posY, int width, int height)
        {
            canvas.DrawFilledRectangle(new Pen(backgroundColor), posX, posY, width, height);
        }

        public static void UpdateResolution(int width, int height)
        {
            canvas.Mode = new Mode(width, height, ColorDepth.ColorDepth32);
            Width = width;
            Height = height;
        }

        public static void Clear(Color backgroundColor)
        {
            canvas.Clear(backgroundColor);
        }
    }
}
