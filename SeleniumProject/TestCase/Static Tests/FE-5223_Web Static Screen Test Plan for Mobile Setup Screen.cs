using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Handler;
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
    class FE_5223_Web_Static_Screen_Test_Plan_for_Mobile_Setup_Screen
    {
        IWebDriver Driver = new ChromeDriver();

        [SetUp]
        public async Task Initialize()
        {
            HomePage home = new HomePage(Driver);
            home.gotoPage();
            await Task.Delay(5000);
        }

        [Test, Order(1)]
        public async Task MobileSetup() // JIRA FE-5223 - Test settings -> Mobile settings
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            //Settings --> Mobile setup
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));")));
            Driver.FindElement(By.CssSelector("WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.setting-container:nth-child(4) > ul:nth-child(2) > li:nth-child(3) > a:nth-child(1) > text:nth-child(1)")));
            Driver.FindElement(By.CssSelector("div.setting-container:nth-child(4) > ul:nth-child(2) > li:nth-child(3) > a:nth-child(1) > text:nth-child(1)")).Click();
            await Task.Delay(2000);

            //Make changes --> Save
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".dynamic-container")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#AuthorizationText")));
            Driver.FindElement(By.CssSelector("#AuthorizationText")).SendKeys(".");
            Driver.FindElement(By.CssSelector("#form > div:nth-child(5) > button:nth-child(1)")).Click();
            await Task.Delay(2000);

            //Go back into set up, and verify changes were made, if they were revert them and pass test. != change, fail test.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));")));
            Driver.FindElement(By.CssSelector("WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.setting-container:nth-child(4) > ul:nth-child(2) > li:nth-child(3) > a:nth-child(1) > text:nth-child(1)")));
            Driver.FindElement(By.CssSelector("div.setting-container:nth-child(4) > ul:nth-child(2) > li:nth-child(3) > a:nth-child(1) > text:nth-child(1)")).Click();
            await Task.Delay(2000);

            var authText = Driver.FindElement(By.CssSelector("#AuthorizationText")).Text;

            if (!authText.Contains("This is the Authorization.")) //Pass
            {
                Driver.FindElement(By.CssSelector("#AuthorizationText")).Click();
                Driver.FindElement(By.CssSelector("#AuthorizationText")).SendKeys(Keys.Backspace);
                Driver.FindElement(By.CssSelector("#form > div:nth-child(5) > button:nth-child(1)")).Click();

            }
            else //Fail
            {
                Assert.Fail("JIRA FE-5223 FAIL. Line 65");
                Driver.FindElement(By.CssSelector("")).Click();
            }

        }

        [TearDown]
        public void Closer()
        {
            Driver.Quit();
        }
    }
}
