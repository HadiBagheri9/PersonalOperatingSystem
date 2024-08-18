using System.Diagnostics;

namespace PersonalOperatingSystem
{
    class RESTART
    {
        public static void Restart(ref string cmd)
        {
            if (cmd.CompareTo("restart") == 0)
            {
                Process.Start("ShutDown", "/r");
            }
        }
    }
}
