using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Console = Colorful.Console;

namespace TCPKeyb
{
    public static class Licence
    {
        public static void Show()
        {
            Header.Draw();

            Console.WriteLine(
                "\tCopyright (C) 2021  Pixel Rain\n" +
                "\thttps://tcpkeyb.pixelra.in", Color.Aquamarine);

            Console.WriteLine("");

            Console.WriteLine(
                "\tThis program is free software: you can redistribute it and / or modify\n" +
                "\tit under the terms of the GNU General Public License as published by\n" +
                "\tthe Free Software Foundation, either version 3 of the License, or\n" +
                "\t(at your option) any later version.\n\n" +

                "\tThis program is distributed in the hope that it will be useful,\n" +
                "\tbut WITHOUT ANY WARRANTY; without even the implied warranty of\n" +
                "\tMERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.\n" +
                "\tSee the GNU General Public License for more details.\n\n" +

                "\tYou should have received a copy of the GNU General Public License\n" +
                "\talong with this program. If not, see https://www.gnu.org/licenses/."
            , Color.Aquamarine);

            Console.WriteLine("");

            Console.Write("\tPress any key to return to the main menu ");
            Console.Read();
            Menu.Show();
        }
    }
}
