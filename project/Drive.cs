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

        private DriveInfo drive = null;

        public Drive()
        {
            string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string rootPath = null;

            if (!string.IsNullOrEmpty(appPath))
                rootPath = Path.GetPathRoot(appPath);

            if (!string.IsNullOrEmpty(rootPath))
                drive = new DriveInfo(rootPath);
        }

        public void PrintDriveInfo()
        {
            if (drive == null)
                return;

            Message.Instance.Write(
                string.Format("Target drive: {0}{1}{2}Available Free Space: {3}",
                drive.Name,
                drive.VolumeLabel,
                Environment.NewLine,
                GetConvertedBytes(drive.AvailableFreeSpace)));
        }

        public long GetAvailableFreeSpace()
        {
            return drive != null ? drive.AvailableFreeSpace : 0;
        }

        private string GetPathRoot()
        {
            return Path.GetPathRoot(System.Reflection.Assembly.GetExecutingAssembly().Location);
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

        private string GetConvertedBytes(long bytes)
        {
            long[] result = ConvertBytes(bytes, 1, 16);
            return string.Format("{0} {1}", result[0].ToString(), (SpaceSize)result[1]);
        }
    }
}
