using System;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using StarWing.Framework.Input;
using StarWing.Framework.Primitives;
using ScrollEventArgs = StarWing.Framework.Input.ScrollEventArgs;

namespace StarWing.Framework
{
    internal class Window : Form, IGameWindow, IKeyboardManipulator, IMouseManipulator
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

        event EventHandler<MouseEventArgs> IPressableManipulator<MouseEventArgs>.KeyDown
        {
            add => MouseDown += new MouseEventHandler(value);
            remove => MouseDown -= new MouseEventHandler(value);
        }

        event EventHandler<KeyEventArgs> IPressableManipulator<KeyEventArgs>.KeyUp
        {
            add => KeyUp += new KeyEventHandler(value);
            remove => KeyUp -= new KeyEventHandler(value);
        }

        event EventHandler<KeyEventArgs> IPressableManipulator<KeyEventArgs>.KeyDown
        {
            add => KeyDown += new KeyEventHandler(value);
            remove => KeyDown -= new KeyEventHandler(value);
        }

        event EventHandler<MouseEventArgs> IPressableManipulator<MouseEventArgs>.KeyUp
        {
            add => MouseUp += new MouseEventHandler(value);
            remove => MouseDown -= new MouseEventHandler(value);
        }

        public new event EventHandler<MouseEventArgs> Move
        {
            add => MouseMove += new MouseEventHandler(value);
            remove => MouseMove -= new MouseEventHandler(value);
        }

        public new event EventHandler<ScrollEventArgs> Scroll
        {
            add => MouseWheel += value.ToMouseEventHandler();
            remove => MouseWheel -= value.ToMouseEventHandler();
        }
    }
}