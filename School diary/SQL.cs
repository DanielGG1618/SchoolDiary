using School_diary.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace School_diary
{
    public static class SQL
    {
        private static SqlConnection _connection;

        private static Queue<string> _commandsQueue = new Queue<string>();

        public static void OpenConnection()
        {
            //string password = "DB4FreemYdIaryGG";

            //_connection = new MySqlConnection($"server=www.db4free.net;port=3306;uid=danielgg;pwd={password};database=mydiary;oldguids=true;");
            _connection = new SqlConnection(Settings.Default.MyDiary);
            _connection.Open();

            DequeueCommands();
        }

        private static bool _isRunning;

        private static async void DequeueCommands()
        {
            _isRunning = true;

            while (_isRunning)
            {
                await Task.Delay(5000);

                if (_connection.State != System.Data.ConnectionState.Open)
                    await new Task(_connection.Open);

                while (_commandsQueue.Count > 0)
                {
                    string commandText = _commandsQueue.Dequeue();

                    SqlCommand command = new SqlCommand(commandText, _connection);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                        command.Dispose();
                    }

                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }
                }
            }
        }

        public static void Stop()
        {
            if (_commandsQueue.Count < 1)
                return;

            Queue<string> commandsQueue = new Queue<string>(_commandsQueue);

            if (_connection.State != System.Data.ConnectionState.Open)
                _connection.Open();

            while (commandsQueue.Count > 0)
            {
                string commandText = commandsQueue.Dequeue();

                SqlCommand command = new SqlCommand(commandText, _connection);

                try
                {
                    command.ExecuteNonQuery();
                    command.Dispose();
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        public static string[][] GetSchedule(string grade = "default")
        {
            string[][] schedule = new string[6][];

            for (int i = 0; i < schedule.Length; i++)
                schedule[i] = new string[9];

            if (grade == "default")
                grade = Settings.Default.Theme;

            List<string> lessons = Select($"SELECT Lesson, Num, DayOfWeek FROM Schedule WHERE Grade = N'{grade}' ORDER BY Num");

            for (int i = 0; i < lessons.Count; i += 3)
            {
                string title = lessons[i];
                int num = int.Parse(lessons[i + 1]);
                int dayOfWeek = int.Parse(lessons[i + 2]);

                schedule[dayOfWeek][num - 1] = title;
            }

            return schedule;
        }

        public static void UpdateScheudleItem(int num, string title, int dayOfWeek, string grade = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Theme;

            EnqueueCommand($"UPDATE Schedule SET Lesson = N'{title}' WHERE Num = '{num}' AND DayOfWeek = '{dayOfWeek}' AND Grade = N'{grade}'");
        }

        public static List<DateTime> GetHolidays(string grade = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Theme;

            List<DateTime> days = new List<DateTime>();

            List<string> holidays = Select($"SELECT DateFrom, DateTo FROM Holidays WHERE Grade = N'{grade}'");

            for (int i = 0; i < holidays.Count; i += 2)
            {
                DateTime dateFrom = DateTime.Parse(holidays[i]);
                DateTime dateTo = DateTime.Parse(holidays[i + 1]);

                for (DateTime date = dateFrom; date <= dateTo; date = date.AddDays(1))
                    days.Add(date);
            }

            return days;
        }

        public static void InsertLessons(Lesson[] lessons, DateTime date, string grade = "default", string user = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Theme;

            if (user == "default")
                user = Settings.Default.Login;

            string lessonsValues = "", doneStatusValues = "";

            foreach (Lesson lesson in lessons)
            {
                lessonsValues += $"('{lesson.Num}', N'{lesson.Title}', '{date.ToSQLstring()}', N'{grade}'), ";
                doneStatusValues += $"('{lesson.Num}', '{date.ToSQLstring()}', '{user}'), ";
            }

            lessonsValues = lessonsValues.Remove(lessonsValues.Length - 2);
            doneStatusValues = doneStatusValues.Remove(doneStatusValues.Length - 2);

            EnqueueCommand($"INSERT INTO Lessons (Num, Title, Date, Grade) VALUES{lessonsValues};" +
                $"INSERT INTO [DoneStatuses] (Num, Date, [User]) VALUES{doneStatusValues}");
        }

        public static void InsertLesson(Lesson lesson, DateTime date, string grade = "default", string user = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Theme;

            if (user == "default")
                user = Settings.Default.Login;

            EnqueueCommand($"INSERT INTO Lessons (Num, Title, Date, Grade) " +
                $"VALUES('{lesson.Num}', N'{lesson.Title}', '{date.ToSQLstring()}', N'{grade}');" +
                $"INSERT INTO [DoneStatuses] (Num, Date, [User]) VALUES('{lesson.Num}', '{date.ToSQLstring()}', '{user}')");
        }


        public static void InsertDoneStatuses(Lesson[] lessons, DateTime date, string user = "default")
        {
            if (user == "default")
                user = Settings.Default.Login;

            string doneStatusValues = "";

            foreach (Lesson lesson in lessons)
                doneStatusValues += $"('{lesson.Num}', '{date.ToSQLstring()}', '{user}'), ";

            doneStatusValues = doneStatusValues.Remove(doneStatusValues.Length - 2);

            EnqueueCommand($"INSERT INTO [DoneStatuses] (Num, Date, [User]) VALUES{doneStatusValues}");
        }

        public static Lesson[] GetLessons(DateTime date, string grade = "default", string user = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Theme;

            if (user == "default")
                user = Settings.Default.Login;

            List<Lesson> lessons = new List<Lesson>();

            List<string> numTitleTask = Select($"SELECT Num, Title, Task FROM Lessons WHERE Grade = N'{grade}' AND Date = '{date.ToSQLstring()}' ORDER BY Num");
            List<string> doneStatuses = Select($"SELECT Done FROM [DoneStatuses] WHERE [User] = '{user}' AND Date = '{date.ToSQLstring()}' ORDER BY Num");

            if (doneStatuses.Count == 0)
            {
                for (int i = 0; i < numTitleTask.Count; i += 3)
                {
                    EnqueueCommand($"INSERT INTO [DoneStatuses] (Num, Date, [User]) VALUES('{numTitleTask[i]}', '{date.ToSQLstring()}', '{user}')");

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
            
            List<string> titleTaskDateNum = Select($"SELECT Title, Task, Lessons.Date, Lessons.Num FROM [DoneStatuses], Lessons WHERE " +
                $"Grade = (SELECT Grade FROM Users WHERE Users.Login = '{user}') AND [User] = '{user}' AND Lessons.Num = [DoneStatuses].Num AND " +
                $"[DoneStatuses].Date = Lessons.Date AND Done = '0' AND Task != 'Default' ORDER BY Lessons.Date ASC, Lessons.Num ASC");

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

            List<string> numTitleTaskDateDone = Select($"SELECT Lessons.Num, Lessons.Title, Lessons.Task, Lessons.Date, [DoneStatuses].Done FROM Lessons " +
                $"JOIN [DoneStatuses] ON Lessons.Date = [DoneStatuses].Date AND Lessons.Num = [DoneStatuses].Num " +
                $"WHERE [DoneStatuses].[User] = '{user}' AND Lessons.Grade = (SELECT Users.Grade FROM Users WHERE Users.Login = '{user}') ORDER BY Date");

            Dictionary<DateTime, Lesson[]> lessons = new Dictionary<DateTime, Lesson[]>();
            DateTime previousDate = DateTime.MinValue;

            List<Lesson> lessonsToAdd = new List<Lesson>();
            for (int i = 0; i < numTitleTaskDateDone.Count; i += 5)
            {
                int num = int.Parse(numTitleTaskDateDone[i]);
                string title = numTitleTaskDateDone[i + 1];
                string task = numTitleTaskDateDone[i + 2];
                DateTime date = DateTime.Parse(numTitleTaskDateDone[i + 3]);
                bool doneStatus = int.Parse(numTitleTaskDateDone[i + 4]) == 1;

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
                grade = Settings.Default.Theme;

            EnqueueCommand($"UPDATE Lessons SET Task = N'{task}' WHERE Grade = N'{grade}' AND Date = '{date.ToSQLstring()}' AND Num = '{num}'");
        }

        public static void UpdateLessonTitle(DateTime date, int num, string title, string grade = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Theme;

            EnqueueCommand($"UPDATE Lessons SET Title = N'{title}' WHERE Grade = N'{grade}' AND Date = '{date.ToSQLstring()}' AND Num = '{num}'");
        }

        public static void UpdateLessonDone(DateTime date, int num, bool done, string user = "default")
        {
            if (user == "default")
                user = Settings.Default.Login;

            EnqueueCommand($"UPDATE [DoneStatuses] SET Done = '{(done ? 1 : 0)}' WHERE [User] = '{user}' AND Date = '{date.ToSQLstring()}' AND Num = '{num}'");
        }

        public static void DeleteLesson(DateTime date, int num, string grade = "default", string user = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Theme;

            if (user == "default")
                user = Settings.Default.Login;

            EnqueueCommand($"UPDATE Lessons SET Title = '' WHERE Grade = N'{grade}' AND Date = '{date.ToSQLstring()}' AND Num = '{num}'");
            EnqueueCommand($"UPDATE [DoneStatuses] SET Done = '0' WHERE [User] = '{user}' AND Date = '{date.ToSQLstring()}' AND Num = '{num}'");
        }

        public static bool HolidaysBeenAdded(DateTime dateFrom, DateTime dateTo, string grade = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Theme;

            return Select($"SELECT Grade FROM Holidays WHERE DateFrom = '{dateFrom.ToSQLstring()}' AND " +
                $"DateTo = '{dateTo.ToSQLstring()}' AND Grade = N'{grade}'").Count > 0;
        }

        public static void AddHolidays(DateTime dateFrom, DateTime dateTo, string grade = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Theme;

            Command($"INSERT INTO Holidays (DateFrom, DateTo, Grade) " +
                $"VALUES ('{dateFrom.ToSQLstring()}', '{dateTo.ToSQLstring()}', N'{grade}')");
        }

        public static void DeleteHolidays(DateTime dateFrom, DateTime dateTo, string grade = "default")
        {
            if (grade == "default")
                grade = Settings.Default.Theme;

            Command($"DELETE FROM Holidays WHERE DateFrom = '{dateFrom.ToSQLstring()}' AND " +
                $"DateTo = '{dateTo.ToSQLstring()}' AND Grade = N'{grade}'");
        }

        private static List<string> Select(string text)
        {
            List<string> results = new List<string>();
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            SqlCommand command = new SqlCommand(text, _connection);

            IDataReader reader = command.ExecuteReader();

            while (reader.Read())
                for (int i = 0; i < reader.FieldCount; i++)
                    results.Add(reader.GetValue(i).ToString());

            reader.Close();

            command.Dispose();

            return results;
        }

        private static void EnqueueCommand(string text)
        {
            _commandsQueue.Enqueue(text);
        }

        private static void Command(string text)
        {
            SqlCommand command = new SqlCommand(text, _connection);

            command.ExecuteNonQuery();

            command.Dispose();
        }
    }
}
