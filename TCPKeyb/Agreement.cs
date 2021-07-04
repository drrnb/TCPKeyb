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

using System.Drawing;
using Console = Colorful.Console;

namespace TCPKeyb
{
    public static class Agreement
    {

        /// <summary>
        /// Show welcome agreement screen
        /// </summary>
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


            switch(Console.ReadKey().Key)
            {
                case System.ConsoleKey.Enter:
                    Menu.Show();
                    break;
                default:
                    Show();
                    break;
            }


        }
    }
}
