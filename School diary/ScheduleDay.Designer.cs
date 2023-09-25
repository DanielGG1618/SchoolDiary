namespace School_diary
{
    partial class ScheduleDay
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._dayOfWeekLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _dayOfWeekLabel
            // 
            this._dayOfWeekLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dayOfWeekLabel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this._dayOfWeekLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._dayOfWeekLabel.Location = new System.Drawing.Point(0, 0);
            this._dayOfWeekLabel.Name = "_dayOfWeekLabel";
            this._dayOfWeekLabel.Size = new System.Drawing.Size(260, 26);
            this._dayOfWeekLabel.TabIndex = 4;
            this._dayOfWeekLabel.Text = "Понедельник";
            this._dayOfWeekLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScheduleDay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this._dayOfWeekLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(260, 260);
            this.MinimumSize = new System.Drawing.Size(260, 260);
            this.Name = "ScheduleDay";
            this.Size = new System.Drawing.Size(260, 260);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label _dayOfWeekLabel;
    }
}
