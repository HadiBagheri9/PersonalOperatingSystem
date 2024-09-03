using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace PersonalOperatingSystem.Multiplex_Prompt
{
    class DC_TEXT
    {
        public static void Dc_Text(ref string cmd)
        {
            if (cmd.StartsWith("dctext"))
            {
                Vars.dcText = Vars.cmd.Split(' ');
                Vars.cmd = Vars.dcText[0];

                if (Vars.dcText.Length >= 3)
                {
                    if (Vars.dcText.Length > 3)
                    {
                        for (int i = 3; i < Vars.dcText.Length; i++)
                        {
                            Vars.dcText[2] += " " + Vars.dcText[i];
                        }
                    }

                    try
                    {
                        Console.WriteLine(DecryptText(Vars.dcText[1], Vars.dcText[2]));
                        //Console.WriteLine(Vars.encText[2]);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (Vars.dcText.Length == 2 || Vars.dcText.Length == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("dctext <16 byte key> <text>");
                }
            }
        }
        protected private static string DecryptText(string key, string text)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(text);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

    }
}
