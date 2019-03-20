using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;

namespace SeleniumProject.PageObject
{
    class FE_Login
    {
        protected IWebDriver Driver;

        public FE_Login(IWebDriver driver)
        {
            Driver = driver;
        }

        public object SeleniumExtras { get; private set; }


        public async void gotoPageAsync()
        {
            Driver = new ChromeDriver();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.Navigate().GoToUrl("https://fieldedgesiteea-staging.azurewebsites.net");
            Driver.Manage().Window.Maximize();
            
            //DotNetSeleniumExtras.WaitHelpers NuGet package needs to be added
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#login-form > div:nth-child(3)")));


            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#LoginEmail")));

            Driver.FindElement(By.CssSelector("#LoginEmail")).SendKeys("auto01@fieldedge.com");
            Driver.FindElement(By.CssSelector("#Password")).SendKeys("qa2019");

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#login-form > div:nth-child(8) > input")));
            Driver.FindElement(By.CssSelector("#login-form > div:nth-child(8) > input")).Click();

            await Task.Delay(8000);

            //Handle popups
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme1 = Driver.FindElement(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button"));
            CloseWalkme1.Click();
            await Task.Delay(5000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-146340 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme2 = Driver.FindElement(By.CssSelector("#wm-shoutout-146340 > div.wm-close-button.walkme-x-button"));
            CloseWalkme2.Click();
            await Task.Delay(5000);

        }


    }
}

