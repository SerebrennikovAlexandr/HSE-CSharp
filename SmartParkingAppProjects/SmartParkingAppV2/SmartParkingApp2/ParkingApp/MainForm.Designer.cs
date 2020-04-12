namespace ParkingApp
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textActiveSession = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textCompletedSessions = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Magneto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Welcome, ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Your active session:";
            // 
            // textActiveSession
            // 
            this.textActiveSession.AcceptsReturn = true;
            this.textActiveSession.AcceptsTab = true;
            this.textActiveSession.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textActiveSession.Location = new System.Drawing.Point(12, 95);
            this.textActiveSession.Multiline = true;
            this.textActiveSession.Name = "textActiveSession";
            this.textActiveSession.ReadOnly = true;
            this.textActiveSession.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textActiveSession.Size = new System.Drawing.Size(432, 90);
            this.textActiveSession.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Your completed sessions:";
            // 
            // textCompletedSessions
            // 
            this.textCompletedSessions.AcceptsReturn = true;
            this.textCompletedSessions.AcceptsTab = true;
            this.textCompletedSessions.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textCompletedSessions.Location = new System.Drawing.Point(12, 253);
            this.textCompletedSessions.Multiline = true;
            this.textCompletedSessions.Name = "textCompletedSessions";
            this.textCompletedSessions.ReadOnly = true;
            this.textCompletedSessions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textCompletedSessions.Size = new System.Drawing.Size(432, 168);
            this.textCompletedSessions.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(462, 433);
            this.Controls.Add(this.textCompletedSessions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textActiveSession);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parking App Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textActiveSession;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCompletedSessions;
    }
}