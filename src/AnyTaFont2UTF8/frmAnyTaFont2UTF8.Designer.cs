namespace AnyTaFont2UTF8
{
    partial class frmAnyTaFont2UTF8
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
            this.uscntrlAnyTaFont2UTF81 = new AnyTaFont2UTF8.uscntrlAnyTaFont2UTF8();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uscntrlAnyTaFont2UTF8Folder1 = new AnyTaFont2UTF8.uscntrlAnyTaFont2UTF8Folder();
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
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uscntrlAnyTaFont2UTF81);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(415, 312);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Text Encode";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // uscntrlAnyTaFont2UTF81
            // 
            this.uscntrlAnyTaFont2UTF81.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uscntrlAnyTaFont2UTF81.Location = new System.Drawing.Point(3, 3);
            this.uscntrlAnyTaFont2UTF81.Name = "uscntrlAnyTaFont2UTF81";
            this.uscntrlAnyTaFont2UTF81.Size = new System.Drawing.Size(409, 306);
            this.uscntrlAnyTaFont2UTF81.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uscntrlAnyTaFont2UTF8Folder1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(415, 312);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Folder Encode";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // uscntrlAnyTaFont2UTF8Folder1
            // 
            this.uscntrlAnyTaFont2UTF8Folder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uscntrlAnyTaFont2UTF8Folder1.Location = new System.Drawing.Point(3, 3);
            this.uscntrlAnyTaFont2UTF8Folder1.Name = "uscntrlAnyTaFont2UTF8Folder1";
            this.uscntrlAnyTaFont2UTF8Folder1.Size = new System.Drawing.Size(409, 306);
            this.uscntrlAnyTaFont2UTF8Folder1.TabIndex = 0;
            // 
            // frmAnyTaFont2UTF8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 338);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAnyTaFont2UTF8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Any Tamil Font To UTF8";
            this.Load += new System.EventHandler(this.frmAnyTaFont2UTF8_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private uscntrlAnyTaFont2UTF8 uscntrlAnyTaFont2UTF81;
        private System.Windows.Forms.TabPage tabPage2;
        private uscntrlAnyTaFont2UTF8Folder uscntrlAnyTaFont2UTF8Folder1;


    }
}

