using School_diary.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_diary
{
    public class LessonsProvider
    {
        private Dictionary<DateTime, Lesson[]> _lessons = new Dictionary<DateTime, Lesson[]>();

        public void LoadLessons()
        {
            _lessons = SQL.GetAllLessons();
        }

        public Lesson[] GetLessons(DateTime date)
        {
            if (!_lessons.ContainsKey(date))
                AddLessons(date);

            return _lessons[date];
        }

        public void SetLesson(int num, DateTime date, Lesson lesson)
        {
            _lessons[date][num - 1] = lesson;
        }

        public void RemoveLesson(int num, DateTime date)
        {
            _lessons[date][num - 1].Remove();
        }

        public void UpdateTitle(int num, DateTime date, string title)
        {
            _lessons[date][num - 1].UpdateTitle(title);
        }

        public void UpdateTask(int num, DateTime date, string task)
        {
            _lessons[date][num - 1].UpdateTask(task);
        }

        private static int BinarySearch(Lesson[] array, int searchedNum, int first, int last)
        {
            if (first > last)
                return -1;

            int middle = (first + last) / 2;
            int middleValue = array[middle].Num;

            if (middleValue == searchedNum)
            {
                return middle;
            }
            else
            {
                if (middleValue > searchedNum)
                    return BinarySearch(array, searchedNum, first, middle - 1);

                else
                    return BinarySearch(array, searchedNum, middle + 1, last);
            }
        }

        private void AddLessons(DateTime date)
        {
            Lesson[] lessons = SQL.GetLessons(date);

            if (lessons.Length > 0)
            {
                SQL.InsertDoneStatuses(lessons, date);
            }

            else
            {
                lessons = Schedule.GetLessonsByDate(date);
                SQL.InsertLessons(lessons, date);
            }

            _lessons.Add(date, lessons);
        }
    }
}
