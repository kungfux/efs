using System;
using System.IO;
using System.Reflection;

namespace ffs_util
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintAbout();

            if (args == null ||
                args.Length <= 0)
            {
                PrintHelp();
                return;
            }

            string drive = "";

            for (int a = 0; a < args.Length; a++)
            {
                if (args[a] == "--help" ||
                    args[a] == "/?")
                {
                    PrintHelp();
                    return;
                }

                if (args[a].StartsWith("-d=") && args[a].Length == 4)
                {
                    drive = args[a].Substring(3, 1);
                    Console.WriteLine(drive);
                }
                else
                {
                    Console.WriteLine(
                        string.Format("ssf-util: '{0}' is not a correct command. See 'ffs-util --help'.",
                        args[a])
                        );
                    return;
                }
            }

            //var efs = new EatFreeSpace();

            //if (efs.IsPieFileExist())
            //    efs.FreeTheSpace();
            //else
            //{
            //    Drive.Instance.PrintDriveInfo();
            //    Message.Instance.Write("Free space on target drive will be filled up. Press any key to continue...");
            //    Console.ReadKey();
            //    efs.FillFreeSpace();
            //}
        }

        static void PrintAbout()
        {
            Console.WriteLine(
                string.Format("Fill Free Space utility [Version {1}]{0}Copyright (c) 2016 Alexander Fuks{0}", 
                Environment.NewLine,
                Assembly.GetExecutingAssembly().GetName().Version.ToString())
                );
        }

        static void PrintHelp()
        {
            // TODO: Add [-m[=(mode 0|1)]]
            Console.WriteLine(
                string.Format(
                    string.Concat(
                        "usage: ffs-util [--help] [/?] [-d[=(drive)]]  {0}{0}",
                        "The keywords used in commands are: {0}",
                        "   drive   System drive name like C or D {0}"),
                    Environment.NewLine)
                );
        }
    }
}
