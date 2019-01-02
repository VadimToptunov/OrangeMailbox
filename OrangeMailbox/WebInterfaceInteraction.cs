using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeMailbox
{
    class WebInterfaceInteraction
    {
        const string YANDEX = "http://yandex.ru";
        IWebDriver browser = new ChromeDriver();

        public void OpenOrangeMailboxPage()
        {
            browser.Navigate().GoToUrl(YANDEX);
            //Run browser,
            // Navigate to the Yandex page,
            //Find the "New Mailbox" link
            // Navigate to the page with the new forms
        }

        public void FindSecretQuestionAndChoose()
        {
            //FindSecretQuestionAndChoose()
        }

        public void FillFormsOnOrangeMailboxPage(string name, string lastName, string login, string password, string secretAnswer, string capcha)
        {
            // Fill the fields with bogus and generated data
        }

        public void CloseOrangeMailboxPage()
        {
            Console.ReadLine();
            browser.Close();
        }
    }
}
