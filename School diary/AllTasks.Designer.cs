namespace School_diary
{
    partial class AllTasks
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
            System.Windows.Forms.Label _allTasksLabel;
            this._checkAllButton = new FontAwesome.Sharp.IconButton();
            this._refreshButton = new FontAwesome.Sharp.IconButton();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._stripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._copyButtonButton = new System.Windows.Forms.ToolStripMenuItem();
            this._refreshButtonButton = new System.Windows.Forms.ToolStripMenuItem();
            this._checkAllButtonButton = new System.Windows.Forms.ToolStripMenuItem();
            this._copyButton = new FontAwesome.Sharp.IconButton();
            this._lessonsPanel = new System.Windows.Forms.Panel();
            _topBarPanel = new System.Windows.Forms.Panel();
            _allTasksLabel = new System.Windows.Forms.Label();
            _topBarPanel.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _topBarPanel
            // 
            _topBarPanel.Controls.Add(this._checkAllButton);
            _topBarPanel.Controls.Add(this._refreshButton);
            _topBarPanel.Controls.Add(this._menuStrip);
            _topBarPanel.Controls.Add(this._copyButton);
            _topBarPanel.Controls.Add(_allTasksLabel);
            _topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            _topBarPanel.Location = new System.Drawing.Point(0, 0);
            _topBarPanel.Name = "_topBarPanel";
            _topBarPanel.Size = new System.Drawing.Size(461, 50);
            _topBarPanel.TabIndex = 6;
            // 
            // _checkAllButton
            // 
            this._checkAllButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._checkAllButton.Dock = System.Windows.Forms.DockStyle.Left;
            this._checkAllButton.FlatAppearance.BorderSize = 0;
            this._checkAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._checkAllButton.IconChar = FontAwesome.Sharp.IconChar.Check;
            this._checkAllButton.IconColor = System.Drawing.Color.Black;
            this._checkAllButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._checkAllButton.IconSize = 40;
            this._checkAllButton.Location = new System.Drawing.Point(100, 0);
            this._checkAllButton.Margin = new System.Windows.Forms.Padding(0);
            this._checkAllButton.Name = "_checkAllButton";
            this._checkAllButton.Size = new System.Drawing.Size(50, 50);
            this._checkAllButton.TabIndex = 6;
            this._checkAllButton.UseVisualStyleBackColor = false;
            this._checkAllButton.Click += new System.EventHandler(this.CheckAllButtonClick);
            // 
            // _refreshButton
            // 
            this._refreshButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._refreshButton.Dock = System.Windows.Forms.DockStyle.Left;
            this._refreshButton.FlatAppearance.BorderSize = 0;
            this._refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._refreshButton.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
            this._refreshButton.IconColor = System.Drawing.Color.Black;
            this._refreshButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._refreshButton.IconSize = 32;
            this._refreshButton.Location = new System.Drawing.Point(50, 0);
            this._refreshButton.Margin = new System.Windows.Forms.Padding(0);
            this._refreshButton.Name = "_refreshButton";
            this._refreshButton.Size = new System.Drawing.Size(50, 50);
            this._refreshButton.TabIndex = 5;
            this._refreshButton.UseVisualStyleBackColor = false;
            this._refreshButton.Click += new System.EventHandler(this.RefreshButtonClick);
            // 
            // _menuStrip
            // 
            this._menuStrip.AutoSize = false;
            this._menuStrip.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._menuStrip.Dock = System.Windows.Forms.DockStyle.Right;
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._stripMenu});
            this._menuStrip.Location = new System.Drawing.Point(411, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._menuStrip.Size = new System.Drawing.Size(50, 50);
            this._menuStrip.TabIndex = 4;
            // 
            // _stripMenu
            // 
            this._stripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._copyButtonButton,
            this._refreshButtonButton,
            this._checkAllButtonButton});
            this._stripMenu.Name = "_stripMenu";
            this._stripMenu.Size = new System.Drawing.Size(43, 19);
            this._stripMenu.Text = "...";
            // 
            // _copyButtonButton
            // 
            this._copyButtonButton.Checked = true;
            this._copyButtonButton.CheckOnClick = true;
            this._copyButtonButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this._copyButtonButton.Name = "_copyButtonButton";
            this._copyButtonButton.Size = new System.Drawing.Size(190, 22);
            this._copyButtonButton.Text = "Кнопка копирования";
            this._copyButtonButton.Click += new System.EventHandler(this.CopyButtonButtonClick);
            // 
            // _refreshButtonButton
            // 
            this._refreshButtonButton.Checked = true;
            this._refreshButtonButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this._refreshButtonButton.Name = "_refreshButtonButton";
            this._refreshButtonButton.Size = new System.Drawing.Size(190, 22);
            this._refreshButtonButton.Text = "Кнопка обновления";
            this._refreshButtonButton.Click += new System.EventHandler(this.RefreshButtonButtonClick);
            // 
            // _checkAllButtonButton
            // 
            this._checkAllButtonButton.Checked = true;
            this._checkAllButtonButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkAllButtonButton.Name = "_checkAllButtonButton";
            this._checkAllButtonButton.Size = new System.Drawing.Size(190, 22);
            this._checkAllButtonButton.Text = "Кнопка отметить все";
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
            // _allTasksLabel
            // 
            _allTasksLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            _allTasksLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            _allTasksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            _allTasksLabel.Location = new System.Drawing.Point(0, 0);
            _allTasksLabel.Margin = new System.Windows.Forms.Padding(0);
            _allTasksLabel.Name = "_allTasksLabel";
            _allTasksLabel.Size = new System.Drawing.Size(461, 50);
            _allTasksLabel.TabIndex = 0;
            _allTasksLabel.Text = "Все задания";
            _allTasksLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lessonsPanel
            // 
            this._lessonsPanel.AutoScroll = true;
            this._lessonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lessonsPanel.Location = new System.Drawing.Point(0, 50);
            this._lessonsPanel.Name = "_lessonsPanel";
            this._lessonsPanel.Size = new System.Drawing.Size(461, 396);
            this._lessonsPanel.TabIndex = 7;
            // 
            // AllTasks
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this._lessonsPanel);
            this.Controls.Add(_topBarPanel);
            this.MinimumSize = new System.Drawing.Size(360, 0);
            this.Name = "AllTasks";
            this.Size = new System.Drawing.Size(461, 446);
            this.Resize += new System.EventHandler(this.OnResize);
            _topBarPanel.ResumeLayout(false);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _stripMenu;
        private System.Windows.Forms.ToolStripMenuItem _copyButtonButton;
        private FontAwesome.Sharp.IconButton _copyButton;
        private System.Windows.Forms.Panel _lessonsPanel;
        private FontAwesome.Sharp.IconButton _refreshButton;
        private System.Windows.Forms.ToolStripMenuItem _refreshButtonButton;
        private System.Windows.Forms.ToolStripMenuItem _checkAllButtonButton;
        private FontAwesome.Sharp.IconButton _checkAllButton;
    }
}
