using System;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using StarWing.Framework.Primitives;

namespace StarWing.Framework
{
    internal class Window : Form, IGameWindow
    {
        public Window()
        {
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            UseWaitCursor = false;
        }


        public Point Position =>
            this.Location;

        public string Title =>
            Text;
    }
}