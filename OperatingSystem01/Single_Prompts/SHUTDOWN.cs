using System.Diagnostics;

namespace PersonalOperatingSystem
{
    class SHUTDOWN
    {
        public static void Shutdown(ref string cmd)
        {
            if (cmd.CompareTo("shutdown") == 0)
            {
                Process.Start("ShutDown", "/s");
            }
        }
    }
}
