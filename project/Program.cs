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

            // TODO: Return feature that file will be created on the active drive without arguments
            if (args == null || args.Length <= 0)
            {
                PrintHelp();
                return;
            }

            for (int a = 0; a < args.Length; a++)
            {
                if (args[a] == "--help" || args[a] == "/?")
                {
                    PrintHelp();
                    return;
                }

                if (args[a].StartsWith("-d=") && args[a].Length == 4)
                {
                    string drive = args[a].Substring(3, 1);
                    new FillFreeSpace().FillFreeSpaceWithEmptyFile(drive);
                    return;
                }

                Message.Instance.PrintError(args[a] + " is not a correct command. See 'ffs-util --help'.");
                return;
            }
        }

        static void PrintAbout()
        {
            Console.WriteLine(
                string.Format(
                    "Fill Free Space utility [Version {1}]{0}" +
                    "Copyright (c) 2016 Alexander Fuks{0}", 
                Environment.NewLine,
                Assembly.GetExecutingAssembly().GetName().Version.ToString())
                );
        }

        static void PrintHelp()
        {
            // TODO: Add [-m[=(mode 0|1)]]
            Console.WriteLine(
                string.Format(
                        "usage: ffs-util [--help] [/?] [-d[=(drive)]] {0}{0}" +
                        "The keywords used in commands are: {0}" +
                        "   drive   System drive name like C or D {0}",
                    Environment.NewLine)
                );
        }
    }
}
