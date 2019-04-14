using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CaretPosition;

namespace Tace16TamilKeyboard
{
    public partial class IsaiyiniKeyBoard : Form
    {
       
        public IsaiyiniKeyBoard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLanSelectToggle();
            
            int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            this.Location = new Point(x, y);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void hIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnLanSelect_Click(object sender, EventArgs e)
        {
            btnLanSelectToggle();
        }
        frmTooltip obj = new frmTooltip();

        private void btnLanSelectToggle()
        {
            if (btnLanSelect.Text == "த")
            {
                btnLanSelect.Text = "A";
                obj.Visible = false;
            }
            else
            {
                btnLanSelect.Text = "த";                
                obj.Show();
            }
        }

        private void btnSettings_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && contextMenuSettings.Visible == false)
            {
                contextMenuSettings.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }
        Point startPosition = new Point(); 
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            // If Left Button was pressed
            if (e.Button == MouseButtons.Left)
            {
                // then move the Tooltip
                this.Left += e.Location.X - startPosition.X;
                this.Top += e.Location.Y - startPosition.Y;
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            startPosition = e.Location;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            // Set the Mouse Cursor
            this.Cursor = Cursors.SizeAll;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            // Set the Mouse Cursor
            this.Cursor = Cursors.Arrow;
        }
    }
}
