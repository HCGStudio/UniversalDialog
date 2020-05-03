using System;
using System.Globalization;
using System.Resources;
using System.Runtime.InteropServices;

namespace HCGStudio.UniversalDialog.Bindings
{
    internal static class CocoaBinding
    {
        internal static DialogResult ShowMessageDialog(string caption, string text, DialogButton button,
            DialogIcon icon)
        {
            var res = new ResourceManager(typeof(Resources.MessageDialog));
            return button switch
            {
                DialogButton.AbortRetryIgnore => ShowMessageDialog(caption, text, icon,
                        res.GetString("Retry", CultureInfo.CurrentUICulture),
                        res.GetString("Abort", CultureInfo.CurrentUICulture),
                        res.GetString("Ignore", CultureInfo.CurrentUICulture)) switch
                    {
                        0 => DialogResult.Retry,
                        1 => DialogResult.Abort,
                        2 => DialogResult.Ignore,
                        _ => DialogResult.Failed
                    },
                DialogButton.Ok => ShowMessageDialog(caption, text, icon, null, null, null) switch
                {
                    0 => DialogResult.Ok,
                    _ => DialogResult.Failed
                },
                DialogButton.OkCancel => ShowMessageDialog(caption, text, icon, null,
                        res.GetString("Cancel", CultureInfo.CurrentUICulture), null) switch
                    {
                        0 => DialogResult.Ok,
                        1 => DialogResult.Cancel,
                        _ => DialogResult.Failed
                    },
                DialogButton.RetryCancel => ShowMessageDialog(caption, text, icon,
                        res.GetString("Retry", CultureInfo.CurrentUICulture),
                        res.GetString("Cancel", CultureInfo.CurrentUICulture), null) switch
                    {
                        0 => DialogResult.Retry,
                        1 => DialogResult.Cancel,
                        _ => DialogResult.Failed
                    },
                DialogButton.YesNo => ShowMessageDialog(caption, text, icon,
                        res.GetString("Yes", CultureInfo.CurrentUICulture),
                        res.GetString("No", CultureInfo.CurrentUICulture), null) switch
                    {
                        0 => DialogResult.Yes,
                        1 => DialogResult.No,
                        _ => DialogResult.Failed
                    },
                DialogButton.YesNoCancel => ShowMessageDialog(caption, text, icon,
                        res.GetString("Yes", CultureInfo.CurrentUICulture),
                        res.GetString("No", CultureInfo.CurrentUICulture),
                        res.GetString("Cancel", CultureInfo.CurrentUICulture)) switch
                    {
                        0 => DialogResult.Yes,
                        1 => DialogResult.No,
                        2 => DialogResult.Cancel,
                        _ => DialogResult.Failed
                    },
                DialogButton.CancelTryContinue => ShowMessageDialog(caption, text, icon,
                        res.GetString("Cancel", CultureInfo.CurrentUICulture),
                        res.GetString("Try", CultureInfo.CurrentUICulture),
                        res.GetString("Continue", CultureInfo.CurrentUICulture)) switch
                    {
                        0 => DialogResult.Cancel,
                        1 => DialogResult.TryAgain,
                        2 => DialogResult.Continue,
                        _ => DialogResult.Failed
                    },
                _ => throw new ArgumentOutOfRangeException(nameof(button), button, null)
            };
        }

        [DllImport("libUniversalDialogCocoaBinding", EntryPoint = "ShowMessageDialog")]
        internal static extern int ShowMessageDialog(string caption, string text, DialogIcon icon,
            string defaultButton, string alternateButton, string otherButton);
    }
}