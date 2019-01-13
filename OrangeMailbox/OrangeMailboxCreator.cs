using System;
using System.Collections.Generic;
using System.Threading;

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
            int answer = int.Parse(Console.ReadLine()); ;
            return answer;
        }

        static void PerformActions()
        {
            Disclaimer();
            int amount = EmailsAmount();
            Thread.Sleep(10000);
            for (int i = 1; i <= amount; i++)
            {
                WebInterfaceInteraction.WebActions();
            }
        }

        static void Main(string[] args)
        {
            PerformActions();

            //Console.ReadLine();
        }
    }
}
