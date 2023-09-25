using System;

namespace School_diary
{
    public static class DateTimeExtentions
    {
        public static string ToSQLstring(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
