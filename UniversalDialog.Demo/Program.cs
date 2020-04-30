using System;
using HCGStudio.UniversalDialog;

namespace UniversalDialog.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(new Dialog
                    {
                        Button = DialogButton.YesNo, 
                        Caption = "杀🐎提示",
                        Icon = DialogIcon.Exclamation,
                        Text = "是否杀了ywz的🐎"

                    }
                .Show());
            Console.ReadLine();
        }
    }
}
