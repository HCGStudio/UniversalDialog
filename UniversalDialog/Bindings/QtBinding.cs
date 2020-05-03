using System.Runtime.InteropServices;

namespace HCGStudio.UniversalDialog.Bindings
{
    internal static class QtBinding
    {
        [DllImport("libUniversalDialogQtBinding")]
        internal static extern DialogResult ShowMessageDialog(string caption,
            string text, DialogButton button, DialogIcon icon);
    }
}