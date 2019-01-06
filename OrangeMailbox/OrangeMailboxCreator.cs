using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeMailbox
{
    class OrangeMailboxCreator
    {
        static int EmailsAmount()
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

        static void FillData()
        {
            // Take a list of Bogus Data and disassemble it into Name, Last name. etc. for filling out the forms
            DataGenerator.CreateBogusData();
            CreateXlsDocument.CreateAndFillFile();
        }

        static void Main(string[] args)
        {

            //Console.OutputEncoding = Encoding.GetEncoding(1251);
            //Console.WriteLine("Hello, now you gonna create some e-mails in Yandex!\n");
            //int emails = EmailsAmount();
            //Console.WriteLine(emails);
            //string fileName = FileNameToSaveTheData();
            //Console.WriteLine(fileName);

            //Console.WriteLine(CreatePassword());
            //RunBrowser();
            //WriteToFile(FillCapcha());
            Console.ReadLine();
        }
    }
}
