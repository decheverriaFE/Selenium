using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
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

namespace SeleniumProject.TestCase
{
    //This class contains Login TestCases.
    [TestFixture] // Nunit - Anotation for a Class contains TestCases


    class Login
    {
               
        protected IWebDriver Driver;
        

        [SetUp]  //Nunit - Anotation to execute a method before every test.
        //Start Chrome and goto URL.
        public void BeforeTest()
        {
           
            Driver = new ChromeDriver();
          
        }

        [Test]//Nunit - Anotation to mark a method as a Automated TestCase 
        public void SuccessfullLoginTest()
        {
            Driver.Navigate().GoToUrl("https://fieldedgesiteea-staging.azurewebsites.net");
            Driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //DotNetSeleniumExtras.WaitHelpers NuGet package needs to be added
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#login-form > div:nth-child(3)")));


            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#LoginEmail")));

            IWebElement textbox = Driver.FindElement(By.CssSelector("#LoginEmail"));
            textbox.SendKeys("decheverria");
            Driver.FindElement(By.CssSelector("#Password")).SendKeys("qa2019");
            var text = textbox.GetAttribute("value");
            if (text != "textbox")
            {
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#login-form > div:nth-child(8) > input")));
                Driver.FindElement(By.CssSelector("#login-form > div:nth-child(8) > input")).Click();
            }










            // wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#login-form > div:nth-child(8) > input")));
            // Driver.FindElement(By.CssSelector("#login-form > div:nth-child(8) > input")).Click();



            //wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#main-page-container > div.top-header-container.dashboard-fixed-elements > div > div > div")));

            /*Driver.FindElement(By.CssSelector("#LoginEmail")).SendKeys("de@qalive.com");
            Driver.FindElement(By.CssSelector("#Password")).SendKeys("qa");

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#login-form > div:nth-child(8) > input")));
            Driver.FindElement(By.CssSelector("#login-form > div:nth-child(8) > input")).Click();*/
        }

        [TearDown]//notation to execute a method after every test.
        //Close Window
        public void AfterTest()
        {
           
              Driver.Quit();

           
         }
     
    }
}
