using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Drawing;
using Console = Colorful.Console;

namespace TCPKeyb
{
    public class Server
    {
        int defaultPort = 5000;

        /// <summary>
        /// Creates the server and runs the start method
        /// </summary>
        public Server()
        {
            Header.Draw();
            SetupServer();
        }


        /// <summary>
        /// Asks for the port number to begin
        /// </summary>
        private void SetupServer()
        {
            Console.Write("\tWhich port would you like to run the server on? ");
            Console.WriteLine($"[{defaultPort}]", Color.Aquamarine);
            Console.Write("\n\t");

            string response = Console.ReadLine();

            // Make sure it's an integer and valid port number,
            // if user didn't just accept default
            if (int.TryParse(response, out int port)
                && (port > 0 && port < 65535))
                StartServer(port);
            else if (string.IsNullOrWhiteSpace(response))
                StartServer(defaultPort);
            else
                SetupServer();
        }


        private static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }


        private void ShowConnectedText(string clientInfo, int port)
        {
            Header.Draw();
            Console.Title = $"{Console.Title} | Connected from {clientInfo}";
            Console.Write("\tClient is ");
            Console.Write("CONNECTED ", Color.HotPink);
            Console.Write("from ");
            Console.Write($"{clientInfo} ", Color.Aquamarine);
            Console.Write("to port ");
            Console.WriteLine(port, Color.Aquamarine);
            Console.WriteLine("");
            Console.Write(
                "\tFor as long as the client stays connected,\n" +
                "\tyou will receive the client keyboard input.");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("\t");
            Beep.Connected();
        }


        /// <summary>
        /// Starts the server
        /// </summary>
        /// <param name="port">The port to run on</param>
        private void StartServer(int port)
        {
            TcpListener server = null;
            string closeReason = string.Empty;

            try
            {
                server = new TcpListener(IPAddress.Parse("0.0.0.0"), port);

                // Start listening for client requests.
                server.Start();

                Header.Draw();
                Console.Write("\tWaiting for a connection on port ");
                Console.Write($"{port}", Color.Aquamarine);
                Console.WriteLine("... ");

                Console.WriteLine(""); // blank line
                Console.WriteLine(""); // blank line

                Console.Write("\tPress ");
                Console.Write("[CTRL+C] ", Color.DarkOrange);
                Console.Write("to cancel and exit ");

                // Enter the listening loop.
                while (true)
                {
                    // Perform a blocking call to accept requests.
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();

                    // Show the connection information
                    string connInfo = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                    ShowConnectedText(connInfo, port);

                    // Loop to receive keys
                    int i;
                    while ((i = stream.ReadByte()) != 0)
                    {
                        if (Console.KeyAvailable)
                            Console.ReadKey(true);

                        Keys key = (Keys)i;

                        ClearCurrentConsoleLine();
                        Console.Write("\tLast Received Key: ", Color.HotPink);
                        Console.Write($"{key} ", Color.DarkOrange);

                        // Press the key on the server
                        Keyboard.PressKey(key);
                        Console.CursorVisible = false;
                    }

                    // Shutdown and end connection
                    client.Close();
                    closeReason = "The client was disconnected.";
                }
            }
            catch (SocketException)
            {
                closeReason = "A socket exception occurred.";
            }
            catch (IOException)
            {
                
                closeReason = "The client was closed.";
            }
            finally
            {
                server.Stop();
                Header.Draw();
                Console.WriteLine($"\t{closeReason}");
                Beep.Disconnected();
                Console.WriteLine("");

                Console.Write("\tPress ");
                Console.Write("[ENTER] ", Color.DarkOrange);
                Console.Write("to return to the main menu ");

                // Make sure no extra keys are output to the console
                if (Console.KeyAvailable)
                    Console.ReadKey(true);

                Console.ReadLine();
                Menu.Show();
            }
        }
    }
}