﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("li.clearfix:nth-child(1) > a:nth-child(3)")));
            Driver.FindElement(By.CssSelector("li.clearfix:nth-child(1) > a:nth-child(3)")).Click();
            await Task.Delay(5000);

        }
    }
}
