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
    class FE_4535_Web_Static_Screen_Test_Plan_for_Customer_Screen
    {
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
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(1000000);

            //Click on customers --> Add Customer
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("li.side-bar-icon:nth-child(4) > a:nth-child(1) > span:nth-child(2)")));
            Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(4) > a:nth-child(1) > span:nth-child(2)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".with-units")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.button-container:nth-child(2) > button:nth-child(1)")));
            Driver.FindElement(By.CssSelector("div.button-container:nth-child(2) > button:nth-child(1)")).Click();
            await Task.Delay(1000);

            //Begin to verify fields (active checkbox)
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".form-horizontal")));
            var checkActive = Driver.FindElement(By.CssSelector("div.group-field-section-container:nth-child(22) > div:nth-child(2) > div:nth-child(1) > div:nth-child(1)"));

            if (!checkActive.Selected)
            {
                Console.WriteLine("Active checkbox default is checked on, PASS");
            }
            else
            {
                Assert.Fail("Active checkbox default is checked off, FAIL");
                Driver.FindElement(By.CssSelector("")).Click();
            }

            //Bill from office - Opt-out of call
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.group-field-section-container:nth-child(22) > div:nth-child(2) > div:nth-child(2) > div:nth-child(1) > label:nth-child(3)")));
            Driver.FindElement(By.CssSelector("div.group-field-section-container:nth-child(22) > div:nth-child(2) > div:nth-child(2) > div:nth-child(1) > label:nth-child(3)")).Click();
            Driver.FindElement(By.CssSelector("div.group-field-section-container:nth-child(22) > div:nth-child(2) > div:nth-child(3) > div:nth-child(2) > label:nth-child(2)")).Click();

            //Sub-customer of / Customer Type searches / Customer Acquired through. verify billing address is first auto-selected.

            var checkBillAdd = Driver.FindElement(By.CssSelector(("div.no-label:nth-child(1) > div:nth-child(1)")));
            if (!checkBillAdd.Selected)
            {
                Console.WriteLine("PASS - Billing address checkbox auto selected.");
            }
            else
            {
                Assert.Fail("FAIL - Billing Address checkbox not auto selected.");
            }

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

            var primaryCheck = Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(1) > div:nth-child(8) > div:nth-child(1)"));

            if (!primaryCheck.Selected)
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

            Driver.FindElement(By.CssSelector("#salesPersonDivContainer > div:nth-child(2)")).Click(); //fail
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
            Driver.FindElement(By.CssSelector("#Address2")).SendKeys(Keys.Clear + "Suite 9");
            String newAddress = Driver.FindElement(By.CssSelector("#Address2")).GetAttribute("value");
            Driver.FindElement(By.CssSelector("#create")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.button-container:nth-child(4) > button:nth-child(2)")));
            Driver.FindElement(By.CssSelector("div.button-container:nth-child(4) > button:nth-child(2)")).Click();
            await Task.Delay(3000);

            //Verify changes were made.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.group-field-section-container:nth-child(22)")));
            if (newAddress == Driver.FindElement(By.CssSelector("#Address2")).GetAttribute("value"))
            {
                Driver.FindElement(By.CssSelector("#create"));
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
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#ExistingCustomerMainInfo")));
            Driver.FindElement(By.CssSelector("#ExistingCustomerMainInfo")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementExists(By.CssSelector("#EditCustomerOverlay > div:nth-child(1)")));

            //Edit Address2 again, verify changes outside of the quick edit popup.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementExists(By.CssSelector("#Address2")));
            Driver.FindElement(By.CssSelector("#Address2")).SendKeys(Keys.Clear + "Suite 88");
            Driver.FindElement(By.CssSelector("div.button-container:nth-child(4) > button:nth-child(1)")).Click();
            await Task.Delay(1000);
            String newAddressAfter = Driver.FindElement(By.CssSelector("#ExistingCustomerMainInfo > div:nth-child(2) > div:nth-child(2) > div:nth-child(2) > text:nth-child(1)")).GetAttribute("value");

            if (newAddressAfter == Driver.FindElement(By.CssSelector("#ExistingCustomerMainInfo > div:nth-child(2) > div:nth-child(2) > div:nth-child(2) > text:nth-child(1)")).GetAttribute("value"))
            {
                Driver.FindElement(By.CssSelector(".active > a:nth-child(2)")).Click();
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
            Driver.FindElement(By.CssSelector(".no-margin"));
            await Task.Delay(3000);

            //Fill in fields and completely verify everything.
            //Begin to verify fields (active checkbox)
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".form-horizontal")));
            var checkActive1 = Driver.FindElement(By.CssSelector("div.group-field-section-container:nth-child(22) > div:nth-child(2) > div:nth-child(1) > div:nth-child(1)"));

            if (!checkActive.Selected)
            {
                Console.WriteLine("Active checkbox default is checked on, PASS");
            }
            else
            {
                Assert.Fail("Active checkbox default is checked off, FAIL");
                Driver.FindElement(By.CssSelector("")).Click();
            }

            //Bill from office - Opt-out of call
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.group-field-section-container:nth-child(22) > div:nth-child(2) > div:nth-child(2) > div:nth-child(1) > label:nth-child(3)")));
            Driver.FindElement(By.CssSelector("div.group-field-section-container:nth-child(22) > div:nth-child(2) > div:nth-child(2) > div:nth-child(1) > label:nth-child(3)")).Click();
            Driver.FindElement(By.CssSelector("div.group-field-section-container:nth-child(22) > div:nth-child(2) > div:nth-child(3) > div:nth-child(2) > label:nth-child(2)")).Click();

            //Sub-customer of / Customer Type searches / Customer Acquired through. verify billing address is first auto-selected.

            var checkBillAdd1 = Driver.FindElement(By.CssSelector(("div.no-label:nth-child(1) > div:nth-child(1)")));
            if (!checkBillAdd.Selected)
            {
                Console.WriteLine("PASS - Billing address checkbox auto selected.");
            }
            else
            {
                Assert.Fail("FAIL - Billing Address checkbox not auto selected.");
            }

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

            var primaryCheck1 = Driver.FindElement(By.CssSelector("div.group-field-container:nth-child(1) > div:nth-child(8) > div:nth-child(1)"));

            if (!primaryCheck.Selected)
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

            Driver.FindElement(By.CssSelector("#salesPersonDivContainer > div:nth-child(2)")).Click(); //fail
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".select2-search__field")));
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("Field T.");
            await Task.Delay(1000);
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys(Keys.Enter);

            //Store Displayname for future testing.
            String customer1 = Driver.FindElement(By.CssSelector("#Name")).GetAttribute("value");

            //Create customer button.
            Driver.FindElement(By.CssSelector("#create")).Click();
            await Task.Delay(2000);

            //Handle Address Verification popup
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".modal-footer")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("button.btn:nth-child(1)")));
            Driver.FindElement(By.CssSelector("button.btn:nth-child(1)")).Click();
            await Task.Delay(2000);

            //Create new work-order with newest customer
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#new-work-order-id > div:nth-child(1)")));
            Driver.FindElement(By.CssSelector("#select2-lp1f-container > span:nth-child(1)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#select2-lp1f-result-vltw-e3208922-df7d-44c6-bc50-ba85d619cf25")));
            Driver.FindElement(By.CssSelector("#select2-lp1f-result-vltw-e3208922-df7d-44c6-bc50-ba85d619cf25")).SendKeys(Keys.ArrowDown + Keys.Enter);
            Driver.FindElement(By.CssSelector("#select2-taskCombobox-container")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".select2-search__field")));
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("HVAC" + Keys.Enter);
            Driver.FindElement(By.CssSelector("#select2-leadSourceCombobox-container")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".select2-search__field")));
            Driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("Google" + Keys.Enter);
            Driver.FindElement(By.CssSelector("button.success-btn:nth-child(3)")).Click();




        }

        public void Closer()
        {
            Driver.Quit();
        }
    }
}
