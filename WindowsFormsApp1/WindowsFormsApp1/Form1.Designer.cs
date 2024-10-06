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
            this.dataGridViewPeople = new System.Windows.Forms.DataGridView();
            this.ButtonNewDependence = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDeleteRecord
            // 
            this.buttonDeleteRecord.Location = new System.Drawing.Point(403, 322);
            this.buttonDeleteRecord.Name = "buttonDeleteRecord";
            this.buttonDeleteRecord.Size = new System.Drawing.Size(181, 102);
            this.buttonDeleteRecord.TabIndex = 0;
            this.buttonDeleteRecord.Text = "delete";
            this.buttonDeleteRecord.UseVisualStyleBackColor = true;
            this.buttonDeleteRecord.Click += new System.EventHandler(this.ButtonDeleteRecord_Click);
            // 
            // buttonEditRecord
            // 
            this.buttonEditRecord.Location = new System.Drawing.Point(216, 322);
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
            // dataGridViewPeople
            // 
            this.dataGridViewPeople.AllowUserToAddRows = false;
            this.dataGridViewPeople.AllowUserToDeleteRows = false;
            this.dataGridViewPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPeople.Location = new System.Drawing.Point(29, 41);
            this.dataGridViewPeople.MultiSelect = false;
            this.dataGridViewPeople.Name = "dataGridViewPeople";
            this.dataGridViewPeople.Size = new System.Drawing.Size(742, 212);
            this.dataGridViewPeople.TabIndex = 11;
            this.dataGridViewPeople.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridViewPeople_CellBeginEdit);
            this.dataGridViewPeople.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewPeople_CellEndEdit);
            this.dataGridViewPeople.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewPeople_CellMouseClick);
            // 
            // ButtonNewDependence
            // 
            this.ButtonNewDependence.Location = new System.Drawing.Point(590, 322);
            this.ButtonNewDependence.Name = "ButtonNewDependence";
            this.ButtonNewDependence.Size = new System.Drawing.Size(181, 102);
            this.ButtonNewDependence.TabIndex = 12;
            this.ButtonNewDependence.Text = "new dependence";
            this.ButtonNewDependence.UseVisualStyleBackColor = true;
            this.ButtonNewDependence.Click += new System.EventHandler(this.ButtonNewDependence_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonNewDependence);
            this.Controls.Add(this.dataGridViewPeople);
            this.Controls.Add(this.buttonNewRecord);
            this.Controls.Add(this.buttonEditRecord);
            this.Controls.Add(this.buttonDeleteRecord);
            this.Name = "Form1";
            this.Text = "People list";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeople)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDeleteRecord;
        private System.Windows.Forms.Button buttonEditRecord;
        private System.Windows.Forms.Button buttonNewRecord;
        private System.Windows.Forms.DataGridView dataGridViewPeople;
        private System.Windows.Forms.Button ButtonNewDependence;
    }
}

