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
    class FE_7954__Web_Static_Screen_Test_Plan_for_Customer_Type_Screen
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
        public async Task CustomerType()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();
            
            await Task.Delay(2000);

            //DotNetSeleniumExtras.WaitHelpers NuGet package needs to be added
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            

            //Go to Settings/Customer Types.
            
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li")).Click();
            await Task.Delay(2000);
            Driver.FindElement(By.CssSelector("div.setting-container:nth-child(3) > ul:nth-child(4) > li:nth-child(3) > a:nth-child(1) > text:nth-child(1)")).Click();

            //Click the "Add Customer Type" button.
            Driver.FindElement(By.CssSelector("div.button-container:nth-child(2) > button:nth-child(1)")).Click();

            
            //DotNetSeleniumExtras.WaitHelpers NuGet package needs to be added
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#CustomerTypeName")));
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(1000000);
            Driver.FindElement(By.CssSelector("#CustomerTypeName")).SendKeys("Automated Test Customer" + randomInt);
            Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(2)")).Click();
                     
           
            //Edit
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr:nth-child(1) > td:nth-child(1) > div")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr:nth-child(1) > td:nth-child(1) > div")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#CustomerTypeName")));
            Driver.FindElement(By.CssSelector("#CustomerTypeName")).Clear();
            Driver.FindElement(By.CssSelector("#CustomerTypeName")).SendKeys("Automated Test Customer_Edit" + randomInt);
            Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(2)")).Click();

            //mark as inactive
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#search")));
            Driver.FindElement(By.CssSelector("#search")).SendKeys("Automated Test Customer_Edit" + Keys.Enter);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr:nth-child(1) > td:nth-child(1) > div")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr:nth-child(1) > td:nth-child(1) > div")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div > div:nth-child(2) > div > div > label")));
            Driver.FindElement(By.CssSelector("#active")).Click();
            Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(2)")).Click();
            await Task.Delay(2000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#main-page-container > div.settings-sub-menu.clearfix > div.filter-container.clearfix > div.filter-group.box.inactive > div")));
            Driver.FindElement(By.CssSelector("#main-page-container > div.settings-sub-menu.clearfix > div.filter-container.clearfix > div.filter-group.box.inactive > div")).Click();
        }

        [TearDown]//notation to execute a method after every test.
        public void AfterTest()
        {


            Driver.Quit();


        }
    }
}
