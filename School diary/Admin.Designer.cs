namespace School_diary
{
    partial class Admin
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
            this._schedulePanel = new System.Windows.Forms.Panel();
            this._scheduleLabel = new System.Windows.Forms.Label();
            this._saveScheduleButton = new FontAwesome.Sharp.IconButton();
            this._addHolidaysLabel = new System.Windows.Forms.Label();
            this._fromLabel = new System.Windows.Forms.Label();
            this._toLabel = new System.Windows.Forms.Label();
            this._holidayFromPicker = new System.Windows.Forms.DateTimePicker();
            this._holidayToPicker = new System.Windows.Forms.DateTimePicker();
            this._addHolidaysButton = new FontAwesome.Sharp.IconButton();
            this._addHolidaysPanel = new System.Windows.Forms.Panel();
            this._scheduleInnerPanel = new System.Windows.Forms.Panel();
            this._schedulePanel.SuspendLayout();
            this._addHolidaysPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _schedulePanel
            // 
            this._schedulePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._schedulePanel.Controls.Add(this._scheduleInnerPanel);
            this._schedulePanel.Controls.Add(this._scheduleLabel);
            this._schedulePanel.Controls.Add(this._saveScheduleButton);
            this._schedulePanel.Location = new System.Drawing.Point(0, 62);
            this._schedulePanel.Margin = new System.Windows.Forms.Padding(0);
            this._schedulePanel.Name = "_schedulePanel";
            this._schedulePanel.Size = new System.Drawing.Size(537, 328);
            this._schedulePanel.TabIndex = 11;
            // 
            // _scheduleLabel
            // 
            this._scheduleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._scheduleLabel.Location = new System.Drawing.Point(0, 0);
            this._scheduleLabel.Margin = new System.Windows.Forms.Padding(0);
            this._scheduleLabel.Name = "_scheduleLabel";
            this._scheduleLabel.Size = new System.Drawing.Size(477, 60);
            this._scheduleLabel.TabIndex = 10;
            this._scheduleLabel.Text = "Расписание";
            this._scheduleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _saveScheduleButton
            // 
            this._saveScheduleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._saveScheduleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._saveScheduleButton.IconChar = FontAwesome.Sharp.IconChar.Save;
            this._saveScheduleButton.IconColor = System.Drawing.Color.Black;
            this._saveScheduleButton.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this._saveScheduleButton.IconSize = 40;
            this._saveScheduleButton.Location = new System.Drawing.Point(477, 0);
            this._saveScheduleButton.Margin = new System.Windows.Forms.Padding(0);
            this._saveScheduleButton.Name = "_saveScheduleButton";
            this._saveScheduleButton.Size = new System.Drawing.Size(60, 60);
            this._saveScheduleButton.TabIndex = 8;
            this._saveScheduleButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._saveScheduleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._saveScheduleButton.UseVisualStyleBackColor = true;
            this._saveScheduleButton.Click += new System.EventHandler(this.SaveScheduleClick);
            // 
            // _addHolidaysLabel
            // 
            this._addHolidaysLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._addHolidaysLabel.Location = new System.Drawing.Point(0, 0);
            this._addHolidaysLabel.Margin = new System.Windows.Forms.Padding(0);
            this._addHolidaysLabel.Name = "_addHolidaysLabel";
            this._addHolidaysLabel.Size = new System.Drawing.Size(237, 62);
            this._addHolidaysLabel.TabIndex = 0;
            this._addHolidaysLabel.Text = "Добавить выходные";
            this._addHolidaysLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _fromLabel
            // 
            this._fromLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._fromLabel.Location = new System.Drawing.Point(299, 0);
            this._fromLabel.Margin = new System.Windows.Forms.Padding(0);
            this._fromLabel.Name = "_fromLabel";
            this._fromLabel.Size = new System.Drawing.Size(40, 31);
            this._fromLabel.TabIndex = 2;
            this._fromLabel.Text = "от";
            this._fromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _toLabel
            // 
            this._toLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._toLabel.Location = new System.Drawing.Point(299, 31);
            this._toLabel.Margin = new System.Windows.Forms.Padding(0);
            this._toLabel.Name = "_toLabel";
            this._toLabel.Size = new System.Drawing.Size(40, 31);
            this._toLabel.TabIndex = 3;
            this._toLabel.Text = "до";
            this._toLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _holidayFromPicker
            // 
            this._holidayFromPicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._holidayFromPicker.CustomFormat = "dd.MM.yyyy";
            this._holidayFromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._holidayFromPicker.Location = new System.Drawing.Point(339, 0);
            this._holidayFromPicker.Margin = new System.Windows.Forms.Padding(0);
            this._holidayFromPicker.Name = "_holidayFromPicker";
            this._holidayFromPicker.Size = new System.Drawing.Size(198, 31);
            this._holidayFromPicker.TabIndex = 4;
            this._holidayFromPicker.ValueChanged += new System.EventHandler(this.DateFromPickerValueChanged);
            // 
            // _holidayToPicker
            // 
            this._holidayToPicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._holidayToPicker.CustomFormat = "dd.MM.yyyy";
            this._holidayToPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._holidayToPicker.Location = new System.Drawing.Point(339, 31);
            this._holidayToPicker.Margin = new System.Windows.Forms.Padding(0);
            this._holidayToPicker.Name = "_holidayToPicker";
            this._holidayToPicker.Size = new System.Drawing.Size(198, 31);
            this._holidayToPicker.TabIndex = 5;
            this._holidayToPicker.ValueChanged += new System.EventHandler(this.DateToPickerValueChanged);
            // 
            // _addHolidaysButton
            // 
            this._addHolidaysButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._addHolidaysButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._addHolidaysButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._addHolidaysButton.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this._addHolidaysButton.IconColor = System.Drawing.Color.Black;
            this._addHolidaysButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._addHolidaysButton.IconSize = 25;
            this._addHolidaysButton.Location = new System.Drawing.Point(237, 0);
            this._addHolidaysButton.Margin = new System.Windows.Forms.Padding(0);
            this._addHolidaysButton.Name = "_addHolidaysButton";
            this._addHolidaysButton.Size = new System.Drawing.Size(62, 62);
            this._addHolidaysButton.TabIndex = 6;
            this._addHolidaysButton.UseVisualStyleBackColor = false;
            this._addHolidaysButton.Click += new System.EventHandler(this.AddHolidaysButtonClick);
            // 
            // _addHolidaysPanel
            // 
            this._addHolidaysPanel.Controls.Add(this._addHolidaysButton);
            this._addHolidaysPanel.Controls.Add(this._addHolidaysLabel);
            this._addHolidaysPanel.Controls.Add(this._holidayToPicker);
            this._addHolidaysPanel.Controls.Add(this._fromLabel);
            this._addHolidaysPanel.Controls.Add(this._holidayFromPicker);
            this._addHolidaysPanel.Controls.Add(this._toLabel);
            this._addHolidaysPanel.Location = new System.Drawing.Point(0, 0);
            this._addHolidaysPanel.Name = "_addHolidaysPanel";
            this._addHolidaysPanel.Size = new System.Drawing.Size(537, 129);
            this._addHolidaysPanel.TabIndex = 7;
            // 
            // _scheduleInnerPanel
            // 
            this._scheduleInnerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._scheduleInnerPanel.AutoScroll = true;
            this._scheduleInnerPanel.Location = new System.Drawing.Point(0, 60);
            this._scheduleInnerPanel.Margin = new System.Windows.Forms.Padding(0);
            this._scheduleInnerPanel.Name = "_scheduleInnerPanel";
            this._scheduleInnerPanel.Size = new System.Drawing.Size(537, 268);
            this._scheduleInnerPanel.TabIndex = 11;
            // 
            // Admin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this._schedulePanel);
            this.Controls.Add(this._addHolidaysPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(537, 389);
            this.Name = "Admin";
            this.Size = new System.Drawing.Size(537, 389);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this._schedulePanel.ResumeLayout(false);
            this._addHolidaysPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _addHolidaysLabel;
        private System.Windows.Forms.Label _fromLabel;
        private System.Windows.Forms.Label _toLabel;
        private System.Windows.Forms.DateTimePicker _holidayToPicker;
        private FontAwesome.Sharp.IconButton _addHolidaysButton;
        private System.Windows.Forms.Panel _addHolidaysPanel;
        private System.Windows.Forms.DateTimePicker _holidayFromPicker;
        private FontAwesome.Sharp.IconButton _saveScheduleButton;
        private System.Windows.Forms.Label _scheduleLabel;
        private System.Windows.Forms.Panel _schedulePanel;
        private System.Windows.Forms.Panel _scheduleInnerPanel;
    }
}
