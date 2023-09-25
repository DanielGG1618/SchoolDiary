namespace School_diary
{
    partial class Main
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
            this._topBarLeft = new System.Windows.Forms.Panel();
            this._cornerPicture = new System.Windows.Forms.PictureBox();
            this._menuPanel = new System.Windows.Forms.Panel();
            this._adminButton = new FontAwesome.Sharp.IconButton();
            this._settingsButton = new FontAwesome.Sharp.IconButton();
            this._allTasksButton = new FontAwesome.Sharp.IconButton();
            this._dayViewButton = new FontAwesome.Sharp.IconButton();
            this._cornerPanel = new System.Windows.Forms.Panel();
            this._topBar = new System.Windows.Forms.Panel();
            this._topBarShadow = new System.Windows.Forms.Panel();
            this._minimizeButton = new FontAwesome.Sharp.IconButton();
            this._maximizeButton = new FontAwesome.Sharp.IconButton();
            this._closeButton = new FontAwesome.Sharp.IconButton();
            this._formTitleLable = new System.Windows.Forms.Label();
            this._desktopPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._cornerPicture)).BeginInit();
            this._menuPanel.SuspendLayout();
            this._cornerPanel.SuspendLayout();
            this._topBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // _topBarLeft
            // 
            this._topBarLeft.BackColor = System.Drawing.Color.Transparent;
            this._topBarLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this._topBarLeft.Location = new System.Drawing.Point(0, 0);
            this._topBarLeft.Name = "_topBarLeft";
            this._topBarLeft.Size = new System.Drawing.Size(220, 50);
            this._topBarLeft.TabIndex = 0;
            this._topBarLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopBarMouseDown);
            // 
            // _cornerPicture
            // 
            this._cornerPicture.Enabled = false;
            this._cornerPicture.Location = new System.Drawing.Point(10, 10);
            this._cornerPicture.Name = "_cornerPicture";
            this._cornerPicture.Size = new System.Drawing.Size(200, 80);
            this._cornerPicture.TabIndex = 1;
            this._cornerPicture.TabStop = false;
            // 
            // _menuPanel
            // 
            this._menuPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this._menuPanel.Controls.Add(this._adminButton);
            this._menuPanel.Controls.Add(this._settingsButton);
            this._menuPanel.Controls.Add(this._allTasksButton);
            this._menuPanel.Controls.Add(this._dayViewButton);
            this._menuPanel.Controls.Add(this._cornerPanel);
            this._menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this._menuPanel.Location = new System.Drawing.Point(0, 0);
            this._menuPanel.MinimumSize = new System.Drawing.Size(0, 420);
            this._menuPanel.Name = "_menuPanel";
            this._menuPanel.Size = new System.Drawing.Size(220, 654);
            this._menuPanel.TabIndex = 0;
            // 
            // _adminButton
            // 
            this._adminButton.Dock = System.Windows.Forms.DockStyle.Top;
            this._adminButton.FlatAppearance.BorderSize = 0;
            this._adminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._adminButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._adminButton.IconChar = FontAwesome.Sharp.IconChar.Toolbox;
            this._adminButton.IconColor = System.Drawing.Color.Black;
            this._adminButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._adminButton.IconSize = 40;
            this._adminButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._adminButton.Location = new System.Drawing.Point(0, 340);
            this._adminButton.Margin = new System.Windows.Forms.Padding(0);
            this._adminButton.Name = "_adminButton";
            this._adminButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this._adminButton.Size = new System.Drawing.Size(220, 80);
            this._adminButton.TabIndex = 4;
            this._adminButton.Tag = "admin";
            this._adminButton.Text = "Админка";
            this._adminButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._adminButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._adminButton.UseVisualStyleBackColor = true;
            this._adminButton.Click += new System.EventHandler(this.ActivateButton);
            // 
            // _settingsButton
            // 
            this._settingsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this._settingsButton.FlatAppearance.BorderSize = 0;
            this._settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._settingsButton.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this._settingsButton.IconColor = System.Drawing.Color.Black;
            this._settingsButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._settingsButton.IconSize = 40;
            this._settingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._settingsButton.Location = new System.Drawing.Point(0, 260);
            this._settingsButton.Margin = new System.Windows.Forms.Padding(0);
            this._settingsButton.Name = "_settingsButton";
            this._settingsButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this._settingsButton.Size = new System.Drawing.Size(220, 80);
            this._settingsButton.TabIndex = 3;
            this._settingsButton.Tag = "options";
            this._settingsButton.Text = "Настройки";
            this._settingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._settingsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._settingsButton.UseVisualStyleBackColor = true;
            this._settingsButton.Click += new System.EventHandler(this.ActivateButton);
            // 
            // _allTasksButton
            // 
            this._allTasksButton.Dock = System.Windows.Forms.DockStyle.Top;
            this._allTasksButton.FlatAppearance.BorderSize = 0;
            this._allTasksButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._allTasksButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._allTasksButton.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this._allTasksButton.IconColor = System.Drawing.Color.Black;
            this._allTasksButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._allTasksButton.IconSize = 40;
            this._allTasksButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._allTasksButton.Location = new System.Drawing.Point(0, 180);
            this._allTasksButton.Margin = new System.Windows.Forms.Padding(0);
            this._allTasksButton.Name = "_allTasksButton";
            this._allTasksButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this._allTasksButton.Size = new System.Drawing.Size(220, 80);
            this._allTasksButton.TabIndex = 2;
            this._allTasksButton.Tag = "allTasks";
            this._allTasksButton.Text = "Задания";
            this._allTasksButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._allTasksButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._allTasksButton.UseVisualStyleBackColor = true;
            this._allTasksButton.Click += new System.EventHandler(this.ActivateButton);
            // 
            // _dayViewButton
            // 
            this._dayViewButton.Dock = System.Windows.Forms.DockStyle.Top;
            this._dayViewButton.FlatAppearance.BorderSize = 0;
            this._dayViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._dayViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._dayViewButton.IconChar = FontAwesome.Sharp.IconChar.Book;
            this._dayViewButton.IconColor = System.Drawing.Color.Black;
            this._dayViewButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._dayViewButton.IconSize = 40;
            this._dayViewButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._dayViewButton.Location = new System.Drawing.Point(0, 100);
            this._dayViewButton.Margin = new System.Windows.Forms.Padding(0);
            this._dayViewButton.Name = "_dayViewButton";
            this._dayViewButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this._dayViewButton.Size = new System.Drawing.Size(220, 80);
            this._dayViewButton.TabIndex = 1;
            this._dayViewButton.Tag = "dayView";
            this._dayViewButton.Text = "Расписание";
            this._dayViewButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._dayViewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._dayViewButton.UseVisualStyleBackColor = true;
            this._dayViewButton.Click += new System.EventHandler(this.ActivateButton);
            // 
            // _cornerPanel
            // 
            this._cornerPanel.Controls.Add(this._cornerPicture);
            this._cornerPanel.Controls.Add(this._topBarLeft);
            this._cornerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._cornerPanel.Location = new System.Drawing.Point(0, 0);
            this._cornerPanel.Name = "_cornerPanel";
            this._cornerPanel.Size = new System.Drawing.Size(220, 100);
            this._cornerPanel.TabIndex = 0;
            this._cornerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopBarMouseDown);
            // 
            // _topBar
            // 
            this._topBar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this._topBar.Controls.Add(this._topBarShadow);
            this._topBar.Controls.Add(this._minimizeButton);
            this._topBar.Controls.Add(this._maximizeButton);
            this._topBar.Controls.Add(this._closeButton);
            this._topBar.Controls.Add(this._formTitleLable);
            this._topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this._topBar.Location = new System.Drawing.Point(220, 0);
            this._topBar.Name = "_topBar";
            this._topBar.Size = new System.Drawing.Size(938, 50);
            this._topBar.TabIndex = 2;
            this._topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopBarMouseDown);
            // 
            // _topBarShadow
            // 
            this._topBarShadow.BackColor = System.Drawing.SystemColors.ControlDark;
            this._topBarShadow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._topBarShadow.Enabled = false;
            this._topBarShadow.Location = new System.Drawing.Point(0, 43);
            this._topBarShadow.Name = "_topBarShadow";
            this._topBarShadow.Size = new System.Drawing.Size(938, 7);
            this._topBarShadow.TabIndex = 2;
            // 
            // _minimizeButton
            // 
            this._minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._minimizeButton.BackColor = System.Drawing.Color.Transparent;
            this._minimizeButton.FlatAppearance.BorderSize = 0;
            this._minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._minimizeButton.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this._minimizeButton.IconColor = System.Drawing.Color.Black;
            this._minimizeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._minimizeButton.IconSize = 24;
            this._minimizeButton.Location = new System.Drawing.Point(866, 0);
            this._minimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this._minimizeButton.Name = "_minimizeButton";
            this._minimizeButton.Size = new System.Drawing.Size(24, 24);
            this._minimizeButton.TabIndex = 1;
            this._minimizeButton.UseVisualStyleBackColor = false;
            this._minimizeButton.Click += new System.EventHandler(this.MinimizeButtonClick);
            // 
            // _maximizeButton
            // 
            this._maximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._maximizeButton.BackColor = System.Drawing.Color.Transparent;
            this._maximizeButton.FlatAppearance.BorderSize = 0;
            this._maximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._maximizeButton.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this._maximizeButton.IconColor = System.Drawing.Color.Black;
            this._maximizeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._maximizeButton.IconSize = 24;
            this._maximizeButton.Location = new System.Drawing.Point(890, 0);
            this._maximizeButton.Margin = new System.Windows.Forms.Padding(0);
            this._maximizeButton.Name = "_maximizeButton";
            this._maximizeButton.Size = new System.Drawing.Size(24, 24);
            this._maximizeButton.TabIndex = 1;
            this._maximizeButton.UseVisualStyleBackColor = false;
            this._maximizeButton.Click += new System.EventHandler(this.MaximizeButtonClick);
            // 
            // _closeButton
            // 
            this._closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._closeButton.BackColor = System.Drawing.Color.Transparent;
            this._closeButton.FlatAppearance.BorderSize = 0;
            this._closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._closeButton.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this._closeButton.IconColor = System.Drawing.Color.Black;
            this._closeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._closeButton.IconSize = 24;
            this._closeButton.Location = new System.Drawing.Point(914, 0);
            this._closeButton.Margin = new System.Windows.Forms.Padding(0);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(24, 24);
            this._closeButton.TabIndex = 1;
            this._closeButton.UseVisualStyleBackColor = false;
            this._closeButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // _formTitleLable
            // 
            this._formTitleLable.BackColor = System.Drawing.Color.Transparent;
            this._formTitleLable.Dock = System.Windows.Forms.DockStyle.Top;
            this._formTitleLable.Enabled = false;
            this._formTitleLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._formTitleLable.ForeColor = System.Drawing.Color.Black;
            this._formTitleLable.Location = new System.Drawing.Point(0, 0);
            this._formTitleLable.Name = "_formTitleLable";
            this._formTitleLable.Size = new System.Drawing.Size(938, 43);
            this._formTitleLable.TabIndex = 0;
            this._formTitleLable.Text = "label1";
            this._formTitleLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _desktopPanel
            // 
            this._desktopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._desktopPanel.Location = new System.Drawing.Point(220, 50);
            this._desktopPanel.Name = "_desktopPanel";
            this._desktopPanel.Size = new System.Drawing.Size(938, 604);
            this._desktopPanel.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1158, 654);
            this.ControlBox = false;
            this.Controls.Add(this._desktopPanel);
            this.Controls.Add(this._topBar);
            this.Controls.Add(this._menuPanel);
            this.MinimumSize = new System.Drawing.Size(500, 340);
            this.Name = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainKeyDown);
            this.Resize += new System.EventHandler(this.OnResize);
            ((System.ComponentModel.ISupportInitialize)(this._cornerPicture)).EndInit();
            this._menuPanel.ResumeLayout(false);
            this._cornerPanel.ResumeLayout(false);
            this._topBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel _menuPanel;
        private FontAwesome.Sharp.IconButton _adminButton;
        private FontAwesome.Sharp.IconButton _settingsButton;
        private FontAwesome.Sharp.IconButton _allTasksButton;
        private FontAwesome.Sharp.IconButton _dayViewButton;
        private System.Windows.Forms.Panel _cornerPanel;
        private System.Windows.Forms.Panel _topBar;
        private FontAwesome.Sharp.IconButton _closeButton;
        private System.Windows.Forms.Label _formTitleLable;
        private System.Windows.Forms.Panel _desktopPanel;
        private FontAwesome.Sharp.IconButton _minimizeButton;
        private FontAwesome.Sharp.IconButton _maximizeButton;
        private System.Windows.Forms.Panel _topBarShadow;
        private System.Windows.Forms.Panel _topBarLeft;
        private System.Windows.Forms.PictureBox _cornerPicture;
    }
}

