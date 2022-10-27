namespace RSE
{
    partial class loginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Display", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(161, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "RSE 1.0";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(106, 130);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(266, 32);
            this.usernameBox.TabIndex = 1;
            this.usernameBox.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(106, 193);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(266, 32);
            this.richTextBox3.TabIndex = 3;
            this.richTextBox3.Text = "";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(194, 95);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(91, 25);
            this.usernameLabel.TabIndex = 4;
            this.usernameLabel.Text = "Username";
            // 
            // passwordBox
            // 
            this.passwordBox.AutoSize = true;
            this.passwordBox.Location = new System.Drawing.Point(194, 165);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(87, 25);
            this.passwordBox.TabIndex = 5;
            this.passwordBox.Text = "Password";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(183, 253);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(112, 34);
            this.loginButton.TabIndex = 6;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(478, 414);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "loginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RSE : Alpha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private RichTextBox usernameBox;
        private RichTextBox richTextBox3;
        private Label usernameLabel;
        private Label passwordBox;
        private Button loginButton;
    }
}