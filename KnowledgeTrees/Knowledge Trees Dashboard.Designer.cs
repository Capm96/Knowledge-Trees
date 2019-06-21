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
            this.dashboardLabel = new System.Windows.Forms.Label();
            this.creditsButton = new System.Windows.Forms.Button();
            this.themeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treesListBox
            // 
            this.treesListBox.BackColor = System.Drawing.Color.White;
            this.treesListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.treesListBox.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treesListBox.ForeColor = System.Drawing.Color.DarkGreen;
            this.treesListBox.FormattingEnabled = true;
            this.treesListBox.HorizontalScrollbar = true;
            this.treesListBox.ItemHeight = 37;
            this.treesListBox.Location = new System.Drawing.Point(192, 224);
            this.treesListBox.Name = "treesListBox";
            this.treesListBox.Size = new System.Drawing.Size(385, 485);
            this.treesListBox.Sorted = true;
            this.treesListBox.TabIndex = 0;
            this.treesListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.treesListBox_DrawItem);
            this.treesListBox.SelectedIndexChanged += new System.EventHandler(this.treesListBox_SelectedIndexChanged);
            // 
            // viewTreeButton
            // 
            this.viewTreeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.viewTreeButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.viewTreeButton.FlatAppearance.BorderSize = 2;
            this.viewTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewTreeButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.viewTreeButton.ForeColor = System.Drawing.Color.Black;
            this.viewTreeButton.Image = ((System.Drawing.Image)(resources.GetObject("viewTreeButton.Image")));
            this.viewTreeButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.viewTreeButton.Location = new System.Drawing.Point(22, 568);
            this.viewTreeButton.Name = "viewTreeButton";
            this.viewTreeButton.Size = new System.Drawing.Size(140, 140);
            this.viewTreeButton.TabIndex = 1;
            this.viewTreeButton.Text = "View";
            this.viewTreeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.viewTreeButton.UseVisualStyleBackColor = false;
            this.viewTreeButton.Click += new System.EventHandler(this.viewTreeButton_Click);
            // 
            // removeTreeButton
            // 
            this.removeTreeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.removeTreeButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.removeTreeButton.FlatAppearance.BorderSize = 2;
            this.removeTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeTreeButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.removeTreeButton.ForeColor = System.Drawing.Color.Black;
            this.removeTreeButton.Image = ((System.Drawing.Image)(resources.GetObject("removeTreeButton.Image")));
            this.removeTreeButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.removeTreeButton.Location = new System.Drawing.Point(22, 396);
            this.removeTreeButton.Name = "removeTreeButton";
            this.removeTreeButton.Size = new System.Drawing.Size(140, 140);
            this.removeTreeButton.TabIndex = 2;
            this.removeTreeButton.Text = "Delete";
            this.removeTreeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.removeTreeButton.UseVisualStyleBackColor = false;
            this.removeTreeButton.Click += new System.EventHandler(this.removeTreeButton_Click);
            // 
            // createTreeButton
            // 
            this.createTreeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.createTreeButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.createTreeButton.FlatAppearance.BorderSize = 2;
            this.createTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTreeButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.createTreeButton.ForeColor = System.Drawing.Color.Black;
            this.createTreeButton.Image = ((System.Drawing.Image)(resources.GetObject("createTreeButton.Image")));
            this.createTreeButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.createTreeButton.Location = new System.Drawing.Point(22, 224);
            this.createTreeButton.Name = "createTreeButton";
            this.createTreeButton.Size = new System.Drawing.Size(140, 140);
            this.createTreeButton.TabIndex = 3;
            this.createTreeButton.Text = "Create";
            this.createTreeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.createTreeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.createTreeButton.UseVisualStyleBackColor = false;
            this.createTreeButton.Click += new System.EventHandler(this.createTreeButton_Click);
            // 
            // createLeafButton
            // 
            this.createLeafButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createLeafButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.createLeafButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.createLeafButton.FlatAppearance.BorderSize = 2;
            this.createLeafButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createLeafButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.createLeafButton.ForeColor = System.Drawing.Color.Black;
            this.createLeafButton.Image = ((System.Drawing.Image)(resources.GetObject("createLeafButton.Image")));
            this.createLeafButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.createLeafButton.Location = new System.Drawing.Point(669, 224);
            this.createLeafButton.Name = "createLeafButton";
            this.createLeafButton.Size = new System.Drawing.Size(140, 140);
            this.createLeafButton.TabIndex = 7;
            this.createLeafButton.Text = "Create";
            this.createLeafButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.createLeafButton.UseVisualStyleBackColor = false;
            this.createLeafButton.Click += new System.EventHandler(this.createLeafButton_Click);
            // 
            // removeLeafButton
            // 
            this.removeLeafButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeLeafButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.removeLeafButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.removeLeafButton.FlatAppearance.BorderSize = 2;
            this.removeLeafButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeLeafButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.removeLeafButton.ForeColor = System.Drawing.Color.Black;
            this.removeLeafButton.Image = ((System.Drawing.Image)(resources.GetObject("removeLeafButton.Image")));
            this.removeLeafButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.removeLeafButton.Location = new System.Drawing.Point(669, 396);
            this.removeLeafButton.Name = "removeLeafButton";
            this.removeLeafButton.Size = new System.Drawing.Size(140, 140);
            this.removeLeafButton.TabIndex = 6;
            this.removeLeafButton.Text = "Delete";
            this.removeLeafButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.removeLeafButton.UseVisualStyleBackColor = false;
            this.removeLeafButton.Click += new System.EventHandler(this.removeLeafButton_Click);
            // 
            // viewLeafButton
            // 
            this.viewLeafButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewLeafButton.AutoSize = true;
            this.viewLeafButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.viewLeafButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.viewLeafButton.FlatAppearance.BorderSize = 2;
            this.viewLeafButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewLeafButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.viewLeafButton.ForeColor = System.Drawing.Color.Black;
            this.viewLeafButton.Image = ((System.Drawing.Image)(resources.GetObject("viewLeafButton.Image")));
            this.viewLeafButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.viewLeafButton.Location = new System.Drawing.Point(669, 568);
            this.viewLeafButton.Name = "viewLeafButton";
            this.viewLeafButton.Size = new System.Drawing.Size(140, 140);
            this.viewLeafButton.TabIndex = 5;
            this.viewLeafButton.Text = "Edit/View";
            this.viewLeafButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.viewLeafButton.UseVisualStyleBackColor = false;
            this.viewLeafButton.Click += new System.EventHandler(this.viewLeafButton_Click);
            // 
            // leavesListBox
            // 
            this.leavesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leavesListBox.BackColor = System.Drawing.Color.White;
            this.leavesListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.leavesListBox.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leavesListBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.leavesListBox.FormattingEnabled = true;
            this.leavesListBox.HorizontalExtent = 200;
            this.leavesListBox.HorizontalScrollbar = true;
            this.leavesListBox.ItemHeight = 37;
            this.leavesListBox.Location = new System.Drawing.Point(839, 224);
            this.leavesListBox.Name = "leavesListBox";
            this.leavesListBox.Size = new System.Drawing.Size(385, 485);
            this.leavesListBox.Sorted = true;
            this.leavesListBox.TabIndex = 8;
            this.leavesListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.leavesListBox_DrawItem);
            // 
            // treesLabel
            // 
            this.treesLabel.BackColor = System.Drawing.Color.ForestGreen;
            this.treesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treesLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.treesLabel.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treesLabel.ForeColor = System.Drawing.Color.White;
            this.treesLabel.Location = new System.Drawing.Point(22, 124);
            this.treesLabel.Name = "treesLabel";
            this.treesLabel.Size = new System.Drawing.Size(555, 64);
            this.treesLabel.TabIndex = 9;
            this.treesLabel.Text = "Trees List";
            this.treesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leavesLabel
            // 
            this.leavesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leavesLabel.BackColor = System.Drawing.Color.ForestGreen;
            this.leavesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leavesLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leavesLabel.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leavesLabel.ForeColor = System.Drawing.Color.White;
            this.leavesLabel.Location = new System.Drawing.Point(669, 124);
            this.leavesLabel.Name = "leavesLabel";
            this.leavesLabel.Size = new System.Drawing.Size(555, 64);
            this.leavesLabel.TabIndex = 10;
            this.leavesLabel.Text = "Leaves List";
            this.leavesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dashboardLabel
            // 
            this.dashboardLabel.BackColor = System.Drawing.Color.ForestGreen;
            this.dashboardLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dashboardLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardLabel.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.dashboardLabel.ForeColor = System.Drawing.Color.White;
            this.dashboardLabel.Location = new System.Drawing.Point(0, 0);
            this.dashboardLabel.Name = "dashboardLabel";
            this.dashboardLabel.Size = new System.Drawing.Size(1260, 78);
            this.dashboardLabel.TabIndex = 11;
            this.dashboardLabel.Text = "     Knowledge Trees Dashboard";
            this.dashboardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // creditsButton
            // 
            this.creditsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.creditsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.creditsButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.creditsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.creditsButton.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.creditsButton.ForeColor = System.Drawing.Color.White;
            this.creditsButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.creditsButton.Location = new System.Drawing.Point(1058, 0);
            this.creditsButton.Name = "creditsButton";
            this.creditsButton.Size = new System.Drawing.Size(202, 78);
            this.creditsButton.TabIndex = 13;
            this.creditsButton.Text = "Credits";
            this.creditsButton.UseVisualStyleBackColor = false;
            this.creditsButton.Click += new System.EventHandler(this.creditsButton_Click);
            // 
            // themeButton
            // 
            this.themeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.themeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.themeButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.themeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.themeButton.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.themeButton.ForeColor = System.Drawing.Color.Transparent;
            this.themeButton.Location = new System.Drawing.Point(857, 0);
            this.themeButton.Name = "themeButton";
            this.themeButton.Size = new System.Drawing.Size(202, 78);
            this.themeButton.TabIndex = 14;
            this.themeButton.Text = "Theme";
            this.themeButton.UseVisualStyleBackColor = false;
            this.themeButton.Click += new System.EventHandler(this.changeTheme_Click);
            // 
            // knowledgeTreesDashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1262, 753);
            this.Controls.Add(this.themeButton);
            this.Controls.Add(this.creditsButton);
            this.Controls.Add(this.dashboardLabel);
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
            this.PerformLayout();

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
        public System.Windows.Forms.Label dashboardLabel;
        private System.Windows.Forms.Button creditsButton;
        private System.Windows.Forms.Button themeButton;
    }
}

