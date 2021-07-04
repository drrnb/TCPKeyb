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
    public static class Beep
    {

        private static byte length = 75;


        /// <summary>
        /// Plays connected console beep
        /// </summary>
        public static void Connected()
        {
            Console.Beep(750, length);
            Console.Beep(1000, length);
        }


        /// <summary>
        /// Plays disconnected console beep
        /// </summary>
        public static void Disconnected()
        {
            Console.Beep(1000, length);
            Console.Beep(750,length);
        }
    }
}
