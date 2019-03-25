using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;



using TamilWords;

namespace AnyTaFont2TACE16
{
    public partial class uscntrlAnyTaFont2TACE16 : UserControl
    {
        public uscntrlAnyTaFont2TACE16()
        {
            InitializeComponent();


        }
        TamilWordNLP objTamilWordNLP = new TamilWordNLP();
        private void loadFontMapDocuments()
        {
            string[] files = objTamilWordNLP.getAvailableFontConversions();

            foreach (string file in files)
            {
                string font_name = Path.GetFileName(file);
                cboTamilFontType.Items.Add(font_name);
            }

            cboTamilFontType.SelectedIndex = 0;
        }

        private void btnToUTF8_Click(object sender, EventArgs e)
        {
            string fileName = cboTamilFontType.Text.ToString();

            if (fileName.Length == 0)
            {
                richTextBox2.Text = objTamilWordNLP.EncodeToUTF8AutoSingle(richTextBox1.Text);
                //richTextBox2.Text = objTamilWordNLP.EncodeToUTF8AutoMultiple(richTextBox1.Text);
            }
            else
            {
                richTextBox2.Text = objTamilWordNLP.EncodeToUTF8(fileName, richTextBox1.Text);
            }
        }



        private void uscntrlAnyTaFont2TACE16_Load(object sender, EventArgs e)
        {
            loadFontMapDocuments();
        }

        private void btnFontType_Click(object sender, EventArgs e)
        {
          cboTamilFontType.Text =  objTamilWordNLP.DetectFontType(richTextBox1.Text);
          //btnFontType.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Install TACE16 Tamil Font
            AboutBox objAboutBox = new AboutBox();
            objAboutBox.ShowDialog();
        }
    }
}
