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
    class FE_5212_Web_Static_Screen_Test_Plan_for_Task_Settings_Screen
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
        public async Task TaskScreen()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(3000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(6) > a > text")));
            Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(6) > a > text")).Click();
            //Add task
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#main-page-container > div.top-header-container > div > div > div.button-container > button")));
            Driver.FindElement(By.CssSelector("#main-page-container > div.top-header-container > div > div > div.button-container > button")).Click();
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#Name")));
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(1000000);
            Driver.FindElement(By.CssSelector("#Name")).SendKeys("Task" + randomInt);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#filter-date > div > div > div.button-container > button.custom-btn.success-btn.first")));
            Driver.FindElement(By.CssSelector("#filter-date > div > div > div.button-container > button.custom-btn.success-btn.first")).Click();
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#search")));
            Driver.FindElement(By.CssSelector("#search")).SendKeys("Task" + Keys.Enter);
            await Task.Delay(2000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr:nth-child(1) > td:nth-child(1) > div")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr:nth-child(1) > td:nth-child(1) > div")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div > div:nth-child(6) > div > div")));

            IWebElement active = Driver.FindElement(By.CssSelector("#form > div > div:nth-child(6) > div > div"));


            if (!active.Selected)
            {
                active.Click();
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#label > div > div.button-container > button.custom-btn.success-btn.first")));
                Driver.FindElement(By.CssSelector("#label > div > div.button-container > button.custom-btn.success-btn.first")).Click();
                await Task.Delay(2000);
            }
            else
            {
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#label > div > div.button-container > button.custom-btn.success-btn.first")));
                Driver.FindElement(By.CssSelector("#label > div > div.button-container > button.custom-btn.success-btn.first")).Click();
                await Task.Delay(2000);
            }


        }
    }
}
