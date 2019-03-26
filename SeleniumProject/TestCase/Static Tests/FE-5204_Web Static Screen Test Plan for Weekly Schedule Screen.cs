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
    class FE_5204_Web_Static_Screen_Test_Plan_for_Weekly_Schedule_Screen
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
        public async Task WeeklySchedule()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(3000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#application-menu > div:nth-child(3) > ul:nth-child(2) > li:nth-child(3) > a > text")));
            Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(3) > ul:nth-child(2) > li:nth-child(3) > a > text")).Click();
            //Update Techs

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#table-btn-container > table > tbody > tr:nth-child(2) > td:nth-child(5) > div.col-lg-9.col-md-8.col-sm-6.col-xs-6 > text")));
            Driver.FindElement(By.CssSelector("#table-btn-container > table > tbody > tr:nth-child(2) > td:nth-child(5) > div.col-lg-9.col-md-8.col-sm-6.col-xs-6 > text")).Click();


            //Set Time

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#startTime > input")));
            Driver.FindElement(By.CssSelector("#startTime > input")).Click();
            Driver.FindElement(By.CssSelector("#startTime > input")).Clear();
            Driver.FindElement(By.CssSelector("#startTime > input")).SendKeys("9 AM");
            //Set a tech "On Call"
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#on-call-container > div")));
            Driver.FindElement(By.CssSelector("#on-call-container > div")).Click();

           
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#weeklySchedulForm > div:nth-child(2) > button.custom-btn.success-btn.small")));
            Driver.FindElement(By.CssSelector("#weeklySchedulForm > div:nth-child(2) > button.custom-btn.success-btn.small")).Click();

            await Task.Delay(3000);

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#table-btn-container > table > tbody > tr:nth-child(2) > td:nth-child(5) > div.col-lg-9.col-md-8.col-sm-6.col-xs-6 > text")));
            Driver.FindElement(By.CssSelector("#table-btn-container > table > tbody > tr:nth-child(2) > td:nth-child(5) > div.col-lg-9.col-md-8.col-sm-6.col-xs-6 > text")).Click();


            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#on-call-container > div")));
            Driver.FindElement(By.CssSelector("#on-call-container > div")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#weeklySchedulForm > div:nth-child(2) > button.custom-btn.success-btn.small")));
            Driver.FindElement(By.CssSelector("#weeklySchedulForm > div:nth-child(2) > button.custom-btn.success-btn.small")).Click();

         
        }
        [TearDown]
        public void closeDown()
        {
            Driver.Quit();
        }
    }
}
