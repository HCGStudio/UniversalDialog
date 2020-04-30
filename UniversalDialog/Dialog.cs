using System;
using System.Runtime.InteropServices;

namespace HCGStudio.UniversalDialog
{
    /// <summary>
    ///     Represent user input of the dialog.
    /// </summary>
    public enum DialogResult
    {
        /// <summary>
        ///     Abort button clicked.
        /// </summary>
        Abort = 3,

        /// <summary>
        ///     Cancel button clicked.
        /// </summary>
        Cancel = 2,

        /// <summary>
        ///     Continue button clicked.
        /// </summary>
        Continue = 11,

        /// <summary>
        ///     Ignore button clicked.
        /// </summary>
        Ignore = 5,

        /// <summary>
        ///     No button clicked.
        /// </summary>
        No = 7,

        /// <summary>
        ///     Ok button clicked.
        /// </summary>
        Ok = 1,

        /// <summary>
        ///     Retry button clicked.
        /// </summary>
        Retry = 4,

        /// <summary>
        ///     Try Again button clicked.
        /// </summary>
        TryAgain = 10,

        /// <summary>
        ///     Yes button clicked.
        /// </summary>
        Yes = 6,

        /// <summary>
        ///     The dialog fails to display or user close the dialog (on qt based platform only).
        /// </summary>
        Failed = 0
    }

    /// <summary>
    ///     Represents button shown in the dialog.
    /// </summary>
    public enum DialogButton : ulong
    {
        /// <summary>
        ///     Show Abort, Retry and Ignore.
        /// </summary>
        AbortRetryIgnore = 0x00000002L,

        /// <summary>
        ///     Show Ok only.
        /// </summary>
        Ok = 0x00000000L,

        /// <summary>
        ///     Show Ok and Cancel.
        /// </summary>
        OkCancel = 0x00000001L,

        /// <summary>
        ///     Show Retry and Cancel.
        /// </summary>
        RetryCancel = 0x00000005L,

        /// <summary>
        ///     Show Yes and No.
        /// </summary>
        YesNo = 0x00000004L,

        /// <summary>
        ///     Show Yes, No and Cancel.
        /// </summary>
        YesNoCancel = 0x00000003L,

        /// <summary>
        ///     Show Cancel, Try and Continue.
        /// </summary>
        CancelTryContinue = 0x00000006L
    }

    /// <summary>
    ///     Represents icon shown in the dialog.
    /// </summary>
    public enum DialogIcon : ulong
    {
        /// <summary>
        ///     Represents warning.
        /// </summary>
        Exclamation = 0x00000030L,

        /// <summary>
        ///     Represent information.
        /// </summary>
        Information = 0x00000040L,

        /// <summary>
        ///     Represents error.
        /// </summary>
        Error = 0x00000010L,

        /// <summary>
        ///     No icon.
        /// </summary>
        None = 0
    }

    public class Dialog
    {
        /// <summary>
        ///     Text shown inside the dialog.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Windows title or caption of the dialog.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        ///     Button of the dialog.
        /// </summary>
        public DialogButton Button { get; set; }

        /// <summary>
        ///     Icon of the dialog.
        /// </summary>
        public DialogIcon Icon { get; set; }

        [DllImport("user32.dll")]
        internal static extern DialogResult MessageBox(IntPtr hWnd, string text, string caption, ulong type);

        [DllImport("libUniversalDialogQtBinding.so")]
        internal static extern DialogResult ShowDialog(string caption, string text, DialogButton button,
            DialogIcon icon);

        /// <summary>
        ///     Show the dialog.
        /// </summary>
        /// <returns>User input of the dialog.</returns>
        public DialogResult Show()
        {
            //Direct call Windows API in Windows
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return MessageBox(IntPtr.Zero, Text, Caption, (ulong) Button | (ulong) Icon);
            //
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ShowDialog(Caption, Text, Button, Icon);
            throw new PlatformNotSupportedException();
        }
    }
}