using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.TestCase.Static_Tests
{
    class FE_5222__Web_Static_Screen_Test_Plan_for_Markup_Settings
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
        public async Task StaticMarkup_Setting()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(3000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));


            //Select Setting/Markup
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#application-menu > div:nth-child(4) > ul > li:nth-child(4) > a > text")));
            Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(4) > ul > li:nth-child(4) > a > text")).Click();

            //Add MarkUP
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#label > div > div.button-container > button")));
            Driver.FindElement(By.CssSelector("#label > div > div.button-container > button")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#Name")));
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(10000);
            Driver.FindElement(By.CssSelector("#Name")).SendKeys("Automation_MarkUp" + randomInt);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#create")));
            Driver.FindElement(By.CssSelector("#create")).Click();
            await Task.Delay(3000);

            //Edit
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.main-content.clearfix > table > tbody > tr:nth-child(1) > td:nth-child(1) > div")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.main-content.clearfix > table > tbody > tr:nth-child(1) > td:nth-child(1) > div")).Click();


            await Task.Delay(3000);

            //inactive
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div.pull-left > div:nth-child(1) > div > div")));
            Driver.FindElement(By.CssSelector("#form > div.pull-left > div:nth-child(1) > div > div")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#Name")));
            Driver.FindElement(By.CssSelector("#Name")).Clear();
            Driver.FindElement(By.CssSelector("#Name")).SendKeys("Automation_MarkUpEdit" + randomInt);
            await Task.Delay(3000);
            

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#create")));
            Driver.FindElement(By.CssSelector("#create")).Click();
            await Task.Delay(3000);


            //Edit
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.main-content.clearfix > table > tbody > tr:nth-child(1) > td:nth-child(1) > div")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.main-content.clearfix > table > tbody > tr:nth-child(1) > td:nth-child(1) > div")).Click();


            await Task.Delay(3000);

            //active
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div.pull-left > div:nth-child(1) > div > div")));
            Driver.FindElement(By.CssSelector("#form > div.pull-left > div:nth-child(1) > div > div")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#create")));
            Driver.FindElement(By.CssSelector("#create")).Click();


        }



    }
}
