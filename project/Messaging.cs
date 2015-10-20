using System;

namespace efs
{
    internal class Messaging
    {
        private static readonly Lazy<Messaging> _instance = new Lazy<Messaging>(() => new Messaging());

        public static Messaging Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void Write(string message, EMessageType messageType = EMessageType.Info)
        {
            Console.ForegroundColor =
                messageType == EMessageType.Error ? ConsoleColor.DarkRed : ConsoleColor.Gray;

            Console.WriteLine(message);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
