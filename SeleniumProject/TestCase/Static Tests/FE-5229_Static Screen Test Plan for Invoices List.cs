using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Handler;
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
    class FE_5229_Static_Screen_Test_Plan_for_Invoices_List
    {
        IWebDriver Driver = new ChromeDriver();
        

        [SetUp]
        public void Initialize() // Initialize new Chrome Driver
        {
            IWebDriver driver = new ChromeDriver();

        }

        [Test]
        [Order(1)]
        public async Task LoginAsync() // Log into FE (Test1)
        {
            
            Driver.Url = "http://fieldedgesiteea-staging.azurewebsites.net";
            Driver.Manage().Window.Maximize();

            Driver.FindElement(By.CssSelector("#LoginEmail")).SendKeys("auto01@fieldedge.com");
            Driver.FindElement(By.CssSelector("#Password")).SendKeys("qa2019");
            Driver.FindElement(By.CssSelector("#login-form > div:nth-child(8) > input")).Click();


            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme1 = Driver.FindElement(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button"));
            CloseWalkme1.Click();
            await Task.Delay(2000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-146340 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme2 = Driver.FindElement(By.CssSelector("#wm-shoutout-146340 > div.wm-close-button.walkme-x-button"));
            CloseWalkme2.Click();
            await Task.Delay(2000);

        }

        [Test]
        [Order(2)]
        public async Task InvoiceListColumns() // Click invoices list and verify columns (Test2)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(8) > a > span:nth-child(2)")));
            Driver.FindElement(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(8) > a > span:nth-child(2)")).Click();
            await Task.Delay(2000);

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(1) > span:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(2) > span:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(3) > span:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(4) > span:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(5) > span:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(6) > span:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(7) > span:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(8) > span:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(9) > span:nth-child(1)")));

            //wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#AddJobModal > div > div.setting-form.scrollable.form-horizontal > div:nth-child(23) > div.group-field-container.clearfix > div:nth-child(1) > div > label"), "Active"));
            //wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#Name")));
            await Task.Delay(2000);
        }

        [Test]
        [Order(3)]
        public async Task InvoiceListFilters() // validate second row of filters
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.filter-group:nth-child(2) > div:nth-child(2)")));//1
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.filter-group:nth-child(4) > div:nth-child(2)")));//2
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.filter-group:nth-child(6) > div:nth-child(2)")));//3
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.filter-group:nth-child(8) > div:nth-child(2)")));//4
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.secondary-filter-container:nth-child(3) > div:nth-child(2) > div:nth-child(1)")));//5
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.secondary-filter-container:nth-child(3) > div:nth-child(3) > div:nth-child(1)")));//6
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.secondary-filter-container:nth-child(3) > div:nth-child(4) > div:nth-child(1)")));//7
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.secondary-filter-container:nth-child(3) > div:nth-child(5) > div:nth-child(1)")));//8
            await Task.Delay(2000);
        }

        [Test]
        [Order(4)]
        public async Task InvoiceListExport()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("button.default-btn:nth-child(1)")));
            Driver.FindElement(By.CssSelector("button.default-btn:nth-child(1)")).Click();
            await Task.Delay(2000);
        }

        [TearDown]
        public void ShutDown()
        {
            Driver.Quit();
        }
    }
}
