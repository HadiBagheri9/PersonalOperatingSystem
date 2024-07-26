﻿using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Globalization;

namespace PersonalOperatingSystem
{
    class Program
    {
        static void Main()
        {
            


            Vars.userName = Environment.UserName;
            Vars.machineName = Environment.MachineName;
            Vars.path = $@"C:\Users\{Vars.userName}";

            //Console.WriteLine("Hadi's personal virtual OS");
            Console.WriteLine(@" ____  ____       _       ______   _____  ");
            Console.WriteLine(@"|_   ||   _|     / \     |_   _ `.|_   _| ");
            Console.WriteLine(@"  | |__| |      / _ \      | | `. \ | |   ");
            Console.WriteLine(@"  |  __  |     / ___ \     | |  | | | |   ");
            Console.WriteLine(@" _| |  | |_  _/ /   \ \_  _| |_.' /_| |_  ");
            Console.WriteLine(@"|____||____||____| |____||______.'|_____| ");

            while (true)
            {
                //Console.Write($"{path}>");
                //Console.Write("<");
                //Console.Write("==");
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("(");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{Vars.userName}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{Vars.machineName}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(")");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("-");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{Vars.path}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("]");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("==");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(">");
                //Console.Write("\n");

                Console.ResetColor();
                Vars.cmd = Console.ReadLine();
                Vars.cmd = Vars.cmd.Trim();
                Vars._cmd = Vars.cmd.Split(' ');
                Vars._cmd[0] = Vars._cmd[0].ToLower();
                Vars.cmd = string.Join(" ", Vars._cmd);

                Console.Write("\n");


                //***cd***
                CD.Cd(ref Vars.cmd);

                //***read***
                READ.Read(ref Vars.cmd);

                //***mkdir***md***makedirectory***
                MAKE_DIRECTORY.Make_Directory(ref Vars.cmd);

                //***touch***
                if (Vars.cmd.StartsWith("touch"))
                {
                    Vars.touch = Vars.cmd.Split(' ');
                    if (Vars.touch.Length == 2)
                    {
                        for (int n = 0; n < Vars.touch.Length; n++)
                        {
                            if (n == 0)
                            {
                                Vars.cmd = Vars.touch[n];
                            }

                            else if (n == 1)
                            {
                                Vars.fileMake = Vars.path + "\\" + Vars.touch[n];
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
                //***delfile***
                else if (Vars.cmd.StartsWith("delfile"))
                {
                    Vars.delFile = Vars.cmd.Split(' ');

                    if (Vars.delFile.Length == 2)
                    {
                        for (int q = 0; q < Vars.delFile.Length; q++)
                        {
                            if (q == 0)
                            {
                                Vars.cmd = Vars.delFile[q];
                            }
                            else if (q == 1)
                            {
                                Vars.delFilePath = Vars.path + @"\" + Vars.delFile[q];

                                if (File.Exists(Vars.delFilePath))
                                {
                                    try
                                    {
                                        File.Delete(Vars.delFilePath);
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Failed to delete file.");
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("File not found.");
                                }
                            }
                        }
                    }
                    else if (Vars.delFile.Length == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("delfile <filename>");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input is wrong.");
                    }
                }
                //***ls***
                LS.Ls(ref Vars.cmd);

                Console.ResetColor();

                switch (Vars.cmd)
                {
                    case "cd":

                        break;

                    case "read":

                        break;

                    case "md":
                    case "mkdir":
                    case "makedirectory":

                        break;

                    case "delfile":

                        break;

                    case "deldir":
                    case "deldirectory":

                        break;

                    case "touch":

                        break;

                    case "ls":

                        break;

                    case "date":

                        Console.WriteLine(GetDate(DateTime.Now));

                        break;

                    case "time":

                        Console.WriteLine(GetTime(DateTime.Now));

                        break;

                    case "ip":

                        var ips = (Dns.GetHostEntry(Dns.GetHostName()).AddressList);

                        foreach (var ip in ips)
                        {
                            Console.WriteLine(ip.ToString());
                        }

                        break;

                    case "cls":
                    case "clear":

                        Console.Clear();

                        break;

                    case "exit":

                        Environment.Exit(0);

                        break;

                    case "shutdown":

                        Process.Start("ShutDown", "/s");

                        break;

                    case "restart":

                        Process.Start("ShutDown", "/r");

                        break;

                    case "help":

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("\'cd <path>\' : To change path(use without \'<\' and \'>\').");//
                        Console.WriteLine("\'read <filename>\' : To read text files(use without \'<\' and \'>\').");
                        Console.WriteLine("\'mkdir <foldername>\' : To make a directory(use without \'<\' and \'>\').");
                        Console.WriteLine("\'delfile <foldername>\' : To delete a file(use without \'<\' and \'>\').");
                        Console.WriteLine("\'deldir <foldername>\' : To delete a directory(use without \'<\' and \'>\').");
                        Console.WriteLine("\'touch <filename>\' : To make a file(use without \'<\' and \'>\').");
                        Console.WriteLine("\'ls\' : To show files and directories.");//
                        Console.WriteLine("\'date\' : To show date of your system.");
                        Console.WriteLine("\'time\' : To show time of your system.");
                        Console.WriteLine("\'ip\' : To show IP list of your system.");
                        Console.WriteLine("\'cls\' or \'clear\' : To clear and refresh window.");
                        Console.WriteLine("\'exit\' : To close this window.");
                        Console.WriteLine("\'shutdown\' : To shutdown your computer.");
                        Console.WriteLine("\'restart\' : To restart your computer.");
                        Console.WriteLine("\'help\' : To see this message.");
                        Console.WriteLine("\'\' : To");

                        break;

                    default:

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input is wrong, Type \'help\' to see more.");

                        break;
                }
                Console.ResetColor();
            }
        }

        static string GetDate(DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            int dd, mm, yyyy;

            dd = persianCalendar.GetDayOfMonth(dateTime);
            mm = persianCalendar.GetMonth(dateTime);
            yyyy = persianCalendar.GetYear(dateTime);

            return $"{yyyy}/{mm}/{dd}";
        }

        static string GetTime(DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            string tt;
            int hours, minutes;

            hours = persianCalendar.GetHour(dateTime);
            minutes = persianCalendar.GetMinute(dateTime);
            tt = dateTime.ToString("tt");

            return $"{hours}:{minutes} {tt}";
        }
    }
}
