using System;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace School_diary
{
    static class Holidays
    {
        private static List<DateTime> _days = new List<DateTime>();

        private static int _firstDBholidayIndex;

        public static void Load()
        {
            LoadWebHolidays();

            _firstDBholidayIndex = _days.Count;

            LoadDBHolidays();
        }

        private static void LoadWebHolidays()
        {
            int month = DateTime.Today.Month;
            int year = DateTime.Today.Year;

            _days.AddRange(GetWebHolidays(year));

            if (12 >= month && month >= 9)
                _days.AddRange(GetWebHolidays(year + 1));

            else
                _days.AddRange(GetWebHolidays(year - 1));

            DateTime day1 = DateTime.Today;
            while (day1.DayOfWeek != DayOfWeek.Sunday)
                day1 = day1.AddDays(1);
            DateTime day11 = day1.AddDays(-1);

            DateTime day2 = DateTime.Today;
            while (day2.DayOfWeek != DayOfWeek.Sunday)
                day2 = day2.AddDays(-1);
            DateTime day22 = day2.AddDays(-1);

            for (int i = 0; i < 365; i += 7)
            {
                _days.Add(day1);
                _days.Add(day2);
                _days.Add(day11);
                _days.Add(day22);

                day1 = day1.AddDays(7);
                day2 = day2.AddDays(-7);
                day11 = day11.AddDays(7);
                day22 = day22.AddDays(-7);
            }
        }

        private static List<DateTime> GetWebHolidays(int year)
        {
            return new List<DateTime>();

            List<DateTime> days = new List<DateTime>();

            HtmlWeb webGet = new HtmlWeb();

            HtmlDocument document = webGet.Load("http://www.consultant.ru/law/ref/calendar/proizvodstvennye/" + year);

            var blocks = document.DocumentNode.SelectNodes("//div[contains(@class, 'col-md-3')]");
            foreach (HtmlNode block in blocks)
            {
                var currentMonthNode = HtmlNode.CreateNode(block.InnerHtml);
                var month = currentMonthNode.SelectNodes("//th[contains(@class, 'month')]");

                if (month != null)
                {
                    int monthNum = 1;
                    var nodes = currentMonthNode.SelectNodes("//td[contains(@class, 'holiday weekend')]");
                    if (nodes == null)
                        nodes = new HtmlNodeCollection(currentMonthNode);
                    foreach (var node in currentMonthNode.SelectNodes("//td[contains(@class, 'weekend')]"))
                        nodes.Add(node);

                    switch (month[0].InnerText)
                    {
                        case "Январь":
                            monthNum = 1;
                            break;
                        case "Февраль":
                            monthNum = 2;
                            break;
                        case "Март":
                            monthNum = 3;
                            break;
                        case "Апрель":
                            monthNum = 4;
                            break;
                        case "Май":
                            monthNum = 5;
                            break;
                        case "Июнь":
                            monthNum = 6;
                            break;
                        case "Июль":
                            monthNum = 7;
                            break;
                        case "Август":
                            monthNum = 8;
                            break;
                        case "Сентябрь":
                            monthNum = 9;
                            break;
                        case "Октябрь":
                            monthNum = 10;
                            break;
                        case "Ноябрь":
                            monthNum = 11;
                            break;
                        case "Декабрь":
                            monthNum = 12;
                            break;
                    }

                    foreach (var node in nodes)
                        days.Add(new DateTime(year, monthNum, int.Parse(node.InnerText)));
                }
            }

            return days;
        }

        public static void Add(DateTime dateFrom, DateTime dateTo)
        {
            SQL.AddHolidays(dateFrom, dateTo);
        }

        public static void Delete(DateTime dateFrom, DateTime dateTo)
        {
            SQL.DeleteHolidays(dateFrom, dateTo);
        }

        public static bool BeenAdded(DateTime dateFrom, DateTime dateTo)
        {
            return SQL.HolidaysBeenAdded(dateFrom, dateTo);
        }

        public static void ReloadDBHolidays()
        {
            _days.RemoveRange(_firstDBholidayIndex, _days.Count - _firstDBholidayIndex);
            LoadDBHolidays();
        }

        private static void LoadDBHolidays()
        {
            List<DateTime> dbHolidays = SQL.GetHolidays();
            _days.AddRange(dbHolidays);
        }
    
        public static bool IsWorking(DateTime date)
        {
            return !_days.Contains(date);
        }
    }
}
