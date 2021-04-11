using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using StarWing.Framework.Primitives;
using Microsoft.VisualBasic.Devices;

namespace StarWing.Framework
{
    internal class GameWindow : Form
    {
        public GameWindow(Game game)
        {
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            UseWaitCursor = false;
            Shown += (sender, args) => game.Start();
        }
    }
}