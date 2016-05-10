using System;
using System.IO;

namespace ffs_util
{
    internal class Drive
    {
        private static Drive _instance = new Drive();

        public static Drive Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Drive();
                return _instance;
            }
        }

        private enum SpaceSize
        {
            Bytes = 1,
            KB = 2,
            MB = 4,
            GB = 8,
            TB = 16
        }

        private DriveInfo _drive = null;

        public bool SetTargetDrive(string drive)
        {
            try
            {
                _drive = new DriveInfo(drive);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public long GetAvailableFreeSpaceAsLong()
        {
            return _drive != null ? _drive.AvailableFreeSpace : 0;
        }

        public string GetAvailableFreeSpaceAsString()
        {
            long[] result = ConvertBytes(GetAvailableFreeSpaceAsLong(), 1, 16);
            return string.Format("{0} {1}", result[0].ToString(), (SpaceSize)result[1]);
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
