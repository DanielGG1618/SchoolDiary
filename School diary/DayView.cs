using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace School_diary
{
    public partial class DayView : UserControl
    {
        private DateTime _firstDay, _lastDay;
        private DateTime _date;

        private LessonsProvider _lessonsProvider = new LessonsProvider();
        private Main _main;

        private Queue<int> _newLessonQueue = new Queue<int>();

        private List<LessonView> _lessonViews = new List<LessonView>();

        private int MinimumHeight => 50 + (70 * _lessonViews.Count);

        public event Action<int> MinimumHeigthChanged;

        public DayView(Main main)
        {
            _lessonsProvider.LoadLessons();
            _main = main;

            InitializeDate();
            InitializeLessons();
            VisualizeSchedule();
            InitializeComponent();

            _dateLabel.Text = _date.ToString("dd.MM.yyyy dddd", new CultureInfo("ru-RU"));

            MouseWheel += OnMouseWheel;
        }

        private void DayViewVisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
                return;

            InitializeDate();
            UpdateLessons();
        }

        private void InitializeDate()
        {
            int year = DateTime.Today.Year - (9 <= DateTime.Today.Month && DateTime.Today.Month <= 12 ? 0 : 1);

            _firstDay = new DateTime(year, 9, 1).ToLocalTime().Date;
            _lastDay = new DateTime(year + 1, 5, 31).ToLocalTime().Date;

            _date = DateTime.Today;

            do
            {
                _date = _date.AddDays(1);

                if (_date >= _lastDay)
                    _date = _firstDay;
            }
            while (!Holidays.IsWorking(_date));
        }

        private void UpdateLessons()
        {
            ClearLessonViews();
            InitializeLessons();
            VisualizeSchedule();
            _dateLabel.Text = _date.ToString("dd.MM.yyyy dddd", new CultureInfo("ru-RU"));
        }

        private void ClearLessonViews()
        {
            foreach (var lesson in _lessonViews)
            {
                Controls.Remove(lesson);
                _main.EditTitle -= lesson.EditTitle;
                _main.EditTask -= lesson.EditTask;
                _main.DeleteLesson -= lesson.Delete;
                lesson.Deleted -= OnLessonDeleted;
            }

            _lessonViews.Clear();
        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                DatePlus();

            else
                DateMinus();

            UpdateLessons();
        }

        private void DateMinusButtonClick(object sender, EventArgs e)
        {
            DateMinus();
            UpdateLessons();
        }

        private void DatePlusButtonClick(object sender, EventArgs e)
        {
            DatePlus();
            UpdateLessons();
        }

        private void InitializeLessons()
        {
            Lesson[] current = _lessonsProvider.GetLessons(_date);

            int colorNum = 1;

            foreach (var lesson in current)
            {
                if (lesson.IsActive)
                {
                    LessonView lessonView = new LessonView(lesson, colorNum++);
                    _lessonViews.Add(lessonView);

                    lessonView.TitleUpdated += _lessonsProvider.UpdateTitle;
                    lessonView.TaskUpdated += _lessonsProvider.UpdateTask;
                }
            }

            InitializeNewLessonsQueue(current);
        }

        private void InitializeNewLessonsQueue(Lesson[] lessons)
        {
            _newLessonQueue.Clear();

            for (int i = 8; i >= -1; i--)
                if (i == -1 || lessons[i].IsActive)
                    for(int j = i; j < 8 && !lessons[j + 1].IsActive; j++)
                        _newLessonQueue.Enqueue(j + 2);
        }

        private void VisualizeSchedule()
        {
            for (int i = 0; i < _lessonViews.Count; i++)
                VisualizeLesson(_lessonViews[i]);

            MinimumSize = new Size(300, MinimumHeight);
            MinimumHeigthChanged?.Invoke(MinimumHeight);
        }

        private void VisualizeLesson(LessonView lesson)
        {
            _main.EditTitle += lesson.EditTitle;
            _main.EditTask += lesson.EditTask;
            _main.DeleteLesson += lesson.Delete;
            lesson.Deleted += OnLessonDeleted;
            lesson.Dock = DockStyle.Top;
            Controls.Add(lesson);

            SortLessonViews();
        }

        private void SortLessonViews()
        {
            _lessonViews.Sort();

            for (int i = 0; i < _lessonViews.Count; i++)
            {
                _lessonViews[i].SetColorNum(i + 1);
                _lessonViews[i].BringToFront();
            }
        }

        private void DateButtonsButtonClick(object sender, EventArgs e)
        {
            _datePlusButton.Visible = _dateButtonsButton.Checked;
            _dateMinusButton.Visible = _dateButtonsButton.Checked;
        }

        private void CopyButtonButtonClick(object sender, EventArgs e)
        {
            _copyButton.Visible = _copyButtonButton.Checked;
        }

        private void СopyButtonClick(object sender, EventArgs e)
        {
            Clipboard.SetImage(Utils.GetControlScreenshotByRectangle(this, new Rectangle(0, 0, Width, MinimumHeight)));
        }

        private void OnResize(object sender, EventArgs e)
        {
            if (Width > 405)
                _dateLabel.Text = _date.ToString("dd.MM.yyyy dddd", new CultureInfo("ru-RU"));
            else
                _dateLabel.Text = _date.ToString("dd.MM.yyyy");

            if (Width > 610)
            {
                _dateMinusButton.Visible = _dateButtonsButton.Checked;
                _datePlusButton.Visible = _dateButtonsButton.Checked;
            }
            else
            {
                _dateMinusButton.Hide();
                _datePlusButton.Hide();
            }
        }

        private void DatePlus()
        {
            int step = ModifierKeys == Keys.Shift ? 7 : 1;

            do
            {
                _date = _date.AddDays(step);

                if (_date >= _lastDay)
                    _date = _firstDay;
            }
            while (!Holidays.IsWorking(_date));
        }

        private void DateMinus()
        {
            int step = ModifierKeys == Keys.Shift ? 7 : 1;

            do
            {
                _date = _date.AddDays(-step);

                if (_date <= _firstDay)
                    _date = _lastDay;
            }
            while (!Holidays.IsWorking(_date));
        }

        private void AddLesson(object sender, EventArgs e)
        {
            if (_newLessonQueue.Count < 1)
            {
                MessageBox.Show("Место в расписании закончилось");

                return;
            }

            int newLessonNum = _newLessonQueue.Dequeue();

            Lesson newLesson = new Lesson(newLessonNum, "", _date);
            LessonView newLessonView = new LessonView(newLesson);
            newLessonView.TitleUpdated += _lessonsProvider.UpdateTitle;
            newLessonView.TaskUpdated += _lessonsProvider.UpdateTask;
            _lessonsProvider.SetLesson(newLesson.Num, newLesson.Date, newLesson);

            _lessonViews.Add(newLessonView);

            VisualizeLesson(newLessonView);
            newLessonView.EditTitle();

            MinimumSize = new Size(300, MinimumHeight);
            MinimumHeigthChanged?.Invoke(MinimumHeight);
        }

        private void OnLessonDeleted(LessonView lesson, int num, DateTime date)
        {
            _lessonViews.Remove(lesson);
            Controls.Remove(lesson);
            _lessonsProvider.RemoveLesson(num, date);
            _main.EditTitle -= lesson.EditTitle;
            _main.EditTask -= lesson.EditTask;
            _main.DeleteLesson -= lesson.Delete;
            lesson.Deleted -= OnLessonDeleted;

            MinimumHeigthChanged?.Invoke(MinimumHeight);
            SortLessonViews();
        }
    }
}
