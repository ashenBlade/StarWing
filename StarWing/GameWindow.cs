using System;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using StarWing.Framework.Input;
using ScrollEventArgs = StarWing.Framework.Input.ScrollEventArgs;

namespace StarWing.Framework
{
    public class GameWindow : Form,  IKeyboardManipulator, IMouseManipulator
    {
        public GameWindow()
        {
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            UseWaitCursor = false;
        }

        public Size WindowSize
        {
            get => Size;
            set => Size = value;
        }

        private bool _fullScreen;

        public bool FullScreen
        {
            get => _fullScreen;
            set
            {
                if (value == _fullScreen)
                    return;
                if (value)
                {
                    EnterFullScreen();
                }
                else
                {
                    ExitFullScreen();
                }
            } }

        private void EnterFullScreen()
        {
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            WindowState = FormWindowState.Maximized;
        }

        private void ExitFullScreen()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            TopMost = false;
            WindowState = FormWindowState.Normal;
        }

        public Point Position =>
            Location;

        public string Title
        {
            get => Text;
            set => Text = value;
        }

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