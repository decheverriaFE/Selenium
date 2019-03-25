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
    class FE_5219_Web_Static_Screen_Test_Plan_for_Time_Entries
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
        public async Task TimeEntry()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(3000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#application-menu > div:nth-child(3) > ul:nth-child(2) > li:nth-child(5) > a > text")));
            Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(3) > ul:nth-child(2) > li:nth-child(5) > a > text")).Click();
            //Select TimeEntries.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr > td:nth-child(1) > div")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr > td:nth-child(1) > div")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(1) > div.clearfix.main-content > table > tbody > tr:nth-child(2) > td:nth-child(3) > div")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(1) > div.clearfix.main-content > table > tbody > tr:nth-child(2) > td:nth-child(3) > div")).Click();
            //Edit time
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#TimeEntryStartTimePicker")));
            
            IWebElement setStartHHMMTimeentry = Driver.FindElement(By.CssSelector("#TimeEntryStartTimePicker"));
            setStartHHMMTimeentry.SendKeys(DateTime.Now.ToString("hh:mm"));
            
            IWebElement setStartHHMMTimeentry1 = Driver.FindElement(By.CssSelector("#TimeEntryEndTimePicker"));
            //Driver.FindElement(By.CssSelector("#TimeEntryEndTimePicker")).Clear();
            setStartHHMMTimeentry1.Clear();
            setStartHHMMTimeentry1.SendKeys("11:24 AM");
            setStartHHMMTimeentry1.SendKeys(Keys.Tab + Keys.Enter);
            await Task.Delay(3000);
          
            //add time
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#main-page-container > div.settings-sub-menu.clearfix > div.left > button")));
            Driver.FindElement(By.CssSelector("#main-page-container > div.settings-sub-menu.clearfix > div.left > button")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#select2-TimeEntryActivityType-container")));

            Driver.FindElement(By.CssSelector("#select2-TimeEntryActivityType-container")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")));
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).Click();
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).SendKeys("idle" + Keys.Enter + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Enter);

            await Task.Delay(3000);
            //Filter
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(1) > div.clearfix.main-content > table > thead > tr > th:nth-child(2)")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(1) > div.clearfix.main-content > table > thead > tr > th:nth-child(2)")).Click();

           
        }
    }
}
