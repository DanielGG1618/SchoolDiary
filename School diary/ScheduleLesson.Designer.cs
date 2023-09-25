namespace School_diary
{
    partial class ScheduleLesson
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
            this._checkBox = new System.Windows.Forms.CheckBox();
            this._numLabel = new System.Windows.Forms.Label();
            this._textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _checkBox
            // 
            this._checkBox.BackColor = System.Drawing.SystemColors.Control;
            this._checkBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._checkBox.Checked = true;
            this._checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBox.Dock = System.Windows.Forms.DockStyle.Left;
            this._checkBox.Location = new System.Drawing.Point(0, 0);
            this._checkBox.Name = "_checkBox";
            this._checkBox.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this._checkBox.Size = new System.Drawing.Size(18, 26);
            this._checkBox.TabIndex = 10;
            this._checkBox.UseVisualStyleBackColor = false;
            this._checkBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // _numLabel
            // 
            this._numLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this._numLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._numLabel.Location = new System.Drawing.Point(18, 0);
            this._numLabel.Margin = new System.Windows.Forms.Padding(0);
            this._numLabel.Name = "_numLabel";
            this._numLabel.Size = new System.Drawing.Size(25, 26);
            this._numLabel.TabIndex = 11;
            this._numLabel.Text = "1";
            // 
            // _textBox
            // 
            this._textBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Алгебра",
            "Английский язык",
            "Информатика",
            "Физика",
            "Химия",
            "Биология",
            "История",
            "Обществознание",
            "Геометрия",
            "Физкультура",
            "География",
            "Индивидуальный проект",
            "Русский язык",
            "Родной язык",
            "Литература",
            "Англ/Инфа",
            "ОБЖ",
            "Математика"});
            this._textBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this._textBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this._textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this._textBox.Location = new System.Drawing.Point(43, 0);
            this._textBox.Name = "_textBox";
            this._textBox.Size = new System.Drawing.Size(217, 39);
            this._textBox.TabIndex = 12;
            // 
            // ScheduleLesson
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this._textBox);
            this.Controls.Add(this._numLabel);
            this.Controls.Add(this._checkBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(260, 26);
            this.MinimumSize = new System.Drawing.Size(260, 26);
            this.Name = "ScheduleLesson";
            this.Size = new System.Drawing.Size(260, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox _checkBox;
        private System.Windows.Forms.Label _numLabel;
        private System.Windows.Forms.TextBox _textBox;
    }
}
