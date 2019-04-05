using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.handler;
using SeleniumProject.PageObject;
using System;
using System.Threading.Tasks;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;
using NUnit.Framework;


namespace SeleniumProject.TestCase.Static_Tests
{
    [TestFixture]
    class FE_4773_Web_Static_Screen_Test_Plan_for_Agreements_Settings
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
        public async Task AgreementsSettings()
        {

            //Declare local variables
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(1000, 3000);
            int randomSecondInt = randomGenerator.Next(51);
            string randomIntString = randomInt.ToString();
            string randomSecondIntString = randomSecondInt.ToString();
            string baseDiscount = "15";




            //Navigate to Settings --> Agreements
            Driver.FindElement(By.CssSelector("li.clearfix:nth-child(1) > a:nth-child(3)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.setting-container:nth-child(3) > ul:nth-child(4) > li:nth-child(1) > a:nth-child(1) > text:nth-child(1)")));
            Driver.FindElement(By.CssSelector("div.setting-container:nth-child(3) > ul:nth-child(4) > li:nth-child(1) > a:nth-child(1) > text:nth-child(1)")).Click();
            await Task.Delay(2000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form")));

            //Verify all fields by altering every one --> Then Save.
            string baseCounter = Driver.FindElement(By.CssSelector("#Properties_AgreementCounter")).GetAttribute("value");
            Driver.FindElement(By.CssSelector("#Properties_AgreementDiscountPercent")).Click();
            Driver.FindElement(By.CssSelector("#Properties_AgreementDiscountPercent")).SendKeys(Keys.Backspace + Keys.Backspace);
            Driver.FindElement(By.CssSelector("#Properties_AgreementDiscountPercent")).SendKeys(randomSecondIntString + Keys.Tab + Keys.Clear + randomIntString);
            Driver.FindElement(By.CssSelector("#allowAgreementPriceOverride")).Click(); //override price
            Driver.FindElement(By.CssSelector("#showAgreementSavings")).Click(); //agreement savings
            Driver.FindElement(By.CssSelector("#EnableAgrSetTechAndTime")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#main-page-container > div.dynamic-content.clearfix > div > div > div > div > div.button-container > button")));
            Driver.FindElement(By.CssSelector("#main-page-container > div.dynamic-content.clearfix > div > div > div > div > div.button-container > button")).Click(); //Popup - Scheduling
            Driver.FindElement(By.CssSelector("#AllowPhoneCallsOnWeekends")).Click();
            Driver.FindElement(By.CssSelector("#manualDeactivation")).Click();
            string currentDiscount = Driver.FindElement(By.CssSelector("#Properties_AgreementDiscountPercent")).GetAttribute("value");
            string currentCounter = Driver.FindElement(By.CssSelector("#Properties_AgreementCounter")).GetAttribute("value");
            Driver.FindElement(By.CssSelector("button.small:nth-child(1)")).Click();
            await Task.Delay(6000);

            //Go back in, and confirm changes were kept --> then revert back to old settings
            Driver.FindElement(By.CssSelector("li.clearfix:nth-child(1) > a:nth-child(3)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.setting-container:nth-child(3) > ul:nth-child(4) > li:nth-child(1) > a:nth-child(1) > text:nth-child(1)")));
            Driver.FindElement(By.CssSelector("div.setting-container:nth-child(3) > ul:nth-child(4) > li:nth-child(1) > a:nth-child(1) > text:nth-child(1)")).Click();
            await Task.Delay(2000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form")));

            if (currentDiscount == randomSecondIntString)
            {

                if (currentCounter == randomIntString)
                {
                    Driver.FindElement(By.CssSelector("#Properties_AgreementDiscountPercent")).Click();
                    Driver.FindElement(By.CssSelector("#Properties_AgreementDiscountPercent")).SendKeys(Keys.Backspace + Keys.Backspace);
                    Driver.FindElement(By.CssSelector("#Properties_AgreementDiscountPercent")).SendKeys(baseDiscount + Keys.Tab + Keys.Clear + baseCounter);
                    Driver.FindElement(By.CssSelector("#allowAgreementPriceOverride")).Click(); //override price
                    Driver.FindElement(By.CssSelector("#showAgreementSavings")).Click(); //agreement savings
                    Driver.FindElement(By.CssSelector("#EnableAgrSetTechAndTime")).Click();
                    Driver.FindElement(By.CssSelector("#AllowPhoneCallsOnWeekends")).Click();
                    Driver.FindElement(By.CssSelector("#automaticDeactivation")).Click();
                    Driver.FindElement(By.CssSelector("button.small:nth-child(1)")).Click();
                    await Task.Delay(2000);
                }
                else
                {
                    Assert.Fail("JIRA FE-4773 FAIL. Updates made to Settings --> Agreements WORKED, but reverting to old settings did not..");
                }
            }
            else
            {
                Assert.Fail("JIRA FE-4773 FAIL. updates made to Settings --> Agreements did not hold, or element is not found.");

            }

            Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(3) > a:nth-child(1) > span:nth-child(2)")).Click();
            await Task.Delay(6000);

        }

        public void Closer()
        {
            Driver.Quit();
        }





    }
}
