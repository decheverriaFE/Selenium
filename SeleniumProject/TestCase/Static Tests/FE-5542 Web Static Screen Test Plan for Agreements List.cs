using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    class Agreement
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
        public async Task AgreementLIst()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(5000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme1 = Driver.FindElement(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button"));
            CloseWalkme1.Click();
            await Task.Delay(5000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-146340 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme2 = Driver.FindElement(By.CssSelector("#wm-shoutout-146340 > div.wm-close-button.walkme-x-button"));
            CloseWalkme2.Click();
            await Task.Delay(5000);
            //Select Agreement
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("li.side-bar-icon:nth-child(7) > a:nth-child(1) > span:nth-child(2)")));
            Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(7) > a:nth-child(1) > span:nth-child(2)")).Click();

        }
    }
}
