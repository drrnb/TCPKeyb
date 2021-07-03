// TCPKeyb (C) 2021 Pixel Rain
// https://tcpkeyb.pixelra.in
//
// TCPKeyb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// TCPKeyb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY

using System;
using System.Threading;
using System.Drawing;
using Console = Colorful.Console;

namespace TCPKeyb
{
    public class Menu
    {

        public static void Show()
        {
            Console.CursorVisible = true;
            Header.Draw();
            ChooseOptions();
        }


        /// <summary>
        /// Choose program option
        /// </summary>
        private static void ChooseOptions()
        {
            Console.Write("\tPlease use this application ");
            Console.Write("RESPONSIBLY", Color.HotPink);
            Console.WriteLine(".");

            Console.WriteLine(""); // Blank line

            Console.WriteLine("" +
                "\tA CLIENT CONNECTION WILL TRANSFER ALL\n" +
                "\tPRESSED KEYBOARD KEYS TO THE SERVER.");

            Console.WriteLine(""); // Blank line
            Console.WriteLine(""); // Blank line

            Console.Write("\t1) ", Color.HotPink);
            Console.WriteLine("Start a server", Color.Aquamarine);

            Console.Write("\t2) ", Color.HotPink);
            Console.WriteLine("Start a client", Color.Aquamarine);
            
            Console.WriteLine(""); // Blank line
            
            Console.Write("\t9) ", Color.HotPink);
            Console.WriteLine("Information", Color.Aquamarine);
            Console.Write("\t0) ", Color.HotPink);
            Console.WriteLine("Exit TCPKeyb", Color.Aquamarine);

            Console.WriteLine(""); // Blank line
            Console.WriteLine(""); // Blank line


            Console.Write("\tChoose a number option then press ");
            Console.Write("[ENTER] ", Color.DarkOrange);

            string response = Console.ReadLine();
            ReadResponse(response);
        }


        /// <summary>
        /// Read the user response
        /// </summary>
        /// <param name="response"></param>
        private static void ReadResponse(string response)
        {
            // If user entered a valid integer...
            if (int.TryParse(response, out int selection))
                switch (selection)
                {
                    case 0:
                        ExitApplication();
                        break;
                    case 1:
                        _ = new Server();
                        break;
                    case 2:
                        Client client = new Client();
                        client.StartClientSetup();
                        break;
                    case 9:
                        Information.Show();
                        break;
                    default:
                        Console.Clear();
                        Show();
                        break;
                }
            else // Not an int, try again...
                Console.Clear();
            Show();
        }


        public static void ExitApplication()
        {
            Header.Draw();
            Console.CursorVisible = false;
            Console.WriteLine("\tThank you for using TCPKeyb!");
            Console.Write("\tHave an awesome day. :) ");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }
}
