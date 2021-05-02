using System;
using System.Windows.Forms;

namespace StarWing
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void btn_Start_MouseHover(object sender, EventArgs e)
        {
            btn_Start.Image = Resources.Pictures.Start_BTN_active;
        }
        

        private void Exit_BTN_MouseHover(object sender, EventArgs e)
        {
            Exit_BTN.Image = Resources.Pictures.Exit_BTN_active;
        }

        private void btn_Start_MouseLeave(object sender, EventArgs e)
        {
            btn_Start.Image = Resources.Pictures.Start_BTN_normal;
        }

        private void Exit_BTN_MouseLeave(object sender, EventArgs e)
        {
            Exit_BTN.Image = Resources.Pictures.Exit_BTN_normal;
        }

        
    }
}