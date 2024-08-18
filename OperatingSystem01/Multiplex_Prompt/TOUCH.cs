using System;
using System.IO;

namespace PersonalOperatingSystem
{
    class TOUCH
    {
        public static void Touch(ref string cmd)
        {
            if (Vars.cmd.StartsWith("touch"))
            {
                Vars.touch = Vars.cmd.Split(' ');
                if (Vars.touch.Length == 2)
                {
                    for (int i = 0; i < Vars.touch.Length; i++)
                    {
                        if (i == 0)
                        {
                            Vars.cmd = Vars.touch[i];
                        }

                        else if (i == 1)
                        {
                            Vars.fileMake = Vars.path + "\\" + Vars.touch[i];
                            if (File.Exists(Vars.fileMake) == false)
                            {
                                try
                                {
                                    File.WriteAllText(Vars.fileMake, "\0");
                                }
                                catch
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Faild to creat file.");
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("This name of file has used.");

                            }
                        }
                    }
                }

                else if (Vars.touch.Length == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("touch <filename>");

                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input is wrong.");
                }
            }
        }
    }
}
