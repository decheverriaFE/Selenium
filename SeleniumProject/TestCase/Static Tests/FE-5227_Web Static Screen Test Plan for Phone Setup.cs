﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.handler;
using SeleniumProject.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;
using NUnit.Framework;

namespace SeleniumProject.TestCase.Static_Tests
{
    class FE_5227_Web_Static_Screen_Test_Plan_for_Phone_Setup
    {
        IWebDriver Driver = new ChromeDriver();

        [SetUp]
        public async Task InitializeASync() // Go to Home page 
        {
            HomePage home = new HomePage(Driver);
            home.gotoPage();
            await Task.Delay(8000);
        }

        [Test, Order(1)]
        public async Task PhoneSetupTest() // FE-5227, test phone setup
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

            //Go to Phone setup
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(5) > a > text")));
            Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(5) > a > text")).Click();

            //verify all elements are visible
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(3) > div:nth-child(1) > div:nth-child(1) > label:nth-child(3)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(4) > div:nth-child(1) > label:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(4) > div:nth-child(2) > label:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(5) > div:nth-child(1) > label:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(6) > div:nth-child(1) > label:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.header:nth-child(7) > span:nth-child(1)")));            
            await Task.Delay(5000);


            //Phone Setup changes
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(3) > div:nth-child(1) > div:nth-child(1) > label:nth-child(3)")));
            Driver.FindElement(By.CssSelector("#UseLegacy")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(4) > div:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#TwilioForwardingPhone")));
            Driver.FindElement(By.CssSelector("#TwilioForwardingPhone")).Click();
            Driver.FindElement(By.CssSelector("#TwilioForwardingPhone")).SendKeys("1234567890");
            await Task.Delay(5000);

            Driver.FindElement(By.CssSelector("button.small:nth-child(1)")).Click();
            await Task.Delay(5000);

           
            //Validation
            //Go to Phone setup
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(5) > a > text")));
            Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(5) > a > text")).Click();

            //verify Forwarding Phone number has '1234567890' then revert back to empty
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(4) > div:nth-child(1)")));
            var phone = Driver.FindElement(By.CssSelector("#TwilioForwardingPhone")).GetAttribute("value");
           

            if (phone == ("1234567890")) // Determines whether update to phone setup are found. Reverts in either case.
            {

                Driver.FindElement(By.CssSelector("#UseLegacy")).Click();
                Driver.FindElement(By.CssSelector("button.small:nth-child(1)")).Click();
                

            }
            else
            {
                Driver.FindElement(By.CssSelector("#UseLegacy")).Click();
                Driver.FindElement(By.CssSelector("button.small:nth-child(1)")).Click();
                Assert.Fail("FE-5227, Changes were not present. FAIL");
                await Task.Delay(5000);
                Driver.FindElement(By.CssSelector("")).Click(); //If this comes here, the test did not find saved changes '1234567890'.
                
            }


            await Task.Delay(5000);
        }

        [TearDown]
        public void Closer()
        {
            Driver.Close();
        }
    }

}
