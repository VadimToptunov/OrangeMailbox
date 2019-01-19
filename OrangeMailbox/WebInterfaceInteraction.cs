using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
        const string SUBMITBUTTONXPATH = "//*[@class='button2 button2_size_l button2_theme_action button2_width_max button2_type_submit js-submit']";
        const string HINTQUESTION = "Фамилия вашего любимого учителя";
        const string HINTANSWERID = "hint_answer";
        const string ERRORXPATH = "//*[@class='suggest__status-text error-message']";
        const string HINTMENU = "//*[@class='menu menu_size_m menu_width_max menu_theme_normal control-questions menu_type_radio select2__menu select2__menu']";
        const string CAPCHALINE = "//*[@class='registration__label']";
        public static string UserNameClass = "//*[@class='mail-User-Name']";


        public static void OpenOrangeMailboxPage()
        {
            var options = new ChromeOptions();
            options.AddArgument("incognito");
            options.ToCapabilities();

            browser = new ChromeDriver();
            browser.Navigate().GoToUrl(YANDEX);
            browser.Navigate().Refresh();
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
                FindByXPathAndClick(HINTQUESTIONXPATH);
                IWebElement menu = browser.FindElement(By.XPath(HINTMENU));
                if (menu.Displayed)
                {
                    IReadOnlyCollection<IWebElement> menuItems = menu.FindElements(By.TagName("span"));
                    foreach (IWebElement menuItem in menuItems)
                    {
                        if (menuItem.Text.Equals(HINTQUESTION))
                        {
                            menuItem.Click();
                            break;
                        }
                    }
                }
            }
            catch (NoSuchElementException exception)
            {
                Console.WriteLine(String.Format("Cannot find the element^ {0}", exception));
            }
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

        static void FindByXPathAndClick(string xpath)
        {
            try
            {
                browser.FindElement(By.XPath(xpath)).Click();
            }
            catch (NoSuchElementException exception)
            {
                Console.WriteLine(String.Format("Failed to find the element: {0} \n\n", exception ));
            }
            
        }


        public static void FillFormsOnOrangeMailboxPage(List<string> bogusData, int amount)
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
            FindByXPathAndClick(NOPHONELINKXPATH);

            ChooseSecretQuestion();
            Thread.Sleep(1000);
            IWebElement hintAnswer = browser.FindElement(By.Id(HINTANSWERID));
            ScrollDownToElement(hintAnswer);
            hintAnswer.SendKeys(secretAnswer);
            IWebElement submitButton = browser.FindElement(By.XPath(SUBMITBUTTONXPATH));
            ScrollDownToElement(submitButton);
            
            CreateXlsDocument.CreateAndFillFile(bogusData, amount);
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

        public static bool CheckMailBoxCreated(string login)
        {
            //Unable to locate element
            //Make it wait!
            if (!browser.FindElement(By.XPath(UserNameClass)).Displayed && !browser.FindElement(By.XPath(UserNameClass)).Text.Equals(login))
            {
                return false;
            }
            else{
                Console.WriteLine(String.Format("The e-mail for the user {0} is successfully created!", login));
                Thread.Sleep(3000);
                CloseOrangeMailboxPage();
                return true;
            }
        }

        public static void CheckMailboxState(string login)
        {
            while (!CheckMailBoxCreated(login).Equals(true))
            {
                Thread.Sleep(1000);
            }
        }

        public static void CloseOrangeMailboxPage()
        {
            browser.Close();
            browser.Quit();
        }

        public static void WebActions(int amount)
        {
            OpenOrangeMailboxPage();
            List<string> bogusData = DataGenerator.CreateBogusData();
            FillFormsOnOrangeMailboxPage(bogusData, amount);
            CheckMailboxState(bogusData[2]);
        }
    }
}
