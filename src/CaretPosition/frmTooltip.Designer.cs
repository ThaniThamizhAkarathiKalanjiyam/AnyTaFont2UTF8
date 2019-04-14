namespace CaretPosition
{
    partial class frmTooltip
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblCaretX = new System.Windows.Forms.Label();
            this.lblCaretY = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lstBoxSuggestedWords = new System.Windows.Forms.ListBox();
            this.txtCaretY = new System.Windows.Forms.TextBox();
            this.lblCurrentApp = new System.Windows.Forms.Label();
            this.txtCaretX = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblCaretX
            // 
            this.lblCaretX.AutoSize = true;
            this.lblCaretX.BackColor = System.Drawing.Color.Transparent;
            this.lblCaretX.Enabled = false;
            this.lblCaretX.Location = new System.Drawing.Point(0, 107);
            this.lblCaretX.Name = "lblCaretX";
            this.lblCaretX.Size = new System.Drawing.Size(28, 13);
            this.lblCaretX.TabIndex = 3;
            this.lblCaretX.Text = "Col :";
            // 
            // lblCaretY
            // 
            this.lblCaretY.AutoSize = true;
            this.lblCaretY.BackColor = System.Drawing.Color.Transparent;
            this.lblCaretY.Enabled = false;
            this.lblCaretY.Location = new System.Drawing.Point(126, 107);
            this.lblCaretY.Name = "lblCaretY";
            this.lblCaretY.Size = new System.Drawing.Size(35, 13);
            this.lblCaretY.TabIndex = 4;
            this.lblCaretY.Text = "Row :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.lstBoxSuggestedWords);
            this.panel1.Controls.Add(this.txtCaretY);
            this.panel1.Controls.Add(this.lblCurrentApp);
            this.panel1.Controls.Add(this.lblCaretY);
            this.panel1.Controls.Add(this.txtCaretX);
            this.panel1.Controls.Add(this.lblCaretX);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 148);
            this.panel1.TabIndex = 6;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(273, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // lstBoxSuggestedWords
            // 
            this.lstBoxSuggestedWords.FormattingEnabled = true;
            this.lstBoxSuggestedWords.Location = new System.Drawing.Point(0, 29);
            this.lstBoxSuggestedWords.Name = "lstBoxSuggestedWords";
            this.lstBoxSuggestedWords.Size = new System.Drawing.Size(280, 69);
            this.lstBoxSuggestedWords.TabIndex = 8;
            // 
            // txtCaretY
            // 
            this.txtCaretY.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtCaretY.Enabled = false;
            this.txtCaretY.Location = new System.Drawing.Point(161, 104);
            this.txtCaretY.Name = "txtCaretY";
            this.txtCaretY.ReadOnly = true;
            this.txtCaretY.Size = new System.Drawing.Size(98, 20);
            this.txtCaretY.TabIndex = 2;
            // 
            // lblCurrentApp
            // 
            this.lblCurrentApp.AutoSize = true;
            this.lblCurrentApp.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentApp.Enabled = false;
            this.lblCurrentApp.Location = new System.Drawing.Point(3, 127);
            this.lblCurrentApp.Name = "lblCurrentApp";
            this.lblCurrentApp.Size = new System.Drawing.Size(132, 13);
            this.lblCurrentApp.TabIndex = 7;
            this.lblCurrentApp.Text = "Currently you can type in : ";
            // 
            // txtCaretX
            // 
            this.txtCaretX.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtCaretX.Enabled = false;
            this.txtCaretX.Location = new System.Drawing.Point(28, 104);
            this.txtCaretX.Name = "txtCaretX";
            this.txtCaretX.ReadOnly = true;
            this.txtCaretX.Size = new System.Drawing.Size(98, 20);
            this.txtCaretX.TabIndex = 1;
            // 
            // frmTooltip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(281, 148);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTooltip";
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmTooltip_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCaretX;
        private System.Windows.Forms.Label lblCaretY;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCurrentApp;
        private System.Windows.Forms.TextBox txtCaretX;
        private System.Windows.Forms.TextBox txtCaretY;
        private System.Windows.Forms.ListBox lstBoxSuggestedWords;
        private System.Windows.Forms.TextBox textBox1;
    }
}

