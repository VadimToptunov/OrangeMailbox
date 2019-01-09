using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        static void FillDataInDocument()
        {
            CreateXlsDocument.CreateAndFillFile();
        }

        static void PerformActions()
        {
            //Method for all Actions, instead of Main
            Disclaimer();
            FillDataInDocument();
            string capcha = FillCapcha();
            //Console.WriteLine(capcha);
        }

        static void Main(string[] args)
        {
            PerformActions();

            Console.ReadLine();
        }
    }
}
