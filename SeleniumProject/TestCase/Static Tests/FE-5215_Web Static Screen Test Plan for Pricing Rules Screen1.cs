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
    class FE_5215_Web_Static_Screen_Test_Plan_for_Pricing_Rules_Screen
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
        public async Task PriceRuleScreen()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(3000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#inventoryContainerMenu > li:nth-child(2) > a > text")));
            Driver.FindElement(By.CssSelector("#inventoryContainerMenu > li:nth-child(2) > a > text")).Click();
            //Make a change and save it..
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#AgreementDiscPercentage")));
            Driver.FindElement(By.CssSelector("#AgreementDiscPercentage")).Clear();
            Driver.FindElement(By.CssSelector("#AgreementDiscPercentage")).SendKeys("20");

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#create")));
            Driver.FindElement(By.CssSelector("#create")).Click();
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#AgreementDiscPercentage")));
            Driver.FindElement(By.CssSelector("#AgreementDiscPercentage")).Clear();
            Driver.FindElement(By.CssSelector("#AgreementDiscPercentage")).SendKeys("15");
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#create")));
            Driver.FindElement(By.CssSelector("#create")).Click();


        }
        [TearDown]
        public void closeDown()
        {
            Driver.Quit();
        }
    }
}

