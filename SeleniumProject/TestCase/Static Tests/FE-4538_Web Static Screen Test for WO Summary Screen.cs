using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.handler;
using SeleniumProject.PageObject;
using System;
using System.Threading.Tasks;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;
using NUnit.Framework;


namespace SeleniumProject.TestCase.Static_Tests
{
    [TestFixture]
    class FE_4538_Web_Static_Screen_Test_for_WO_Summary_Screen
    {
        //Globals
        IWebDriver Driver = new ChromeDriver();

        [SetUp]
        public async Task InitializeASync() // Go to Home page 
        {
            HomePage home = new HomePage(Driver);
            home.gotoPage();
            await Task.Delay(5000);

        }

        [Test, Order(1)]
        public async Task WO_Summary_Screen()
        {

            //Declare local variables
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(1000000);
            int randomSingleInt = randomGenerator.Next(10);
            DateTime today = DateTime.Today;
            var date = today.Date;


            //Navigate to an existing customer in FE Web
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("li.side-bar-icon:nth-child(4) > a:nth-child(1) > span:nth-child(2)")));
            Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(4) > a:nth-child(1) > span:nth-child(2)")).Click();
            await Task.Delay(2000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#search")));
            Driver.FindElement(By.CssSelector("#search")).Click();
            Driver.FindElement(By.CssSelector("#search")).SendKeys("Automation" + " " + randomSingleInt + Keys.Enter);
            await Task.Delay(2000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(1) > div:nth-child(1)")));
            Driver.FindElement(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(1) > div:nth-child(1)")).Click();

            //Work-orders microdashboard --> new Work-order.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#details-navigator > div:nth-child(3) > div:nth-child(2)")));
            Driver.FindElement(By.CssSelector("#details-navigator > div:nth-child(3) > div:nth-child(2)")).Click();
            await Task.Delay(1000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#details-list-container > div:nth-child(2) > button:nth-child(1)")));
            Driver.FindElement(By.CssSelector("#details-list-container > div:nth-child(2) > button:nth-child(1)")).Click();
            await Task.Delay(1000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#ExistingCustomerMainInfo > div.header")));

            //Create Work-order -- Fill all fields in WO, assign primary tech -- Create-Work-Order.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#task-details")));
            Driver.FindElement(By.CssSelector("span.select2:nth-child(5) > span:nth-child(1)")).Click();
            await Task.Delay(1000);
            Driver.FindElement(By.CssSelector(".business-unit")).SendKeys(Keys.ArrowDown + Keys.Enter);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#taskdivcontainer > span:nth-child(2) > span:nth-child(1)")));
            Driver.FindElement(By.CssSelector("#taskdivcontainer > span:nth-child(2) > span:nth-child(1)")).Click();
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("HVAC" + Keys.Enter);
            Driver.FindElement(By.CssSelector("#leadSourceDivContainer > span > span.selection > span > span.select2-selection__arrow")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")));
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).SendKeys(Keys.ArrowDown + Keys.Enter);

            Driver.FindElement(By.CssSelector("#select2-primary-tech-dropdown-container")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")));
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).SendKeys("Field T." + Keys.Enter);
            Driver.FindElement(By.CssSelector("#start-date")).SendKeys(date.ToString("MM/dd/yyyy") + Keys.Enter);
            Driver.FindElement(By.CssSelector("#startTime")).Click();
            Driver.FindElement(By.CssSelector("#CustomerPO")).Click();
            Driver.FindElement(By.CssSelector("#CustomerPO")).SendKeys("" + randomInt);
            Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(3)")).Click();
            await Task.Delay(6000);

            //Complete work-order -- No show
            await Task.Delay(10000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#label")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#label > div.clearfix > div.button-container > button.custom-btn.success-btn.save-btn")));            
            Driver.FindElement(By.CssSelector("#label > div.clearfix > div.button-container > button.custom-btn.success-btn.save-btn")).Click();
            await Task.Delay(8000);
            
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("li.radio:nth-child(13) > label:nth-child(2)")));
            Driver.FindElement(By.CssSelector("li.radio:nth-child(13) > label:nth-child(2)")).Click();
            await Task.Delay(2000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#saveModal > div:nth-child(2) > div.clearfix.modal-button-container > button.custom-btn.success-btn.modal-confirm-button")));
            Driver.FindElement(By.CssSelector("#saveModal > div:nth-child(2) > div.clearfix.modal-button-container > button.custom-btn.success-btn.modal-confirm-button")).Click();

            //Store latest work-order
            string myWO = Driver.FindElement(By.CssSelector("div.active:nth-child(3)")).Text;
            await Task.Delay(2000);

            //Navigate to Work orders list, and ensure you can access this work order
            Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(6) > a:nth-child(1) > span:nth-child(2)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".with-units")));
            await Task.Delay(2000);
            Driver.FindElement(By.CssSelector("#search")).SendKeys(myWO + Keys.Enter);
            await Task.Delay(4000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(2) > div:nth-child(1)")));
            Driver.FindElement(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(2) > div:nth-child(1)")).Click();


            await Task.Delay(4000);
        }

        [TearDown]
        public void Closer()
        {
           Driver.Quit();
        }





    }
}
