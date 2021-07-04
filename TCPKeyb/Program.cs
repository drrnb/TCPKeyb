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

namespace TCPKeyb
{
    class Program
    {

        /// <summary>
        /// Program entry point
        /// </summary>
        static void Main()
        {
            InitConsole();
            Agreement.Show();
        }

        /// <summary>
        /// Sets up a handler for CTRL+C
        /// </summary>
        private static void InitConsole()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(ExitHandler);
        }

        /// <summary>
        /// Handles CTRL+C press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void ExitHandler(object sender, ConsoleCancelEventArgs args)
        {
            Console.ResetColor();
            Console.Clear();
            Menu.ExitApplication();
        }
    }
}
