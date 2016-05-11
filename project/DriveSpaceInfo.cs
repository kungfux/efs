using System;
using System.IO;

namespace ffs_util
{
    internal class DriveSpaceInfo
    {
        private enum ESpaceSize
        {
            Bytes = 1,
            KB = 2,
            MB = 4,
            GB = 8,
            TB = 16
        }

        private string _driveName = "";


        public DriveSpaceInfo(string DriveName)
        {
            _driveName = DriveName;
        }


        public long GetFreeSpaceAsLong()
        {
            try
            {
                DriveInfo dinfo = new DriveInfo(_driveName);
                return dinfo.AvailableFreeSpace;
            }
            catch (Exception ex)
            {
                Message.Instance.PrintError(ex.Message);
                Environment.Exit(1);
                return -1;
            }
        }


        public string GetFreeSpaceAsString()
        {
            long space = GetFreeSpaceAsLong();
            long[] result = ConvertBytes(space, 1, 16);
            return string.Format("{0} {1}", result[0].ToString(), (ESpaceSize)result[1]);
        }


        private long[] ConvertBytes(long bytes, int minEnum, int maxEnum)
        {
            int value = 1024;
            int sizeName = 1;
            double size = bytes;
            while ((size > value && sizeName < maxEnum) || sizeName < minEnum)
            {
                size = size / 1024;
                sizeName = sizeName * 2;
            }
            return new long[] { (long)Math.Round(size, 0), sizeName };
        }
    }
}
