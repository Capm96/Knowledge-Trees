namespace KnowledgeTrees
{
    partial class treeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(treeView));
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.leafCountText = new System.Windows.Forms.Label();
            this.niceMessageLabel = new System.Windows.Forms.Label();
            this.treePicture = new System.Windows.Forms.PictureBox();
            this.returnToDashboardButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.treePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI Light", 28F, System.Drawing.FontStyle.Bold);
            this.welcomeLabel.ForeColor = System.Drawing.Color.Gray;
            this.welcomeLabel.Location = new System.Drawing.Point(12, 19);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(375, 62);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "<Welcome Text>";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // leafCountText
            // 
            this.leafCountText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leafCountText.AutoSize = true;
            this.leafCountText.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.leafCountText.ForeColor = System.Drawing.Color.Gray;
            this.leafCountText.Location = new System.Drawing.Point(12, 151);
            this.leafCountText.Name = "leafCountText";
            this.leafCountText.Size = new System.Drawing.Size(193, 41);
            this.leafCountText.TabIndex = 2;
            this.leafCountText.Text = "<Leaf Count>";
            // 
            // niceMessageLabel
            // 
            this.niceMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.niceMessageLabel.AutoSize = true;
            this.niceMessageLabel.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.niceMessageLabel.ForeColor = System.Drawing.Color.Gray;
            this.niceMessageLabel.Location = new System.Drawing.Point(12, 271);
            this.niceMessageLabel.MaximumSize = new System.Drawing.Size(300, 0);
            this.niceMessageLabel.Name = "niceMessageLabel";
            this.niceMessageLabel.Size = new System.Drawing.Size(225, 41);
            this.niceMessageLabel.TabIndex = 5;
            this.niceMessageLabel.Text = "<nice message>";
            // 
            // treePicture
            // 
            this.treePicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.treePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.treePicture.Image = ((System.Drawing.Image)(resources.GetObject("treePicture.Image")));
            this.treePicture.Location = new System.Drawing.Point(394, 99);
            this.treePicture.Name = "treePicture";
            this.treePicture.Size = new System.Drawing.Size(600, 600);
            this.treePicture.TabIndex = 10;
            this.treePicture.TabStop = false;
            // 
            // returnToDashboardButton
            // 
            this.returnToDashboardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.returnToDashboardButton.BackColor = System.Drawing.Color.ForestGreen;
            this.returnToDashboardButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.returnToDashboardButton.FlatAppearance.BorderSize = 2;
            this.returnToDashboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnToDashboardButton.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.returnToDashboardButton.ForeColor = System.Drawing.Color.White;
            this.returnToDashboardButton.Location = new System.Drawing.Point(12, 625);
            this.returnToDashboardButton.Name = "returnToDashboardButton";
            this.returnToDashboardButton.Size = new System.Drawing.Size(357, 64);
            this.returnToDashboardButton.TabIndex = 11;
            this.returnToDashboardButton.Text = "Return to Dashboard";
            this.returnToDashboardButton.UseVisualStyleBackColor = false;
            this.returnToDashboardButton.Click += new System.EventHandler(this.returnToDashboardButton_Click);
            // 
            // treeView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.returnToDashboardButton);
            this.Controls.Add(this.treePicture);
            this.Controls.Add(this.niceMessageLabel);
            this.Controls.Add(this.leafCountText);
            this.Controls.Add(this.welcomeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "treeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tree View";
            ((System.ComponentModel.ISupportInitialize)(this.treePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label leafCountText;
        private System.Windows.Forms.Label niceMessageLabel;
        private System.Windows.Forms.PictureBox treePicture;
        private System.Windows.Forms.Button returnToDashboardButton;
    }
}