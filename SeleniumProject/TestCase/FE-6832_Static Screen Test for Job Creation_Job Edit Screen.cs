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
    class FE_6832_Static_Screen_Test_for_Job_Creation_Job_Edit_Screen
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
        public async Task CustomerJobEditScreen()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(2000);

            //Go to Customer/go to their "Jobs" tab and click the "Add Job" button.
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("li.side-bar-icon:nth-child(4) > a:nth-child(1) > span:nth-child(2)")));
            Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(4) > a:nth-child(1) > span:nth-child(2)")).Click();
            await Task.Delay(2000);


            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.Id("search")));
            IWebElement SearchCustomer = Driver.FindElement(By.Id("search"));
            SearchCustomer.SendKeys("Aberdeen" + Keys.Enter);
            await Task.Delay(5000);
            //Close Popups WalkMe and wait 30s
            //DotNetSeleniumExtras.WaitHelpers NuGet package needs to be added
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme1 = Driver.FindElement(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button"));
            CloseWalkme1.Click();
            await Task.Delay(2000);

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(1) > div:nth-child(1)")));

            Driver.FindElement(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(1) > div:nth-child(1)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#address-info-container > label:nth-child(1)"), "Address"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#details-navigator > div:nth-child(2) > div.clearfix.section-header > div.icon > img")));
            Driver.FindElement(By.CssSelector("#details-navigator > div:nth-child(2) > div.clearfix.section-header > div.icon > img")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#details-list-container > div:nth-child(3) > div.clearfix > button")));
            Driver.FindElement(By.CssSelector("#details-list-container > div:nth-child(3) > div.clearfix > button")).Click();

            //Verify the fields.

            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#AddJobModal > div > div.setting-form.scrollable.form-horizontal > div:nth-child(23) > div.group-field-container.clearfix > div:nth-child(1) > div > label"), "Active"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#AddJobModal > div > div.setting-form.scrollable.form-horizontal > div:nth-child(23) > div.group-field-container.clearfix > div:nth-child(2) > div > label"), "Bill from Office"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#Name")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#Information")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#select2-parentEntity-container")));
            
            /*wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#select2-4dwx-container > span")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#select2-flatRateItem-container")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#select2-flatRateItem-container")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#select2-gwgp-container")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#select2-brei-container")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#select2-fprr-container")));*/
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#startDate")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#projectEndDate")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#endDate")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#AddJobModal > div > div:nth-child(4) > div > button.custom-btn.success-btn")));

            

            //Save job

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#AddJobModal > div > div:nth-child(4) > div > button.custom-btn.success-btn")));
          Driver.FindElement(By.CssSelector("#AddJobModal > div > div:nth-child(4) > div > button.custom-btn.success-btn")).Click();


        }

        public void AfterTest()
        {


            Driver.Quit();


        }
    }
}
