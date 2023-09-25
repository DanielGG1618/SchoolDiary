namespace School_diary
{
    partial class DayView
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
            System.Windows.Forms.Panel _topBarPanel;
            this._addLessonButton = new FontAwesome.Sharp.IconButton();
            this._datePlusButton = new FontAwesome.Sharp.IconButton();
            this._dateMinusButton = new FontAwesome.Sharp.IconButton();
            this._copyButton = new FontAwesome.Sharp.IconButton();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._stripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._dateButtonsButton = new System.Windows.Forms.ToolStripMenuItem();
            this._copyButtonButton = new System.Windows.Forms.ToolStripMenuItem();
            this._dateLabel = new System.Windows.Forms.Label();
            _topBarPanel = new System.Windows.Forms.Panel();
            _topBarPanel.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _topBarPanel
            // 
            _topBarPanel.Controls.Add(this._addLessonButton);
            _topBarPanel.Controls.Add(this._datePlusButton);
            _topBarPanel.Controls.Add(this._dateMinusButton);
            _topBarPanel.Controls.Add(this._copyButton);
            _topBarPanel.Controls.Add(this._menuStrip);
            _topBarPanel.Controls.Add(this._dateLabel);
            _topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            _topBarPanel.Location = new System.Drawing.Point(0, 0);
            _topBarPanel.Name = "_topBarPanel";
            _topBarPanel.Size = new System.Drawing.Size(607, 50);
            _topBarPanel.TabIndex = 5;
            // 
            // _addLessonButton
            // 
            this._addLessonButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._addLessonButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._addLessonButton.FlatAppearance.BorderSize = 0;
            this._addLessonButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._addLessonButton.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this._addLessonButton.IconColor = System.Drawing.Color.Black;
            this._addLessonButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._addLessonButton.IconSize = 23;
            this._addLessonButton.Location = new System.Drawing.Point(557, 20);
            this._addLessonButton.Margin = new System.Windows.Forms.Padding(0);
            this._addLessonButton.Name = "_addLessonButton";
            this._addLessonButton.Size = new System.Drawing.Size(50, 30);
            this._addLessonButton.TabIndex = 6;
            this._addLessonButton.UseVisualStyleBackColor = false;
            this._addLessonButton.Click += new System.EventHandler(this.AddLesson);
            // 
            // _datePlusButton
            // 
            this._datePlusButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._datePlusButton.Dock = System.Windows.Forms.DockStyle.Left;
            this._datePlusButton.FlatAppearance.BorderSize = 0;
            this._datePlusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._datePlusButton.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this._datePlusButton.IconColor = System.Drawing.Color.Black;
            this._datePlusButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._datePlusButton.IconSize = 32;
            this._datePlusButton.Location = new System.Drawing.Point(100, 0);
            this._datePlusButton.Margin = new System.Windows.Forms.Padding(0);
            this._datePlusButton.Name = "_datePlusButton";
            this._datePlusButton.Size = new System.Drawing.Size(50, 50);
            this._datePlusButton.TabIndex = 1;
            this._datePlusButton.UseVisualStyleBackColor = false;
            this._datePlusButton.Click += new System.EventHandler(this.DatePlusButtonClick);
            // 
            // _dateMinusButton
            // 
            this._dateMinusButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._dateMinusButton.Dock = System.Windows.Forms.DockStyle.Left;
            this._dateMinusButton.FlatAppearance.BorderSize = 0;
            this._dateMinusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._dateMinusButton.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            this._dateMinusButton.IconColor = System.Drawing.Color.Black;
            this._dateMinusButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._dateMinusButton.IconSize = 32;
            this._dateMinusButton.Location = new System.Drawing.Point(50, 0);
            this._dateMinusButton.Margin = new System.Windows.Forms.Padding(0);
            this._dateMinusButton.Name = "_dateMinusButton";
            this._dateMinusButton.Size = new System.Drawing.Size(50, 50);
            this._dateMinusButton.TabIndex = 1;
            this._dateMinusButton.UseVisualStyleBackColor = false;
            this._dateMinusButton.Click += new System.EventHandler(this.DateMinusButtonClick);
            // 
            // _copyButton
            // 
            this._copyButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._copyButton.Dock = System.Windows.Forms.DockStyle.Left;
            this._copyButton.FlatAppearance.BorderSize = 0;
            this._copyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._copyButton.IconChar = FontAwesome.Sharp.IconChar.Copy;
            this._copyButton.IconColor = System.Drawing.Color.Black;
            this._copyButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._copyButton.IconSize = 32;
            this._copyButton.Location = new System.Drawing.Point(0, 0);
            this._copyButton.Margin = new System.Windows.Forms.Padding(0);
            this._copyButton.Name = "_copyButton";
            this._copyButton.Size = new System.Drawing.Size(50, 50);
            this._copyButton.TabIndex = 1;
            this._copyButton.UseVisualStyleBackColor = false;
            this._copyButton.Click += new System.EventHandler(this.СopyButtonClick);
            // 
            // _menuStrip
            // 
            this._menuStrip.AutoSize = false;
            this._menuStrip.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._menuStrip.Dock = System.Windows.Forms.DockStyle.Right;
            this._menuStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._stripMenu});
            this._menuStrip.Location = new System.Drawing.Point(557, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this._menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._menuStrip.Size = new System.Drawing.Size(50, 50);
            this._menuStrip.TabIndex = 4;
            // 
            // _stripMenu
            // 
            this._stripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._dateButtonsButton,
            this._copyButtonButton});
            this._stripMenu.Name = "_stripMenu";
            this._stripMenu.Size = new System.Drawing.Size(48, 19);
            this._stripMenu.Text = "...";
            // 
            // _dateButtonsButton
            // 
            this._dateButtonsButton.Checked = true;
            this._dateButtonsButton.CheckOnClick = true;
            this._dateButtonsButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this._dateButtonsButton.Name = "_dateButtonsButton";
            this._dateButtonsButton.Size = new System.Drawing.Size(207, 22);
            this._dateButtonsButton.Text = "Кнопки изменения даты";
            this._dateButtonsButton.Click += new System.EventHandler(this.DateButtonsButtonClick);
            // 
            // _copyButtonButton
            // 
            this._copyButtonButton.Checked = true;
            this._copyButtonButton.CheckOnClick = true;
            this._copyButtonButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this._copyButtonButton.Name = "_copyButtonButton";
            this._copyButtonButton.Size = new System.Drawing.Size(207, 22);
            this._copyButtonButton.Text = "Кнопка копирования";
            this._copyButtonButton.Click += new System.EventHandler(this.CopyButtonButtonClick);
            // 
            // _dateLabel
            // 
            this._dateLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._dateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._dateLabel.Location = new System.Drawing.Point(0, 0);
            this._dateLabel.Margin = new System.Windows.Forms.Padding(0);
            this._dateLabel.Name = "_dateLabel";
            this._dateLabel.Size = new System.Drawing.Size(607, 50);
            this._dateLabel.TabIndex = 0;
            this._dateLabel.Text = "01.01.1970 понедельник";
            this._dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DayView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.Controls.Add(_topBarPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DayView";
            this.Size = new System.Drawing.Size(607, 507);
            this.VisibleChanged += new System.EventHandler(this.DayViewVisibleChanged);
            this.Resize += new System.EventHandler(this.OnResize);
            _topBarPanel.ResumeLayout(false);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _dateLabel;
        private FontAwesome.Sharp.IconButton _dateMinusButton;
        private FontAwesome.Sharp.IconButton _datePlusButton;
        private FontAwesome.Sharp.IconButton _copyButton;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _stripMenu;
        private System.Windows.Forms.ToolStripMenuItem _dateButtonsButton;
        private System.Windows.Forms.ToolStripMenuItem _copyButtonButton;
        private FontAwesome.Sharp.IconButton _addLessonButton;
    }
}
