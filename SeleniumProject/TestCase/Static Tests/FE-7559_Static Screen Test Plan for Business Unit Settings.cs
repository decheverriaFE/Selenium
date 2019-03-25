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
    class FE_7559__Static_Screen_Test_Plan_for_Business_Unit_Settings
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
        public async Task CustomerTypeBU()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(2000);
        }


            /*//In FE web, go to Settings / Business Unit Settings / Ability to sort the columns, search, view inactive BU's, filter the list, and view Add Unit screen

            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();
            await Task.Delay(2000);
            Driver.FindElement(By.CssSelector(".bus-unit-access > text:nth-child(1)")).Click();

            WebDriverWait wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait2.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("th.sortable:nth-child(1) > span:nth-child(2)")));


            Driver.FindElement(By.CssSelector("th.sortable:nth-child(1) > span:nth-child(2)")).Click();

            wait2.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("th.sortable:nth-child(2) > span:nth-child(1)")));
            Driver.FindElement(By.CssSelector("th.sortable:nth-child(2) > span:nth-child(1)")).Click();

            await Task.Delay(2000);

            //DotNetSeleniumExtras.WaitHelpers NuGet package needs to be added

            await Task.Delay(2000);


            //Click Add Unit button.
            wait2.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.button-container:nth-child(2) > button:nth-child(1)")));
            Driver.FindElement(By.CssSelector("div.button-container:nth-child(2) > button:nth-child(1)")).Click();
            wait2.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("input.required")));

            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(1000000);
            int randomint2 = randomGenerator.Next(10000);
            int randomint3 = randomGenerator.Next(10);
            int randomint4 = randomGenerator.Next(3000);

            Driver.FindElement(By.CssSelector("input.required")).SendKeys("Automated Test BU" + randomInt);
            Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(3) > div:nth-child(2) > input:nth-child(2)")).SendKeys("Automated Test BU" + randomInt);
            wait2.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".business-unit > span:nth-child(2) > b:nth-child(1)")));
            Driver.FindElement(By.CssSelector(".business-unit > span:nth-child(2) > b:nth-child(1)")).Click();
            await Task.Delay(3000);
            Driver.FindElement(By.CssSelector("#select2-2rcy-container > span")).Click();

        }

        /* Driver.FindElement(By.CssSelector("#select2-2rcy-container > span")).SendKeys("Global" + Keys.Enter);
        // IList<IWebElement> options1 = Driver.FindElements(By.ClassName("select2-results__options"));

        // if (options1.Any())
            // options1[0].Click();

         wait2.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("button.custom-btn:nth-child(3)")));
         Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(3)")).Click();

         //Edit the new BU:  add an address and upload an image, then save the changes.
         wait2.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.Id("search")));
         Driver.FindElement(By.Id("search")).SendKeys("Automated_Test_BU" + Keys.Enter);
         await Task.Delay(3000);
         Driver.FindElement(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(1) > div:nth-child(1)")).Click();
         wait2.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.group-field-container:nth-child(5) > div:nth-child(1) > input:nth-child(2)")));
         Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(5) > div:nth-child(1) > input:nth-child(2)")).Clear();
         Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(5) > div:nth-child(1) > input:nth-child(2)")).SendKeys(randomint2 + " NW " + randomint3 + "th St");
         Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(5) > div:nth-child(3) > input:nth-child(2)")).Clear();
         Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(5) > div:nth-child(3) > input:nth-child(2)")).SendKeys("Cape Coral");
         Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(5) > div:nth-child(4) > input:nth-child(2)")).Clear();
         Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(5) > div:nth-child(4) > input:nth-child(2)")).SendKeys("FL");
         Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(5) > div:nth-child(5) > input:nth-child(2)")).Clear();
         Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(5) > div:nth-child(5) > input:nth-child(2)")).SendKeys(randomint4 +"9");
         Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(6) > div:nth-child(1) > div:nth-child(2) > input:nth-child(1)")).Clear();
         Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(6) > div:nth-child(1) > div:nth-child(2) > input:nth-child(1)")).SendKeys("AutomatedTestBU" + randomInt + "@gmail.com");
         Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(3)")).Click();
         await Task.Delay(3000);
         wait2.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.Id("search")));
         Driver.FindElement(By.Id("search")).SendKeys("Automated_Test_BU" + Keys.Enter);
         await Task.Delay(3000);
         Driver.FindElement(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(1) > div:nth-child(1)")).Click();
         wait2.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".checkbox > label:nth-child(2)")));
         Driver.FindElement(By.CssSelector("#active")).Click();
         Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(3)")).Click();*/



        [TearDown]//notation to execute a method after every test.
        //Close Window
        public void AfterTest()
        {

            Driver.Quit();


        }
    }



}
