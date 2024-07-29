using System;
using System.Net;
using System.Diagnostics;

namespace PersonalOperatingSystem
{
    class Program
    {
        static void Main()
        {
            


            Vars.userName = Environment.UserName;
            Vars.machineName = Environment.MachineName;
            Vars.path = $@"C:\Users\{Vars.userName}";

            //Console.WriteLine("Hadi's personal virtual OS");
            Console.WriteLine(@" ____  ____       _       ______   _____  ");
            Console.WriteLine(@"|_   ||   _|     / \     |_   _ `.|_   _| ");
            Console.WriteLine(@"  | |__| |      / _ \      | | `. \ | |   ");
            Console.WriteLine(@"  |  __  |     / ___ \     | |  | | | |   ");
            Console.WriteLine(@" _| |  | |_  _/ /   \ \_  _| |_.' /_| |_  ");
            Console.WriteLine(@"|____||____||____| |____||______.'|_____| ");

            while (true)
            {
                //Console.Write($"{path}>");
                //Console.Write("<");
                //Console.Write("==");
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("(");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{Vars.userName}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{Vars.machineName}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(")");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("-");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{Vars.path}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("]");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("==");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(">");
                //Console.Write("\n");

                Console.ResetColor();
                Vars.cmd = Console.ReadLine();
                Vars.cmd = Vars.cmd.Trim();
                Vars._cmd = Vars.cmd.Split(' ');
                Vars._cmd[0] = Vars._cmd[0].ToLower();
                Vars.cmd = string.Join(" ", Vars._cmd);

                Console.Write("\n");


                //***cd***
                CD.Cd(ref Vars.cmd);

                //***read***
                READ.Read(ref Vars.cmd);

                //***mkdir***md***makedirectory***
                MAKE_DIRECTORY.Make_Directory(ref Vars.cmd);

                //***touch***
                TOUCH.Touch(ref Vars.cmd);

                //***delfile***
                DELETE_FILE.Del_File(ref Vars.cmd);

                //***deldir***
                DELETE_DIRECTORY.Delete_Directory(ref Vars.cmd);

                //***ls***
                LS.Ls(ref Vars.cmd);

                //***date***
                DATE.Date(ref Vars.cmd);

                //***time***
                TIME.Time(ref Vars.cmd);

                //***cls***
                CLEAR.Clear(ref Vars.cmd);

                //***exit***
                EXIT.Exit(ref Vars.cmd);

                Console.ResetColor();

                switch (Vars.cmd)
                {
                    case "cd":
                        break;

                    case "read":
                        break;

                    case "md":
                    case "mkdir":
                    case "makedirectory":
                        break;

                    case "delfile":
                    case "deletefile":
                        break;

                    case "deldir":
                    case "deletedirectory":
                        break;

                    case "touch":
                        break;

                    case "ls":
                        break;

                    case "date":
                        break;

                    case "time":
                        break;

                    case "ip":

                        var ips = (Dns.GetHostEntry(Dns.GetHostName()).AddressList);

                        foreach (var ip in ips)
                        {
                            Console.WriteLine(ip.ToString());
                        }

                        break;

                    case "cls":
                    case "clear":
                        break;

                    case "exit":
                        break;

                    case "shutdown":

                        Process.Start("ShutDown", "/s");

                        break;

                    case "restart":

                        Process.Start("ShutDown", "/r");

                        break;

                    case "help":
                        break;

                    default:

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input is wrong, Type \'help\' to see more.");

                        break;
                }
                Console.ResetColor();
            }
        }

        

        
    }
}
