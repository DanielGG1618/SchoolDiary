using System.Drawing;
using System.Windows.Forms;

namespace School_diary
{
    public partial class ScheduleDay : UserControl
    {
        private readonly string[] _daysOfWeek = new string[7] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };
        private ScheduleLesson[] _lessons = new ScheduleLesson[9];

        public ScheduleDay(int dayOfWeek, string[] titles, Admin admin)
        {
            for (int i = 0; i < _lessons.Length; i++)
            {
                _lessons[i] = new ScheduleLesson(i + 1, titles[i], dayOfWeek, admin);
                Controls.Add(_lessons[i]);
                _lessons[i].Location = new Point(0, 26 * (i + 1));
            }

            InitializeComponent();

            _dayOfWeekLabel.Text = _daysOfWeek[dayOfWeek];
        }
    }
}
