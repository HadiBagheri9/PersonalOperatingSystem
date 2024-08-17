using System;
using System.Globalization;

namespace PersonalOperatingSystem
{
    class DATE
    {
        public static void Date(ref string cmd)
        {
            if (cmd.CompareTo("date") == 0)
            {
                Console.WriteLine(GetDate(DateTime.Now));
            }
        }

        protected static string GetDate(DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            int dd, mm, yyyy;

            dd = persianCalendar.GetDayOfMonth(dateTime);
            mm = persianCalendar.GetMonth(dateTime);
            yyyy = persianCalendar.GetYear(dateTime);

            return $"{yyyy}/{mm}/{dd}";
        }
    }
}
