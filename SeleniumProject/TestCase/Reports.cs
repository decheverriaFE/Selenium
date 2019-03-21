using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumProject.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumProject.TestCase
{
    class Reports
    {
        //Selenium Driver
        protected IWebDriver Driver;


        public object SeleniumExtras { get; private set; }

        [SetUp]  //Nunit - Anotation to execute a method before every test.
        //Start Chrome and goto URL.
        public void BeforeTest()
        {

            Driver = new ChromeDriver();

        }

        [Test]//Nunit - Anotation to mark a method as a Automated TestCase 
        public async Task ReportsFE()

        {
            HomePage home = new HomePage(Driver);
            home.gotoPage();


            await Task.Delay(8000);


            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //Select Report Menu ---OK
            IWebElement ClickReport = Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(12) > a:nth-child(1) > span:nth-child(2)"));
            ClickReport.Click();
                        
            Driver.FindElement(By.CssSelector("#submenu > ul > li.submenu-item.selected")).Click();

            //------------------Sales Repots/technician Sales Analysis------------------

            Driver.FindElement(By.CssSelector("#MainMenu > li:nth-child(1) > div.clearfix.main-content > div.submenu-content.open > div:nth-child(1) > div.title")).Click();
            Driver.FindElement(By.CssSelector("#main-page-container > div.dynamic-content.clearfix.full > div.overlay.wide > div > div.clearfix.button-container > button")).Click();
            await Task.Delay(3000);
            var tabs = Driver.WindowHandles;
                            if (tabs.Count > 1)
                              {
                                 Driver.SwitchTo().Window(tabs[1]);
                                 Driver.Close();
                                 Driver.SwitchTo().Window(tabs[0]);
                               }
            Driver.FindElement(By.CssSelector("#close-dialog-btn > span")).Click();


            //------------------Sales Repots/Sales Report By Class------------------
            Driver.FindElement(By.CssSelector("#MainMenu > li:nth-child(1) > div.clearfix.main-content > div.submenu-content.open > div:nth-child(2) > div.title")).Click();
            Driver.FindElement(By.CssSelector("#main-page-container > div.dynamic-content.clearfix.full > div.overlay.wide > div > div.clearfix.button-container > button")).Click();

            await Task.Delay(2000);
            var tabs1 = Driver.WindowHandles;
                            Driver.SwitchTo().Window(tabs1[1]);
                            Driver.Close();
                            Driver.SwitchTo().Window(tabs1[0]);

            Driver.FindElement(By.CssSelector("#close-dialog-btn > span")).Click();

            //------------------Work Order Reports/Technician Hours------------------

            Driver.FindElement(By.CssSelector("#submenu > ul > li:nth-child(2)")).Click();
            Driver.FindElement(By.CssSelector("#MainMenu > li:nth-child(1) > div.clearfix.main-content > div.submenu-content.open > div:nth-child(1) > div.title")).Click();
            Driver.FindElement(By.CssSelector("#main-page-container > div.dynamic-content.clearfix.full > div.overlay.wide > div > div.clearfix.button-container > button")).Click();
            await Task.Delay(2000);
            var tabs2 = Driver.WindowHandles;
            Driver.SwitchTo().Window(tabs2[1]);
            Driver.Close();
            Driver.SwitchTo().Window(tabs2[0]);
            Driver.FindElement(By.CssSelector("#close-dialog-btn > span")).Click();
        }


        public void AfterTest()
        {


            Driver.Quit();


        }
    }

}
