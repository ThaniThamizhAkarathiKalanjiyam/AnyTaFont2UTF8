namespace AnyTaFont2TACE16
{
    partial class uscntrlAnyTaFont2TACE16
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboTamilFontType = new System.Windows.Forms.ComboBox();
            this.btnToUTF8 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboTamilFontType
            // 
            this.cboTamilFontType.BackColor = System.Drawing.Color.White;
            this.cboTamilFontType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTamilFontType.Enabled = false;
            this.cboTamilFontType.FormattingEnabled = true;
            this.cboTamilFontType.Items.AddRange(new object[] {
            "UTF8"});
            this.cboTamilFontType.Location = new System.Drawing.Point(271, 3);
            this.cboTamilFontType.Name = "cboTamilFontType";
            this.cboTamilFontType.Size = new System.Drawing.Size(137, 21);
            this.cboTamilFontType.TabIndex = 7;
            // 
            // btnToUTF8
            // 
            this.btnToUTF8.Location = new System.Drawing.Point(333, 127);
            this.btnToUTF8.Name = "btnToUTF8";
            this.btnToUTF8.Size = new System.Drawing.Size(75, 23);
            this.btnToUTF8.TabIndex = 6;
            this.btnToUTF8.Text = "To TACE16";
            this.btnToUTF8.UseVisualStyleBackColor = true;
            this.btnToUTF8.Click += new System.EventHandler(this.btnToUTF8_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("TAC-Barathi", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(14, 151);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(394, 107);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(14, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(394, 94);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "அம்மா";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Encrypted text content here";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(11, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Plaint TACE16 converted tamil text (Click me for more help)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Powered by Isaiyini Community | isaiyini@yahoogroups.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(305, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "https://thanithamizhakarathikalanjiyam.github.io/anytafont2utf8";
            // 
            // uscntrlAnyTaFont2TACE16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTamilFontType);
            this.Controls.Add(this.btnToUTF8);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Name = "uscntrlAnyTaFont2TACE16";
            this.Size = new System.Drawing.Size(419, 315);
            this.Load += new System.EventHandler(this.uscntrlAnyTaFont2TACE16_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTamilFontType;
        private System.Windows.Forms.Button btnToUTF8;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
