using System;

namespace ffs_util
{
    internal class Message
    {
        private static readonly Lazy<Message> _instance = new Lazy<Message>(() => new Message());

        public static Message Instance
        {
            get
            {
                return _instance.Value;
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
