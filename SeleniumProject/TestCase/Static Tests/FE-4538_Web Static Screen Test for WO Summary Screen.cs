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
    class FE_4538_Web_Static_Screen_Test_for_WO_Summary_Screen
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
        public async Task WO_Summary_Screen()
        {








            await Task.Delay(1000);
        }





    }
}
