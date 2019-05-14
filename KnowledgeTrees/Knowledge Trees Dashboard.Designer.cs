namespace KnowledgeTrees
{
    partial class knowledgeTreesDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(knowledgeTreesDashboard));
            this.treesListBox = new System.Windows.Forms.ListBox();
            this.viewTreeButton = new System.Windows.Forms.Button();
            this.removeTreeButton = new System.Windows.Forms.Button();
            this.createTreeButton = new System.Windows.Forms.Button();
            this.createLeafButton = new System.Windows.Forms.Button();
            this.removeLeafButton = new System.Windows.Forms.Button();
            this.viewLeafButton = new System.Windows.Forms.Button();
            this.leavesListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // treesListBox
            // 
            this.treesListBox.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treesListBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.treesListBox.FormattingEnabled = true;
            this.treesListBox.ItemHeight = 37;
            this.treesListBox.Location = new System.Drawing.Point(22, 269);
            this.treesListBox.Name = "treesListBox";
            this.treesListBox.Size = new System.Drawing.Size(319, 411);
            this.treesListBox.TabIndex = 0;
            this.treesListBox.SelectedIndexChanged += new System.EventHandler(this.treesListBox_SelectedIndexChanged);
            // 
            // viewTreeButton
            // 
            this.viewTreeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.viewTreeButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.viewTreeButton.FlatAppearance.BorderSize = 2;
            this.viewTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewTreeButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.viewTreeButton.ForeColor = System.Drawing.Color.Black;
            this.viewTreeButton.Location = new System.Drawing.Point(22, 188);
            this.viewTreeButton.Name = "viewTreeButton";
            this.viewTreeButton.Size = new System.Drawing.Size(319, 57);
            this.viewTreeButton.TabIndex = 1;
            this.viewTreeButton.Text = "View Tree";
            this.viewTreeButton.UseVisualStyleBackColor = false;
            this.viewTreeButton.Click += new System.EventHandler(this.viewTreeButton_Click);
            // 
            // removeTreeButton
            // 
            this.removeTreeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.removeTreeButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.removeTreeButton.FlatAppearance.BorderSize = 2;
            this.removeTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeTreeButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.removeTreeButton.ForeColor = System.Drawing.Color.Black;
            this.removeTreeButton.Location = new System.Drawing.Point(22, 107);
            this.removeTreeButton.Name = "removeTreeButton";
            this.removeTreeButton.Size = new System.Drawing.Size(319, 57);
            this.removeTreeButton.TabIndex = 2;
            this.removeTreeButton.Text = "Remove Tree";
            this.removeTreeButton.UseVisualStyleBackColor = false;
            this.removeTreeButton.Click += new System.EventHandler(this.removeTreeButton_Click);
            // 
            // createTreeButton
            // 
            this.createTreeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.createTreeButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.createTreeButton.FlatAppearance.BorderSize = 2;
            this.createTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTreeButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.createTreeButton.ForeColor = System.Drawing.Color.Black;
            this.createTreeButton.Location = new System.Drawing.Point(22, 26);
            this.createTreeButton.Name = "createTreeButton";
            this.createTreeButton.Size = new System.Drawing.Size(319, 57);
            this.createTreeButton.TabIndex = 3;
            this.createTreeButton.Text = "Create Tree";
            this.createTreeButton.UseVisualStyleBackColor = false;
            this.createTreeButton.Click += new System.EventHandler(this.createTreeButton_Click);
            // 
            // createLeafButton
            // 
            this.createLeafButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createLeafButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.createLeafButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.createLeafButton.FlatAppearance.BorderSize = 2;
            this.createLeafButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createLeafButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.createLeafButton.ForeColor = System.Drawing.Color.Black;
            this.createLeafButton.Location = new System.Drawing.Point(667, 26);
            this.createLeafButton.Name = "createLeafButton";
            this.createLeafButton.Size = new System.Drawing.Size(327, 57);
            this.createLeafButton.TabIndex = 7;
            this.createLeafButton.Text = "Create Leaf";
            this.createLeafButton.UseVisualStyleBackColor = false;
            this.createLeafButton.Click += new System.EventHandler(this.createLeafButton_Click);
            // 
            // removeLeafButton
            // 
            this.removeLeafButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeLeafButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.removeLeafButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.removeLeafButton.FlatAppearance.BorderSize = 2;
            this.removeLeafButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeLeafButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.removeLeafButton.ForeColor = System.Drawing.Color.Black;
            this.removeLeafButton.Location = new System.Drawing.Point(667, 107);
            this.removeLeafButton.Name = "removeLeafButton";
            this.removeLeafButton.Size = new System.Drawing.Size(327, 57);
            this.removeLeafButton.TabIndex = 6;
            this.removeLeafButton.Text = "Remove Leaf";
            this.removeLeafButton.UseVisualStyleBackColor = false;
            this.removeLeafButton.Click += new System.EventHandler(this.removeLeafButton_Click);
            // 
            // viewLeafButton
            // 
            this.viewLeafButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewLeafButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.viewLeafButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.viewLeafButton.FlatAppearance.BorderSize = 2;
            this.viewLeafButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewLeafButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.viewLeafButton.ForeColor = System.Drawing.Color.Black;
            this.viewLeafButton.Location = new System.Drawing.Point(667, 188);
            this.viewLeafButton.Name = "viewLeafButton";
            this.viewLeafButton.Size = new System.Drawing.Size(327, 57);
            this.viewLeafButton.TabIndex = 5;
            this.viewLeafButton.Text = "View Leaf";
            this.viewLeafButton.UseVisualStyleBackColor = false;
            this.viewLeafButton.Click += new System.EventHandler(this.viewLeafButton_Click);
            // 
            // leavesListBox
            // 
            this.leavesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leavesListBox.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leavesListBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.leavesListBox.FormattingEnabled = true;
            this.leavesListBox.ItemHeight = 37;
            this.leavesListBox.Location = new System.Drawing.Point(667, 269);
            this.leavesListBox.Name = "leavesListBox";
            this.leavesListBox.Size = new System.Drawing.Size(319, 411);
            this.leavesListBox.TabIndex = 8;
            // 
            // knowledgeTreesDashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.leavesListBox);
            this.Controls.Add(this.createLeafButton);
            this.Controls.Add(this.removeLeafButton);
            this.Controls.Add(this.viewLeafButton);
            this.Controls.Add(this.createTreeButton);
            this.Controls.Add(this.removeTreeButton);
            this.Controls.Add(this.viewTreeButton);
            this.Controls.Add(this.treesListBox);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "knowledgeTreesDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Knowledge Trees Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox treesListBox;
        private System.Windows.Forms.Button viewTreeButton;
        private System.Windows.Forms.Button removeTreeButton;
        private System.Windows.Forms.Button createTreeButton;
        private System.Windows.Forms.Button createLeafButton;
        private System.Windows.Forms.Button removeLeafButton;
        private System.Windows.Forms.Button viewLeafButton;
        private System.Windows.Forms.ListBox leavesListBox;
    }
}

