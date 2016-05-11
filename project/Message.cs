using System;
using System.Collections.Generic;
using System.Reflection;
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


        public void PrintError(string Message)
        {
            Console.WriteLine("ffs-util: " + Message);
        }


        public void PrintMessage(string Message)
        {
            Console.WriteLine(Message);
        }


        public void PrintGreetings()
        {
            StringBuilder help = new StringBuilder();

            help.Append("Fill Free Space utility [Version ");
            help.Append(Assembly.GetExecutingAssembly().GetName().Version.ToString());
            help.AppendLine("]");
            help.AppendLine("Copyright (c) 2016 Alexander Fuks");

            Console.WriteLine(help.ToString());
        }


        public void PrintHelp()
        {
            // TODO: Add [-m[=(mode 0|1)]]

            StringBuilder help = new StringBuilder();
            
            help.AppendLine("usage: ffs-util [--help] [/?] [-d[=(drive)]]");
            help.AppendLine();
            help.AppendLine("The keywords used in commands are:");
            help.AppendLine("   drive   System drive name e.g. C");

            Console.WriteLine(help.ToString());
        }
    }
}
