using System.Drawing;
using Console = Colorful.Console;

namespace TCPKeyb
{
    public class Information
    {
        public static void Show()
        {
            Header.Draw();

            Console.Title = $"About TCPKeyb ({Header.Version})";
            Console.WriteLine("" +
                "\tCopyright (c) 2021 Pixel Rain\n" +
                "\thttps://tcpkeyb.pixelra.in", Color.Aquamarine);

            Console.WriteLine(""); // blank

            Console.WriteLine("" +
                "\tThis program comes with ABSOLUTELY NO WARRANTY;\n" +
                "\tTCPKeyb is free software, and you are welcome to\n" +
                "\tredistribute it under certain conditions.", Color.Aquamarine);

            Console.WriteLine(""); // blank
            Console.WriteLine(""); // blank

            Console.WriteLine($"\tAbout TCPKeyb ({Header.Version})", Color.HotPink);
            Console.WriteLine("" +
                "\tTCPKeyb is a utility that allows you to send keystrokes\n" +
                "\tover a network connection (a client) or receive keystrokes\n" +
                "\tfrom a client connection (a server) and have the keys press.\n" +
                "\tTCPKeyb doesn't have to be in the foreground to work.", Color.Aquamarine);

            Console.WriteLine(""); // blank
            Console.WriteLine(""); // blank

            Console.Write("\tPress ");
            Console.Write("[L]", Color.DarkOrange);
            Console.WriteLine(" to view GNU licence details");


            Console.Write("\tPress ");
            Console.Write("[ENTER]", Color.DarkOrange);
            Console.Write(" to return to the main menu ");

            string response = Console.ReadLine().ToUpper();

            switch (response)
            {
                case ("L"):
                    Licence.Show();
                    break;
                default:
                    Menu.Show();
                    break;
            }

            Console.ReadLine();
            Menu.Show();
        }
    }
}
