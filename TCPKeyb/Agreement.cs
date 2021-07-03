using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Console = Colorful.Console;

namespace TCPKeyb
{
    public static class Agreement
    {
        public static void Show()
        {
            Header.Draw();

            Console.WriteLine("" +
                "\tCopyright (C) 2021  Pixel Rain\n" +
                "\thttps://tcpkeyb.pixelra.in\n\n" +
                "\tThis program comes with ABSOLUTELY NO WARRANTY;\n" +
                "\tTCPKeyb is free software, and you are welcome to\n" +
                "\tredistribute it under certain conditions.\n" +
                "\tChoose \"Information\" from the main menu for details.", Color.Aquamarine);

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("\tBy continuing you also agree to use this software responsibly.", Color.HotPink);
            Console.WriteLine("");

            Console.Write("\tPress ");
            Console.Write("[ENTER] ", Color.DarkOrange);
            Console.WriteLine("to agree and continue");

            Console.Write("\tPress ");
            Console.Write("[CTRL+C] ", Color.DarkOrange);
            Console.Write("to exit TCPKeyb ");

            Console.CursorVisible = false;


            Console.ReadKey();
            Menu.Show();
        }
    }
}
