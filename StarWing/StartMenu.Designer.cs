using System.ComponentModel;

namespace StarWing
{
    partial class StartMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Exit_BTN = new System.Windows.Forms.PictureBox();
            this.btn_Start = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.Exit_BTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.btn_Start)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.Exit_BTN);
            this.panel1.Controls.Add(this.btn_Start);
            this.panel1.Location = new System.Drawing.Point(176, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 395);
            this.panel1.TabIndex = 0;
            // 
            // Exit_BTN
            // 
            this.Exit_BTN.BackgroundImage = global::StarWing.Resources.Pictures.Exit_BTN;
            this.Exit_BTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Exit_BTN.Location = new System.Drawing.Point(41, 220);
            this.Exit_BTN.Name = "Exit_BTN";
            this.Exit_BTN.Size = new System.Drawing.Size(336, 111);
            this.Exit_BTN.TabIndex = 1;
            this.Exit_BTN.TabStop = false;
            this.Exit_BTN.MouseLeave += new System.EventHandler(this.Exit_BTN_MouseLeave);
            this.Exit_BTN.MouseHover += new System.EventHandler(this.Exit_BTN_MouseHover);
            // 
            // btn_Start
            // 
            this.btn_Start.BackgroundImage = global::StarWing.Resources.Pictures.Start_BTN;
            this.btn_Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Start.Location = new System.Drawing.Point(41, 70);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(336, 111);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.TabStop = false;
            this.btn_Start.MouseLeave += new System.EventHandler(this.btn_Start_MouseLeave);
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StarWing.Resources.Pictures._201324101801319034;
            this.ClientSize = new System.Drawing.Size(804, 708);
            this.Controls.Add(this.panel1);
            this.Name = "StartMenu";
            this.Text = "StartMenu";
            this.MouseHover += new System.EventHandler(this.btn_Start_MouseHover);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.Exit_BTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.btn_Start)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox Exit_BTN;

        private System.Windows.Forms.PictureBox btn_Start;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.PictureBox pictureBox2;

        private System.Windows.Forms.PictureBox pictureBox1;

        #endregion
    }
}