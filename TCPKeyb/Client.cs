using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing;
using Console = Colorful.Console;

namespace TCPKeyb
{
    class Client
    {
        /// <summary>
        /// Setup the client information
        /// </summary>
        public void StartClientSetup()
        {
            Header.Draw();

            // User entered IP
            string ip = SetupIP();
            Header.Draw();

            // User entered Port
            int port = SetupPort(ip);

            ConfirmResponses(ip, port);
        }


        /// <summary>
        /// Confirm user entries
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        private void ConfirmResponses(string ip, int port)
        {
            // Reset window
            Header.Draw();

            Console.Write("\tConnection details are: ");
            Console.Write($"{ip}:{port}", Color.Aquamarine);
            Console.WriteLine("");

            Console.Write("\tIs this correct? ");
            Console.WriteLine("[y/n]", Color.DarkOrange);
            Console.Write("\n\t");

            string response = Console.ReadLine().ToUpper();

            // Ask if sure
            if (response == "N")
                StartClientSetup();
            if (response == "Y")
                StartKeyboardListener(ip, port);
            else
                ConfirmResponses(ip, port);
        }



        private void StartKeyboardListener(string ip, int port)
        {
            Thread keyHook = new Thread(() =>
            ClientConnection.InitKeyboardHookClient(ip, port));
            keyHook.Start();

            while (keyHook.IsAlive)
            {
                Console.CursorVisible = false;
                Console.ReadKey(true);
            }
        }


        /// <summary>
        /// Asks the user for the port number
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public int SetupPort(string ip)
        {
            int port = 0;
            bool portOK = false;

            string portPrompt = $"\tWhich port number for {ip}?";
            Console.WriteLine(portPrompt);
            Console.Write("\n\t");


            while (!portOK)
            {

                string response = Console.ReadLine();

                if (!int.TryParse(response, out port)
                    || (port <= 0 || port > 65535))
                {
                    Header.Draw();
                    Console.WriteLine(portPrompt);
                    Console.Write("\n\t");
                }
                else if (port >= 0 && port <= 65535)
                {
                    portOK = true;
                }
            }

            return port;
        }


        /// <summary>
        /// Asks the user for the IP Address
        /// </summary>
        /// <returns>The IP address</returns>
        public string SetupIP()
        {
            IPAddress ip = null;

            string ipPrompt = "\tWhat's the IP address of the server you are connecting to?";
            Console.WriteLine(ipPrompt);
            Console.Write("\n\t");

            while (ip == null)
            {
                if (!IPAddress.TryParse(Console.ReadLine(), out ip))
                {
                    Header.Draw();
                    Console.WriteLine(ipPrompt);
                    Console.Write("\n\t");
                }
            }

            return ip.ToString();
        }
    }
}
