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
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".fixed-body")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("tr.single:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("tr.single:nth-child(1) > td:nth-child(1) > div:nth-child(1) > div:nth-child(1)")));
            //Select CheckBox on First Element
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr:nth-child(1) > td:nth-child(1) > div > div")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr:nth-child(1) > td:nth-child(1) > div > div")).Click();

            Driver.FindElement(By.CssSelector("#EditItemsButton")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.radio:nth-child(1) > label:nth-child(2)")));
            Driver.FindElement(By.CssSelector("div.radio:nth-child(1) > label:nth-child(2)")).Click();
            await Task.Delay(5000);

            var burnerStove = Driver.FindElement(By.CssSelector("tr.single:nth-child(1) > td:nth-child(2) > div:nth-child(1)")).Text;

            if (!burnerStove.Contains("6 Burner Stove")) //Fail - If it finds 6 burner stove in first element of index[0]
            {
                Assert.Fail("JIRA FE-5226, Test Failed did not make equipment type inactive");
                Driver.FindElement(By.CssSelector("")).Click();

            }
            else //Pass - It did not find it - type was succesfully made inactive, reverts back.
            {
                Driver.FindElement(By.CssSelector("div.filter-group:nth-child(1) > div:nth-child(2)")).Click();
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#select0")));
                Driver.FindElement(By.CssSelector("#select0")).Click();
                Driver.FindElement(By.CssSelector("#EditItemsButton"));
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#edit-items > div:nth-child(1) > form:nth-child(3) > div:nth-child(4) > button:nth-child(1)")));
                Driver.FindElement(By.CssSelector("#edit-items > div:nth-child(1) > form:nth-child(3) > div:nth-child(4) > button:nth-child(1)")).Click();

            }

            
        }

        [TearDown]
        public void Closer()
        {
            //Driver.Quit();
        }
    }
}
