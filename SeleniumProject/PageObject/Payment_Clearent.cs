using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;

namespace SeleniumProject.PageObject
{
    class Payment_Clearent
    {
        protected IWebDriver Driver;

        public Payment_Clearent(IWebDriver driver)
        {
            Driver = driver;
        }

        [SetUp]  //Nunit - Anotation to execute a method before every test.
        //Start Chrome and goto URL.
        public void BeforeTest()
        {

            Driver = new ChromeDriver();

        }

        public object SeleniumExtras { get; private set; }

        [SetUp]  //Nunit - Anotation to execute a method before every test.
        //Start Chrome and goto URL.

            [Test]

        public void gotoPage()
        {

             WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //DotNetSeleniumExtras.WaitHelpers NuGet package needs to be added
                     
            //Payment..

           //wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.header-information > div.payment-info")));
                     
            
            IWebElement ClickCardNumber = Driver.FindElement(By.Id("Clearent-card"));
            ClickCardNumber.Click();
            ClickCardNumber.SendKeys("41111111111111111");

            IWebElement ClickExpDate = Driver.FindElement(By.Id("Clearent-exp-date"));
            ClickExpDate.Click();
            ClickExpDate.SendKeys("1220");

            IWebElement ClickSecCode = Driver.FindElement(By.Id("Clearent-cvc"));
            ClickSecCode.Click();
            ClickSecCode.SendKeys("999");

            IWebElement EnterFirtNameCard = Driver.FindElement(By.Id("Clearent-first-name"));
            EnterFirtNameCard.Click();
            EnterFirtNameCard.SendKeys("FirstName");

            IWebElement EnterLastNameCard = Driver.FindElement(By.Id("Clearent-last-name"));
            EnterLastNameCard.Click();
            EnterLastNameCard.SendKeys("LastName");

            IWebElement EnterAddressCard = Driver.FindElement(By.Id("Clearent-address"));
            EnterAddressCard.Click();
            EnterAddressCard.SendKeys("Address");

            IWebElement EnterCityCard = Driver.FindElement(By.Id("Clearent-city"));
            EnterCityCard.Click();
            EnterCityCard.SendKeys("Cape Coral");

            IWebElement EnterStateCard = Driver.FindElement(By.Id("Clearent-state"));
            EnterStateCard.Click();
            EnterStateCard.SendKeys("Florida");
            EnterStateCard.SendKeys(Keys.Enter);

            IWebElement EnterZipCard = Driver.FindElement(By.Id("Clearent-zip"));
            EnterZipCard.Click();
            EnterZipCard.SendKeys("85284");

            IWebElement PayNowClearent = Driver.FindElement(By.Id("Clearent-submit"));
            PayNowClearent.Click();


            


            //Go to FE WebAppp
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#label > div.clearfix > div.button-container > button.custom-btn.success-btn.save-btn")));

            IWebElement ClickOnSaveButtonWO = Driver.FindElement(By.CssSelector("#label > div.clearfix > div.button-container > button.custom-btn.success-btn.save-btn"));
            ClickOnSaveButtonWO.Click();

          


            IWebElement ClickOnConfirrmButtonWO = Driver.FindElement(By.CssSelector("#saveModal > div:nth-child(2) > div.clearfix.modal-button-container > button.custom-btn.success-btn.modal-confirm-button"));
            ClickOnConfirrmButtonWO.Click();

        }
        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
    
}
