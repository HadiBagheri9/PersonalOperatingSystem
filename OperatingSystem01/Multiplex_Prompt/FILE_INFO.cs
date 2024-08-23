using System;
using System.IO;

namespace PersonalOperatingSystem.Multiplex_Prompt
{
    class FILE_INFO
    {
        public static void File_Info(ref string cmd)
        {
            if (cmd.StartsWith("fileinfo"))
            {
                Vars.fileInfo = Vars.cmd.Split(' ');
                Vars.cmd = Vars.fileInfo[0];

                if (Vars.fileInfo.Length == 2)
                {
                    Vars.fileName = Vars.path + "\\" + Vars.fileInfo[1];
                    if (File.Exists(Vars.fileName))
                    {
                        try
                        {
                            FileInfo fileInfo = new FileInfo(Vars.fileName);
                            Vars.fileInfos = string.Format(
                                $"Name : \t\t\t{fileInfo.Name}\n" +
                                $"File extension : \t{fileInfo.Extension}\n" +
                                $"Directory : \t\t{fileInfo.Directory}\n" +
                                $"Directory name : \t{fileInfo.DirectoryName}\n" +
                                $"File full name : \t{fileInfo.FullName}\n" +
                                $"Size : \t\t\t{fileInfo.Length * 1024} KB\n" +
                                $"Read only : \t\t{fileInfo.IsReadOnly}\n" +
                                $"Attributes : \t\t{fileInfo.Attributes}\n" +
                                $"Creation time : \t{fileInfo.CreationTime}\n" +
                                $"Last access time : \t{fileInfo.LastAccessTime}\n" +
                                $"Last write time : \t{fileInfo.LastWriteTime}\n");

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(Vars.fileInfos);
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
                        Console.WriteLine($"File <{Vars.fileInfo[1]}> not found!");
                    }
                }
                else if (Vars.fileInfo.Length == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("fileinfo <filename>");
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
