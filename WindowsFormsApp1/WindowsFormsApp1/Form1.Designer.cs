namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDeleteRecord = new System.Windows.Forms.Button();
            this.buttonEditRecord = new System.Windows.Forms.Button();
            this.buttonNewRecord = new System.Windows.Forms.Button();
            this.peopleList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonDeleteRecord
            // 
            this.buttonDeleteRecord.Location = new System.Drawing.Point(550, 322);
            this.buttonDeleteRecord.Name = "buttonDeleteRecord";
            this.buttonDeleteRecord.Size = new System.Drawing.Size(181, 102);
            this.buttonDeleteRecord.TabIndex = 0;
            this.buttonDeleteRecord.Text = "delete";
            this.buttonDeleteRecord.UseVisualStyleBackColor = true;
            this.buttonDeleteRecord.Click += new System.EventHandler(this.ButtonDeleteRecord_Click);
            // 
            // buttonEditRecord
            // 
            this.buttonEditRecord.Location = new System.Drawing.Point(292, 322);
            this.buttonEditRecord.Name = "buttonEditRecord";
            this.buttonEditRecord.Size = new System.Drawing.Size(181, 102);
            this.buttonEditRecord.TabIndex = 8;
            this.buttonEditRecord.Text = "edit";
            this.buttonEditRecord.UseVisualStyleBackColor = true;
            this.buttonEditRecord.Click += new System.EventHandler(this.ButtonEditRecord_Click);
            // 
            // buttonNewRecord
            // 
            this.buttonNewRecord.Location = new System.Drawing.Point(29, 322);
            this.buttonNewRecord.Name = "buttonNewRecord";
            this.buttonNewRecord.Size = new System.Drawing.Size(181, 102);
            this.buttonNewRecord.TabIndex = 9;
            this.buttonNewRecord.Text = "create";
            this.buttonNewRecord.UseVisualStyleBackColor = true;
            this.buttonNewRecord.Click += new System.EventHandler(this.ButtonNewRecord_Click);
            // 
            // peopleList
            // 
            this.peopleList.FormattingEnabled = true;
            this.peopleList.Location = new System.Drawing.Point(86, 41);
            this.peopleList.Name = "peopleList";
            this.peopleList.Size = new System.Drawing.Size(586, 212);
            this.peopleList.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.peopleList);
            this.Controls.Add(this.buttonNewRecord);
            this.Controls.Add(this.buttonEditRecord);
            this.Controls.Add(this.buttonDeleteRecord);
            this.Name = "Form1";
            this.Text = "People list";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDeleteRecord;
        private System.Windows.Forms.Button buttonEditRecord;
        private System.Windows.Forms.Button buttonNewRecord;
        public System.Windows.Forms.ListBox peopleList;
    }
}

