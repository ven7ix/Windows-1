namespace WindowsFormsApp1
{
    partial class NewRecord
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
            this.personCardNumber = new System.Windows.Forms.TextBox();
            this.personName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.personBirthday = new System.Windows.Forms.DateTimePicker();
            this.buttonDeny = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // personCardNumber
            // 
            this.personCardNumber.Location = new System.Drawing.Point(80, 73);
            this.personCardNumber.Name = "personCardNumber";
            this.personCardNumber.Size = new System.Drawing.Size(289, 20);
            this.personCardNumber.TabIndex = 0;
            // 
            // personName
            // 
            this.personName.Location = new System.Drawing.Point(80, 168);
            this.personName.Name = "personName";
            this.personName.Size = new System.Drawing.Size(289, 20);
            this.personName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "CardNumber";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Birthday";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(429, 325);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(110, 64);
            this.buttonAccept.TabIndex = 7;
            this.buttonAccept.Text = "ok";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // personBirthday
            // 
            this.personBirthday.Location = new System.Drawing.Point(80, 277);
            this.personBirthday.Name = "personBirthday";
            this.personBirthday.Size = new System.Drawing.Size(180, 20);
            this.personBirthday.TabIndex = 8;
            // 
            // buttonDeny
            // 
            this.buttonDeny.Location = new System.Drawing.Point(582, 323);
            this.buttonDeny.Name = "buttonDeny";
            this.buttonDeny.Size = new System.Drawing.Size(113, 65);
            this.buttonDeny.TabIndex = 9;
            this.buttonDeny.Text = "nope";
            this.buttonDeny.UseVisualStyleBackColor = true;
            this.buttonDeny.Click += new System.EventHandler(this.buttonDeny_Click);
            // 
            // NewRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDeny);
            this.Controls.Add(this.personBirthday);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.personName);
            this.Controls.Add(this.personCardNumber);
            this.KeyPreview = true;
            this.Name = "NewRecord";
            this.Text = "newRecord";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewRecord_KeyDown_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonDeny;
        public System.Windows.Forms.TextBox personName;
        public System.Windows.Forms.DateTimePicker personBirthday;
        public System.Windows.Forms.TextBox personCardNumber;
    }
}