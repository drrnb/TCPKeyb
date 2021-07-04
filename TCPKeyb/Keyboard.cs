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
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TCPKeyb
{
    public class Keyboard
    {
        /// <summary>
        /// Presses then releases a keyboard key
        /// </summary>
        /// <param name="key">The key to press</param>
        public static void PressKey(Keys key)
        {
            SetForegroundWindow(GetForegroundWindow());
            SetActiveWindow(GetForegroundWindow());
            SetFocus(GetForegroundWindow());
            ushort scanCodeForKey = (ushort)MapVirtualKey((uint)key, 0);
            ClickKey(scanCodeForKey);
        }

        #region Input Structs

        // Keyboard
        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardInput
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        
        // Mouse
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        // Other Hardware
        [StructLayout(LayoutKind.Sequential)]
        public struct HardwareInput
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }
        
        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)] public MouseInput mi;
            [FieldOffset(0)] public KeyboardInput ki;
            [FieldOffset(0)] public HardwareInput hi;
        }

        // Input
        public struct Input
        {
            public int type;
            public InputUnion u;
        }

        #endregion

        #region Input Enums

        [Flags]
        public enum InputType
        {
            Mouse = 0,
            Keyboard = 1,
            Hardware = 2
        }

        [Flags]
        public enum KeyEventF
        {
            KeyDown = 0x0000,
            ExtendedKey = 0x0001,
            KeyUp = 0x0002,
            Unicode = 0x0004,
            Scancode = 0x0008
        }

        #endregion

        #region Keyboard Input Methods

        /// <summary>
        /// Creates the keyboard input to send
        /// </summary>
        /// <param name="kbInputs"></param>
        public static void SendKeyboardInput(KeyboardInput[] kbInputs)
        {
            Input[] inputs = new Input[kbInputs.Length];

            for (int i = 0; i < kbInputs.Length; i++)
            {
                inputs[i] = new Input {
                    type = (int)InputType.Keyboard,
                    u = new InputUnion {
                        ki = kbInputs[i]
                    }
                };
            }

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
        }


        /// <summary>
        /// "Presses" then releases a key on the keyboard
        /// </summary>
        /// <param name="scanCode"></param>
        public static void ClickKey(ushort scanCode)
        {
            var inputs = new KeyboardInput[]
            {
                new KeyboardInput
                {
                    wScan = scanCode,
                    dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                    dwExtraInfo = GetMessageExtraInfo()
                },
                new KeyboardInput
                {
                    wScan = scanCode,
                    dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                    dwExtraInfo = GetMessageExtraInfo()
                }
            };

            SendKeyboardInput(inputs);
        }

        #endregion

        #region Keyboard Imports

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll",
        CallingConvention = CallingConvention.StdCall,
        CharSet = CharSet.Unicode,
        EntryPoint = "MapVirtualKey",
        SetLastError = true,
        ThrowOnUnmappableChar = false)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        #endregion

        #region Window Imports

        // Active window
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool SetFocus(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool SetActiveWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetForegroundWindow();

        #endregion
    }
}