using System;
using System.IO;

namespace PersonalOperatingSystem
{
    static class CD
    {
        public static void Cd(ref string cmd)
        {
            if (cmd.StartsWith("cd"))
            {
                Vars.cd = cmd.Split(' ');

                if (Vars.cd.Length == 2)
                {
                    for (int i = 0; i < Vars.cd.Length; i++)
                    {
                        if (i == 0)
                        {
                            cmd = Vars.cd[i];
                        }
                        else if (i == 1)
                        {
                            if (Vars.cd[i].Contains(":\\") || Vars.cd[i].Contains(":/"))
                            {
                                if (Directory.Exists(Vars.cd[i]))
                                {
                                    Vars.path = Vars.cd[i];
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Path [{Vars.cd[i]}] is wrong.");
                                }
                            }
                            else //if (Vars.cd[i].Contains("\\") || Vars.cd[i].Contains("/"))
                            {
                                if (Directory.Exists(Vars.path + "\\" + Vars.cd[i]))
                                {
                                    Vars.path = Path.GetFullPath(Vars.path + "\\" + Vars.cd[i]);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Directory [{Vars.cd[i]}] didn't exist.");
                                }
                            }
                            
                        }
                    }
                }
                else if (Vars.cd.Length == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("cd <path>");
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
