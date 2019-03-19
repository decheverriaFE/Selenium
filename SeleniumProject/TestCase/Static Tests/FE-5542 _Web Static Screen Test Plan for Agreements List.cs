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
    class FE_5542__Web_Static_Screen_Test_Plan_for_Agreements_List
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
        public async Task Agreement_List()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(8000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme1 = Driver.FindElement(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button"));
            CloseWalkme1.Click();
            await Task.Delay(5000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-146340 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme2 = Driver.FindElement(By.CssSelector("#wm-shoutout-146340 > div.wm-close-button.walkme-x-button"));
            CloseWalkme2.Click();

            await Task.Delay(2000);
            //Select Agreement List
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(7) > a")));
            Driver.FindElement(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(7) > a")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#main-page-container > div.top-header-container > div > div > div.active")));
            //Verify Columns
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(1) > span:nth-child(1)"), "Customer"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(2) > span:nth-child(1)"), "Agreement #"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(3) > span:nth-child(1)"), "Agreement Plan"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(4) > span:nth-child(1)"), "Next Service Date"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(5) > span:nth-child(1)"), "Next Invoice Date"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(6) > span:nth-child(1)"), "Address"));
            //verify Filters
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#main-page-container > div.with-units.settings-sub-menu.clearfix > div.filter-container.clearfix > div.filter-group.box.inactive > div"), "include inactive"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#main-page-container > div.with-units.settings-sub-menu.clearfix > div.filter-container.clearfix > div.filter-group.box.selected > div.group-name"), "all"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#main-page-container > div.with-units.settings-sub-menu.clearfix > div.filter-container.clearfix > div:nth-child(4) > div.group-name"), "expiring"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#main-page-container > div.with-units.settings-sub-menu.clearfix > div.filter-container.clearfix > div:nth-child(6) > div.group-name"), "awaiting"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#main-page-container > div.with-units.settings-sub-menu.clearfix > div.filter-container.clearfix > div:nth-child(8) > div.group-name"), "unfinished"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#main-page-container > div.with-units.settings-sub-menu.clearfix > div.filter-container.clearfix > div:nth-child(3) > div.secondary-filter.box.date-filter > div:nth-child(1)"), "select date"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#main-page-container > div.with-units.settings-sub-menu.clearfix > div.filter-container.clearfix > div:nth-child(3) > div.secondary-filter.box.short.short > div:nth-child(1)"), "amount"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#main-page-container > div.with-units.settings-sub-menu.clearfix > div.filter-container.clearfix > div:nth-child(3) > div.secondary-filter.box.long > div:nth-child(1)"), "agreement plan"));
            //Export
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#main-page-container > div.top-header-container > div > div > div.button-container > button")));
            Driver.FindElement(By.CssSelector("#main-page-container > div.top-header-container > div > div > div.button-container > button")).Click();

            //Search agreement
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#search")));
            Driver.FindElement(By.CssSelector("#search")).SendKeys("Aberdeen" + Keys.Enter);
            await Task.Delay(2000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr > td:nth-child(6) > div > span")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr > td:nth-child(6) > div > span")).Click();
            //Verify maps
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.overlay:nth-child(1) > div:nth-child(1) > div:nth-child(4)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.overlay:nth-child(1) > div:nth-child(1) > div:nth-child(1) > button:nth-child(1)")));
            Driver.FindElement(By.CssSelector("div.overlay:nth-child(1) > div:nth-child(1) > div:nth-child(1) > button:nth-child(1)")).Click();

            

            //Clic First Element 
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr > td:nth-child(1) > div")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr > td:nth-child(1) > div")).Click();




        }
    }
}
