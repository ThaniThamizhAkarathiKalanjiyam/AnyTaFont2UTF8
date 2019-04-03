namespace AnyTaFont2TACE16
{
    partial class frmAnyTaFont2TACE16
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uscntrlAnyTaFont2TACE161 = new AnyTaFont2TACE16.uscntrlAnyTaFont2TACE16();
            this.uscntrlUTF82TACE16Folder1 = new AnyTaFont2TACE16.uscntrlUTF82TACE16Folder();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(423, 338);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uscntrlAnyTaFont2TACE161);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(415, 312);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "UTF8 Text to TACE16";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uscntrlUTF82TACE16Folder1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(415, 312);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "UTF8 File to TACE16";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // uscntrlAnyTaFont2TACE161
            // 
            this.uscntrlAnyTaFont2TACE161.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uscntrlAnyTaFont2TACE161.Location = new System.Drawing.Point(3, 3);
            this.uscntrlAnyTaFont2TACE161.Name = "uscntrlAnyTaFont2TACE161";
            this.uscntrlAnyTaFont2TACE161.Size = new System.Drawing.Size(409, 306);
            this.uscntrlAnyTaFont2TACE161.TabIndex = 1;
            // 
            // uscntrlUTF82TACE16Folder1
            // 
            this.uscntrlUTF82TACE16Folder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uscntrlUTF82TACE16Folder1.Location = new System.Drawing.Point(3, 3);
            this.uscntrlUTF82TACE16Folder1.Name = "uscntrlUTF82TACE16Folder1";
            this.uscntrlUTF82TACE16Folder1.Size = new System.Drawing.Size(409, 306);
            this.uscntrlUTF82TACE16Folder1.TabIndex = 0;
            // 
            // frmAnyTaFont2TACE16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 338);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAnyTaFont2TACE16";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UTF8 to TACE16";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private uscntrlAnyTaFont2TACE16 uscntrlAnyTaFont2TACE161;
        private System.Windows.Forms.TabPage tabPage2;
        private uscntrlUTF82TACE16Folder uscntrlUTF82TACE16Folder1;


    }
}

