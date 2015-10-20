using System;
using System.IO;

namespace efs
{
    internal class FreeSpace
    {
        const string _pieFile = "pie.efs";
        const string _pieBuffer = "AMAMAMAMAM";
        const int _maxBuffer = int.MaxValue;

        public void Do()
        {
            if (IsPieExist())
                FreeTheSpace();
            else
                EatFreeSpace();
        }

        private void EatFreeSpace()
        {
            Drive.Instance.PrintDriveInfo();

            Messaging.Instance.Write("Eating...");

            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(_pieFile);
                while (true)
                {
                    sw.Write(_pieBuffer);
                }
            }
            catch (IOException ex)
            {
                if (ex.HResult == 27 || ex.HResult == 70)
                    Messaging.Instance.Write("Free Space has ended.");
                else
                    Messaging.Instance.Write(ex.Message, EMessageType.Error);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        private void FreeTheSpace()
        {
            try
            {
                File.Delete(_pieFile);
                Messaging.Instance.Write("Free space has been released.");
            }
            catch (Exception ex)
            {
                Messaging.Instance.Write(ex.Message, EMessageType.Error);
            }
        }

        private bool IsPieExist()
        {
            return File.Exists(_pieFile);
        }
    }
}
