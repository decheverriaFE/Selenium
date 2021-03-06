﻿using OpenQA.Selenium;
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
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;
using NUnit.Framework;

namespace SeleniumProject.TestCase.Static_Tests
{
    class FE_5229_Web_Static_Screen_Test_Plan_for_Invoices_List
    {
        IWebDriver Driver = new ChromeDriver();
        

        [SetUp]
        public async Task Initialize() // Initialize new Chrome Driver, go to homepage
        {
            HomePage home = new HomePage(Driver);
            home.gotoPage();
            await Task.Delay(8000);          
        }

        [Test, Order(1)]
        public async Task InvoiceListColumns() // Click invoices list and verify columns (Test1)
        {
            
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            //click invoices list
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(8) > a > span:nth-child(2)")));
            Driver.FindElement(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(8) > a > span:nth-child(2)")).Click();
            await Task.Delay(2000);

            //Verify each column-Filters are visible
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#main-page-container > div.top-header-container > div > div > div.active")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("th.sortable:nth-child(2) > span:nth-child(1)")));//1
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("th.sortable:nth-child(2) > span:nth-child(1)"), "WO #"));//2
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("th.sortable:nth-child(3) > span:nth-child(1)"), "PO#"));//3
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("th.sortable:nth-child(4) > span:nth-child(1)"), "Invoice #"));//4
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("th.sortable:nth-child(5) > span:nth-child(1)"), "Date"));//5
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("th.sortable:nth-child(6) > span:nth-child(1)"), "Due Date"));//6
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("th.sortable:nth-child(7) > span:nth-child(1)"), "Total"));//7
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("th.sortable:nth-child(8) > span:nth-child(1)"), "Due"));//8
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("th.sortable:nth-child(9) > span:nth-child(1)"), "Technician"));//9
            await Task.Delay(2000);
            

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.filter-group:nth-child(2) > div:nth-child(2)")));//1
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.filter-group:nth-child(4) > div:nth-child(2)")));//2
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.filter-group:nth-child(6) > div:nth-child(2)")));//3
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.filter-group:nth-child(8) > div:nth-child(2)")));//4
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.secondary-filter-container:nth-child(3) > div:nth-child(2) > div:nth-child(1)")));//5
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.secondary-filter-container:nth-child(3) > div:nth-child(3) > div:nth-child(1)")));//6
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.secondary-filter-container:nth-child(3) > div:nth-child(4) > div:nth-child(1)")));//7
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.secondary-filter-container:nth-child(3) > div:nth-child(5) > div:nth-child(1)")));//8
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("button.default-btn:nth-child(1)"))); //export
            await Task.Delay(2000);

            Driver.FindElement(By.CssSelector("div.filter-group:nth-child(8) > div:nth-child(2)")).Click();
            Driver.FindElement(By.CssSelector("#search")).SendKeys("Aberdeen");
            await Task.Delay(2000);

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.filter-group:nth-child(8) > div:nth-child(2)")));
            Driver.FindElement(By.CssSelector("div.filter-group:nth-child(8) > div:nth-child(2)")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("tr.regular:nth-child(1) > td:nth-child(1) > div:nth-child(1)")));
            Driver.FindElement(By.CssSelector("tr.regular:nth-child(1) > td:nth-child(1) > div:nth-child(1)")).Click();
            await Task.Delay(5000);
        }
        [TearDown]
        public void ShutDown() //Shut down driver
        {
            Driver.Quit();
        }
    }
}
