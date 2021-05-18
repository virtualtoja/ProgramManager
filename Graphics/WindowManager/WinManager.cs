using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramManager.Graphics.WindowManager
{
    public static class WinManager
    {
        public static List<Window> windows = new List<Window>();

        public static void RegisterWindow(Window window)
        {
            windows.Add(window);
            window.OnWindowCreated();
        }

        public static void Update()
        {
            foreach(Window win in windows)
            {
                win.Update();
            }
        }
    }
}
