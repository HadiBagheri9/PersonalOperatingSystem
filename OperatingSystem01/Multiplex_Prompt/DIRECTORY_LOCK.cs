using System;
using System.IO;
using HB_Shell.Parents;
using PersonalOperatingSystem;

namespace HB_Shell.Multiplex_Prompt
{
    class DIRECTORY_LOCK : DirectoryAccessControl
    {
        public static void Directory_Lock(ref string cmd)
        {
            if (cmd.StartsWith("dirlock"))
            {
                Vars._cmd = Vars.cmd.Split(' ');
                Vars.cmd = Vars._cmd[0];

                if (Vars._cmd.Length == 2)
                {
                    if (Directory.Exists(Vars.path + "\\" + Vars._cmd[1]))
                    {
                        try
                        {
                            LockDirectory(Vars.path + "\\" + Vars._cmd[1]);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{Vars._cmd[1]} has been locked. Type \'dirinfo\' to see more.");
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (Vars._cmd.Length == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("dirlock <dirname>");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input is wrong!");
                }
            }
        }
    }
}
