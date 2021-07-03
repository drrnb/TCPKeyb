using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace TCPKeyb
{
    public class ClientConnection
    {
        public byte PressedKey { get; set; } = 0x00;

        /// <summary>
        /// Attempts to make a connection to the server:port
        /// </summary>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="message"></param>
        public ClientConnection(string server, int port)
        {

            try
            {
                // Create a TcpClient.
                TcpClient client = new TcpClient(server, port);

                // Get a client stream for reading and writing.
                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer.
                while (stream.CanWrite)
                {
                    Console.WriteLine(PressedKey);
                    if (this.PressedKey != 0x00)
                    {
                        //stream.WriteByte(pressedKey);
                        Console.WriteLine($"Sending key byte: {this.PressedKey}");
                        this.PressedKey = 0x00;
                    }
                    //byte[] data = Encoding.ASCII.GetBytes("test\n");
                    // If keypress, send it
                    //stream.Write(data, 0, data.Length);
                }

                /*
                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new byte[1];

                // String to store the response ASCII representation.
                string responseData = string.Empty;

                // Read the first batch of the TcpServer response bytes.
                int bytes = stream.Read(data, 0, 1);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {responseData}");
                */

                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
    }
}
