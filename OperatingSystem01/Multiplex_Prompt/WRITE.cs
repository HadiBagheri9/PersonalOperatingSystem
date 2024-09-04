using System;
using System.IO;

namespace PersonalOperatingSystem
{
    class WRITE
    {
        public static void Write(ref string cmd)
        {
            if (cmd.StartsWith("write"))
            {
                Vars.write = cmd.Split(' ');
                Vars.cmd = Vars.write[0];

                if (Vars.write.Length == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("write <filename> <text>");
                }
                else if (Vars.write.Length == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("write <filename> <text>");
                }
                else if (Vars.write.Length > 2)
                {
                    if (File.Exists(Vars.path+"\\"+Vars.write[1]))
                    {
                        for (int i = 0; i < Vars.write.Length; i++)
                        {
                            if (i == 0)
                            {
                                Vars.cmd = Vars.write[i];
                            }
                            else if (i == 1)
                            {
                                Vars.fileName = Vars.write[i];
                            }
                            else if (i == 2)
                            {
                                Vars.textToWrite = Vars.write[i];
                            }
                            else
                            {
                                Vars.textToWrite += " " + Vars.write[i];
                            }

                        }

                        try
                        {
                            File.AppendAllText(Vars.path+"\\"+Vars.write[1], Vars.textToWrite.Trim());
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
                        Console.WriteLine($"File name {Vars.write[1]} wrong.");
                    }
                    
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
