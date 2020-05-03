using System;
using System.Globalization;
using HCGStudio.UniversalDialog;

namespace UniversalDialog.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new MessageDialog
            {
                Button = DialogButton.Ok,
                Caption = "Sample dialog",
                Text = "This is a dialog with OK button only."
            }.Show();
            Console.WriteLine($"You chose {result}.");
            result = new MessageDialog
            {
                Button = DialogButton.YesNoCancel,
                Caption = "Sample dialog",
                Icon = DialogIcon.Error,
                Text = "This is a dialog with three buttons and an error icon."
            }.Show();
            Console.WriteLine($"You chose {result}.");
            result = new MessageDialog
            {
                Button = DialogButton.CancelTryContinue,
                Caption = "Sample dialog",
                Icon = DialogIcon.Information,
                Text = "This is a dialog with three buttons and an information icon."
            }.Show();
            Console.WriteLine($"You chose {result}.");

        }
    }
}
