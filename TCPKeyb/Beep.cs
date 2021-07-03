using System;

namespace TCPKeyb
{
    public static class Beep
    {

        private static byte length = 75;

        public static void Connected()
        {
            Console.Beep(750, length);
            Console.Beep(1000, length);
        }


        public static void Disconnected()
        {
            Console.Beep(1000, length);
            Console.Beep(750,length);
        }
    }
}
