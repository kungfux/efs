using System;
using System.IO;

namespace efs
{
    internal class EatFreeSpace
    {
        private const string _pieFile = "pie.efs";

        /// <summary>
        /// Fill available free space using 'empty' file with defined length
        /// </summary>
        public void FillFreeSpace()
        {
            long freeSpace = Drive.Instance.GetAvailableFreeSpace();

            if (freeSpace <= 0)
            {
                Message.Instance.Write("There is no free space available.");
            }

            try
            {
                using (var fs = new FileStream(_pieFile, FileMode.CreateNew, FileAccess.Write))
                {
                    fs.SetLength(freeSpace);
                    fs.Close();
                    Message.Instance.Write("Free space on target drive has been filled up.");
                }
            }
            catch(Exception ex)
            {
                Message.Instance.Write(ex.Message, EMessageType.Error);
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
                Message.Instance.Write("Free space has been released.");
            }
            catch (Exception ex)
            {
                Message.Instance.Write(ex.Message, EMessageType.Error);
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
