using System;
using System.IO;

namespace PersonalOperatingSystem
{
    class READ
    {
        public static void Read(ref string cmd)
        {
            if (Vars.cmd.StartsWith("read"))
            {
                Vars.read = Vars.cmd.Split(' ');
                if (Vars.read.Length == 2)
                {
                    for (int j = 0; j < Vars.read.Length; j++)
                    {
                        if (j == 0)
                        {
                            Vars.cmd = Vars.read[j];
                        }

                        if (j == 1)
                        {
                            Vars.fileReadPath = Vars.path + '\\' + Vars.read[j];
                            if (File.Exists(Vars.fileReadPath))
                            {
                                try
                                {
                                    Vars.fileRead = File.ReadAllText(Vars.fileReadPath);
                                    Console.WriteLine(Vars.fileRead);
                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"File name [{Vars.read[j]}] is wrong.");
                            }
                        }
                    }
                }

                else if (Vars.read.Length == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("read <filename>");
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
