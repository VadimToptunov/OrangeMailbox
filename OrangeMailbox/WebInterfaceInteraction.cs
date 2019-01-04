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
        IWebDriver browser;
        const string YANDEX = "https:///passport.yandex.ru//registration//mail?from=mail&origin=home_v14_ru&retpath=https%3A%2F%2Fmail.yandex.ru%2F";
         
        const string NAMEID = "firstname";
        const string LASTNAMEID = "lastname";
        const string LOGINID = "login";
        const string PASSWID = "password";
        const string PASSWIDCONFIRM = "password_confirm";
        const string NOPHONELINKTEXT = "У меня нет телефона";
        const string CAPTCHA = "captcha";
        const string SUBMITBUTTONTYPE = "submit";
        //const string HINTqUESTION = "";
        const string HINTANSWERTEXT = "Ответ на контрольный вопрос";

        public void OpenOrangeMailboxPage()
        {
            browser = new ChromeDriver();
            browser.Navigate().GoToUrl(YANDEX);
        }

        public void FindSecretQuestionAndChoose()
        {
            //FindSecretQuestionAndChoose()
        }

        public void FillFormsOnOrangeMailboxPage(string name, string lastName, string login, string password, string secretAnswer, string capcha)
        {
            IWebElement UserName = browser.FindElement(By.Id(NAMEID));
            UserName.SendKeys(name);

            IWebElement LastName = browser.FindElement(By.Id(LASTNAMEID));
            LastName.SendKeys(lastName);

            IWebElement Login = browser.FindElement(By.Id(LOGINID));
            Login.SendKeys(login);

            IWebElement Password = browser.FindElement(By.Id(PASSWID));
            Password.SendKeys(password);

            IWebElement RepeatPassword = browser.FindElement(By.Id(PASSWIDCONFIRM));
            RepeatPassword.SendKeys(password);
            browser.FindElement(By.LinkText(NOPHONELINKTEXT)).Click();

            IWebElement SecretAnswer = browser.FindElement(By.LinkText(HINTANSWERTEXT));
            SecretAnswer.SendKeys(DataGenerator.CreateRandomString());

            IWebElement FillCaptcha = browser.FindElement(By.Id(CAPTCHA));
            FillCaptcha.SendKeys(capcha);
        }

        public void CloseOrangeMailboxPage()
        {
            Console.ReadLine();
            browser.Close();
        }
    }
}
