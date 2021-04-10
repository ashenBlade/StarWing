using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using StarWing.Framework.Primitives;
using Microsoft.VisualBasic.Devices;

namespace StarWing.Framework
{
    public class GameWindow : Form
    {
        public GameWindow()
        {
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            UseWaitCursor = false;
        }
    }
}