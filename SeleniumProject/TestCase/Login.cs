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

namespace SeleniumProject.TestCase
{
    //This class contains Login TestCases.
    [TestFixture] // Nunit - Anotation for a Class contains TestCases

    class Login
    {
        //Selenium Driver
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
            HomePage home = new HomePage(Driver);
            home.gotoPage();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#main-page-container > div.top-header-container.dashboard-fixed-elements > div > div > div")));

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
