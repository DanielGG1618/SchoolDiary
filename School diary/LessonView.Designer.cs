namespace School_diary
{
    partial class LessonView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Panel _topPanel;
            this._titleTextBox = new System.Windows.Forms.TextBox();
            this._checkBox = new System.Windows.Forms.CheckBox();
            this._contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._changeTitleItem = new System.Windows.Forms.ToolStripMenuItem();
            this._changeTaskItem = new System.Windows.Forms.ToolStripMenuItem();
            this._deleteLessonItem = new System.Windows.Forms.ToolStripMenuItem();
            this._copyTaskItem = new System.Windows.Forms.ToolStripMenuItem();
            this._title = new SingleClickLabel();
            this._dateLabel = new SingleClickLabel();
            this._doneButton = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this._taskTextBox = new System.Windows.Forms.TextBox();
            this._numPlusButton = new FontAwesome.Sharp.IconButton();
            this._numMinusButton = new FontAwesome.Sharp.IconButton();
            this._task = new SingleClickLabel();
            this._num = new SingleClickLabel();
            _topPanel = new System.Windows.Forms.Panel();
            _topPanel.SuspendLayout();
            this._contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _topPanel
            // 
            _topPanel.Controls.Add(this._titleTextBox);
            _topPanel.Controls.Add(this._checkBox);
            _topPanel.Controls.Add(this._title);
            _topPanel.Controls.Add(this._dateLabel);
            _topPanel.Controls.Add(this._doneButton);
            _topPanel.Controls.Add(this.panel1);
            _topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            _topPanel.Location = new System.Drawing.Point(50, 0);
            _topPanel.Name = "_topPanel";
            _topPanel.Size = new System.Drawing.Size(466, 25);
            _topPanel.TabIndex = 8;
            // 
            // _titleTextBox
            // 
            this._titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._titleTextBox.AutoCompleteCustomSource.AddRange(new string[] {
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
            "Русский язык",
            "Родной язык",
            "Литература",
            "ОБЖ",
            "Математика"});
            this._titleTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this._titleTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this._titleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.92F);
            this._titleTextBox.Location = new System.Drawing.Point(25, 0);
            this._titleTextBox.Margin = new System.Windows.Forms.Padding(0);
            this._titleTextBox.Name = "_titleTextBox";
            this._titleTextBox.Size = new System.Drawing.Size(416, 25);
            this._titleTextBox.TabIndex = 9;
            this._titleTextBox.Visible = false;
            this._titleTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // _checkBox
            // 
            this._checkBox.BackColor = System.Drawing.Color.Transparent;
            this._checkBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._checkBox.ContextMenuStrip = this._contextMenuStrip;
            this._checkBox.FlatAppearance.BorderSize = 0;
            this._checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._checkBox.Location = new System.Drawing.Point(0, -2);
            this._checkBox.Margin = new System.Windows.Forms.Padding(0);
            this._checkBox.Name = "_checkBox";
            this._checkBox.Size = new System.Drawing.Size(25, 25);
            this._checkBox.TabIndex = 7;
            this._checkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._checkBox.UseVisualStyleBackColor = false;
            this._checkBox.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);
            // 
            // _contextMenuStrip
            // 
            this._contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._changeTitleItem,
            this._changeTaskItem,
            this._deleteLessonItem,
            this._copyTaskItem});
            this._contextMenuStrip.Name = "_contextMenuStrip";
            this._contextMenuStrip.Size = new System.Drawing.Size(193, 92);
            // 
            // _changeTitleItem
            // 
            this._changeTitleItem.Name = "_changeTitleItem";
            this._changeTitleItem.Size = new System.Drawing.Size(192, 22);
            this._changeTitleItem.Text = "Изменить название";
            this._changeTitleItem.Click += new System.EventHandler(this.StartEditTitle);
            // 
            // _changeTaskItem
            // 
            this._changeTaskItem.Name = "_changeTaskItem";
            this._changeTaskItem.Size = new System.Drawing.Size(192, 22);
            this._changeTaskItem.Text = "Изменить задание";
            this._changeTaskItem.Click += new System.EventHandler(this.StartEditTask);
            // 
            // _deleteLessonItem
            // 
            this._deleteLessonItem.Name = "_deleteLessonItem";
            this._deleteLessonItem.Size = new System.Drawing.Size(192, 22);
            this._deleteLessonItem.Text = "Удалить урок";
            this._deleteLessonItem.Click += new System.EventHandler(this.DeleteButtonClick);
            // 
            // _copyTaskItem
            // 
            this._copyTaskItem.Name = "_copyTaskItem";
            this._copyTaskItem.Size = new System.Drawing.Size(192, 22);
            this._copyTaskItem.Text = "Скопировать задание";
            this._copyTaskItem.Click += new System.EventHandler(this.CopyTaskItemClick);
            // 
            // _title
            // 
            this._title.BackColor = System.Drawing.Color.Transparent;
            this._title.CausesValidation = false;
            this._title.ContextMenuStrip = this._contextMenuStrip;
            this._title.Dock = System.Windows.Forms.DockStyle.Fill;
            this._title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this._title.Location = new System.Drawing.Point(0, 0);
            this._title.Margin = new System.Windows.Forms.Padding(0);
            this._title.Name = "_title";
            this._title.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            this._title.Size = new System.Drawing.Size(354, 25);
            this._title.TabIndex = 1;
            this._title.Text = "Если ты это вилишь, то что-то не так";
            this._title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._title.DoubleClick += new System.EventHandler(this.StartEditTitle);
            this._title.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StartEditTitle);
            // 
            // _dateLabel
            // 
            this._dateLabel.BackColor = System.Drawing.Color.Transparent;
            this._dateLabel.CausesValidation = false;
            this._dateLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this._dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this._dateLabel.Location = new System.Drawing.Point(354, 0);
            this._dateLabel.Margin = new System.Windows.Forms.Padding(0);
            this._dateLabel.Name = "_dateLabel";
            this._dateLabel.Size = new System.Drawing.Size(87, 25);
            this._dateLabel.TabIndex = 8;
            this._dateLabel.Text = "21.01 - пт";
            this._dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._dateLabel.Visible = false;
            // 
            // _doneButton
            // 
            this._doneButton.ContextMenuStrip = this._contextMenuStrip;
            this._doneButton.Dock = System.Windows.Forms.DockStyle.Right;
            this._doneButton.FlatAppearance.BorderSize = 0;
            this._doneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._doneButton.IconChar = FontAwesome.Sharp.IconChar.Check;
            this._doneButton.IconColor = System.Drawing.Color.Black;
            this._doneButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._doneButton.IconSize = 20;
            this._doneButton.Location = new System.Drawing.Point(441, 0);
            this._doneButton.Margin = new System.Windows.Forms.Padding(0);
            this._doneButton.Name = "_doneButton";
            this._doneButton.Size = new System.Drawing.Size(25, 25);
            this._doneButton.TabIndex = 5;
            this._doneButton.UseVisualStyleBackColor = true;
            this._doneButton.Visible = false;
            this._doneButton.Click += new System.EventHandler(this.DoneButtonClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(430, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(36, 23);
            this.panel1.TabIndex = 9;
            // 
            // _taskTextBox
            // 
            this._taskTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._taskTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this._taskTextBox.Location = new System.Drawing.Point(50, 25);
            this._taskTextBox.Margin = new System.Windows.Forms.Padding(0);
            this._taskTextBox.Multiline = true;
            this._taskTextBox.Name = "_taskTextBox";
            this._taskTextBox.Size = new System.Drawing.Size(466, 45);
            this._taskTextBox.TabIndex = 4;
            this._taskTextBox.Text = "рандомный текст, который не должно быть видно";
            this._taskTextBox.Visible = false;
            this._taskTextBox.TextChanged += new System.EventHandler(this.TaskTextBoxTextChanged);
            this._taskTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // _numPlusButton
            // 
            this._numPlusButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this._numPlusButton.FlatAppearance.BorderSize = 0;
            this._numPlusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._numPlusButton.IconChar = FontAwesome.Sharp.IconChar.AngleDown;
            this._numPlusButton.IconColor = System.Drawing.Color.Black;
            this._numPlusButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._numPlusButton.IconSize = 18;
            this._numPlusButton.Location = new System.Drawing.Point(0, 0);
            this._numPlusButton.Margin = new System.Windows.Forms.Padding(0);
            this._numPlusButton.Name = "_numPlusButton";
            this._numPlusButton.Rotation = 180D;
            this._numPlusButton.Size = new System.Drawing.Size(50, 14);
            this._numPlusButton.TabIndex = 9;
            this._numPlusButton.UseVisualStyleBackColor = false;
            this._numPlusButton.Click += new System.EventHandler(this.NumPlusButtonClick);
            this._numPlusButton.MouseEnter += new System.EventHandler(this.MouseEnterNum);
            this._numPlusButton.MouseLeave += new System.EventHandler(this.MouseLeaveNum);
            // 
            // _numMinusButton
            // 
            this._numMinusButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this._numMinusButton.FlatAppearance.BorderSize = 0;
            this._numMinusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._numMinusButton.IconChar = FontAwesome.Sharp.IconChar.AngleDown;
            this._numMinusButton.IconColor = System.Drawing.Color.Black;
            this._numMinusButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._numMinusButton.IconSize = 18;
            this._numMinusButton.Location = new System.Drawing.Point(0, 56);
            this._numMinusButton.Margin = new System.Windows.Forms.Padding(0);
            this._numMinusButton.Name = "_numMinusButton";
            this._numMinusButton.Size = new System.Drawing.Size(50, 14);
            this._numMinusButton.TabIndex = 10;
            this._numMinusButton.UseVisualStyleBackColor = false;
            this._numMinusButton.Click += new System.EventHandler(this.NumMinusButtonClick);
            this._numMinusButton.MouseEnter += new System.EventHandler(this.MouseEnterNum);
            this._numMinusButton.MouseLeave += new System.EventHandler(this.MouseLeaveNum);
            // 
            // _task
            // 
            this._task.ContextMenuStrip = this._contextMenuStrip;
            this._task.Dock = System.Windows.Forms.DockStyle.Fill;
            this._task.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._task.Location = new System.Drawing.Point(50, 25);
            this._task.Margin = new System.Windows.Forms.Padding(0);
            this._task.Name = "_task";
            this._task.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this._task.Size = new System.Drawing.Size(466, 45);
            this._task.TabIndex = 2;
            this._task.Text = "label3";
            this._task.DoubleClick += new System.EventHandler(this.StartEditTask);
            this._task.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StartEditTask);
            // 
            // _num
            // 
            this._num.BackColor = System.Drawing.SystemColors.ControlLight;
            this._num.ContextMenuStrip = this._contextMenuStrip;
            this._num.Dock = System.Windows.Forms.DockStyle.Left;
            this._num.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._num.Location = new System.Drawing.Point(0, 0);
            this._num.Name = "_num";
            this._num.Size = new System.Drawing.Size(50, 70);
            this._num.TabIndex = 0;
            this._num.Text = "1";
            this._num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._num.MouseEnter += new System.EventHandler(this.MouseEnterNum);
            this._num.MouseLeave += new System.EventHandler(this.MouseLeaveNum);
            // 
            // LessonView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this._numMinusButton);
            this.Controls.Add(this._numPlusButton);
            this.Controls.Add(this._taskTextBox);
            this.Controls.Add(this._task);
            this.Controls.Add(_topPanel);
            this.Controls.Add(this._num);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LessonView";
            this.Size = new System.Drawing.Size(516, 70);
            _topPanel.ResumeLayout(false);
            _topPanel.PerformLayout();
            this._contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SingleClickLabel _task;
        private System.Windows.Forms.TextBox _taskTextBox;
        private FontAwesome.Sharp.IconButton _doneButton;
        private SingleClickLabel _title;
        private System.Windows.Forms.CheckBox _checkBox;
        private SingleClickLabel _dateLabel;
        private SingleClickLabel _num;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox _titleTextBox;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _changeTitleItem;
        private System.Windows.Forms.ToolStripMenuItem _changeTaskItem;
        private System.Windows.Forms.ToolStripMenuItem _deleteLessonItem;
        private System.Windows.Forms.ToolStripMenuItem _copyTaskItem;
        private FontAwesome.Sharp.IconButton _numPlusButton;
        private FontAwesome.Sharp.IconButton _numMinusButton;
    }
}
