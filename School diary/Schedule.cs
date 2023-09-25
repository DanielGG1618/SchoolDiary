using System;

namespace School_diary
{
    public static class Schedule
    {
        private static string[][] _currentSchedule;

        public static void Load()
        {
            _currentSchedule = SQL.GetSchedule();
        }

        public static Lesson[] GetLessonsByDate(DateTime date)
        {
            string[] titles = _currentSchedule[(int)date.DayOfWeek - 1];

            Lesson[] lessons = new Lesson[titles.Length];

            for (int i = 0; i < lessons.Length; i++)
                lessons[i] = new Lesson(i + 1, titles[i], date); ;

            return lessons;
        }

        public static string[] GetTitles(int dayOfWeek)
        {
            return _currentSchedule[dayOfWeek];
        }
    }
}
