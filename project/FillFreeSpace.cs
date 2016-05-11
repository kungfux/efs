using System;
using System.IO;

namespace ffs_util
{
    internal class FillFreeSpace
    {
        private const string _pieFile = "pie.ffs";

        /// <summary>
        /// Fill available free space using temporary file declaration with defined length
        /// </summary>
        public void FillFreeSpaceWithEmptyFileOrDelete(string DriveName)
        {
            DriveSpaceInfo drive = new DriveSpaceInfo(DriveName);

            string pieFileFullName = DriveName + @":\" + _pieFile;

            if (File.Exists(pieFileFullName))
            {
                DeletePieFile(pieFileFullName);
                return;
            }

            CreatePieFile(pieFileFullName, drive.GetFreeSpaceAsLong(), drive.GetFreeSpaceAsString());
        }


        private void CreatePieFile(string PieFileFullName, long DriveFreeSpace, string DriveFreeSpaceAsString)
        {
            if (DriveFreeSpace <= 0)
            {
                Message.Instance.PrintError("There is no free space available. Operation is aborted.");
                return;
            }

            Message.Instance.PrintMessage(
                string.Format("Creating file {0} with size of {1}...",
                PieFileFullName, DriveFreeSpaceAsString)
                );

            try
            {
                using (var fs = new FileStream(PieFileFullName, FileMode.CreateNew, FileAccess.Write))
                {
                    fs.SetLength(DriveFreeSpace);
                    fs.Close();
                    Message.Instance.PrintMessage("Done.");
                }
            }
            catch(Exception ex)
            {
                Message.Instance.PrintError(ex.Message);
            }
        }


        private void DeletePieFile(string PieFileFullName)
        {
            Message.Instance.PrintMessage("Temporary file already exists. Removing...");

            try
            {
                File.Delete(PieFileFullName);
                Message.Instance.PrintMessage("Done.");
            }
            catch (Exception ex)
            {
                Message.Instance.PrintError(ex.Message);
            }
        }
    }
}
