using System;

namespace School_diary
{
    public class Lesson: IComparable<Lesson>
    {
        public string Title { get; private set; }
        public string Task { get; private set; }
        public bool Done { get; private set; }
        public int Num { get; private set; }
        public DateTime Date { get; private set; }

        public bool IsActive => !string.IsNullOrEmpty(Title);

        public Lesson(int num, string title, DateTime date)
        {
            Num = num;
            Title = title;
            Date = date;
            Task = "Default";
            Done = false;
        }

        public Lesson(int num, string title, string task, DateTime date, bool done)
        {
            Date = date;
            Done = done;
            Title = title;
            Task = task;
            Num = num;
        }

        public void Remove()
        {
            Title = "";
            Task = "Default";
            UpdateTask(Task);
        }

        public void UpdateDoneStatus(bool done)
        {
            Done = done;
            SQL.UpdateLessonDone(Date, Num, Done);
        }

        public void UpdateTask(string task)
        {
            if (string.IsNullOrWhiteSpace(task))
                Task = "Default";
            else
                Task = task;

            SQL.UpdateLessonTask(Date, Num, Task);
        }

        public void UpdateTitle(string title)
        {
            Title = title;

            SQL.UpdateLessonTitle(Date, Num, Title);
        }

        public void Delete()
        {
            SQL.DeleteLesson(Date, Num);
        }

        public int CompareTo(Lesson lesson)
        {
            return Num.CompareTo(lesson.Num);
        }
    }
}
