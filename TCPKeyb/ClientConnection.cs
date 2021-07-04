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
using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using Console = Colorful.Console;
using System.Text.RegularExpressions;
using System.Linq;

namespace TCPKeyb
{
    public class ClientConnection
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static NetworkStream stream;
        private static TcpClient client;



        /// <summary>
        /// Begin the connection and init the keyboard hooks
        /// </summary>
        /// <param name="server"></param>
        /// <param name="port"></param>
        public static void InitKeyboardHookClient(string server, int port)
        {
            try
            {
                Header.Draw();
                Console.Write("\tAttempting to connect to ");
                Console.Write($"{server}:{port}",Color.Aquamarine);
                Console.Write("... ");

                client = new TcpClient(server, port);
                stream = client.GetStream();

                _hookID = SetHook(_proc);

                Header.Draw();
                Console.Title = $"{Console.Title} | Connected to {client.Client.RemoteEndPoint}";
                Console.Write("\tCONNECTED ", Color.HotPink);
                Console.Write("to ");
                Console.WriteLine($"{client.Client.RemoteEndPoint}", Color.Aquamarine);

                Console.WriteLine(""); // blank line
                Console.WriteLine(
                    "\tALL KEYBOARD KEYS PRESSED ON THIS\n" +
                    "\tSYSTEM WILL BE SENT TO THE SERVER!");

                Beep.Connected();

                Application.Run();
                UnhookWindowsHookEx(_hookID);

            }
            catch (Exception e)
            {
                string[] errorLines = SpliceText(e.Message);

                Header.Draw();
                Console.WriteLine("\tCONNECTION ERROR:", Color.HotPink);

                foreach (string line in errorLines)
                    Console.WriteLine($"\t{line}", Color.HotPink);

                Console.WriteLine("");
                Console.WriteLine("");

                Console.Write("\tPress ");
                Console.Write("[ENTER] ", Color.DarkOrange);
                Console.Write("to exit TCPKeyb ");

                Console.CursorVisible = false;

                Beep.Disconnected();

                Console.ReadLine();
                Menu.ExitApplication();
                
            }
        }


        /// <summary>
        /// Splits text longer than lineLength characters into multilines
        /// </summary>
        /// <param name="text"></param>
        /// <param name="lineLength"></param>
        /// <returns></returns>
        private static string[] SpliceText(string text, int lineLength=46)
        {
            return Regex.Matches(text, ".{1," + lineLength + "}").Cast<Match>().Select(m => m.Value).ToArray();
        }


        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }


        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);


        /// <summary>
        /// Called when a key is pressed
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            try
            {
                    if (stream.CanWrite)
                    {
                        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
                        {
                            int vkCode = Marshal.ReadInt32(lParam);
                            stream.WriteByte((byte)(Keys)vkCode);
                        }
                    }
                    else
                    {
                        stream.Close();
                        client.Close();
                }
            }
            catch(Exception e){
                stream.Close();
                client.Close();

                string[] errorLines = SpliceText(e.Message);

                Header.Draw();
                Console.WriteLine("\tERROR:", Color.HotPink);

                foreach (string line in errorLines)
                {
                    Console.WriteLine($"\t{line}", Color.HotPink);
                }

                Console.WriteLine("");
                Console.WriteLine("");

                Console.Write("\tPress ");
                Console.Write("[ENTER] ", Color.DarkOrange);
                Console.Write("to exit TCPKeyb ");

                Console.CursorVisible = false;

                Beep.Disconnected();

                Console.ReadLine();
                Menu.ExitApplication();
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }


        #region Imports

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion

    }
}