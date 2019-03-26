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


namespace SeleniumProject.MasterTest.StaticTestsWithReports
{
    [TestFixture]
    class StaticTestsWithReports
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

        [SetUp]
        public async Task InitializeASync() // Go to Home page 
        {
            HomePage home = new HomePage(Driver);
            home.gotoPage();
            await Task.Delay(5000);

        }

    }
}

