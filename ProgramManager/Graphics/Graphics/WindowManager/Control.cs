using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramManager.Graphics.WindowManager
{
    public class Control
    {
        public int x;
        public int y;
        public int w;
        public int h;
        public string Text;
        public bool AutoSize;
        public Window parent;

        public virtual void Update()
        {

        }
    }
}
