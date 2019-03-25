using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
    class FE_5214_Web_Static_Screen_Test_Plan_for_Appointment_Block_Configuration_Screen
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
        public async Task AppointmentBlockConfigurationScreen()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(3000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(1) > a > text")));
            Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(1) > a > text")).Click();
            //Make a change and save it..

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#PropertiesBlockSchedulePercentAlloc")));
            Driver.FindElement(By.CssSelector("#PropertiesBlockSchedulePercentAlloc")).Clear();
            Driver.FindElement(By.CssSelector("#PropertiesBlockSchedulePercentAlloc")).SendKeys("85");

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(5) > button.custom-btn.success-btn.small")));
            Driver.FindElement(By.CssSelector("#form > div:nth-child(5) > button.custom-btn.success-btn.small")).Click();
            await Task.Delay(3000);
            

        }
    }
}
