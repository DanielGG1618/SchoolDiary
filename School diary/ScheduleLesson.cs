using System;
using System.Windows.Forms;

namespace School_diary
{
    public partial class ScheduleLesson : UserControl
    {
        private int _num, _dayOfWeek;

        private string _startTitle;

        public ScheduleLesson(int num, string title, int dayOfWeek, Admin admin)
        {
            _num = num;
            _startTitle = title;
            _dayOfWeek = dayOfWeek;
            admin.SaveScheduleClicked += Save;

            InitializeComponent();

            _checkBox.Checked = !string.IsNullOrEmpty(title);

            _numLabel.Text = num.ToString();
            _textBox.Text = title;

            Colorize();
        }

        private void Save()
        {
            if (_startTitle == _textBox.Text)
                return;

            SQL.UpdateScheudleItem(_num, _textBox.Text, _dayOfWeek);
        }

        private void OnCheckedChanged(object sender, EventArgs e)
        {
            if (_checkBox.Checked)
                Enable();
            else
                Disable();
        }

        private void Colorize()
        {
            _numLabel.BackColor = _num % 2 == 0 ? ThemeManager.EvenLessonNumLabelBg : ThemeManager.OddLessonNumLabelBg;
            _checkBox.BackColor = _num % 2 == 0 ? ThemeManager.EvenLessonNumLabelBg : ThemeManager.OddLessonNumLabelBg;
        }

        private void Enable()
        {
            _textBox.Enabled = true;

            _numLabel.ForeColor = ThemeManager.LessonNumLabelFg;

            _textBox.Focus();
        }

        private void Disable()
        {
            _textBox.Enabled = false;

            _numLabel.ForeColor = _num % 2 == 0 ? ThemeManager.DisabledEvenLessonNumLabelFg : ThemeManager.DisabledOddLessonNumLabelFg;

            _textBox.Text = "";
        }
    }
}
