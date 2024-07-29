using System;
using System.Globalization;

namespace PersonalOperatingSystem
{
    class TIME
    {
        public static void Time(ref string cmd)
        {
            if (cmd.CompareTo("time") == 0)
            {
                Console.WriteLine(GetTime(DateTime.Now));
            }
        }


        private static string GetTime(DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            string tt;
            int hours, minutes;

            hours = persianCalendar.GetHour(dateTime);
            minutes = persianCalendar.GetMinute(dateTime);
            tt = dateTime.ToString("tt");

            return $"{hours}:{minutes} {tt}";
        }
    }
}
