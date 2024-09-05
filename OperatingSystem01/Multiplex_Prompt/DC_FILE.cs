using System;
using System.IO;
using System.Text;

namespace PersonalOperatingSystem.Multiplex_Prompt
{
    class DC_FILE : DC_TEXT
    {
        public static void Dc_File(ref string cmd)
        {
            if (cmd.StartsWith("dcfile"))
            {
                Vars.dcFile = Vars.cmd.Split(' ');
                Vars.cmd = Vars.dcFile[0];

                if (Vars.dcFile.Length == 3)
                {
                    if (File.Exists(Vars.path + "\\" + Vars.dcFile[2]))
                    {
                        StreamWriter st = null;
                        try
                        {
                            Vars.fileContent = File.ReadAllText(Vars.path + "\\" + Vars.dcFile[2]);
                            Vars.fileContent = DecryptText(Vars.dcFile[1], Vars.fileContent);
                            if (!Vars.fileContent.Equals(null) && !Vars.fileContent.Equals(""))
                            {
                                st = new StreamWriter(Vars.path + "\\" + Vars.dcFile[2], false, Encoding.UTF8);
                                st.WriteLine(Vars.fileContent);
                                st.Close();
                                st.Dispose();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Key is wrong!");
                            }
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
                        Console.WriteLine($"File <{Vars.dcFile[2]}> not found!");
                    }
                }
                else if (Vars.dcFile.Length == 2 || Vars.dcFile.Length == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("dcfile <16 byte key> <filename>");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Input is wrong!");
                }
            }
        }
    }
}
