using ProgramManager.Graphics.WindowManager;
using Cosmos.System.Graphics;
using System.Drawing;

namespace ProgramManager.Graphics.Controls
{
    public class Button : Control
    {
        public override void Update()
        {
            int lx = x + parent.x;
            int ly = y + parent.y;
            Screen.DrawFilledRectangle(Color.Gray, lx, ly, w, h);
            int sx = (x / 2) - (Screen.defaultFont.Width / 2); 
            int sy = (y / 2) - ((Screen.defaultFont.Height * Text.Length) / 2); 
            Screen.DrawString(Text, Screen.defaultFont, new Pen(Color.Black), sx, sy);
        }
    }
}
