
using System;

namespace TCPKeyb
{
    class Program
    {
        static void Main()
        {
            InitConsole();
            Agreement.Show();
        }

        private static void InitConsole()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(ExitHandler);
        }

        private static void ExitHandler(object sender, ConsoleCancelEventArgs args)
        {
            Console.ResetColor();
            Console.Clear();
            Menu.ExitApplication();
        }
    }
}
