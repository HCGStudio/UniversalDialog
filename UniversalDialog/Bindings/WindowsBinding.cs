using System;
using System.Runtime.InteropServices;

namespace HCGStudio.UniversalDialog.Bindings
{
    internal static class WindowsBinding
    {
        [DllImport("user32.dll")]
        internal static extern DialogResult MessageBox(IntPtr hWnd, string text, string caption, ulong type);
    }
}