using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrangeMailbox
{
    class WebInterfaceInteraction
    {
        public static IWebDriver browser;
        const string YANDEX = "https:\\yandex.ru/";
        const string REGISTERLINK = "https:\\passport.yandex.ru/registration/mail?from=mail&origin=home_v14_ru&retpath=https%3A%2F%2Fmail.yandex.ru%2F";
        const string NAMEID = "firstname";
        const string LASTNAMEID = "lastname";
        const string LOGINID = "login";
        const string PASSWID = "password";
        const string PASSWIDCONFIRM = "password_confirm";
        const string NOPHONELINKXPATH = "//*[@class='toggle-link link_has-no-phone']";
        
        const string CAPTCHA = "captcha";
        const string SUBMITBUTTONTYPE = "submit";
        const string HINTQUESTION = "Фамилия вашего любимого учителя";
        const string HINTANSWERID = "hint_answer";

        public static void OpenOrangeMailboxPage()
        {
            var options = new ChromeOptions();
            options.AddArgument("incognito");
            options.ToCapabilities();

            browser = new ChromeDriver();
            browser.Navigate().GoToUrl(YANDEX);
            browser.Navigate().Refresh();

            FindElementByLinkText("Завести почту");
            SetElementData(NAMEID, "Вася");
            SetElementData(LASTNAMEID, "Пупкин");
            SetElementData(LOGINID, "Pupkus87");
            SetElementData(PASSWID, "lFdHppiuhg8734");
            SetElementData(PASSWIDCONFIRM, "lFdHppiuhg8734");
            FindNoPhone();
            //Thread.Sleep(5000);

            IWebElement hintAnswer = browser.FindElement(By.Id(HINTANSWERID));
            ScrollDownToElement(hintAnswer);
            hintAnswer.SendKeys(DataGenerator.CreateRandomString());
            
            Console.ReadLine();
        }

        static void FindNoPhone()
        {
            try
            {
                IWebElement noPhone = browser.FindElement(By.XPath(NOPHONELINKXPATH));
                noPhone.Click();
            }
            catch (NoSuchElementException exception)
            {
                Console.WriteLine(String.Format("The element you search cannot be found: {0} \n\n", exception));
            }
        }

        static void ScrollDownToElement(IWebElement element)
        {
            Actions actions = new Actions(browser);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static string GetSecretQuestion()
        {
            //browser.FindElement(By.LinkText(NOPHONELINKTEXT)).Click();

            List<string> listOfSecretQuestions = new List<string>();
            // Find a question "Девичья фамилия матери"
            //string secretQuestion = listOfSecretQuestions[index];
            string secretQuestion = "Фамилия вашего любимого музыканта";
            return secretQuestion;
        }

        public static void ChooseSecretQuestion()
        {
            //GetSecretQuestion();
            // here should be used a secret question
            browser.FindElement(By.LinkText(HINTQUESTION)).Click();
        }
           

        static void SetElementData(string elementID, string elementData)
        {
            try
            {
                browser.FindElement(By.Id(elementID)).SendKeys(elementData);
            }
                catch (NoSuchElementException exception)
            {
                Console.WriteLine(String.Format("The element cannot be found by Id: \n\n {0}", exception));
            }
        }

        static void FindElementByLinkText(string linkText)
        {
            try
            {
                browser.FindElement(By.LinkText(linkText)).Click();
            }
            catch (NoSuchElementException exception)
            {
                Console.WriteLine(String.Format("The element cannot be found by link text: \n\n {0}", exception));
            }
        }


        public void FillFormsOnOrangeMailboxPage(string name, string lastName, string login, string password, string secretQuestion, string secretAnswer, string capcha)
        {
            browser.FindElement(By.LinkText("Завести почту")).Click();


            SetElementData(NAMEID, name);
            SetElementData(LASTNAMEID, lastName);
            SetElementData(LOGINID, login);
            SetElementData(PASSWID, password);
            SetElementData(PASSWIDCONFIRM, password);

            //ChooseSecretQuestion(secretQuestion);

            //browser.FindElement(By.LinkText(HINTANSWERTEXT)).SendKeys(DataGenerator.CreateRandomString());
        
            SetElementData(CAPTCHA, capcha);
        }

        public static void CloseOrangeMailboxPage()
        {
            browser.Close();
            browser.Quit();
        }

        public static void WebActions()
        {
            OpenOrangeMailboxPage();
            //SetElementData(NAMEID, "Вася");
            //SetElementData(LASTNAMEID, "Пупкин");
            //SetElementData(LOGINID, "Pupkus_87");
            //SetElementData(PASSWID, "lFdHppiuhg8734");
            //SetElementData(PASSWIDCONFIRM, "lFdHppiuhg8734");
            CloseOrangeMailboxPage();
        }
    }
}
