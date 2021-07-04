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

using System.Reflection;
using System.Drawing;
using Console = Colorful.Console;

namespace TCPKeyb
{
    public class Header
    {

        /// <summary>
        /// Returns the version information string
        /// </summary>
        public static string Version { get; } = "v" +
                $"{Assembly.GetExecutingAssembly().GetName().Version.Major}" +
                "." +
                $"{Assembly.GetExecutingAssembly().GetName().Version.Minor}" +
                "." +
                $"{Assembly.GetExecutingAssembly().GetName().Version.Revision}";


        /// <summary>
        /// Draws the header logo
        /// </summary>
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
