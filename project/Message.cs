using System;

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

        /// <summary>
        /// Write message to console
        /// </summary>
        /// <param name="message">Text of message</param>
        /// <param name="messageType">Message type</param>
        public void Write(string message, EMessageType messageType = EMessageType.Info)
        {
            ConsoleColor currentColor = Console.ForegroundColor;

            switch (messageType)
            {
                case EMessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case EMessageType.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
            }

            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }
    }
}
