﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;

namespace SeleniumProject.PageObject
{
    class HomePage
    {

    
        protected IWebDriver Driver;

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        [SetUp]  //Nunit - Anotation to execute a method before every test.
        //Start Chrome and goto URL.
        public void BeforeTest()
        {

            Driver = new ChromeDriver();

        }

        public object SeleniumExtras { get; private set; }

        [SetUp]  //Nunit - Anotation to execute a method before every test.
        //Start Chrome and goto URL.
        public void gotoPage()
        {
            
            Driver.Navigate().GoToUrl("https://fieldedgesiteea-staging.azurewebsites.net");
           // Driver.Navigate().GoToUrl("https://fieldedge.com");
            Driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            //DotNetSeleniumExtras.WaitHelpers NuGet package needs to be added
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#login-form > div:nth-child(3)")));

            
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#LoginEmail")));

            //Staging -- EA
            Driver.FindElement(By.CssSelector("#LoginEmail")).SendKeys("auto01@fieldedge.com");
            Driver.FindElement(By.CssSelector("#Password")).SendKeys("qa2019");

            //Driver.FindElement(By.CssSelector("#LoginEmail")).SendKeys("de@qalive.com");
            //Driver.FindElement(By.CssSelector("#Password")).SendKeys("qa");

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#login-form > div:nth-child(8) > input")));
            Driver.FindElement(By.CssSelector("#login-form > div:nth-child(8) > input")).Click();

            Thread.Sleep(4000);


            //Popups, This handles 2, adjust accordingly until function is created for this.

            /* wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme1 = Driver.FindElement(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button"));
            CloseWalkme1.Click();
            Thread.Sleep(8000);

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-146340 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme2 = Driver.FindElement(By.CssSelector("#wm-shoutout-146340 > div.wm-close-button.walkme-x-button"));
            CloseWalkme2.Click();
            Thread.Sleep(8000);*/

         


        }
        [TearDown]
        public void TearDown()
        {
           // Driver.Close();
        }

    }
}

