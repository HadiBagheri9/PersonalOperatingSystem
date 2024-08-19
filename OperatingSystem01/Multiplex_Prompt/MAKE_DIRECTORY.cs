using System;
using System.IO;

namespace PersonalOperatingSystem
{
    class MAKE_DIRECTORY
    {
        public static void Make_Directory(ref string cmd)
        {
            if (cmd.StartsWith("mkdir") || cmd.StartsWith("md") || cmd.StartsWith("makedirectory"))
            {
                Vars.mkdir = Vars.cmd.Split(' ');
                if (Vars.mkdir.Length == 2)
                {
                    for (int i = 0; i < Vars.mkdir.Length; i++)
                    {
                        if (i == 0)
                        {
                            Vars.cmd = Vars.mkdir[i];
                        }

                        else if (i == 1)
                        {
                            Vars.dirMake = Vars.path + "\\" + Vars.mkdir[1];
                            try
                            {
                                Directory.CreateDirectory(Vars.dirMake);
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("This name for directory is used, Try another name.");
                            }
                        }
                    }
                }

                else if (Vars.mkdir.Length == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("md <foldername>");
                    Console.WriteLine("mkdir <foldername>");
                    Console.WriteLine("makedirectory <foldername>");
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Command is wrong.");
                }
            }
        }
    }
}
