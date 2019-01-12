using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;

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
        const string HINTQUESTIONXPATH = "//*[@class='button2 button2_size_m button2_theme_normal control-questions button2_width_max select2__button select2__button']";
        const string SUBMITBUTTONTYPE = "submit";
        const string HINTQUESTION = "Фамилия вашего любимого учителя";
        const string HINTANSWERID = "hint_answer";
        const string ERRORXPATH = "//*[@class='suggest__status-text error-message']"; 

        public static void OpenOrangeMailboxPage()
        {
            var options = new ChromeOptions();
            options.AddArgument("incognito");
            options.ToCapabilities();

            browser = new ChromeDriver();
            browser.Navigate().GoToUrl(YANDEX);
            browser.Navigate().Refresh();
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

        public static void ChooseSecretQuestion()
        {
            try
            {
                browser.FindElement(By.XPath(HINTQUESTIONXPATH)).Click();
                //browser.FindElement(By.XPath("//*[@class='menu__text']")).Click();

            }
            catch (NoSuchElementException exception)
            {
                Console.WriteLine(String.Format("Cannot find the element^ {0}", exception));
            }
            //GetSecretQuestion();
            // here should be used a secret question
            //browser.FindElement(By.LinkText(HINTQUESTION)).Click();
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


        public static void FillFormsOnOrangeMailboxPage(List<string> bogusData)
        {
            browser.FindElement(By.LinkText("Завести почту")).Click();

            List<string> generatedData = bogusData;
            string name = generatedData[0];
            string lastName = generatedData[1];
            string login = generatedData[2];
            string password = generatedData[3];
            string secretQuestion = generatedData[4];
            string secretAnswer = generatedData[5];
            SetElementData(NAMEID, name);
            SetElementData(LASTNAMEID, lastName);
            SetElementData(LOGINID, login);
            //Check no errors appear
            SetElementData(PASSWID, password);
            SetElementData(PASSWIDCONFIRM, password);
            CheckNoErrorsAppear();
            FindNoPhone();

            ChooseSecretQuestion();

            IWebElement hintAnswer = browser.FindElement(By.Id(HINTANSWERID));
            ScrollDownToElement(hintAnswer);
            hintAnswer.SendKeys(secretAnswer);
            Thread.Sleep(20000); 
            // Sleep to fill Capcha
            CreateXlsDocument.CreateAndFillFile(bogusData);
            //Click "Submit"
            //Check the mailbox is successfully created

            //SetElementData(PASSWID, "lFdHppiuhg8734");
        }

        public static void CheckNoErrorsAppear()
        {
            try
            {
                IWebElement error = browser.FindElement(By.XPath(ERRORXPATH));
                while (error.Displayed)
                {
                    browser.FindElement(By.Id(LOGINID)).Clear();
                    SetElementData(LOGINID, DataGenerator.BogusUsername());
                    Thread.Sleep(3000);
                }
            }
            catch (NoSuchElementException exception){}
        } 

        public static bool CheckMailBoxCreated()
        {
            //Check the mailbox is successfully created
            // Use ternary operator  
            return true;
        }

        public static void CloseOrangeMailboxPage()
        {
            browser.Close();
            browser.Quit();
        }

        public static void WebActions()
        {
            OpenOrangeMailboxPage();
            FillFormsOnOrangeMailboxPage(DataGenerator.CreateBogusData());
            CloseOrangeMailboxPage();
        }
    }
}
