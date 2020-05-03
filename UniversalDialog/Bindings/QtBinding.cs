using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace HCGStudio.UniversalDialog.Bindings
{
    class QtBinding
    {
        [DllImport("libUniversalDialogQtBinding")]
        internal static extern DialogResult ShowMessageDialog(string caption, string text, DialogButton button,
            DialogIcon icon);
    }
}
