namespace AdminApplication
{
    partial class AdminForm
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
            this.textBoxPercent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textCurrentSessions = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textPastSessions = new System.Windows.Forms.RichTextBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.countBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textIncome = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxPercent
            // 
            this.textBoxPercent.Location = new System.Drawing.Point(259, 100);
            this.textBoxPercent.Name = "textBoxPercent";
            this.textBoxPercent.ReadOnly = true;
            this.textBoxPercent.Size = new System.Drawing.Size(124, 22);
            this.textBoxPercent.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.label4.Location = new System.Drawing.Point(210, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(258, 31);
            this.label4.TabIndex = 13;
            this.label4.Text = "Parking administration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = " - Percent of filled spaces:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F);
            this.label2.Location = new System.Drawing.Point(11, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 27);
            this.label2.TabIndex = 15;
            this.label2.Text = "Current state of a parking lot";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(12, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = " - Current parking sessions:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F);
            this.label5.Location = new System.Drawing.Point(12, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 27);
            this.label5.TabIndex = 18;
            this.label5.Text = "Check statistics";
            // 
            // textCurrentSessions
            // 
            this.textCurrentSessions.Location = new System.Drawing.Point(259, 136);
            this.textCurrentSessions.Name = "textCurrentSessions";
            this.textCurrentSessions.ReadOnly = true;
            this.textCurrentSessions.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textCurrentSessions.Size = new System.Drawing.Size(411, 96);
            this.textCurrentSessions.TabIndex = 19;
            this.textCurrentSessions.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(13, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = " - Total income:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(12, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = " - Past parking sessions:";
            // 
            // textPastSessions
            // 
            this.textPastSessions.Location = new System.Drawing.Point(259, 271);
            this.textPastSessions.Name = "textPastSessions";
            this.textPastSessions.ReadOnly = true;
            this.textPastSessions.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textPastSessions.Size = new System.Drawing.Size(411, 96);
            this.textPastSessions.TabIndex = 22;
            this.textPastSessions.Text = "";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(88, 423);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(165, 22);
            this.dateTimePickerStart.TabIndex = 23;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(88, 451);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(165, 22);
            this.dateTimePickerEnd.TabIndex = 24;
            // 
            // countBtn
            // 
            this.countBtn.Location = new System.Drawing.Point(88, 479);
            this.countBtn.Name = "countBtn";
            this.countBtn.Size = new System.Drawing.Size(165, 32);
            this.countBtn.TabIndex = 25;
            this.countBtn.Text = "Count";
            this.countBtn.UseVisualStyleBackColor = true;
            this.countBtn.Click += new System.EventHandler(this.countBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(32, 425);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 20);
            this.label8.TabIndex = 26;
            this.label8.Text = "Start:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(32, 453);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "End:";
            // 
            // textIncome
            // 
            this.textIncome.Location = new System.Drawing.Point(144, 385);
            this.textIncome.Name = "textIncome";
            this.textIncome.ReadOnly = true;
            this.textIncome.Size = new System.Drawing.Size(124, 22);
            this.textIncome.TabIndex = 28;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(682, 513);
            this.Controls.Add(this.textIncome);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.countBtn);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.textPastSessions);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textCurrentSessions);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPercent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPercent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox textCurrentSessions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox textPastSessions;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Button countBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textIncome;
    }
}

