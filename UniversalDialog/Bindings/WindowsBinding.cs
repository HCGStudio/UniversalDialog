using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace HCGStudio.UniversalDialog.Bindings
{
    internal static class WindowsBinding
    {
        [DllImport("user32.dll")]
        internal static extern DialogResult MessageBox(IntPtr hWnd, string text, string caption, ulong type);
    }
}
