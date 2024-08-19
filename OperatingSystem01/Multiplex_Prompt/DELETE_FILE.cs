using System;
using System.IO;
namespace PersonalOperatingSystem
{
    class DELETE_FILE
    {
        public static void Del_File(ref string cmd)
        {
            if (cmd.StartsWith("delfile") || cmd.StartsWith("deletefile"))
            {
                Vars.delFile = Vars.cmd.Split(' ');

                if (Vars.delFile.Length == 2)
                {
                    for (int i = 0; i < Vars.delFile.Length; i++)
                    {
                        if (i == 0)
                        {
                            Vars.cmd = Vars.delFile[i];
                        }
                        else if (i == 1)
                        {
                            Vars.delFilePath = Vars.path + @"\" + Vars.delFile[i];

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
        }
    }
}
