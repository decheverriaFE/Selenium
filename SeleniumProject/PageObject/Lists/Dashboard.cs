using NUnit.Framework;
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

namespace SeleniumProject.PageObject.Lists
{
    class Dashboard
    {




        public async Task OpenFEAsync() // Open FE
        {

            var runBrowser = new FE_Login();
            await runBrowser.StartBrowser();
            
        }


        public void ClickDashboard() // click on dashboard 
        {
            IWebDriver driver = new ChromeDriver();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-145434 > div.wm-close-button.walkme-x-button")));
            driver.FindElement(By.CssSelector("#wm-shoutout-145434 > div.wm-close-button.walkme-x-button")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(1) > a > span:nth-child(2)")));
            driver.FindElement(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(1) > a > span:nth-child(2)")).Click();
        }






    }
}
