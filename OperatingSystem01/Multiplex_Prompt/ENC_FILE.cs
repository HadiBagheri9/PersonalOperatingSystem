using System;
using System.IO;
using System.Text;

namespace PersonalOperatingSystem.Multiplex_Prompt
{
    class ENC_FILE : ENC_TEXT
    {
        public static void Enc_File(ref string cmd)
        {
            if (cmd.StartsWith("encfile"))
            {
                Vars.encFile = Vars.cmd.Split(' ');
                Vars.cmd = Vars.encFile[0];

                if (Vars.encFile.Length == 3)
                {
                    if (File.Exists(Vars.path + "\\" + Vars.encFile[2]))
                    {
                        StreamWriter st = null;
                        try
                        {
                            Vars.fileContent = File.ReadAllText(Vars.path + "\\" + Vars.encFile[2]);
                            st = new StreamWriter(Vars.path + "\\" + Vars.encFile[2], false, Encoding.UTF8);
                            st.WriteLine(EncryptText(Vars.encFile[1], Vars.fileContent));
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            st.Close();
                            st.Dispose();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"File <{Vars.encFile[2]}> not found!");
                    }
                }
                else if (Vars.encFile.Length == 2 || Vars.encFile.Length == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("encfile <16 byte key> <filename>");
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
