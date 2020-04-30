using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;

namespace HCGStudio.UniversalDialog
{
    public enum DialogResult
    {
        Abort = 3,
        Cancel = 2,
        Continue = 11,
        Ignore = 5,
        No = 7,
        Ok = 1,
        Retry = 4,
        TryAgain = 10,
        Yes = 6,
        Failed = 0
    }

    public enum DialogButton : ulong
    {
        AbortRetryIgnore = 0x00000002L,
        Ok = 0x00000000L,
        OkCancel = 0x00000001L,
        RetryCancel = 0x00000005L,
        YesNo = 0x00000004L,
        YesNoCancel = 0x00000003L,
        CancelTryContinue = 0x00000006L
    }

    public enum DialogIcon : ulong
    {
        Exclamation = 0x00000030L,
        Information = 0x00000040L,
        Error = 0x00000010L,
        None = 0
    }
    public class Dialog
    {
        [DllImport("user32.dll")]
        internal static extern DialogResult MessageBox(IntPtr hWnd,string text,string caption,ulong type);
        [DllImport("libUniversalDialogQtBinding.so")]
        internal static extern DialogResult ShowDialog(string caption, string text, DialogButton button, DialogIcon icon);
        public string Text { get; set; }
        public string Caption { get; set; }
        public DialogButton Button { get; set; }
        public DialogIcon Icon { get; set; }
        
        public DialogResult Show()
        {
            //Direct call Windows API in Windows
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return MessageBox(IntPtr.Zero, Text, Caption, (ulong)Button | (ulong)Icon);
            //
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ShowDialog(Caption,Text,Button,Icon);
            throw new PlatformNotSupportedException();
        }
    }
}
