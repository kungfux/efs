using System;
using System.IO;
using System.Reflection;

namespace ffs_util
{
    class Program
    {
        static void Main(string[] args)
        {
            Message.Instance.PrintGreetings();

            if (args == null || args.Length <= 0)
            {
                string activeDrive = Assembly.GetExecutingAssembly().Location.Substring(0, 1);
                Message.Instance.PrintMessage("Note: No arguments were specified. Using drive " + activeDrive);
                new FillFreeSpace().FillFreeSpaceWithEmptyFileOrDelete(activeDrive);
                return;
            }

            for (int a = 0; a < args.Length; a++)
            {
                if (args[a] == "--help" || args[a] == "/?")
                {
                    Message.Instance.PrintHelp();
                    break;
                }

                if (args[a].StartsWith("-d=") && args[a].Length == 4)
                {
                    char driveName = args[a].Substring(3, 1).ToUpper().ToCharArray()[0];
                    if (driveName >= 'A' && driveName <= 'Z')
                    {
                        string drive = args[a].Substring(3, 1);
                        new FillFreeSpace().FillFreeSpaceWithEmptyFileOrDelete(drive);
                        break;
                    }

                    Message.Instance.PrintError(driveName + " is not a correct drive name. See 'ffs-util --help'.");
                    break;
                }

                Message.Instance.PrintError(args[a] + " is not a correct command. See 'ffs-util --help'.");
            }
        }
    }
}
