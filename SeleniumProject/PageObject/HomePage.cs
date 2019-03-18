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
            Driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //DotNetSeleniumExtras.WaitHelpers NuGet package needs to be added
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#login-form > div:nth-child(3)")));

            
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#LoginEmail")));

            Driver.FindElement(By.CssSelector("#LoginEmail")).SendKeys("auto01@fieldedge.com");
            Driver.FindElement(By.CssSelector("#Password")).SendKeys("qa2019");

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#login-form > div:nth-child(8) > input")));
            Driver.FindElement(By.CssSelector("#login-form > div:nth-child(8) > input")).Click();

        }
        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }

    }
}

