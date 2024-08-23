using System;
using System.IO;

namespace PersonalOperatingSystem
{
    class LS : TIME
    {
        public static void Ls(ref string cmd)
        {
            if (cmd.StartsWith("ls"))
            {
                Vars.showFilesAndFolders = Vars.cmd.Split(' ');

                if (Vars.showFilesAndFolders.Length == 2)
                {
                    for (int i = 0; i < Vars.showFilesAndFolders.Length; i++)
                    {
                        if (i == 0)
                        {
                            Vars.cmd = Vars.showFilesAndFolders[i];
                        }

                        else if (i == 1)
                        {

                            Vars.ls = Vars.showFilesAndFolders[i];

                            if (Vars.ls.CompareTo("-h") == 0/* || ls.CompareTo("-H") == 0*/)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("ls <secend CMD> : Custom working");
                                Console.WriteLine("<-h> : Show this message.");
                                Console.WriteLine("<-d> : Show name of directoties.");
                                Console.WriteLine("<-f> : Show name of files.>");
                                Console.WriteLine("<-dc> : Show name of directories + Show Creation time.");
                                Console.WriteLine("<-fc> : Show name of files + Show Creation time.");
                            }

                            else if (Vars.ls.CompareTo("-d") == 0 /*|| ls.CompareTo("-D") == 0*/)
                            {
                                Vars.directories = Directory.GetDirectories(Vars.path);

                                foreach (string directory in Vars.directories)
                                {
                                    DirectoryInfo directoryInfo = new DirectoryInfo(directory);

                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.WriteLine(directoryInfo.Name);
                                }
                            }

                            else if (Vars.ls.CompareTo("-f") == 0)
                            {
                                Vars.files = Directory.GetFiles(Vars.path);

                                foreach (string file in Vars.files)
                                {
                                    FileInfo fileInfo = new FileInfo(file);

                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine(fileInfo.Name);
                                }
                            }

                            else if (Vars.ls.CompareTo("-dc") == 0 /*|| ls.CompareTo("-D") == 0*/)
                            {
                                Vars.directories = Directory.GetDirectories(Vars.path);

                                foreach (string directory in Vars.directories)
                                {
                                    DirectoryInfo directoryInfo = new DirectoryInfo(directory);

                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.WriteLine(directoryInfo.Name + "\t\t\t" + GetDate(directoryInfo.CreationTime) + "\t" + GetTime(directoryInfo.CreationTime));
                                }
                            }

                            else if (Vars.ls.CompareTo("-fc") == 0)
                            {
                                Vars.files = Directory.GetFiles(Vars.path);

                                foreach (string file in Vars.files)
                                {
                                    FileInfo fileInfo = new FileInfo(file);

                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine(fileInfo.Name + "\t\t\t" + GetDate(fileInfo.CreationTime) + "\t" + GetTime(fileInfo.CreationTime));
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

                else if (Vars.showFilesAndFolders.Length == 1)
                {
                    try
                    {


                        Vars.directories = Directory.GetDirectories(Vars.path);
                        Vars.files = Directory.GetFiles(Vars.path);

                        foreach (string directory in Vars.directories)
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine(directoryInfo.Name);
                        }

                        foreach (string file in Vars.files)
                        {
                            FileInfo fileInfo = new FileInfo(file);

                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine(fileInfo.Name);
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
        }
    }
}
