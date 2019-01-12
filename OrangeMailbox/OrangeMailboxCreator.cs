using System;
using System.Collections.Generic;

namespace OrangeMailbox
{
    class OrangeMailboxCreator
    {
        static void Disclaimer()
        {
            string disclaimer = "\t\t\t\tDear user! \n" +
                "\t\tYou\'re using a program for mass-creation of mailboxes for one Yellow//Orange Search Engine. \n" +
                "\t\tPlease, follow the instructions below.\n\n";
            Console.WriteLine(disclaimer);
        }
        public static int EmailsAmount()
        {
            Console.WriteLine("How many e-mails do you need? \n");
            return int.Parse(Console.ReadLine());
        }

        static string FillCapcha()
        {
            Console.WriteLine("Please, write down the CAPTCHA value Here: \n");
            string capchaValue = Console.ReadLine();
            return capchaValue;
        }

        static void PerformActions()
        {
            //Method for all Actions, instead of Main
            //Disclaimer();
            //FillDataInDocument();
            WebInterfaceInteraction.WebActions();
            //string capcha = FillCapcha();
            //Console.WriteLine(capcha);
        }

        static void Main(string[] args)
        {
            PerformActions();

            Console.ReadLine();
        }
    }
}
