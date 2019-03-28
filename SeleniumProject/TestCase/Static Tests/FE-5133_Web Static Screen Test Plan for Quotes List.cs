using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;

namespace SeleniumProject.TestCase.Static_Tests
{
    class FE_5133_Web_Static_Screen_Test_Plan_for_Quotes_List
    {
        //Selenium Driver
        protected IWebDriver Driver;


        public object SeleniumExtras { get; private set; }

        [SetUp]  //Nunit - Anotation to execute a method before every test.
        //Start Chrome
        public void BeforeTest()
        {
            Driver = new ChromeDriver();


        }

        [Test]//Nunit - Anotation to mark a method as a Automated TestCase 
        public async Task QuoteList()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(3000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

            
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(9) > a > span:nth-child(2)")));
            Driver.FindElement(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(9) > a > span:nth-child(2)")).Click();

            await Task.Delay(3000);
            //Verify columns
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#search")));
            Driver.FindElement(By.CssSelector("#search")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(1) > span:nth-child(1)")));

            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(1) > span:nth-child(1)"), "Customer"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(2) > span:nth-child(1)"), "Address"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(3) > span:nth-child(1)"), "Quote #"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(4) > span:nth-child(1)"), "Date"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(5) > span:nth-child(1)"), "Status"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(6) > span:nth-child(1)"), "Expiration Date"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(7) > span:nth-child(1)"), "Amount"));
            //Assert.Pass("Columns validated");
            await Task.Delay(2000);

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#main-page-container > div.top-header-container > div > div > div.button-container > button > span:nth-child(2)")));
            Driver.FindElement(By.CssSelector("#main-page-container > div.top-header-container > div > div > div.button-container > button > span:nth-child(2)")).Click();
            await Task.Delay(2000);
            //Search
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#search")));
            Driver.FindElement(By.CssSelector("#search")).Click();
            Driver.FindElement(By.CssSelector("#search")).SendKeys("3531 SE 22nd Place - Cape Coral FL 33904" + Keys.Enter);
            Driver.FindElement(By.CssSelector("#search")).Clear();
            await Task.Delay(2000);
            Driver.FindElement(By.CssSelector("#search")).SendKeys("Aberdeen" + Keys.Enter);
           
            await Task.Delay(2000);

            


            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(1)")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(1)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(2)")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(2)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(3)")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(3)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(4)")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(4)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(5)")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(5)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(6)")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(6)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(7)")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(7)")).Click();



            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(3)")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(3)")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#search")));
            Driver.FindElement(By.CssSelector("#search")).Click();
            Driver.FindElement(By.CssSelector("#search")).SendKeys("3531 SE 22nd Place - Cape Coral FL 33904" + Keys.Enter);
            Driver.FindElement(By.CssSelector("#search")).Clear();
            await Task.Delay(2000);
            Driver.FindElement(By.CssSelector("#search")).SendKeys("Aberdeen" + Keys.Enter);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr > td:nth-child(1) > div")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr > td:nth-child(1) > div")).Click();

        }

        public void Closer()
        {
            Driver.Quit();
        }
    }
}

