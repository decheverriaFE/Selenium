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
    class FE_5221__Web_Static_Screen_Test_Plan_Payment_Processing
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
        public async Task Static_PaymentProcess()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(3000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#application-menu > div:nth-child(4) > ul > li:nth-child(10) > a > text")));
            Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(4) > ul > li:nth-child(10) > a > text")).Click();

             //Payment select        
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div.group-field-container.clearfix > div:nth-child(2) > div")));
            Driver.FindElement(By.CssSelector("#form > div.group-field-container.clearfix > div:nth-child(2) > div")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div.group-field-container.clearfix > div:nth-child(3) > div")));
            Driver.FindElement(By.CssSelector("#form > div.group-field-container.clearfix > div:nth-child(3) > div")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div.group-field-container.clearfix > div:nth-child(1) > div")));
            Driver.FindElement(By.CssSelector("#form > div.group-field-container.clearfix > div:nth-child(1) > div")).Click();
            //Save
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#filter-date > div > div > div.button-container > button.custom-btn.success-btn.small")));
            Driver.FindElement(By.CssSelector("#filter-date > div > div > div.button-container > button.custom-btn.success-btn.small")).Click();


        }

        [TearDown]
        public void closeDown()
        {
            Driver.Quit();
        }
    }


    
}
