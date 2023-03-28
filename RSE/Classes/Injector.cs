using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace RSE
{
    class Injector
    {
        public enum InjectionResult
        {
            DllNotFound,
            GameProcessNotFound,
            InjectionFailed,
            Success
        }

        public sealed class DllInjector
        {
            private static readonly IntPtr INTPTR_ZERO = IntPtr.Zero;
            private const uint PROCESS_ALL_ACCESS = 0x1F0FFF;

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern int CloseHandle(IntPtr hObject);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress,
                IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

            private static DllInjector _instance;

            public static DllInjector Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new DllInjector();
                    }
                    return _instance;
                }
            }

            private DllInjector() { }

            public InjectionResult Inject(string processName, string dllPath)
            {
                try
                {
                    if (!File.Exists(dllPath))
                    {
                        return InjectionResult.DllNotFound;
                    }

                    uint processId = 0;

                    foreach (Process process in Process.GetProcessesByName(processName))
                    {
                        processId = (uint)process.Id;
                        break;
                    }

                    if (processId == 0)
                    {
                        return InjectionResult.GameProcessNotFound;
                    }

                    if (!InjectDll(processId, dllPath))
                    {
                        return InjectionResult.InjectionFailed;
                    }

                    return InjectionResult.Success;
                }
                catch (Exception ex)
                {
                    // Log the error here
                    return InjectionResult.InjectionFailed;
                }
            }

            private bool InjectDll(uint processId, string dllPath)
            {
                IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, 1, processId);

                if (processHandle == INTPTR_ZERO)
                {
                    return false;
                }

                IntPtr loadLibraryAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

                if (loadLibraryAddress == INTPTR_ZERO)
                {
                    return false;
                }

                IntPtr remoteMemory = VirtualAllocEx(processHandle, INTPTR_ZERO, (IntPtr)dllPath.Length, 0x1000 | 0x2000, 0X40);

                if (remoteMemory == INTPTR_ZERO)
                {
                    return false;
                }

                byte[] bytes = Encoding.ASCII.GetBytes(dllPath);

                if (WriteProcessMemory(processHandle, remoteMemory, bytes, (uint)bytes.Length, 0) == 0)
                {
                    return false;
                }
                if (CreateRemoteThread(processHandle, INTPTR_ZERO, INTPTR_ZERO, loadLibraryAddress, remoteMemory, 0, INTPTR_ZERO) == INTPTR_ZERO)
                {
                    return false;
                }

                CloseHandle(processHandle);

                return true;
            }
        }
    }
}
