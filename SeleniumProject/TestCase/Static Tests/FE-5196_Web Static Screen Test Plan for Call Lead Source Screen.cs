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
    class FE_5196_Web_Static_Screen_Test_Plan_for_Call_Lead_Source_Screen
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
        public async Task CallLeadSource()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(3000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(3) > a > text")));
            Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(3) > a > text")).Click();
            //Add Skill and verify field
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#main-page-container > div.top-header-container > div > div > div.button-container")));
            Driver.FindElement(By.CssSelector("#main-page-container > div.top-header-container > div > div > div.button-container")).Click();
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#Name")));

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div > div:nth-child(4) > div:nth-child(2) > manage-business-unit-prop > div > div > span > span.selection > span > span.select2-selection__arrow")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div > div:nth-child(5) > div:nth-child(1) > div")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div > div:nth-child(5) > div:nth-child(2) > div > input.form-control.long")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div > div:nth-child(5) > div:nth-child(3) > div:nth-child(2) > input.form-control.phone-number")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div > div:nth-child(5) > div:nth-child(3) > div.group-field-container.clearfix > div")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#releaseGetNumberButton")));

            //var Sampler = wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#useExisting")));

            /*if (!Sampler.Displayed)
            {
                Console.WriteLine("Element Visible");
                Assert.Pass("Element Visible");

            }*/

            //Add New Lead Source

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#Name")));
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(1000000);
            Driver.FindElement(By.CssSelector("#Name")).SendKeys("AutomationNewLeadSource" + randomInt);

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div > div:nth-child(4) > div:nth-child(2) > manage-business-unit-prop > div > div > span > span.selection > span > span.select2-selection__arrow > b")));
            Driver.FindElement(By.CssSelector("#form > div > div:nth-child(4) > div:nth-child(2) > manage-business-unit-prop > div > div > span > span.selection > span > span.select2-selection__arrow > b")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.ClassName("select2-results__options")));
            IList<IWebElement> options1 = Driver.FindElements(By.ClassName("select2-results__options"));

            if (options1.Any())
                options1[0].Click();


             wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div > div:nth-child(5) > div:nth-child(2) > div > input.form-control.long")));
            Driver.FindElement(By.CssSelector("#form > div > div:nth-child(5) > div:nth-child(2) > div > input.form-control.long")).Click();




            //Need Add Phone Number





        }
        [TearDown]
        public void CloseDown()
        {
            Driver.Quit();

        }
    }
}


