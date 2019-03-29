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


namespace SeleniumProject.handler
{
    
    public class ReportHandler//Reports handler, to be callable
    {
        
        IWebDriver Driver = new ChromeDriver();
        public static ExtentReports extent = new ExtentReports();
        public static ExtentTest test = null;

        //Start extent reporting instance using htmlreporter
        public static void generateReport(List xmlSuites, List suites, String outputDirectory)
        {
            extent = new ExtentReports(); // Create object for extent reports
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\rdasilva\Source\Repos\decheverriaFE\Selenium\SeleniumProject\ExtentReport\"); // needs html endpoint, storing on extentreport folder
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public static void ExtentClose()
        {
            extent.Flush();
        }

    }
}

