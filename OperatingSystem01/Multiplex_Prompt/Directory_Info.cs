using System;
using System.IO;

namespace PersonalOperatingSystem.Multiplex_Prompt
{
    class Directory_Info
    {
        public static void Dir_Info(ref string cmd)
        {
            if (cmd.StartsWith("dirinfo"))
            {
                Vars.dirInfo = Vars.cmd.Split(' ');
                Vars.cmd = Vars.dirInfo[0];

                if (Vars.dirInfo.Length == 2)
                {
                    Vars.dirName = Vars.path + "\\" + Vars.dirInfo[1];
                    if (Directory.Exists(Vars.dirName))
                    {
                        try
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo(Vars.dirName);
                            Vars.dirInfos = string.Format(
                                $"Name : \t\t\t{directoryInfo.Name}\n" +
                                $"Directory extension : \t{directoryInfo.Extension}\n" +
                                $"Directory parent : \t{directoryInfo.Parent}\n" +
                                $"Directory root : \t{directoryInfo.Root}\n" +
                                $"Directory full name : \t{directoryInfo.FullName}\n" +
                                $"Attributes : \t\t{directoryInfo.Attributes}\n" +
                                $"Creation time : \t{directoryInfo.CreationTime}\n" +
                                $"Last access time : \t{directoryInfo.LastAccessTime}\n" +
                                $"Last write time : \t{directoryInfo.LastWriteTime}\n");

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(Vars.dirInfos);
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
                        Console.WriteLine($"Folder <{Vars.dirInfo[1]}> not found!");
                    }
                }
                else if (Vars.dirInfo.Length == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("dirinfo <dirname>");
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

