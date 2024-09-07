using System;
using System.IO;
using HB_Shell.Parents;
using PersonalOperatingSystem;

namespace HB_Shell.Multiplex_Prompt
{
    class DIRECTORY_UNLOCK : DirectoryAccessControl
    {
        public static void Directory_UnLock(ref string cmd)
        {
            if (cmd.StartsWith("dirunlock"))
            {
                Vars._cmd = Vars.cmd.Split(' ');
                Vars.cmd = Vars._cmd[0];

                if (Vars._cmd.Length == 2)
                {
                    if (Directory.Exists(Vars.path + "\\" + Vars._cmd[1]))
                    {
                        try
                        {
                            UnLockDirectory(Vars.path + "\\" + Vars._cmd[1]);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{Vars._cmd[1]} has been unlocked. Type \'dirinfo\' to see more.");
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
                    Console.WriteLine("dirunlock <dirname>");
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
