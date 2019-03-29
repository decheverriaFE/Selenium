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
    class FE_4535_Web_Static_Screen_Test_Plan_for_Customer_Screenn
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

        [Test]
        public async Task CustomerScreenTest()
        {
            //Declare local variables
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            WebDriverWait waitPopUp = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(1000000);
            int randomInt2 = randomGenerator.Next(10000000);

            //Click on customers --> Add Customer
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("li.side-bar-icon:nth-child(4) > a:nth-child(1) > span:nth-child(2)")));
            Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(4) > a:nth-child(1) > span:nth-child(2)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".with-units")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.button-container:nth-child(2) > button:nth-child(1)")));
            Driver.FindElement(By.CssSelector("div.button-container:nth-child(2) > button:nth-child(1)")).Click();
            await Task.Delay(1000);

            //Begin to verify fields (active checkbox)
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".form-horizontal")));
            bool active = Driver.FindElement(By.Id("active")).Selected;


            if (active == true)
            {
                Console.WriteLine("Active checkbox default is checked on, PASS");
            }
            else
            {
                Assert.Fail("Active checkbox default is checked off, FAIL");
                
            }

            //Bill from office - Opt-out of call
            //Sub-customer of / Customer Type searches / Customer Acquired through. verify billing address is first auto-selected.
            bool checkBillAdd = Driver.FindElement(By.CssSelector(("div.no-label:nth-child(1) > div:nth-child(1)"))).Selected;

            if (!checkBillAdd == true)
            {
                Console.WriteLine("PASS - Billing address checkbox auto selected.");
            }
            else
            {
                Assert.Fail("FAIL - Billing Address checkbox not auto selected.");
            }

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.group-field-section-container:nth-child(22) > div:nth-child(2) > div:nth-child(2) > div:nth-child(1) > label:nth-child(3)")));
            Driver.FindElement(By.CssSelector("div.group-field-section-container:nth-child(22) > div:nth-child(2) > div:nth-child(2) > div:nth-child(1) > label:nth-child(3)")).Click();
            Driver.FindElement(By.CssSelector("div.group-field-section-container:nth-child(22) > div:nth-child(2) > div:nth-child(3) > div:nth-child(2) > label:nth-child(2)")).Click();

            Driver.FindElement(By.CssSelector("#select2-parentEntityID-container")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".select2-search__field")));
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("Davis");
            await Task.Delay(4000);
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys(Keys.Enter);


            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#select2-CustomerType-container")));
            Driver.FindElement(By.CssSelector("#select2-CustomerType-container")).Click();
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("Residential");
            await Task.Delay(2000);
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys(Keys.Enter);

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#select2-user-leadSource-combo-container")));
            Driver.FindElement(By.CssSelector("#select2-user-leadSource-combo-container")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".select2-search__field")));
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("Google");
            await Task.Delay(2000);
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys(Keys.Enter);

            //First-Last-Company-Display Names add --> Address 1/Address 2 City/state/zip
            Driver.FindElement(By.CssSelector("#FirstName")).SendKeys("Automation");
            Driver.FindElement(By.CssSelector("#LastName")).SendKeys("Test" + " " + randomInt);
            Driver.FindElement(By.CssSelector("#CompanyName")).SendKeys("Umbrella Corporation");
            Driver.FindElement(By.CssSelector("#Address1")).SendKeys(randomInt + " " + "Test Road");
            Driver.FindElement(By.CssSelector("#Address2")).SendKeys("Suite 343");
            Driver.FindElement(By.CssSelector("#City")).SendKeys("Fort Myers");
            Driver.FindElement(By.CssSelector("#State")).SendKeys("FL");
            Driver.FindElement(By.CssSelector("#Zip")).SendKeys("33919");



            //Phone Label-Number --> Email label-Address. Confirm Primary is auto selected
            Driver.FindElement(By.CssSelector("#PhoneLabel"));
            Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(1) > div:nth-child(2) > div:nth-child(2) > input:nth-child(1)")).SendKeys("123-456-7890");
            Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(1) > div:nth-child(3) > div:nth-child(2) > input:nth-child(1)"));
            Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(1) > div:nth-child(4) > div:nth-child(2) > input:nth-child(1)"))
                .SendKeys(randomInt + "@gmail.com");

            bool primaryCheck = Driver.FindElement(By.CssSelector("div.field-container:nth-child(8) > div:nth-child(1)")).Selected;

            if (!primaryCheck == true)
            {
                Console.WriteLine("PASS - Primary Email checkbox auto selected.");
            }
            else
            {
                Assert.Fail("FAIL - Primary Email checkbox NOT auto selected.");
            }

            //Add additional contact button --> Contact on primary (check boxes)
            Driver.FindElement(By.CssSelector(".default-btn")).Click();
            Driver.FindElement(By.CssSelector(".contact-on > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > label:nth-child(3)")).Click();
            Driver.FindElement(By.CssSelector("div.no-label:nth-child(2) > div:nth-child(1) > label:nth-child(3)")).Click();
            Driver.FindElement(By.CssSelector("div.no-label:nth-child(3) > div:nth-child(1) > label:nth-child(3)")).Click();

            //Pinned Notes --> Business Profile
            Driver.FindElement(By.CssSelector("#Information")).SendKeys("Pinned Note #: " + randomInt + "Test");
            Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(28) > div:nth-child(1) > div:nth-child(1) > label:nth-child(3)")).Click();
            Driver.FindElement(By.CssSelector("#select2-flatRateItem-container"));
            Driver.FindElement(By.CssSelector("#select2-taxCode-container"));

            Driver.FindElement(By.CssSelector("#salesPersonDivContainer > div:nth-child(2)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".select2-search__field")));
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("Field T.");
            await Task.Delay(1000);
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys(Keys.Enter);

            //Store Displayname for future testing.
            String customer = Driver.FindElement(By.CssSelector("#Name")).GetAttribute("value");

            //Create customer button.
            Driver.FindElement(By.CssSelector("#create")).Click();
            await Task.Delay(2000);

            //Handle Address Verification popup
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".modal-footer")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("button.btn:nth-child(1)")));
            Driver.FindElement(By.CssSelector("button.btn:nth-child(1)")).Click();
            await Task.Delay(2000);


            //Go back into Fieldedge Customers list and verify new customer is created.
            Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(4) > a:nth-child(1) > span:nth-child(2)")).Click();
            await Task.Delay(1000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.search-container")));
            Driver.FindElement(By.CssSelector("#search")).SendKeys(customer);
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(1) > div:nth-child(1)")));
            Driver.FindElement(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(1) > div:nth-child(1)")).Click();

            //Verify Fields, and Edit customer.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.button-container:nth-child(4) > button:nth-child(2)")));
            Driver.FindElement(By.CssSelector("div.button-container:nth-child(4) > button:nth-child(2)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.group-field-section-container:nth-child(22)")));
            await Task.Delay(1000);

            //Change address 2 and save --> leave and come back in to confirm changes
            Driver.FindElement(By.CssSelector("#Address2")).Click();
            Driver.FindElement(By.CssSelector("#Address2")).Clear();
            Driver.FindElement(By.CssSelector("#Address2")).SendKeys("Suite 98");
            String newAddress = Driver.FindElement(By.CssSelector("#Address2")).GetAttribute("value");
            

            //Verify changes were made.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#Address2")));
            if (newAddress == Driver.FindElement(By.CssSelector("#Address2")).GetAttribute("value"))
            {
                Driver.FindElement(By.CssSelector("#create")).Click();
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.bootbox.modal.fade.custom-bootbox.normal.in > div > div > div.modal-footer")));
                await Task.Delay(1000);
                Driver.FindElement(By.CssSelector("body > div.bootbox.modal.fade.custom-bootbox.normal.in > div > div > div.modal-footer > button.btn.success-btn.custom-btn")).Click();
                Console.WriteLine("Pass");
            }
            else
            {
                Assert.Fail("FAIL - Address 2 is was not updated... ");
            }

            //Click on Work-orders microdashboard --> Create new Work-order --> Customer edit. Verify popup comes in.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#details-navigator > div:nth-child(3) > div:nth-child(2)")));
            Driver.FindElement(By.CssSelector("#details-navigator > div:nth-child(3) > div:nth-child(2)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#details-list-container > div:nth-child(2) > button:nth-child(1)")));
            Driver.FindElement(By.CssSelector("#details-list-container > div:nth-child(2) > button:nth-child(1)")).Click();
            await Task.Delay(1000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#ExistingCustomerMainInfo > div.header")));
            Driver.FindElement(By.CssSelector("#ExistingCustomerMainInfo > div.header > a")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementExists(By.CssSelector("#EditCustomerOverlay > div:nth-child(1)")));

            //Edit Address2 again, verify changes outside of the quick edit popup.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementExists(By.CssSelector("#Address2")));
            Driver.FindElement(By.CssSelector("#Address2")).Clear();
            Driver.FindElement(By.CssSelector("#Address2")).SendKeys("Suite 88");
            String newAddressAfter = Driver.FindElement(By.CssSelector("#Address2")).GetAttribute("value");
            Driver.FindElement(By.CssSelector("div.button-container:nth-child(4) > button:nth-child(1)")).Click();
            await Task.Delay(2000);
            Driver.FindElement(By.CssSelector("#successMessage > div.button-container.clearfix > button.custom-btn.success-btn")).Click();
            await Task.Delay(4000);

            //Go back into customer and verify updated address from quick edit popup.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#label > div")));
            Driver.FindElement(By.CssSelector("#label > div > div.active > a")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#label > div > div.button-container")));
            Driver.FindElement(By.CssSelector("#label > div > div.button-container > button:nth-child(2)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.group-field-section-container:nth-child(22)")));
            String popUpAddress = Driver.FindElement(By.CssSelector("#Address2")).GetAttribute("value");

            if (newAddressAfter == popUpAddress)
            {
                Driver.FindElement(By.CssSelector("#create")).Click();
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".modal-footer")));
                Driver.FindElement(By.CssSelector("button.btn:nth-child(1)")).Click();
                await Task.Delay(1000);
            }
            else
            {
                Assert.Fail("FAIL - Changes made inside of Address 2 change (Work-Orders Edit customer popup) were not MADE!");

            }

            //Go to dispatching board --> +New work order --> Create customer.
            Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(3) > a:nth-child(1) > span:nth-child(2)")).Click();
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".with-units")));
            Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(7)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.setting-form:nth-child(3)")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".select2-search__field")));
            await Task.Delay(3000);
            Driver.FindElement(By.CssSelector("#new-work-order-id > div.form-formatted > div.setting-form.scrollable.form-horizontal.no-margin-top > div:nth-child(2) > div:nth-child(2) > div > button")).Click();          
            await Task.Delay(1000);


            //Fill in fields and completely verify everything.
            //Begin to verify fields (active checkbox)
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#add-new-customer > div:nth-child(21)")));
            bool checkActive1 = Driver.FindElement(By.CssSelector("#active")).Selected;

            if (checkActive1 == true)
            {
                Console.WriteLine("Active checkbox default is checked on, PASS");
            }
            else
            {
                Assert.Fail("Active checkbox default is checked off, FAIL");
                Driver.FindElement(By.CssSelector("")).Click();
            }

            //Sub-customer of / Customer Type searches / Customer Acquired through. verify billing address is first auto-selected.

            bool checkBillAdd1 = Driver.FindElement(By.CssSelector(("div.no-label:nth-child(1) > div:nth-child(1)"))).Selected;
            if (!checkBillAdd1 == true)
            {
                Console.WriteLine("PASS - Billing address checkbox auto selected.");
            }
            else
            {
                Assert.Fail("FAIL - Billing Address checkbox not auto selected.");
            }

            //Bill from office - Opt-out of call
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.group-field-section-container:nth-child(21) > div:nth-child(2) > div:nth-child(2) > div:nth-child(1)")));
            Driver.FindElement(By.CssSelector("div.group-field-section-container:nth-child(21) > div:nth-child(2) > div:nth-child(2) > div:nth-child(1)")).Click();
            Driver.FindElement(By.CssSelector("div.group-field-section-container:nth-child(21) > div:nth-child(2) > div:nth-child(3) > div:nth-child(2)")).Click();

            Driver.FindElement(By.CssSelector("#select2-parentEntityID-container")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".select2-search__field")));
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("Davis");
            await Task.Delay(3000);
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys(Keys.Enter);


            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#select2-CustomerType-container")));
            Driver.FindElement(By.CssSelector("#select2-CustomerType-container")).Click();
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("Residential");
            await Task.Delay(2000);
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys(Keys.Enter);

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#select2-user-leadSource-combo-container")));
            Driver.FindElement(By.CssSelector("#select2-user-leadSource-combo-container")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".select2-search__field")));
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("Google");
            await Task.Delay(2000);
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys(Keys.Enter);

            //First-Last-Company-Display Names add --> Address 1/Address 2 City/state/zip
            Driver.FindElement(By.CssSelector("#FirstName")).SendKeys("Automation");
            Driver.FindElement(By.CssSelector("#LastName")).SendKeys("Test" + " " + randomInt2);
            Driver.FindElement(By.CssSelector("#CompanyName")).SendKeys("Umbrella Corporation");
            Driver.FindElement(By.CssSelector("#Address1")).SendKeys(randomInt2 + " " + "Test Road");
            Driver.FindElement(By.CssSelector("#Address2")).SendKeys("Suite 343");
            Driver.FindElement(By.CssSelector("#City")).SendKeys("Fort Myers");
            Driver.FindElement(By.CssSelector("#City")).SendKeys(Keys.Tab + "FL");
            Driver.FindElement(By.CssSelector("#City")).SendKeys(Keys.Tab + Keys.Tab + "33919");



            //Phone Label-Number --> Email label-Address. Confirm Primary is auto selected
            Driver.FindElement(By.CssSelector("#PhoneLabel"));
            Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(1) > div:nth-child(2) > div:nth-child(2) > input:nth-child(1)")).SendKeys("123-456-7890");
            Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(1) > div:nth-child(3) > div:nth-child(2) > input:nth-child(1)"));
            Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(1) > div:nth-child(4) > div:nth-child(2) > input:nth-child(1)"))
                .SendKeys(randomInt + "@gmail.com");

            bool primaryCheck1 = Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(1) > div:nth-child(8) > div:nth-child(1)")).Selected;

            if (!primaryCheck1 == true)
            {
                Console.WriteLine("PASS - Primary Email checkbox auto selected.");
            }
            else
            {
                Assert.Fail("FAIL - Primary Email checkbox NOT auto selected.");
            }

            //Add additional contact button --> Contact on primary (check boxes)
            Driver.FindElement(By.CssSelector("#ContactInfo > div.group-field-section-container.clearfix > div > button")).Click();
            Driver.FindElement(By.CssSelector("#phone")).Click();
            Driver.FindElement(By.CssSelector("#mobile")).Click();
            Driver.FindElement(By.CssSelector("#email")).Click();

            //Pinned Notes --> Business Profile
            Driver.FindElement(By.CssSelector("#Information")).SendKeys("Pinned Note #: " + randomInt + " Test");
            Driver.FindElement(By.CssSelector("#requirePO")).Click();

            //Create customer button.
            Driver.FindElement(By.CssSelector("div.form-formatted:nth-child(2) > div:nth-child(4) > div:nth-child(1) > button:nth-child(2)")).Click();
            await Task.Delay(2000);

            //Handle Address Verification popup
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".modal-footer")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("button.btn:nth-child(1)")));
            Driver.FindElement(By.CssSelector("button.btn:nth-child(1)")).Click();

            //Verify record does not already exist
            bool popUp = Driver.FindElement(By.CssSelector("#main-page-container > feedback-message:nth-child(5) > div:nth-child(1)")).Selected;

            if(!popUp == true)
            {
                Console.WriteLine("No popup.");
            }
            else
            {
                Assert.Fail("FAIL -- Record already exists, check variables assigned to displayName.");
            }

            //Create new work-order with newest customer
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#new-work-order-id > div:nth-child(1)")));
            Driver.FindElement(By.CssSelector("span.select2:nth-child(3) > span:nth-child(1)")).Click();
            await Task.Delay(1000);
            Driver.FindElement(By.CssSelector(".business-unit")).SendKeys(Keys.ArrowDown + Keys.Enter);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#taskdivcontainer > span:nth-child(2) > span:nth-child(1)")));
            Driver.FindElement(By.CssSelector("#taskdivcontainer > span:nth-child(2) > span:nth-child(1)")).Click();
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("HVAC" + Keys.Enter);
            Driver.FindElement(By.CssSelector("#CustomerPO")).Click();
            Driver.FindElement(By.CssSelector("#CustomerPO")).SendKeys("" + randomInt2);
            Driver.FindElement(By.CssSelector("button.success-btn:nth-child(3)")).Click();
            await Task.Delay(5000);

            Driver.FindElement(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(1) > a > span:nth-child(2)")).Click();
            await Task.Delay(2000);

        }

        public void Closer()
        {
            Driver.Quit();
        }
    }
}
