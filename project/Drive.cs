using System;
using System.IO;

namespace efs
{
    internal class Drive
    {
        private static readonly Lazy<Drive> _instance = new Lazy<Drive>(() => new Drive());

        public static Drive Instance
        {
            get
            {
                return _instance.Value;
            }
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
                string.Format("Target drive: {0}{1}{2}Available Free Space: {3} bytes",
                drive.Name,
                drive.VolumeLabel,
                Environment.NewLine,
                drive.AvailableFreeSpace));
        }

        public long GetAvailableFreeSpace()
        {
            return drive != null ? drive.AvailableFreeSpace : 0;
        }

        private string GetPathRoot()
        {
            return Path.GetPathRoot(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}
