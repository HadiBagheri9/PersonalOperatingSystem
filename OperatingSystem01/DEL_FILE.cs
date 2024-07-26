using System;
using System.IO;
namespace PersonalOperatingSystem
{
    class DEL_FILE
    {
        public static void Del_File(ref string cmd)
        {
            if (Vars.cmd.StartsWith("delfile"))
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
        }
    }
}
