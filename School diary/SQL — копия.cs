using MySql.Data.MySqlClient;
using School_diary.Properties;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_diary
{
    public static class SQL
    {
        private static MySqlConnection _asyncConnection, _syncConnection;
        private static Queue<string> _commandsQueue = new Queue<string>(); 

        public static void OpenConnection()
        {
            string password = "DB4FreemYdIaryGG";

            _syncConnection = new MySqlConnection($"server=www.db4free.net;port=3306;uid=danielgg;pwd={password};database=mydiary;oldguids=true;");
            _syncConnection.Open();
            
            _asyncConnection = new MySqlConnection($"server=www.db4free.net;port=3306;uid=danielgg;pwd={password};database=mydiary;oldguids=true;");
            _asyncConnection.Open();

            DequeueCommands();
        }

        private static async void DequeueCommands()
        {
            while (true)
            {
                await Task.Delay(200);
                if (_commandsQueue.Count > 0)
                {
                    MySqlCommand command = new MySqlCommand(_commandsQueue.Dequeue(), _asyncConnection);

                    command.ExecuteNonQuery();

                    command.Dispose();
                }
            }
        }

        public static List<Schedule.Item>[] GetSchedule(string grade = "default")
        {
            List<Schedule.Item>[] schedule = new List<Schedule.Item>[5];

            for (int i = 0; i < schedule.Length; i++)
                schedule[i] = new List<Schedule.Item>();

            if (grade == "default")
                grade = Settings.Default.Grade;

            List<string> lessons = Select($"SELECT Lesson, Num, DayOfWeek FROM Schedule WHERE Class = '{grade}' ORDER BY Num");

            for (int i = 0; i < lessons.Count; i += 3)
            {
                int dayOfWeek = int.Parse(lessons[i + 2]);

                schedule[dayOfWeek - 1].Add(new Schedule.Item(int.Parse(lessons[i + 1]), lessons[i]));
            }

            return schedule;
        }

        public static List<DateTime> GetHolidays(string grade = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Grade;

            List<DateTime> days = new List<DateTime>();

            List<string> holidays = Select($"SELECT DateFrom, DateTo FROM Holidays WHERE Class = '{grade}'");

            for (int i = 0; i < holidays.Count; i += 2)
            {
                DateTime dateFrom = DateTime.Parse(holidays[i]);
                DateTime dateTo = DateTime.Parse(holidays[i + 1]);

                for (DateTime date = dateFrom; date <= dateTo; date = date.AddDays(1))
                    days.Add(date);
            }

            return days;
        }

        public static void InsertLesson(int num, string title, DateTime date, string grade = "default", string user = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Grade;

            if (user == "default")
                user = Settings.Default.Login;

            EnqueueCommand($"INSERT INTO Lessons (Num, Title, Date, Class) VALUES('{num}', '{title}', '{date.ToSQLstring()}', '{grade}');" +
                $"INSERT INTO DoneStatus (Num, Date, User) VALUES('{num}', '{date.ToSQLstring()}', '{user}')");
        }

        public static void InsertLessons(Lesson[] lessons, DateTime date, string grade = "default", string user = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Grade;

            if (user == "default")
                user = Settings.Default.Login;

            string lessonsValues = "", doneStatusValues = "";

            foreach (Lesson lesson in lessons)
            {
                lessonsValues += $"('{lesson.Num}', '{lesson.Title}', '{date.ToSQLstring()}', '{grade}'), ";
                doneStatusValues += $"('{lesson.Num}', '{date.ToSQLstring()}', '{user}'), ";
            }

            lessonsValues = lessonsValues.Remove(lessonsValues.Length - 2);
            doneStatusValues = doneStatusValues.Remove(doneStatusValues.Length - 2);

            EnqueueCommand($"INSERT INTO Lessons (Num, Title, Date, Class) VALUES{lessonsValues};" +
                $"INSERT INTO DoneStatus (Num, Date, User) VALUES{doneStatusValues}");
        }

        public static void InsertDoneStatuses(Lesson[] lessons, DateTime date, string user = "default")
        {
            if (user == "default")
                user = Settings.Default.Login;

            string doneStatusValues = "";

            foreach (Lesson lesson in lessons)
                doneStatusValues += $"('{lesson.Num}', '{date.ToSQLstring()}', '{user}'), ";

            doneStatusValues = doneStatusValues.Remove(doneStatusValues.Length - 2);

            EnqueueCommand($"INSERT INTO DoneStatus (Num, Date, User) VALUES{doneStatusValues}");
        }

        public static Lesson[] GetLessons(DateTime date, string grade = "default", string user = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Grade;

            if (user == "default")
                user = Settings.Default.Login;

            List<Lesson> lessons = new List<Lesson>();

            List<string> numTitleTask = Select($"SELECT Num, Title, Task FROM Lessons WHERE Class = '{grade}' AND Date = '{date.ToSQLstring()}' ORDER BY Num");
            List<string> doneStatuses = Select($"SELECT Done FROM DoneStatus WHERE User = '{user}' AND Date = '{date.ToSQLstring()}' ORDER BY Num");

            if (doneStatuses.Count == 0)
            {
                for (int i = 0; i < numTitleTask.Count; i += 3)
                {
                    EnqueueCommand($"INSERT INTO DoneStatus (Num, Date, User) VALUES('{numTitleTask[i]}', '{date.ToSQLstring()}', '{user}')");

                    doneStatuses.Add("false");
                }
            }

            for (int i = 0; i < numTitleTask.Count; i += 3)
            {
                string title = numTitleTask[i + 1];
                string task = numTitleTask[i + 2];
                bool doneStatus = bool.Parse(doneStatuses[i / 3]);
                int num = int.Parse(numTitleTask[i]);
                Lesson lesson = new Lesson(num, title, task, date, doneStatus);
                lessons.Add(lesson);
            }

            return lessons.ToArray();
        }

        public static Lesson[] GetAllTasks(string user = "default")
        {
            if (user == "default")
                user = Settings.Default.Login;
            
            List<string> titleTaskDateNum = Select($"SELECT Title, Task, Lessons.Date, Lessons.Num FROM DoneStatus, Lessons WHERE " +
                $"Class = (SELECT Class FROM Users WHERE Users.Login = '{user}') AND User = '{user}' AND Lessons.Num = DoneStatus.Num AND " +
                $"DoneStatus.Date = Lessons.Date AND Done = '0' AND Task != 'Default' ORDER BY Lessons.Date ASC, Lessons.Num ASC");

            Lesson[] lessons = new Lesson[titleTaskDateNum.Count / 4];

            for (int i = 0; i < titleTaskDateNum.Count; i += 4)
            {
                string title = titleTaskDateNum[i];
                string task = titleTaskDateNum[i + 1];
                DateTime date = DateTime.Parse(titleTaskDateNum[i + 2]);
                int num = int.Parse(titleTaskDateNum[i + 3]);

                lessons[i / 4] = new Lesson(num, title, task, date, false);
            }

            return lessons;
        }

        public static Dictionary<DateTime, Lesson[]> GetAllLessons(string user = "default")
        {
            if (user == "default")
                user = Settings.Default.Login;

            List<string> numTitleTaskDateDone = Select($"SELECT Lessons.Num, Lessons.Title, Lessons.Task, Lessons.Date, DoneStatus.Done FROM Lessons " +
                $"JOIN DoneStatus ON Lessons.Date = DoneStatus.Date AND Lessons.Num = DoneStatus.Num " +
                $"WHERE DoneStatus.User = '{user}' AND Lessons.Class = (SELECT Users.Class FROM Users WHERE Users.Login = '{user}') ORDER BY Date");

            Dictionary<DateTime, Lesson[]> lessons = new Dictionary<DateTime, Lesson[]>();
            DateTime previousDate = DateTime.MinValue;

            List<Lesson> lessonsToAdd = new List<Lesson>();
            for (int i = 0; i < numTitleTaskDateDone.Count; i += 5)
            {
                int num = int.Parse(numTitleTaskDateDone[i]);
                string title = numTitleTaskDateDone[i + 1];
                string task = numTitleTaskDateDone[i + 2];
                DateTime date = DateTime.Parse(numTitleTaskDateDone[i + 3]);
                bool doneStatus = bool.Parse(numTitleTaskDateDone[i + 4]);

                Lesson lesson = new Lesson(num, title, task, date, doneStatus);
                
                if (!date.Equals(previousDate))
                {
                    lessonsToAdd.Sort((Lesson l1, Lesson l2) => l1.Num - l2.Num);
                    lessons.Add(previousDate, lessonsToAdd.ToArray());
                    lessonsToAdd.Clear();

                    previousDate = date;
                }

                lessonsToAdd.Add(lesson);
            }

            lessonsToAdd.Sort((Lesson l1, Lesson l2) => l1.Num - l2.Num);
            lessons.Add(previousDate, lessonsToAdd.ToArray());

            return lessons;
        }

        public static void UpdateLessonTask(DateTime date, int num, string task, string grade = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Grade;

            EnqueueCommand($"UPDATE Lessons SET Task = '{task}' WHERE Class = '{grade}' AND Date = '{date.ToSQLstring()}' AND Num = '{num}'");
        }

        public static void UpdateLessonTitle(DateTime date, int num, string title, string grade = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Grade;

            EnqueueCommand($"UPDATE Lessons SET Title = '{title}' WHERE Class = '{grade}' AND Date = '{date.ToSQLstring()}' AND Num = '{num}'");
        }

        public static void UpdateLessonDone(DateTime date, int num, bool done, string user = "default")
        {
            if (user == "default")
                user = Settings.Default.Login;

            EnqueueCommand($"UPDATE DoneStatus SET Done = '{(done ? 1 : 0)}' WHERE User = '{user}' AND Date = '{date.ToSQLstring()}' AND Num = '{num}'");
        }

        public static void DeleteLesson(DateTime date, int num, string grade = "default", string user = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Grade;

            if (user == "default")
                user = Settings.Default.Login;

            EnqueueCommand($"DELETE FROM Lessons WHERE Class = '{grade}' AND Date = '{date.ToSQLstring()}' AND Num = '{num}'");
            EnqueueCommand($"DELETE FROM DoneStatus WHERE User = '{user}' AND Date = '{date.ToSQLstring()}' AND Num = '{num}'");
        }

        public static bool HolidaysBeenAdded(DateTime dateFrom, DateTime dateTo, string grade = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Grade;

            return Select($"SELECT Class FROM Holidays WHERE DateFrom = '{dateFrom.ToSQLstring()}' AND " +
                $"DateTo = '{dateTo.ToSQLstring()}' AND Class = '{grade}'").Count > 0;
        }

        public static void AddHolidays(DateTime dateFrom, DateTime dateTo, string grade = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Grade;

            EnqueueCommand($"INSERT INTO Holidays (DateFrom, DateTo, Class) " +
                $"VALUES ('{dateFrom.ToSQLstring()}', '{dateTo.ToSQLstring()}', '{grade}')");
        }

        public static void DeleteHolidays(DateTime dateFrom, DateTime dateTo, string grade = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Grade;

            EnqueueCommand($"DELETE FROM Holidays WHERE DateFrom = '{dateFrom.ToSQLstring()}' AND " +
                $"DateTo = '{dateTo.ToSQLstring()}' AND Class = '{grade}'");
        }

        private static List<string> Select(string text, Dictionary<string, string> parameters = null)
        {
            List<string> results = new List<string>();

            MySqlCommand command = new MySqlCommand(text, _syncConnection);

            if (parameters != null)
                foreach (var pair in parameters)
                    command.Parameters.AddWithValue(pair.Key, pair.Value);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
                for (int i = 0; i < reader.FieldCount; i++)
                    results.Add(reader.GetValue(i).ToString());

            reader.Close();

            command.Dispose();

            return results;
        }

        private static bool _lastCommandDisposed = true;

        private static async void CommandAsync(string text)
        {
            while (!_lastCommandDisposed) await Task.Delay(20);

            _lastCommandDisposed = false;

            MySqlCommand command = new MySqlCommand(text, _asyncConnection);

            await Task.Run(command.ExecuteNonQuery);

            await Task.Run(command.Dispose);
            _lastCommandDisposed = true;
        }

        private static void EnqueueCommand(string text)
        {
            _commandsQueue.Enqueue(text);
        }

        private static void Command(string text)
        {
            MySqlCommand command = new MySqlCommand(text, _syncConnection);

            command.ExecuteNonQuery();

            command.Dispose();
        }
    }
}
