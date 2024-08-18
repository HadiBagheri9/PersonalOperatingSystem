using System;

namespace PersonalOperatingSystem
{
    class EXIT
    {
        public static void Exit(ref string cmd)
        {
            if (cmd.CompareTo("exit") == 0)
            {
                Environment.Exit(0);
            }
        }
    }
}
