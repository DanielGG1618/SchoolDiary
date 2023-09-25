using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_diary
{
    public partial class Admin : UserControl
    {
        private ScheduleDay[] _scheduleDays = new ScheduleDay[6];

        public event Action SaveScheduleClicked;

        public Admin()
        {
            InitializeComponent();

            _holidayFromPicker.Value = DateTime.Today;
            _holidayToPicker.Value = DateTime.Today;

            InitSchedulePanel();
        }

        private void InitSchedulePanel()
        {
            for(int i = 0; i < 6; i++)
            {
                ScheduleDay scheduleDay = new ScheduleDay(i, Schedule.GetTitles(i), this);
                _scheduleDays[i] = scheduleDay;

                _scheduleInnerPanel.Controls.Add(scheduleDay);
            }

            RearrangeSchedulePanel();
        }

        private void DateFromPickerValueChanged(object sender, EventArgs e)
        {
            _holidayToPicker.MinDate = _holidayFromPicker.Value;
        }

        private void DateToPickerValueChanged(object sender, EventArgs e)
        {
            _holidayFromPicker.MaxDate = _holidayToPicker.Value;
        }

        private void AddHolidaysButtonClick(object sender, EventArgs e)
        {
            if (SQL.HolidaysBeenAdded(GetHolidayFrom(), GetHolidayTo()))
                Holidays.Delete(GetHolidayFrom(), GetHolidayTo());

            else
                Holidays.Add(GetHolidayFrom(), GetHolidayTo());

            UpdateAddHolidayButtonStatus();
            Holidays.ReloadDBHolidays();
        }

        private DateTime GetHolidayFrom() => DateTime.Parse(_holidayFromPicker.Text);

        private DateTime GetHolidayTo() => DateTime.Parse(_holidayToPicker.Text);

        private void UpdateAddHolidayButtonStatus()
        {
            if (SQL.HolidaysBeenAdded(GetHolidayFrom(), GetHolidayTo()))
                _addHolidaysButton.IconChar = FontAwesome.Sharp.IconChar.Minus;

            else
                _addHolidaysButton.IconChar = FontAwesome.Sharp.IconChar.Plus;
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            RearrangeSchedulePanel();
        }

        private int _previousRows = -1;

        private void RearrangeSchedulePanel()
        {
            int rows;
            int scrollbarOffset = 17;

            if (Width >= 260 * 6 + scrollbarOffset)
                rows = 1;
            else if (Width >= 260 * 3 + scrollbarOffset)
                rows = 2;
            else
                rows = 3;

            if (rows != _previousRows)
            {
                _scheduleInnerPanel.AutoScrollPosition = new Point(0, 0);

                for (int i = 0; i < 6; i++)
                {
                    int x = i / rows;
                    int y = i - rows * x;
                    _scheduleDays[i].Location = new Point(x * 260, y * 260);
                }

                _previousRows = rows;
            }
        }

        private void SaveScheduleClick(object sender, EventArgs e)
        {
            SaveScheduleClicked?.Invoke();
        }
    }
}
