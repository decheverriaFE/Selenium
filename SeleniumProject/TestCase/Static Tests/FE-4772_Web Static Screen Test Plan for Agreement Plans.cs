using OpenQA.Selenium;
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
    class FE_4772_Web_Static_Screen_Test_Plan_for_Agreement_Plans
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
        public async Task AgreementPlans()
        {
            // Test uses Business Units in them

            // Locals 
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(10000000);
            String agreementPlan = "1 Visit Per year\n" +
                "10 point safety inspection - Heating OR Cooling\n" +
                "20 point Performance Check - Heating OR Cooling\n" +
                "Check Gas or Refrigerant Press - YES\n" +
                "Clean Drain Lines - YES\n" +
                "Priority Status - YES\n" +
                "No Emergency Charges - YES\n" +
                "Light Rinsing of Outdoor Coils - $35\n" +
                "Complete Outdoor Coil Cleaning - $139\n" +
                "IAQ Accessories - $3/Mo @ $40ea\n" +
                "Burners Cleaned (As needed) - $99\n" +
                "Blower Cleaned (as needed) - $249\n";


            // Go to settings --> Agreement Plans
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("li.clearfix:nth-child(1) > a:nth-child(3)")));
            Driver.FindElement(By.CssSelector("li.clearfix:nth-child(1) > a:nth-child(3)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.setting-container:nth-child(3) > ul:nth-child(4) > li:nth-child(2) > a:nth-child(1) > text:nth-child(1)")));
            Driver.FindElement(By.CssSelector("div.setting-container:nth-child(3) > ul:nth-child(4) > li:nth-child(2) > a:nth-child(1) > text:nth-child(1)")).Click();


            // Click Add plan button 
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".top-header > div:nth-child(1)")));
            Driver.FindElement(By.CssSelector("div.button-container:nth-child(2) > button:nth-child(1)")).Click();
            await Task.Delay(2000);

            // Perform static screen tests on agreement plans screen --> Create new agreement
            // Agreement Plan name - Item
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".form-horizontal")));
            Driver.FindElement(By.CssSelector("input.required")).SendKeys("Auto Plan" + " " + randomInt);
            Driver.FindElement(By.CssSelector("#select2-AgreementItem-container")).Click();
            await Task.Delay(2000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".select2-search__field")));
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("Agreement Plan");
            await Task.Delay(4000);
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys(Keys.Enter);

            // Class - Bunit
            Driver.FindElement(By.CssSelector("#select2-DepartmentID-container")).Click();
            await Task.Delay(2000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".select2-search__field")));
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys(Keys.ArrowDown + Keys.Enter);
            Driver.FindElement(By.CssSelector(".business-unit")).Click();
            await Task.Delay(2000);
            Driver.FindElement(By.CssSelector(".business-unit")).SendKeys(Keys.ArrowDown + Keys.Enter);


            // Description - Standard pricing rule
            Driver.FindElement(By.CssSelector("textarea.form-control")).SendKeys(agreementPlan);
            Driver.FindElement(By.CssSelector("#UseDefaultPricing")).Click();
            await Task.Delay(1000);

            // Save Plan
            Driver.FindElement(By.CssSelector("#create")).Click();

            // Finish test --> Go to Dashboard
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("li.side-bar-icon:nth-child(1) > a:nth-child(1) > span:nth-child(2)")));
            Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(1) > a:nth-child(1) > span:nth-child(2)")).Click();


            await Task.Delay(5000);
        }

        [TearDown]
        public void Closer()
        {
            Driver.Quit();
        }



    }
}
