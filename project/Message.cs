using System;
using System.Collections.Generic;
using System.Text;

namespace ffs_util
{
    internal class Message
    {
        private static Message _instance = new Message();

        public static Message Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Message();
                return _instance;
            }
        }

        public void PrintError(string message)
        {
            Console.WriteLine("ffs-util: " + message);
        }
    }
}
