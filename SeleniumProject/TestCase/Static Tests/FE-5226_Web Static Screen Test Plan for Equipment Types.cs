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
    class FE_5226_Web_Static_Screen_Test_Plan_for_Equipment_Types
    {
        IWebDriver Driver = new ChromeDriver();

        [SetUp]
        public async Task Initialize()
        {
            HomePage home = new HomePage(Driver);
            home.gotoPage();
            await Task.Delay(8000);
        }

        [Test, Order(1)]
        public async Task EquipmentTypes() //Run Equipment type test for JIRA FE-5226
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            //Global settings, select Equipment type.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("li.clearfix:nth-child(1) > a:nth-child(3)")));
            Driver.FindElement(By.CssSelector("li.clearfix:nth-child(1) > a:nth-child(3)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.setting-container:nth-child(2) > ul:nth-child(4) > li:nth-child(3) > a:nth-child(1) > text:nth-child(1)")));
            Driver.FindElement(By.CssSelector("div.setting-container:nth-child(2) > ul:nth-child(4) > li:nth-child(3) > a:nth-child(1) > text:nth-child(1)")).Click();

            await Task.Delay(5000);

            //Select Equipment and make one inactive --> save. Verify it is no longer in view.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#search")));
            Driver.FindElement(By.CssSelector("#search")).SendKeys("6 Burner Stove" + Keys.Enter);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".checkbox-inline")));
            Driver.FindElement(By.CssSelector(".checkbox-inline")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#EditItemsButton")));
            Driver.FindElement(By.CssSelector("#EditItemsButton")).Click();

            //Click 'Mark Inactive' --> Save
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#edit-items > div:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.radio:nth-child(1) > label:nth-child(2)")));
            Driver.FindElement(By.CssSelector("div.radio:nth-child(1) > label:nth-child(2)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#edit-items > div:nth-child(1) > form:nth-child(3) > div:nth-child(4) > button:nth-child(1)")));
            Driver.FindElement(By.CssSelector("#edit-items > div:nth-child(1) > form:nth-child(3) > div:nth-child(4) > button:nth-child(1)")).Click();

            await Task.Delay(3000);


            var equipType = Driver.FindElement(By.CssSelector("tr.single:nth-child(1)")).Text; //returns string inside of inactive element

            if (!equipType.Equals("6 Burner Stove")) //Pass - Made EquipType Inactive
            {
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#search")));
                Driver.FindElement(By.CssSelector("#search")).SendKeys("6 Burner Stove" + Keys.Enter);
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.filter-group:nth-child(1) > div:nth-child(2)")));
                Driver.FindElement(By.CssSelector("div.filter-group:nth-child(1) > div:nth-child(2)")).Click();
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".checkbox-inline")));
                Driver.FindElement(By.CssSelector(".checkbox-inline")).Click();
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#EditItemsButton")));
                Driver.FindElement(By.CssSelector("#EditItemsButton")).Click();
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#edit-items > div:nth-child(1)")));
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#edit-items > div:nth-child(1) > form:nth-child(3) > div:nth-child(4) > button:nth-child(1)")));
                Driver.FindElement(By.CssSelector("#edit-items > div:nth-child(1) > form:nth-child(3) > div:nth-child(4) > button:nth-child(1)")).Click();
                await Task.Delay(2000);
            }
            else //Pass - It did not find it - type was succesfully made inactive, reverts back.
            {
                Assert.Fail("JIRA FE-5226, Test Failed did not make equipment type inactive");
                Driver.FindElement(By.CssSelector("")).Click();
            }

            //Check filters in Settings --> Equipment types
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".secondary-filter")));
            Driver.FindElement(By.CssSelector(".secondary-filter")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".filter-popup")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".filter-multiselect > div:nth-child(1)")));
            Driver.FindElement(By.CssSelector("#selected0_0_1")).Click();
            Driver.FindElement(By.CssSelector("#selected0_0_10")).Click();
            await Task.Delay(1000);
            Driver.FindElement(By.CssSelector(".filter-popup > div:nth-child(4) > button:nth-child(1)")).Click();
            await Task.Delay(2000);
            Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(4) > a:nth-child(1)")).Click();
            await Task.Delay(3000);
            
        }

        [TearDown]
        public void Closer() //Close browser
        {
            Driver.Quit();
        }
    }
}
