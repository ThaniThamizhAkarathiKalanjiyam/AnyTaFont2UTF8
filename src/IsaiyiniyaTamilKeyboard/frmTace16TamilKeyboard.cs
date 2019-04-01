using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        private void btnLanSelectToggle()
        {
            if (btnLanSelect.Text == "த")
            {
                btnLanSelect.Text = "A";
            }
            else
            {
                btnLanSelect.Text = "த";
            }
        }
    }
}
