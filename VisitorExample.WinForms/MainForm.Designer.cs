namespace VisitorExample
{
    partial class MainForm
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
            this.InfoTextBox = new System.Windows.Forms.TextBox();
            this.addClerkButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.addDirectorButton = new System.Windows.Forms.Button();
            this.addPresidentButton = new System.Windows.Forms.Button();
            this.increaseVacationsButton = new System.Windows.Forms.Button();
            this.giveRaisesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InfoTextBox
            // 
            this.InfoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoTextBox.Location = new System.Drawing.Point(12, 80);
            this.InfoTextBox.Multiline = true;
            this.InfoTextBox.Name = "InfoTextBox";
            this.InfoTextBox.ReadOnly = true;
            this.InfoTextBox.Size = new System.Drawing.Size(776, 358);
            this.InfoTextBox.TabIndex = 8;
            // 
            // addClerkButton
            // 
            this.addClerkButton.Location = new System.Drawing.Point(12, 43);
            this.addClerkButton.Name = "addClerkButton";
            this.addClerkButton.Size = new System.Drawing.Size(75, 23);
            this.addClerkButton.TabIndex = 2;
            this.addClerkButton.Text = "Clerk";
            this.addClerkButton.UseVisualStyleBackColor = true;
            this.addClerkButton.Click += new System.EventHandler(this.AddClerkButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(255, 43);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(56, 10);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(193, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(14, 14);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // addDirectorButton
            // 
            this.addDirectorButton.Location = new System.Drawing.Point(93, 43);
            this.addDirectorButton.Name = "addDirectorButton";
            this.addDirectorButton.Size = new System.Drawing.Size(75, 23);
            this.addDirectorButton.TabIndex = 3;
            this.addDirectorButton.Text = "Director";
            this.addDirectorButton.UseVisualStyleBackColor = true;
            this.addDirectorButton.Click += new System.EventHandler(this.AddDirectorButton_Click);
            // 
            // addPresidentButton
            // 
            this.addPresidentButton.Location = new System.Drawing.Point(174, 43);
            this.addPresidentButton.Name = "addPresidentButton";
            this.addPresidentButton.Size = new System.Drawing.Size(75, 23);
            this.addPresidentButton.TabIndex = 4;
            this.addPresidentButton.Text = "President";
            this.addPresidentButton.UseVisualStyleBackColor = true;
            this.addPresidentButton.Click += new System.EventHandler(this.AddPresidentButton_Click);
            // 
            // increaseVacationsButton
            // 
            this.increaseVacationsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.increaseVacationsButton.Location = new System.Drawing.Point(713, 43);
            this.increaseVacationsButton.Name = "increaseVacationsButton";
            this.increaseVacationsButton.Size = new System.Drawing.Size(75, 23);
            this.increaseVacationsButton.TabIndex = 6;
            this.increaseVacationsButton.Text = "Vacations";
            this.increaseVacationsButton.UseVisualStyleBackColor = true;
            this.increaseVacationsButton.Click += new System.EventHandler(this.IncreaseVacationsButton_Click);
            // 
            // giveRaisesButton
            // 
            this.giveRaisesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.giveRaisesButton.Location = new System.Drawing.Point(632, 43);
            this.giveRaisesButton.Name = "giveRaisesButton";
            this.giveRaisesButton.Size = new System.Drawing.Size(75, 23);
            this.giveRaisesButton.TabIndex = 5;
            this.giveRaisesButton.Text = "Raises";
            this.giveRaisesButton.UseVisualStyleBackColor = true;
            this.giveRaisesButton.Click += new System.EventHandler(this.GiveRaisesButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.giveRaisesButton);
            this.Controls.Add(this.increaseVacationsButton);
            this.Controls.Add(this.addPresidentButton);
            this.Controls.Add(this.addDirectorButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.addClerkButton);
            this.Controls.Add(this.InfoTextBox);
            this.Name = "MainForm";
            this.Text = "Visitor Example";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InfoTextBox;
        private System.Windows.Forms.Button addClerkButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button addDirectorButton;
        private System.Windows.Forms.Button addPresidentButton;
        private System.Windows.Forms.Button increaseVacationsButton;
        private System.Windows.Forms.Button giveRaisesButton;
    }
}

