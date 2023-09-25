using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace School_diary
{
    public partial class Main : Form
    {
        private const int _buttonHeight = 80, _buttonBorderWidth = 7;

        private Dictionary<string, Control> _userControls = new Dictionary<string, Control>();

        private IconButton _currentButton;
        private Panel _buttonBorder;
        private Control _currentUserControl;

        private DayView _dayView;
        private AllTasks _allTasks;
        private Options _options;
        private Admin _admin;

        public event Action<int> EditTask, EditTitle, DeleteLesson;

        public Main()
        {
            InitializeComponent();

            _buttonBorder = new Panel { Size = new Size(_buttonBorderWidth, _buttonHeight) };
            _userControls.Add("dayView", _dayView = new DayView(this));
            _userControls.Add("allTasks", _allTasks = new AllTasks());
            _userControls.Add("options", _options = new Options());
            _userControls.Add("admin", _admin = new Admin());

            _allTasksButton.Click += _allTasks.Reload;

            foreach (var control in _userControls.Values)
            {
                control.Dock = DockStyle.Fill;
                control.Visible = false;
                _desktopPanel.Controls.Add(control);
            }

            _menuPanel.Controls.Add(_buttonBorder);

            ActivateButton(_dayViewButton, new EventArgs());
            ChangeMinimumHeight(_dayView.MinimumSize.Height);
            _dayView.MinimumHeigthChanged += ChangeMinimumHeight;

            ApplyTheme();

            KeyPreview = true;
        }

        private void ApplyTheme()
        {
            BackColor = ThemeManager.WindowBg;

            _topBar.BackColor = ThemeManager.WindowBgOver;
            _menuPanel.BackColor = ThemeManager.WindowBgOver;

            _topBarShadow.BackColor = ThemeManager.WindowShadows;

            _minimizeButton.ForeColor = ThemeManager.ControlBoxButtonsFg;
            _maximizeButton.ForeColor = ThemeManager.ControlBoxButtonsFg;
            _closeButton.ForeColor = ThemeManager.ControlBoxButtonsFg;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void TopBarMouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void ActivateButton(object sender, EventArgs e)
        {
            if (sender != null)
            {
                DisableButton();

                _currentButton = (IconButton)sender;
                _currentButton.BackColor = ThemeManager.MenuButtonsActiveBg;
                _currentButton.ForeColor = ThemeManager.MenuButtonsActiveFg;
                _currentButton.TextAlign = ContentAlignment.MiddleCenter;
                _currentButton.IconColor = ThemeManager.MenuButtonsActiveFg;
                _currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;
                _currentButton.ImageAlign = ContentAlignment.MiddleRight;

                _buttonBorder.BackColor = ThemeManager.MenuButtonsActiveFg;
                _buttonBorder.Location = new Point(0, _currentButton.Location.Y);
                _buttonBorder.Visible = true;
                _buttonBorder.BringToFront();

                Button button = (IconButton)sender;
                ShowUserControl(_userControls[button.Tag.ToString()], button.Text);
            }
        }

        private void ShowUserControl(Control control, string text)
        {
            if (_currentUserControl != null)
                _currentUserControl.Hide();

            _currentUserControl = control;
            _currentUserControl.Show();
            _formTitleLable.Text = text;
            ChangeMinimumSize(_currentUserControl.MinimumSize);
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void MaximizeButtonClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                _maximizeButton.IconChar = IconChar.WindowMaximize;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                _maximizeButton.IconChar = IconChar.WindowRestore;
            }
        }

        private void MinimizeButtonClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void OnResize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                _maximizeButton.IconChar = IconChar.WindowRestore;
            else
                _maximizeButton.IconChar = IconChar.WindowMaximize;
        }

        private void DisableButton()
        {
            if (_currentButton != null)
            {
                _currentButton.BackColor = ThemeManager.MenuButtonsPassiveBg;
                _currentButton.ForeColor = ThemeManager.MenuButtonsPassiveFg;
                _currentButton.TextAlign = ContentAlignment.MiddleLeft;
                _currentButton.IconColor = ThemeManager.MenuButtonsPassiveFg;
                _currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                _currentButton.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            SQL.Stop();
        }

        private void ChangeMinimumHeight(int height) => MinimumSize = new Size(MinimumSize.Width, height + _topBar.Height + 16);

        private void MainKeyDown(object sender, KeyEventArgs e)
        {
            if (_currentUserControl == _dayView)
            {
                if (e.Control)
                {
                    int num = e.KeyValue - 48;
                    if (num < 0 || num > 10)
                        return;
                    if (num == 0)
                        num = 10;

                    if (e.Shift)
                        EditTitle?.Invoke(num);
                    else if (e.Alt)
                        DeleteLesson?.Invoke(num);
                    else
                        EditTask?.Invoke(num);
                }
            }
        }

        private void ChangeMinimumSize(Size size)
        {
            MinimumSize = new Size(size.Width + _menuPanel.Width + 16, Math.Max(size.Height + _topBar.Height, _menuPanel.MinimumSize.Height) + 16);
        }
    }
}
