using System.Drawing;
using Cosmos.System.Graphics;
using System.Collections.Generic;

namespace ProgramManager.Graphics.WindowManager
{
    public class Window
    {
        public int x;
        public int y;
        public int w;
        public int h;
        public string title;
        public List<Control> controls = new List<Control>();

        public void AddControl(Control control)
        {
            controls.Add(control);
            control.parent = this;
        }

        public virtual void OnWindowCreated()
        {
            Screen.DrawFilledRectangle(Color.White, x, y, w, h);
            Screen.DrawFilledRectangle(Color.Blue, x, y, w, 10);
            Screen.DrawString(title, Screen.defaultFont, new Pen(Color.White), x, y);
        }

        public virtual void Update()
        {
            Screen.DrawFilledRectangle(Color.White, x, y, w, h);
            Screen.DrawFilledRectangle(Color.Blue, x, y, w, 10);
            Screen.DrawString(title, Screen.defaultFont, new Pen(Color.White), x, y);
        }
    }
}
