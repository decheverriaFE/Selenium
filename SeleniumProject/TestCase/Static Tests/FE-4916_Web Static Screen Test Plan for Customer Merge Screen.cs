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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;

namespace SeleniumProject.TestCase.Static_Tests
{
    class FE_4916_Web_Static_Screen_Test_Plan_for_Customer_Merge_Screen
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
        public async Task MergeCustomer1()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(3000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));



            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#application-menu > div:nth-child(3) > ul:nth-child(4) > li:nth-child(4) > a > text")));
            Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(3) > ul:nth-child(4) > li:nth-child(4) > a > text")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#main-page-container > div.settings-sub-menu.clearfix.transparent > div > div > div:nth-child(1) > div > span > span.selection > span > span.select2-selection__arrow > b")));
            Driver.FindElement(By.CssSelector("#main-page-container > div.settings-sub-menu.clearfix.transparent > div > div > div:nth-child(1) > div > span > span.selection > span > span.select2-selection__arrow > b")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")));
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).SendKeys("aber");

            await Task.Delay(3000);
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).SendKeys(Keys.Enter);


            await Task.Delay(3000);
      
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#main-page-container > div.settings-sub-menu.clearfix.transparent > div > div > div:nth-child(2) > div > span > span.selection > span > span.select2-selection__arrow > b")));
            Driver.FindElement(By.CssSelector("#main-page-container > div.settings-sub-menu.clearfix.transparent > div > div > div:nth-child(2) > div > span > span.selection > span > span.select2-selection__arrow > b")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")));
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).SendKeys("aber");
            await Task.Delay(3000);
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).SendKeys(Keys.Enter);


            //QB step 

        }
        [TearDown]
        public void CloseDown()
        {
            // Driver.Quit();

        }

    }
}
