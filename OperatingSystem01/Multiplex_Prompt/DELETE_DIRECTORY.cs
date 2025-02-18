﻿using System;
using System.IO;

namespace PersonalOperatingSystem
{
    class DELETE_DIRECTORY
    {
        public static void Delete_Directory(ref string cmd)
        {
            if (cmd.StartsWith("deldir") || cmd.StartsWith("deletedirectory"))
            {
                Vars.delDirectory = Vars.cmd.Split(' ');

                if (Vars.delDirectory.Length == 2)
                {
                    for (int i = 0; i < Vars.delDirectory.Length; i++)
                    {
                        if (i == 0)
                        {
                            Vars.cmd = Vars.delDirectory[i];
                        }
                        else if (i == 1)
                        {
                            Vars.delDirectoryPath = Vars.path + @"\" + Vars.delDirectory[i];

                            if (Directory.Exists(Vars.delDirectoryPath))
                            {
                                try
                                {
                                    Directory.Delete(Vars.delDirectoryPath);
                                }
                                catch
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Failed to delete folder.");
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Folder not found.");
                            }
                        }
                    }
                }
                else if (Vars.delDirectory.Length == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("deldir <foldername>");
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
