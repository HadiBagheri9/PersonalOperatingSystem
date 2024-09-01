using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalOperatingSystem
{
    class HELP
    {
        public static void Help(ref string cmd)
        {
            if (cmd.CompareTo("help") == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.WriteLine("\'cd <path>\' : To change path(use without \'<\' and \'>\').");//
                Console.WriteLine("\'read <filename>\' : To read text files(use without \'<\' and \'>\').");
                Console.WriteLine("\'mkdir <foldername>\' : To make a directory(use without \'<\' and \'>\').");
                Console.WriteLine("\'touch <filename>\' : To make a file(use without \'<\' and \'>\').");
                Console.WriteLine("\'write <filename> <text>\' : To write a text inside a file.");//developing
                Console.WriteLine("\'delfile <foldername>\' : To delete a file(use without \'<\' and \'>\').");
                Console.WriteLine("\'deldir <foldername>\' : To delete a directory(use without \'<\' and \'>\').");
                Console.WriteLine("\'fileinfo <filename>\' : To display file informations.");
                Console.WriteLine("\'dirinfo <dirname>\' : To display directory informations.");
                Console.WriteLine("\'enctext <16 byte key> <text>\' : To encrypt a text.");
                Console.WriteLine("\'dctext <16 byte key> <text>\' : To decrypt a text.");
                Console.WriteLine("\'ls\' : To show files and directories.");
                Console.WriteLine("\'date\' : To show date of your system.");
                Console.WriteLine("\'time\' : To show time of your system.");
                Console.WriteLine("\'ip\' : To show IP list of your system.");
                Console.WriteLine("\'cls\' or \'clear\' : To clear and refresh window.");
                Console.WriteLine("\'exit\' : To close this window.");
                Console.WriteLine("\'shutdown\' : To shutdown your computer.");
                Console.WriteLine("\'restart\' : To restart your computer.");
                Console.WriteLine("\'help\' : To see this message.");
            }
        }
    }
}
