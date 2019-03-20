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
    class FE_5227_Web_Static_Screen_Test_Plan_for_Phone_Setup
    {
        IWebDriver Driver = new ChromeDriver();

        [SetUp]
        public async Task InitializeASync() // Go to Home page 
        {
            HomePage home = new HomePage(Driver);
            home.gotoPage();
            await Task.Delay(5000);

            //Handle popups
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme1 = Driver.FindElement(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button"));
            CloseWalkme1.Click();
            await Task.Delay(5000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-146340 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme2 = Driver.FindElement(By.CssSelector("#wm-shoutout-146340 > div.wm-close-button.walkme-x-button"));
            CloseWalkme2.Click();
            await Task.Delay(5000);
        }

        [Test, Order(1)]
        public async Task PhoneSetupTest() // FE-5227, test phone setup
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            //Go to Phone setup
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(5) > a > text")));
            Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(5) > a > text")).Click();

            //verify all elements are visible
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(3) > div:nth-child(1) > div:nth-child(1) > label:nth-child(3)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("html.js.flexbox.flexboxlegacy.canvas.canvastext.webgl.no-touch.geolocation.postmessage.no-websqldatabase.indexeddb.hashchange.history.draganddrop.websockets.rgba.hsla.multiplebgs.backgroundsize.borderimage.borderradius.boxshadow.textshadow.opacity.cssanimations.csscolumns.cssgradients.no-cssreflections.csstransforms.csstransforms3d.csstransitions.fontface.generatedcontent.video.audio.localstorage.sessionstorage.webworkers.applicationcache.svg.inlinesvg.smil.svgclippaths body div#wrapper div#page-content-wrapper div#main-page-container.container-fluid div.dynamic-content.clearfix div div.dynamic-container.form-horizontal.form-formatted.clearfix form#form.setting-form div.group-field-container.clearfix div.field-container div.checkbox.checkbox-success label")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(4) > div:nth-child(1) > label:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(4) > div:nth-child(2) > label:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(5) > div:nth-child(1) > label:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(6) > div:nth-child(1) > label:nth-child(1)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.header:nth-child(7) > span:nth-child(1)")));

            
            await Task.Delay(5000);
        }

        [Test, Order(2)]
        public async Task PhoneSetupChanges()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#TwilioFailoverPhone")));
            Driver.FindElement(By.CssSelector("#TwilioFailoverPhone")).Click();
            Driver.FindElement(By.CssSelector("#TwilioFailoverPhone")).SendKeys("1234567890");
            await Task.Delay(5000);

            Driver.FindElement(By.CssSelector("button.small:nth-child(1)")).Click();
            await Task.Delay(5000);
        }

        [Test, Order(3)]
        public async Task PhoneSetupRevert()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            //Go to Phone setup
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(5) > a > text")));
            Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(5) > a > text")).Click();

            //verify fallback number has '1234567890' then revert back to empty
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#TwilioForwardingPhone")));



            await Task.Delay(5000);
        }

        [TearDown]
        public void Closer()
        {
            Driver.Close();
        }
    }

}
