using System;
using System.IO;

namespace ffs_util
{
    internal class FillFreeSpace
    {
        private const string _pieFile = "pie.ffs";
        private readonly Drive _drive = new Drive();

        /// <summary>
        /// Fill available free space using 'empty' file declaration with defined length
        /// </summary>
        public void FillFreeSpaceWithEmptyFile(string drive)
        {
            if (!_drive.SetTargetDrive(drive))
            {
                Message.Instance.PrintError("Cannot use the drive specified.");
                return;
            }

            long freeSpace = _drive.GetAvailableFreeSpaceAsLong();

            if (freeSpace <= 0)
            {
                Message.Instance.PrintError("There is no free space available.");
                return;
            }

            Console.WriteLine(
                string.Format("Creating file {0} with size of {1}...",
                drive + @":\" + _pieFile,
                _drive.GetAvailableFreeSpaceAsString())
                );

            try
            {
                using (var fs = new FileStream(drive + @":\" + _pieFile, FileMode.CreateNew, FileAccess.Write))
                {
                    fs.SetLength(freeSpace);
                    fs.Close();
                    Console.WriteLine("Done.");
                }
            }
            catch(Exception ex)
            {
                Message.Instance.PrintError("Unable to create the file because of following exception:" 
                    + ex.Message);
            }
            
        }

        /// <summary>
        /// Remove 'empty' file to release the free space
        /// </summary>
        public void FreeTheSpace()
        {
            try
            {
                File.Delete(_pieFile);
                Console.WriteLine("Free space has been released.");
            }
            catch (Exception ex)
            {
                Message.Instance.PrintError(ex.Message);
            }
        }

        /// <summary>
        /// Check if 'empty' file is exists
        /// </summary>
        public bool IsPieFileExist()
        {
            return File.Exists(_pieFile);
        }
    }
}
