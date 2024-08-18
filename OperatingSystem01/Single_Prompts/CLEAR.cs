using System;

namespace PersonalOperatingSystem
{
    class CLEAR
    {
        public static void Clear(ref string cmd)
        {
            if (cmd.CompareTo("clear") == 0 || cmd.CompareTo("cls") == 0)
            {
                Console.Clear();
            }
        }
    }
}
