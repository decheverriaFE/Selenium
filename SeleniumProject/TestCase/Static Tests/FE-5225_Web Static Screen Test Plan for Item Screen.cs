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
    class FE_5225_Web_Static_Screen_Test_Plan_for_Item_Screen
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
        public async Task ItemsScreen() //Run Item screen task for JIRA FE-5225
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));


            //Go to items --> Add item
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("li.side-bar-icon:nth-child(10) > a:nth-child(1) > span:nth-child(2)")));
            Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(10) > a:nth-child(1) > span:nth-child(2)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".fixed-body")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.button-container:nth-child(2) > button:nth-child(1)")));
            Driver.FindElement(By.CssSelector("div.button-container:nth-child(2) > button:nth-child(1)")).Click();
            await Task.Delay(2000);

            //Add new non-inventory item
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#itemType_chosen > a:nth-child(1) > span:nth-child(1)")));
            Driver.FindElement(By.CssSelector("#itemType_chosen > a:nth-child(1) > span:nth-child(1)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#itemType_chosen > div:nth-child(2)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#itemType_chosen > div:nth-child(2) > ul:nth-child(2)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("li.active-result:nth-child(2)")));
            Driver.FindElement(By.CssSelector("li.active-result:nth-child(2)")).Click();

            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(1000000);
            Driver.FindElement(By.CssSelector("#NonInventoryItemName")).SendKeys("Automation Test" + randomInt + Keys.Enter);

            Driver.FindElement(By.CssSelector("#InventoryItemCost")).Clear();
            Driver.FindElement(By.CssSelector("#InventoryItemCost")).SendKeys("5");
            Driver.FindElement(By.CssSelector("#InventoryItemPrice")).Clear();
            Driver.FindElement(By.CssSelector("#InventoryItemPrice")).SendKeys("10");

            Driver.FindElement(By.CssSelector("#InventoryItemForm > div:nth-child(19) > div:nth-child(2) > div:nth-child(3) > div:nth-child(1) > div:nth-child(2) > div:nth-child(3) > a:nth-child(1)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#InventoryItemForm > div:nth-child(19) > div:nth-child(2) > div:nth-child(3) > div:nth-child(1) > div:nth-child(2) > div:nth-child(3) > div:nth-child(2)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("li.active-result:nth-child(3)")));
            Driver.FindElement(By.CssSelector("li.active-result:nth-child(3)")).Click();
            Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(2)")).Click();
            
            
        }


    }
}
