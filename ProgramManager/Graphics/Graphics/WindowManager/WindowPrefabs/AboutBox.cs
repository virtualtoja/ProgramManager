using ProgramManager.Graphics.WindowManager;
using Cosmos.System.Graphics;
using System.Drawing;
using ProgramManager.Graphics.Controls;

namespace ProgramManager.Graphics.WindowPrefabs
{
    public class AboutBox : Window
    {
        public string text;

        public override void OnWindowCreated()
        {
            base.OnWindowCreated();
            AddControl(new Button { x = x + 10, y = y + 45, w = w - 20, h = 30, Text = "OK" });
        }

        public override void Update()
        {
            base.Update();
            Screen.DrawString(text, Screen.defaultFont, new Pen(Color.Black), x + 10, y + 30);
        }
    }
}
