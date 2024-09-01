using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace PersonalOperatingSystem.Multiplex_Prompt
{
    class ENC_TEXT
    {
        public static void Enc_Text(ref string cmd)
        {
            if (cmd.StartsWith("enctext"))
            {
                Vars.encText = Vars.cmd.Split(' ');
                Vars.cmd = Vars.encText[0];

                if (Vars.encText.Length >= 3)
                {
                    if (Vars.encText.Length > 3)
                    {
                        for (int i = 3; i < Vars.encText.Length; i++)
                        {
                            Vars.encText[2] += " " + Vars.encText[i];
                        }
                    }

                    try
                    {
                        Console.WriteLine(EncryptText(Vars.encText[1], Vars.encText[2]));
                        //Console.WriteLine(Vars.encText[2]);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (Vars.encText.Length == 2 || Vars.encText.Length == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("enctext <16 byte key> <text>");
                }
            }
        }
        protected private static string EncryptText(string key, string text)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(text);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }
    }
}
