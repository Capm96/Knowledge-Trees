namespace KnowledgeTrees
{
    partial class createTreeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(createTreeForm));
            this.treeNameLabel = new System.Windows.Forms.Label();
            this.treeNameValue = new System.Windows.Forms.TextBox();
            this.createNewTreeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeNameLabel
            // 
            this.treeNameLabel.AutoSize = true;
            this.treeNameLabel.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeNameLabel.ForeColor = System.Drawing.Color.Black;
            this.treeNameLabel.Location = new System.Drawing.Point(12, 19);
            this.treeNameLabel.Name = "treeNameLabel";
            this.treeNameLabel.Size = new System.Drawing.Size(115, 50);
            this.treeNameLabel.TabIndex = 1;
            this.treeNameLabel.Text = "Name";
            // 
            // treeNameValue
            // 
            this.treeNameValue.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.treeNameValue.Location = new System.Drawing.Point(133, 30);
            this.treeNameValue.Name = "treeNameValue";
            this.treeNameValue.Size = new System.Drawing.Size(447, 39);
            this.treeNameValue.TabIndex = 2;
            // 
            // createNewTreeButton
            // 
            this.createNewTreeButton.BackColor = System.Drawing.Color.LightGreen;
            this.createNewTreeButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.createNewTreeButton.FlatAppearance.BorderSize = 2;
            this.createNewTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createNewTreeButton.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.createNewTreeButton.ForeColor = System.Drawing.Color.Black;
            this.createNewTreeButton.Location = new System.Drawing.Point(21, 95);
            this.createNewTreeButton.Name = "createNewTreeButton";
            this.createNewTreeButton.Size = new System.Drawing.Size(559, 64);
            this.createNewTreeButton.TabIndex = 12;
            this.createNewTreeButton.Text = "Create Tree";
            this.createNewTreeButton.UseVisualStyleBackColor = false;
            this.createNewTreeButton.Click += new System.EventHandler(this.createNewTreeButton_Click);
            // 
            // createTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(592, 186);
            this.Controls.Add(this.createNewTreeButton);
            this.Controls.Add(this.treeNameValue);
            this.Controls.Add(this.treeNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "createTreeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Tree";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label treeNameLabel;
        private System.Windows.Forms.TextBox treeNameValue;
        private System.Windows.Forms.Button createNewTreeButton;
    }
}