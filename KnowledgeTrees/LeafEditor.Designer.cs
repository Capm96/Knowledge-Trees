namespace KnowledgeTrees
{
    partial class leafEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(leafEditor));
            this.textControl1 = new TXTextControl.TextControl();
            this.buttonBar2 = new TXTextControl.ButtonBar();
            this.statusBar2 = new TXTextControl.StatusBar();
            this.saveLeafButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textControl1
            // 
            this.textControl1.ButtonBar = this.buttonBar2;
            this.textControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(0, 28);
            this.textControl1.Name = "textControl1";
            this.textControl1.Size = new System.Drawing.Size(1006, 671);
            this.textControl1.StatusBar = this.statusBar2;
            this.textControl1.TabIndex = 0;
            this.textControl1.Text = "<Leaf Name>";
            this.textControl1.UserNames = null;
            // 
            // buttonBar2
            // 
            this.buttonBar2.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBar2.Location = new System.Drawing.Point(0, 0);
            this.buttonBar2.Name = "buttonBar2";
            this.buttonBar2.Size = new System.Drawing.Size(1006, 28);
            this.buttonBar2.TabIndex = 5;
            this.buttonBar2.Text = "buttonBar2";
            // 
            // statusBar2
            // 
            this.statusBar2.BackColor = System.Drawing.SystemColors.Control;
            this.statusBar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar2.Location = new System.Drawing.Point(0, 699);
            this.statusBar2.Name = "statusBar2";
            this.statusBar2.Size = new System.Drawing.Size(1006, 22);
            this.statusBar2.TabIndex = 6;
            // 
            // saveLeafButton
            // 
            this.saveLeafButton.BackColor = System.Drawing.Color.Gainsboro;
            this.saveLeafButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.saveLeafButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveLeafButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.saveLeafButton.ForeColor = System.Drawing.Color.Black;
            this.saveLeafButton.Location = new System.Drawing.Point(0, 34);
            this.saveLeafButton.Name = "saveLeafButton";
            this.saveLeafButton.Size = new System.Drawing.Size(79, 43);
            this.saveLeafButton.TabIndex = 7;
            this.saveLeafButton.Text = "Save";
            this.saveLeafButton.UseVisualStyleBackColor = false;
            this.saveLeafButton.Click += new System.EventHandler(this.saveLeafButton_Click);
            // 
            // leafEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.saveLeafButton);
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.buttonBar2);
            this.Controls.Add(this.statusBar2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "leafEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leafy";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private TXTextControl.TextControl textControl1;
        private TXTextControl.StatusBar statusBar2;
        private TXTextControl.ButtonBar buttonBar2;
        private System.Windows.Forms.Button saveLeafButton;
    }
}