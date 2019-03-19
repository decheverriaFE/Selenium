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

namespace SeleniumProject.PageObject.Lists
{
    class Dashboard
    {

        [SetUp]
        public void OpenFE()
        {

            var runBrowser = new FE_Login();
            runBrowser.StartBrowser();
        }

        [Test]
        public void ClickDashboard()
        {

        }






    }
}
