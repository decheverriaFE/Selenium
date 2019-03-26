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
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System.Drawing.Imaging;

namespace SeleniumProject.TestCase.Static_Tests
{
    [TestFixture]
    class FE_5214_Web_Static_Screen_Test_Plan_for_Appointment_Block_Configuration_Screen
    {
        IWebDriver Driver = new ChromeDriver();
        ExtentReports extent = null;
        ExtentTest test = null;


        [OneTimeSetUp] //Start extent reporting instance using htmlreporter
        public void ExtentStart()
        {
            extent = new ExtentReports(); // Create object for extent reports
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\rdasilva\Source\Repos\decheverriaFE\Selenium\SeleniumProject\ExtentReport\"); // needs html endpoint, storing on extentreport folder
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }

        public object SeleniumExtras { get; private set; }

        [Test, Order(1)]//Nunit - Anotation to mark a method as a Automated TestCase 
        public async Task AppointmentBlockConfigurationScreen()
        {
            try
            {
                test = extent.CreateTest("FE_5216_EquipmentScreenTest").Info("Test Started"); //Mark start of test.

                HomePage home = new HomePage(Driver);
                home.gotoPage();

                await Task.Delay(3000);
                test.Log(Status.Pass, "Go to homepage, successfull - PASS");


                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
                Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(1) > a > text")));
                Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(1) > a > text")).Click();
                //Make a change and save it..
                test.Log(Status.Pass, "Go to settings --> Appointment block configuration. - PASS");


                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#PropertiesBlockSchedulePercentAlloc")));
                Driver.FindElement(By.CssSelector("#PropertiesBlockSchedulePercentAlloc")).Clear();
                Driver.FindElement(By.CssSelector("#PropertiesBlockSchedulePercentAlloc")).SendKeys("85");

                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(5) > button.custom-btn.success-btn.small")));
                Driver.FindElement(By.CssSelector("#form > div:nth-child(5) > button.custom-btn.success-btn.small")).Click();
                await Task.Delay(3000);

                test.Log(Status.Pass, "Make changes and save - PASS");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                test.Log(Status.Fail, "Tested Filters --> Return to Dashboard.");
                throw;
            }


        }
        [TearDown]
        public void closeDown()
        {
            Driver.Quit();
        }
    }
}
