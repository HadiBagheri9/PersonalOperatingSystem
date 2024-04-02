using System;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace OperatingSystem01
{
    class Program
    {
        static void Main()
        {
            string[] cd, read, mkdir, touch, showFilesAndFolders, directories, files;
            string path, cmd, userName, machineName, fileReadPath, fileRead, dirMake, fileMake, ls;

            userName = Environment.UserName;
            machineName = Environment.MachineName;
            path = $@"C:\Users\{userName}";

            Console.WriteLine("Hadi's personal virtual OS");

            while (true)
            {
                //Console.Write($"{path}>");
                //Console.Write("<");
                //Console.Write("==");
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("(");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{userName}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{machineName}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(")");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("-");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{path}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("]");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("==");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(">");
                //Console.Write("\n");

                Console.ResetColor();
                cmd = Console.ReadLine();
                cmd = cmd.Trim().ToLower();
                Console.Write("\n");

                if (cmd.StartsWith("cd"))
                {
                    cd = cmd.Split(' ');

                    if (cd.Length == 2)
                    {
                        for (int i = 0; i < cd.Length; i++)
                        {
                            if (i == 0)
                            {
                                cmd = cd[i];
                            }
                            else if (i == 1)
                            {
                                if (Directory.Exists(cd[i]))
                                {
                                    path = cd[i];
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Path [{cd[i]}] is wrong.");
                                }
                            }
                        }
                    }
                    else if (cd.Length == 1)
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
                else if (cmd.StartsWith("read"))
                {
                    read = cmd.Split(' ');
                    if (read.Length == 2)
                    {
                        for (int j = 0; j < read.Length; j++)
                        {
                            if (j == 0)
                            {
                                cmd = read[j];
                            }

                            if (j == 1)
                            {
                                fileReadPath = path + '\\' + read[j];
                                if (File.Exists(fileReadPath))
                                {
                                    fileRead = File.ReadAllText(fileReadPath);
                                    Console.WriteLine(fileRead);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"File name [{read[j]}] is wrong.");
                                }
                            }
                        }
                    }

                    else if (read.Length == 1)
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

                else if (cmd.StartsWith("mkdir") || cmd.StartsWith("md") || cmd.StartsWith("makedirectory"))
                {
                    mkdir = cmd.Split(' ');
                    if (mkdir.Length == 2)
                    {
                        for (int k = 0; k < mkdir.Length; k++)
                        {
                            if (k == 0)
                            {
                                cmd = mkdir[k];
                            }

                            else if (k == 1)
                            {
                                dirMake = path + "\\" + mkdir[1];
                                try
                                {
                                    Directory.CreateDirectory(dirMake);
                                }
                                catch
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("This name for directory is used, Try another name.");
                                }
                            }
                        }
                    }

                    else if (mkdir.Length == 1)
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

                else if (cmd.StartsWith("touch"))
                {
                    touch = cmd.Split(' ');
                    if (touch.Length == 2)
                    {
                        for (int n = 0; n < touch.Length; n++)
                        {
                            if (n == 0)
                            {
                                cmd = touch[n];
                            }

                            else if (n == 1)
                            {
                                fileMake = path + "\\" + touch[n];
                                if (File.Exists(fileMake) == false)
                                {
                                    try
                                    {
                                        File.WriteAllText(fileMake, "\0");
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

                    else if (touch.Length == 1)
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

                else if (cmd.StartsWith("ls"))
                {
                    showFilesAndFolders = cmd.Split(' ');

                    if (showFilesAndFolders.Length == 2)
                    {
                        for (int l = 0; l < showFilesAndFolders.Length; l++)
                        {
                            if (l == 0)
                            {
                                cmd = showFilesAndFolders[l];
                            }

                            else if (l == 1) { 
                            
                                ls = showFilesAndFolders[l];

                                if (ls.CompareTo("-h") == 0/* || ls.CompareTo("-H") == 0*/)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("ls <secend CMD> : Custom working");
                                    Console.WriteLine("<-h> : Show this message.");
                                    Console.WriteLine("<-d> : Show name of directoties.");
                                    Console.WriteLine("<-f> : Show name of files.>");
                                    Console.WriteLine("<-dc> : Show name of directories + Show Creation time.");
                                    Console.WriteLine("<-fc> : Show name of files + Show Creation time.");
                                }

                                else if (ls.CompareTo("-d") == 0 /*|| ls.CompareTo("-D") == 0*/)
                                {
                                    directories = Directory.GetDirectories(path);

                                    foreach (string directory in directories)
                                    {
                                        DirectoryInfo directoryInfo = new DirectoryInfo(directory);

                                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                        Console.WriteLine(directoryInfo.Name);
                                    }
                                }

                                else if (ls.CompareTo("-f") == 0)
                                {
                                    files = Directory.GetFiles(path);

                                    foreach (string file in files)
                                    {
                                        FileInfo fileInfo = new FileInfo(file);

                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        Console.WriteLine(fileInfo.Name);
                                    }
                                }

                                else if (ls.CompareTo("-dc") == 0 /*|| ls.CompareTo("-D") == 0*/)
                                {
                                    directories = Directory.GetDirectories(path);

                                    foreach (string directory in directories)
                                    {
                                        DirectoryInfo directoryInfo = new DirectoryInfo(directory);

                                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                        Console.WriteLine(directoryInfo.Name + "\t\t\t" + directoryInfo.CreationTime);
                                    }
                                }

                                else if (ls.CompareTo("-fc") == 0)
                                {
                                    files = Directory.GetFiles(path);

                                    foreach (string file in files)
                                    {
                                        FileInfo fileInfo = new FileInfo(file);

                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        Console.WriteLine(fileInfo.Name + "\t\t\t" + fileInfo.CreationTime);
                                    }
                                }

                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("Type \'ls -h\' to see help message.");
                                }
                            }
                        }
                    }

                    else if (showFilesAndFolders.Length == 1)
                    {
                        try { 
                        
                        
                            directories = Directory.GetDirectories(path);
                            files = Directory.GetFiles(path);

                            foreach (string directory in directories)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine(directory);
                            }

                            foreach (string file in files)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine(file);
                            }
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Can't use this command in this path.");
                        }
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input is wrong.");
                    }
                }

                Console.ResetColor();

                switch (cmd)
                {
                    case "cd":

                        break;

                    case "read":

                        break;

                    case "md":
                    case "mkdir":
                    case "makedirectory":

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
                        Console.WriteLine("\'cd <path>\' : To change path(use without \'<\' and \'>\').");
                        Console.WriteLine("\'read <filename>\' : To read text files(use without \'<\' and \'>\').");
                        Console.WriteLine("\'mkdir <foldername>\' : To make a directory(use without \'<\' and \'>\').");
                        Console.WriteLine("\'touch <filename>\' : To make a file(use without \'<\' and \'>\').");
                        Console.WriteLine("\'ls\' : To show files and directories.");
                        Console.WriteLine("\'date\' : To show date of your system.");
                        Console.WriteLine("\'time\' : To show time of your system.");
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
