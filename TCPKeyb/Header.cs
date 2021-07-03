using System;
using System.Reflection;
using System.Drawing;
using Console = Colorful.Console;

namespace TCPKeyb
{
    public class Header
    {
        public static string Version { get; } = "v" +
                $"{Assembly.GetExecutingAssembly().GetName().Version.Major}" +
                "." +
                $"{Assembly.GetExecutingAssembly().GetName().Version.Minor}";


        public static void Draw()
        {
            Console.Title = "TCPKeyb";
            Console.Clear();
            Console.WriteLine(""); // Blank line
            Console.WriteLine(""); // Blank line
            Console.WriteLine("\t----------------------------------------", Color.DeepPink);
            Console.WriteLine("\t _____ ____ ____  _  __          _     ", Color.Aqua);
            Console.WriteLine("\t|_   _/ ___|  _ \\| |/ /___ _   _| |__  ");
            Console.WriteLine("\t  | || |   | |_) | ' // _ \\ | | | '_ \\ ", Color.HotPink);
            Console.WriteLine("\t  | || |___|  __/| . \\  __/ |_| | |_) |", Color.DeepPink);
            Console.WriteLine("\t  |_| \\____|_|   |_|\\_\\___|\\__, |_.__/ ", Color.Aqua);
            Console.WriteLine($"\t                           |___/ {Version}");
            Console.WriteLine("\t----------------------------------------", Color.DeepPink);

            Console.WriteLine(""); // Blank line
            Console.WriteLine(""); // Blank line
        }
    }
}
