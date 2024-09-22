namespace WindowsFormsApp1
{
    partial class Authorisation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxLogin = new System.Windows.Forms.ComboBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonOkAuth = new System.Windows.Forms.Button();
            this.buttonCancelAuth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "password";
            // 
            // comboBoxLogin
            // 
            this.comboBoxLogin.FormattingEnabled = true;
            this.comboBoxLogin.Items.AddRange(new object[] {
            "user",
            "admin"});
            this.comboBoxLogin.Location = new System.Drawing.Point(24, 93);
            this.comboBoxLogin.Name = "comboBoxLogin";
            this.comboBoxLogin.Size = new System.Drawing.Size(166, 21);
            this.comboBoxLogin.TabIndex = 2;
            this.comboBoxLogin.Text = "user";
            this.comboBoxLogin.SelectedIndexChanged += new System.EventHandler(this.comboBoxLogin_SelectedIndexChanged);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Enabled = false;
            this.textBoxPassword.Location = new System.Drawing.Point(439, 94);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(167, 20);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.Text = "*";
            // 
            // buttonOkAuth
            // 
            this.buttonOkAuth.Location = new System.Drawing.Point(353, 342);
            this.buttonOkAuth.Name = "buttonOkAuth";
            this.buttonOkAuth.Size = new System.Drawing.Size(172, 79);
            this.buttonOkAuth.TabIndex = 5;
            this.buttonOkAuth.Text = "ok";
            this.buttonOkAuth.UseVisualStyleBackColor = true;
            // 
            // buttonCancelAuth
            // 
            this.buttonCancelAuth.Location = new System.Drawing.Point(594, 342);
            this.buttonCancelAuth.Name = "buttonCancelAuth";
            this.buttonCancelAuth.Size = new System.Drawing.Size(170, 79);
            this.buttonCancelAuth.TabIndex = 6;
            this.buttonCancelAuth.Text = "cancel";
            this.buttonCancelAuth.UseVisualStyleBackColor = true;
            // 
            // Authorisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCancelAuth);
            this.Controls.Add(this.buttonOkAuth);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.comboBoxLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Authorisation";
            this.Text = "Authorisation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboBoxLogin;
        public System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonOkAuth;
        private System.Windows.Forms.Button buttonCancelAuth;
    }
}