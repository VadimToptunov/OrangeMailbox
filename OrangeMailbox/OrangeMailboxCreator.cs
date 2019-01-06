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

        static string FileNameToSaveTheData()
        {
            Console.WriteLine("Now specify a folder or a file to save the information: \n");
            return Console.ReadLine();
        }

        static string FillCapcha()
        {
            Console.WriteLine("Please, write down the CAPTCHA value Here: \n");
            string capchaValue = Console.ReadLine();

            return capchaValue;
        }

        static void Main(string[] args)
        {
            DataGenerator.CreateBogusData();
            CreateXlsDocument.CreateAndFillFile();

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
