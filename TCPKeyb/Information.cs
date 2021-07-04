// TCPKeyb | <https://tcpkeyb.pixelra.in>
// Copyright (c) 2021 Pixel Rain
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY - without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program. If not, see <https://www.gnu.org/licenses/>.

using System;
using System.Drawing;
using Console = Colorful.Console;

namespace TCPKeyb
{
    public class Information
    {

        /// <summary>
        /// Show application information screen
        /// </summary>
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

            Console.WriteLine("\tThe source code is available under a\n" +
                              "\tGNU AGPL3 licence at the above URL.", Color.Aquamarine);

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

            Console.CursorVisible = false;

            switch  (Console.ReadKey().Key)
            {
                case ConsoleKey.L:
                    Licence.Show();
                    break;
                case ConsoleKey.Enter:
                    Menu.Show();
                    break;
            }
        }
    }
}
