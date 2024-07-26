using System;
using System.IO;

namespace PersonalOperatingSystem
{
    class MAKE_DIRECTORY
    {
        public static void Make_Directory(ref string cmd)
        {
            if (Vars.cmd.StartsWith("mkdir") || Vars.cmd.StartsWith("md") || Vars.cmd.StartsWith("makedirectory"))
            {
                Vars.mkdir = Vars.cmd.Split(' ');
                if (Vars.mkdir.Length == 2)
                {
                    for (int k = 0; k < Vars.mkdir.Length; k++)
                    {
                        if (k == 0)
                        {
                            Vars.cmd = Vars.mkdir[k];
                        }

                        else if (k == 1)
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
