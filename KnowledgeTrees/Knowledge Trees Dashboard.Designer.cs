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
            this.treesLabel = new System.Windows.Forms.Label();
            this.leavesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // treesListBox
            // 
            this.treesListBox.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treesListBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.treesListBox.FormattingEnabled = true;
            this.treesListBox.HorizontalScrollbar = true;
            this.treesListBox.ItemHeight = 37;
            this.treesListBox.Location = new System.Drawing.Point(22, 306);
            this.treesListBox.Name = "treesListBox";
            this.treesListBox.Size = new System.Drawing.Size(246, 374);
            this.treesListBox.TabIndex = 0;
            this.treesListBox.SelectedIndexChanged += new System.EventHandler(this.treesListBox_SelectedIndexChanged);
            // 
            // viewTreeButton
            // 
            this.viewTreeButton.BackColor = System.Drawing.Color.LightGreen;
            this.viewTreeButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.viewTreeButton.FlatAppearance.BorderSize = 2;
            this.viewTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewTreeButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.viewTreeButton.ForeColor = System.Drawing.Color.Black;
            this.viewTreeButton.Location = new System.Drawing.Point(22, 244);
            this.viewTreeButton.Name = "viewTreeButton";
            this.viewTreeButton.Size = new System.Drawing.Size(246, 42);
            this.viewTreeButton.TabIndex = 1;
            this.viewTreeButton.Text = "View";
            this.viewTreeButton.UseVisualStyleBackColor = false;
            this.viewTreeButton.Click += new System.EventHandler(this.viewTreeButton_Click);
            // 
            // removeTreeButton
            // 
            this.removeTreeButton.BackColor = System.Drawing.Color.LightGreen;
            this.removeTreeButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.removeTreeButton.FlatAppearance.BorderSize = 2;
            this.removeTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeTreeButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.removeTreeButton.ForeColor = System.Drawing.Color.Black;
            this.removeTreeButton.Location = new System.Drawing.Point(22, 180);
            this.removeTreeButton.Name = "removeTreeButton";
            this.removeTreeButton.Size = new System.Drawing.Size(246, 42);
            this.removeTreeButton.TabIndex = 2;
            this.removeTreeButton.Text = "Delete";
            this.removeTreeButton.UseVisualStyleBackColor = false;
            this.removeTreeButton.Click += new System.EventHandler(this.removeTreeButton_Click);
            // 
            // createTreeButton
            // 
            this.createTreeButton.BackColor = System.Drawing.Color.LightGreen;
            this.createTreeButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.createTreeButton.FlatAppearance.BorderSize = 2;
            this.createTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTreeButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.createTreeButton.ForeColor = System.Drawing.Color.Black;
            this.createTreeButton.Location = new System.Drawing.Point(22, 116);
            this.createTreeButton.Name = "createTreeButton";
            this.createTreeButton.Size = new System.Drawing.Size(246, 42);
            this.createTreeButton.TabIndex = 3;
            this.createTreeButton.Text = "Create";
            this.createTreeButton.UseVisualStyleBackColor = false;
            this.createTreeButton.Click += new System.EventHandler(this.createTreeButton_Click);
            // 
            // createLeafButton
            // 
            this.createLeafButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createLeafButton.BackColor = System.Drawing.Color.LightGreen;
            this.createLeafButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.createLeafButton.FlatAppearance.BorderSize = 2;
            this.createLeafButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createLeafButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.createLeafButton.ForeColor = System.Drawing.Color.Black;
            this.createLeafButton.Location = new System.Drawing.Point(733, 116);
            this.createLeafButton.Name = "createLeafButton";
            this.createLeafButton.Size = new System.Drawing.Size(246, 42);
            this.createLeafButton.TabIndex = 7;
            this.createLeafButton.Text = "Create";
            this.createLeafButton.UseVisualStyleBackColor = false;
            this.createLeafButton.Click += new System.EventHandler(this.createLeafButton_Click);
            // 
            // removeLeafButton
            // 
            this.removeLeafButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeLeafButton.BackColor = System.Drawing.Color.LightGreen;
            this.removeLeafButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.removeLeafButton.FlatAppearance.BorderSize = 2;
            this.removeLeafButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeLeafButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.removeLeafButton.ForeColor = System.Drawing.Color.Black;
            this.removeLeafButton.Location = new System.Drawing.Point(733, 180);
            this.removeLeafButton.Name = "removeLeafButton";
            this.removeLeafButton.Size = new System.Drawing.Size(246, 42);
            this.removeLeafButton.TabIndex = 6;
            this.removeLeafButton.Text = "Delete";
            this.removeLeafButton.UseVisualStyleBackColor = false;
            this.removeLeafButton.Click += new System.EventHandler(this.removeLeafButton_Click);
            // 
            // viewLeafButton
            // 
            this.viewLeafButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewLeafButton.BackColor = System.Drawing.Color.LightGreen;
            this.viewLeafButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.viewLeafButton.FlatAppearance.BorderSize = 2;
            this.viewLeafButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewLeafButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.viewLeafButton.ForeColor = System.Drawing.Color.Black;
            this.viewLeafButton.Location = new System.Drawing.Point(733, 244);
            this.viewLeafButton.Name = "viewLeafButton";
            this.viewLeafButton.Size = new System.Drawing.Size(246, 42);
            this.viewLeafButton.TabIndex = 5;
            this.viewLeafButton.Text = "View";
            this.viewLeafButton.UseVisualStyleBackColor = false;
            this.viewLeafButton.Click += new System.EventHandler(this.viewLeafButton_Click);
            // 
            // leavesListBox
            // 
            this.leavesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leavesListBox.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leavesListBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.leavesListBox.FormattingEnabled = true;
            this.leavesListBox.HorizontalScrollbar = true;
            this.leavesListBox.ItemHeight = 37;
            this.leavesListBox.Location = new System.Drawing.Point(733, 306);
            this.leavesListBox.Name = "leavesListBox";
            this.leavesListBox.Size = new System.Drawing.Size(246, 374);
            this.leavesListBox.TabIndex = 8;
            // 
            // treesLabel
            // 
            this.treesLabel.BackColor = System.Drawing.Color.ForestGreen;
            this.treesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treesLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.treesLabel.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.treesLabel.ForeColor = System.Drawing.Color.White;
            this.treesLabel.Location = new System.Drawing.Point(22, 40);
            this.treesLabel.Name = "treesLabel";
            this.treesLabel.Size = new System.Drawing.Size(246, 52);
            this.treesLabel.TabIndex = 9;
            this.treesLabel.Text = "Trees";
            this.treesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leavesLabel
            // 
            this.leavesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leavesLabel.BackColor = System.Drawing.Color.ForestGreen;
            this.leavesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leavesLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leavesLabel.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.leavesLabel.ForeColor = System.Drawing.Color.White;
            this.leavesLabel.Location = new System.Drawing.Point(733, 40);
            this.leavesLabel.Name = "leavesLabel";
            this.leavesLabel.Size = new System.Drawing.Size(246, 52);
            this.leavesLabel.TabIndex = 10;
            this.leavesLabel.Text = "Leaves";
            this.leavesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // knowledgeTreesDashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.leavesLabel);
            this.Controls.Add(this.treesLabel);
            this.Controls.Add(this.leavesListBox);
            this.Controls.Add(this.createLeafButton);
            this.Controls.Add(this.removeLeafButton);
            this.Controls.Add(this.viewLeafButton);
            this.Controls.Add(this.createTreeButton);
            this.Controls.Add(this.removeTreeButton);
            this.Controls.Add(this.viewTreeButton);
            this.Controls.Add(this.treesListBox);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.LightGreen;
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
        public System.Windows.Forms.Label treesLabel;
        public System.Windows.Forms.Label leavesLabel;
    }
}

