namespace KnowledgeTrees
{
    partial class createLeafForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(createLeafForm));
            this.createNewLeafButton = new System.Windows.Forms.Button();
            this.leafNameValue = new System.Windows.Forms.TextBox();
            this.leafNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createNewLeafButton
            // 
            this.createNewLeafButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.createNewLeafButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.createNewLeafButton.FlatAppearance.BorderSize = 2;
            this.createNewLeafButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createNewLeafButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.createNewLeafButton.ForeColor = System.Drawing.Color.Black;
            this.createNewLeafButton.Location = new System.Drawing.Point(21, 94);
            this.createNewLeafButton.Name = "createNewLeafButton";
            this.createNewLeafButton.Size = new System.Drawing.Size(559, 64);
            this.createNewLeafButton.TabIndex = 15;
            this.createNewLeafButton.Text = "Create Leaf";
            this.createNewLeafButton.UseVisualStyleBackColor = false;
            this.createNewLeafButton.Click += new System.EventHandler(this.createNewLeafButton_Click);
            // 
            // leafNameValue
            // 
            this.leafNameValue.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.leafNameValue.Location = new System.Drawing.Point(133, 29);
            this.leafNameValue.Name = "leafNameValue";
            this.leafNameValue.Size = new System.Drawing.Size(447, 39);
            this.leafNameValue.TabIndex = 14;
            // 
            // leafNameLabel
            // 
            this.leafNameLabel.AutoSize = true;
            this.leafNameLabel.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leafNameLabel.ForeColor = System.Drawing.Color.Gray;
            this.leafNameLabel.Location = new System.Drawing.Point(12, 18);
            this.leafNameLabel.Name = "leafNameLabel";
            this.leafNameLabel.Size = new System.Drawing.Size(115, 50);
            this.leafNameLabel.TabIndex = 13;
            this.leafNameLabel.Text = "Name";
            // 
            // createLeafForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(592, 186);
            this.Controls.Add(this.createNewLeafButton);
            this.Controls.Add(this.leafNameValue);
            this.Controls.Add(this.leafNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "createLeafForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Leaf";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createNewLeafButton;
        private System.Windows.Forms.TextBox leafNameValue;
        private System.Windows.Forms.Label leafNameLabel;
    }
}