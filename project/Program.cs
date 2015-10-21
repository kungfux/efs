using System;

namespace efs
{
    class Program
    {
        static void Main(string[] args)
        {
            var efs = new EatFreeSpace();

            if (efs.IsPieFileExist())
                efs.FreeTheSpace();
            else
            {
                Drive.Instance.PrintDriveInfo();
                Message.Instance.Write("Free space on target drive will be filled up. Press any key to continue...");
                Console.ReadKey();
                efs.FillFreeSpace();
            }
        }
    }
}
