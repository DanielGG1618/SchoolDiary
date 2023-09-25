using System;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace School_diary
{
    public partial class LessonView : UserControl, IComparable<LessonView>
    {
        public event Action<LessonView, int, DateTime> Deleted;

        private Lesson _lesson;
        private EditType _editType;

        private int _colorNum;
        private Color NumLabelBg => _colorNum % 2 == 0 ? ThemeManager.EvenLessonNumLabelBg : ThemeManager.OddLessonNumLabelBg;

        public event Action<int, DateTime, string> TitleUpdated, TaskUpdated;

        public LessonView(Lesson lesson, int colorNum = 0)
        {
            InitializeComponent();

            _colorNum = colorNum;
            _lesson = lesson;
            Visualize(_lesson);
        }

        public LessonView(Lesson lesson, DateTime date, int colorNum)
        {
            InitializeComponent();

            _colorNum = colorNum;
            _lesson = lesson;
            Visualize(_lesson);
            SetDate(date);
            HideNum();
        }

        public bool GetDone() => _lesson.Done;

        public void Check()
        {
            _checkBox.Checked = true;
        }

        public void SetColorNum(int colorNum)
        {
            _colorNum = colorNum;
            Colorize();
        }

        private void SetDate(DateTime date)
        {
            _dateLabel.Show();
            _dateLabel.Text = date.ToString("dd.MM - ddd", new CultureInfo("ru-RU"));
        }

        private void HideNum()
        {
            _num.Hide();

            _numPlusButton.Hide();
            _numMinusButton.Hide();

            _taskTextBox.Location = new Point(0, 23);
            _taskTextBox.Size = new Size(Width, 47);
        }

        private void Visualize(Lesson lesson)
        {
            _title.Text = lesson.Title;
            _checkBox.Checked = lesson.Done;
            _num.Text = lesson.Num.ToString();

            if (lesson.Num <= 1) _numPlusButton.Hide();
            else if (lesson.Num >= 9) _numMinusButton.Hide();

            if (lesson.Task == "Default")
                _task.Text = DefaultTasks.Get(lesson.Title);
            else
                _task.Text = lesson.Task;

            Colorize();
        }

        private void Colorize()
        {
            _num.BackColor = NumLabelBg;

            _numPlusButton.BackColor = NumLabelBg;
            _numMinusButton.BackColor = NumLabelBg;

            _numPlusButton.IconColor = NumLabelBg;
            _numMinusButton.IconColor = NumLabelBg;
        }

        private void StartEditTitle(object sender, EventArgs e)
        {
            _titleTextBox.Text = _title.Text;

            _titleTextBox.Show();
            _titleTextBox.Focus();
            _titleTextBox.SelectionStart = _titleTextBox.TextLength;
            _doneButton.Show();

            _editType = _editType == EditType.Task ? EditType.TitleTask : EditType.Title;
        }

        private void StartEditTitle(object sender, MouseEventArgs e) => StartEditTitle(sender, new EventArgs());

        public void EditTitle(int num)
        {
            if (num == _lesson.Num)
                EditTitle();
        }

        public void EditTitle()
        {
            switch (_editType)
            {
                case EditType.None:
                case EditType.Task:
                    StartEditTitle(null, new EventArgs());
                    break;
                case EditType.Title:
                    UpdateTitle();
                    _doneButton.Hide();
                    Visualize(_lesson);
                    _editType = EditType.None;
                    break;
                case EditType.TitleTask:
                    UpdateTitle();
                    Visualize(_lesson);
                    _editType = EditType.Task;
                    break;
            }
        }

        private void StartEditTask(object sender, EventArgs e)
        {
            if (_lesson.Task != "Default")
                _taskTextBox.Text = _task.Text;
            else
                _taskTextBox.Text = "";

            _taskTextBox.Show();
            _taskTextBox.Focus();
            _taskTextBox.SelectionStart = _taskTextBox.TextLength;
            _doneButton.Show();

            _editType = _editType == EditType.Title ? EditType.TitleTask : EditType.Task;
        }

        private void StartEditTask(object sender, MouseEventArgs e) => StartEditTask(sender, new EventArgs());

        public void EditTask(int num) 
        { 
            if (num == _lesson.Num)
            {
                switch (_editType)
                {
                    case EditType.None:
                    case EditType.Title:
                        StartEditTask(null, new EventArgs());
                        break;
                    case EditType.Task:
                        UpdateTask();
                        _doneButton.Hide();
                        Visualize(_lesson);
                        _editType = EditType.None;
                        break;
                    case EditType.TitleTask:
                        UpdateTask();
                        Visualize(_lesson);
                        _editType = EditType.Title;
                        break;
                }
            }
        }

        private void DoneButtonClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Сохранить изменения?", "", MessageBoxButtons.YesNoCancel);

            if (result != DialogResult.Cancel)
            {
                if (result == DialogResult.Yes)
                {
                    switch (_editType)
                    {
                        case EditType.Task:
                            UpdateTask();
                            break;

                        case EditType.Title:
                            UpdateTitle();
                            break;

                        case EditType.TitleTask:
                            UpdateTask();
                            UpdateTitle();
                            break;
                    }
                }

                _editType = EditType.None;
                
                _doneButton.Hide();

                Visualize(_lesson);
            }
        }

        private void UpdateTitle()
        {
            _titleTextBox.Hide();
            TitleUpdated?.Invoke(_lesson.Num, _lesson.Date, _titleTextBox.Text);
        }

        private void UpdateTask()
        {
            _taskTextBox.Hide();
            TaskUpdated?.Invoke(_lesson.Num, _lesson.Date, _taskTextBox.Text);
        }

        enum EditType { None, Title, Task, Num, NumTitle, NumTask, TitleTask, NumTitleTask }

        private void TaskTextBoxTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            int selection = textBox.SelectionStart;

            string text = textBox.Text;
            if (text.ToLower().Contains("параграф"))
            {
                textBox.Text = Regex.Replace(text, "параграф", "§", RegexOptions.IgnoreCase);

                textBox.SelectionStart = Math.Max(selection - 7, 0);
            }
        }

        public void Delete(int num)
        {
            if (num == _lesson.Num)
                Delete();
        }
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Удалить {_lesson.Title.ToLower()}?" , "", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) Delete();
        }

        private void Delete()
        {
            Deleted?.Invoke(this, _lesson.Num, _lesson.Date);
            _lesson.Delete();
        }

        private void CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            _lesson.UpdateDoneStatus(_checkBox.Checked);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (_titleTextBox.Focused)
            {
                if (e.KeyCode == Keys.Enter) EditTitle(_lesson.Num);//TODO fix that shit и добавить cancel via ESC
            }
            else if (_taskTextBox.Focused)
            {
                if (e.KeyCode == Keys.Enter && !e.Shift) EditTask(_lesson.Num);//TODO fix that shit
            }
        }

        private void CopyTaskItemClick(object sender, EventArgs e)
        {
            Clipboard.SetText(_task.Text);
        }

        public int CompareTo(LessonView lessonView)
        {
            return ((IComparable<Lesson>)_lesson).CompareTo(lessonView._lesson);
        }

        private int _mouseEnterCount = 0;

        private void MouseEnterNum(object sender, EventArgs e)
        {
            if (++_mouseEnterCount == 1)
            {
                if (_lesson.Num > 1) _numPlusButton.IconColor = ThemeManager.LessonNumLabelFg;
                if (_lesson.Num < 9) _numMinusButton.IconColor = ThemeManager.LessonNumLabelFg;
            }
        }

        private void MouseLeaveNum(object sender, EventArgs e)
        {
            if (--_mouseEnterCount == 0)
            {
                _numPlusButton.IconColor = NumLabelBg;
                _numMinusButton.IconColor = NumLabelBg;
            }
        }

        private void NumPlusButtonClick(object sender, EventArgs e)
        {

        }

        private void NumMinusButtonClick(object sender, EventArgs e)
        {

        }
    }
}
