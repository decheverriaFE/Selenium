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
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SeleniumProject.Handler
{
    [TestFixture]
    public class ReportHandler //Reports handler, to be callable
    {
        IWebDriver Driver = new ChromeDriver();
        ExtentReports extent = null;
        ExtentTest test = null;


        [OneTimeSetUp] //Start extent reporting instance using htmlreporter
        public void ExtentStart()
        {
            extent = new ExtentReports(); // Create object for extent reports
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\rdasilva\Source\Repos\decheverriaFE\Selenium\SeleniumProject\ExtentReport\"); // needs html endpoint, storing on extentreport folder
            extent.AttachReporter(htmlReporter); //takes one argument which is the htmlreport filepath
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }

    }
}

