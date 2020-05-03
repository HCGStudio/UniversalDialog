using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace HCGStudio.UniversalDialog.Bindings
{
    class CocoaBinding
    {
        [DllImport("libUniversalDialogCocoaBinding.dylib",EntryPoint = "ShowMessageDialog")]
        internal static extern DialogResult ShowMessageDialog(string caption, string text, DialogButton button,
            DialogIcon icon);
    }
}
