using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_diary
{
    public static class DefaultTasks
    {
        private const string _noTaskText = "Не задано";

        private static Dictionary<string, string> _tasks = new Dictionary<string, string>();

        public static void Load()
        {
            string[] lessonsDefaultWorks = File.ReadAllLines("DefaultTasks.diary-tasks", Encoding.UTF8);

            _tasks.Clear();

            foreach (var lessonsDefaultWork in lessonsDefaultWorks)
            {
                string[] keyValue = lessonsDefaultWork.Split(new string[] { ": " }, StringSplitOptions.None);

                _tasks.Add(keyValue[0], keyValue[1]);
            }
        }

        public static string Get(string lesson)
        {
            if (_tasks.ContainsKey(lesson))
                return _tasks[lesson];

            return _noTaskText;
        }
    }
}
