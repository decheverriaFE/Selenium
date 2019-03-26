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
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;

namespace SeleniumProject.TestCase.Static_Tests
{
    class FE_6836__Static_Screen_Test_for_Customers_List
    {

        //Selenium Driver
        protected IWebDriver Driver;

        public object SeleniumExtras { get; private set; }

        [SetUp]  //Nunit - Anotation to execute a method before every test.
        //Start Chrome
        public void BeforeTest()
        {
            Driver = new ChromeDriver();


        }

        [Test]//Nunit - Anotation to mark a method as a Automated TestCase 
        public async Task CustomerTypeList()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(2000);


            //Go to Settings/Customer Types.
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("li.side-bar-icon:nth-child(4) > a:nth-child(1) > span:nth-child(2)")));
            Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(4) > a:nth-child(1) > span:nth-child(2)")).Click();
            await Task.Delay(2000);

           


            // Validate the column labels displayed.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th.sortable.emailed_printed")));
                  
                //validate - Name/Customertype/Address/Phone/Email/LeadSource        
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("th.sortable:nth-child(1) > span:nth-child(1)"), "Name"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("th.sortable:nth-child(2) > span:nth-child(1)"), "Customer Type"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("th.sortable:nth-child(3) > span:nth-child(1)"), "Address"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("th.sortable:nth-child(4) > span:nth-child(1)"), "Phone"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("th.sortable:nth-child(5) > span:nth-child(1)"), "Email"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("th.sortable:nth-child(6) > span:nth-child(1)"), "Lead Source"));

            //Validate the filter labels displayed.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("div.filter-group:nth-child(1) > div:nth-child(2)"), "include inactive"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("div.filter-group:nth-child(2) > div:nth-child(2)"), "all"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("div.filter-group:nth-child(4) > div:nth-child(2)"), "recent"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("div.filter-group:nth-child(6) > div:nth-child(2)"), "no contract"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("div.secondary-filter-container:nth-child(3) > div:nth-child(2) > div:nth-child(1)"), "date added"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("div.secondary-filter-container:nth-child(3) > div:nth-child(3) > div:nth-child(1)"), "all leads"));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("div.secondary-filter-container:nth-child(3) > div:nth-child(4) > div:nth-child(1)"), "customer type"));

            //Verify hierarchical context within the Customer List,
            //Verify that clicking on a given row in the list opens the expected screen.  
            

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.Id("search")));
            IWebElement SearchCustomer = Driver.FindElement(By.Id("search"));
            SearchCustomer.SendKeys("Aberdeen" + Keys.Enter);

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(1) > div:nth-child(1)")));

            Driver.FindElement(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(1) > div:nth-child(1)")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#address-info-container > label:nth-child(1)"), "Address"));

            //Verify that clicking on address link opens Google mapping.
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#address-info > text")));
            Driver.FindElement(By.CssSelector("#address-info > text")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#map-canvas")));

            //Verify that clicking on phone number link invokes call back feature.---Pending
            //wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#ContactInformation > div:nth-child(2) > div > span")));
            //Driver.FindElement(By.CssSelector("#ContactInformation > div:nth-child(2) > div > span")).Click();

            //Click Customer list "Add Customer" button.
            IWebElement ClickCustomer = Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(4) > a:nth-child(1) > span:nth-child(2)"));
            ClickCustomer.Click();

            //Click AddCustomer
            IWebElement ClicAddCustomer = Driver.FindElement(By.CssSelector("#main-page-container > div.top-header-container > div > div > div.button-container > button.custom-btn.success-btn"));
            ClicAddCustomer.Click();
            //TestCase with BU
            IWebElement SelectBU_Customer = Driver.FindElement(By.CssSelector("#form > div:nth-child(22) > div:nth-child(3) > manage-business-unit-prop > div > div > span > span.selection > span > span.select2-selection__arrow"));
            SelectBU_Customer.Click();
            //TypeBU
            //IWebElement TypeBU = Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input"));



            IList<IWebElement> options = Driver.FindElements(By.ClassName("select2-results__options"));

            if (options.Any() && options.Count() <= 20)

            {

                options[0].Click();

            }

            else
            {
                IWebElement typeBU = Driver.FindElement(By.ClassName("select2-search__field"));
                typeBU.SendKeys("GLobal");
                typeBU.SendKeys(Keys.Enter);

            }




            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(1000000);
            int randomint2 = randomGenerator.Next(10000000);
            int randomint3 = randomGenerator.Next(10);
            int randomint4 = randomGenerator.Next(30001);

            //Enter First Name, Last Name, Company Name
            IWebElement Customer_FirstName = Driver.FindElement(By.Id("FirstName"));
            Customer_FirstName.SendKeys("CustomerS" + randomInt);
            IWebElement Customer_LastName = Driver.FindElement(By.Id("LastName"));
            Customer_LastName.SendKeys("SeleniumS" + randomInt);

            IWebElement Customer_companyname = Driver.FindElement(By.Id("CompanyName"));
            //Enter randon value for customer.
            Customer_companyname.Click();


            Customer_companyname.SendKeys("Customer" + randomInt);
            //await Task.Delay(2000);

            //Enter random value for address
            IWebElement Customer_address = Driver.FindElement(By.CssSelector("#Address1"));
            Customer_address.Click();
            Customer_address.SendKeys(randomint2 + " NW " + randomint3 + "th St");
            IWebElement Customer_city = Driver.FindElement(By.Id("City"));
            Customer_address.Click();
            Customer_city.SendKeys("Cape Coral");
            IWebElement Customer_State = Driver.FindElement(By.Id("State"));
            Customer_State.Click();
            Customer_State.SendKeys("Florida");
            IWebElement Customer_zipcode = Driver.FindElement(By.Id("Zip"));
            Customer_zipcode.Click();
            Customer_zipcode.SendKeys("" + randomint4);

            //Eneter Contact Info
            IWebElement Customer_PhoneNumber = Driver.FindElement(By.Name("Customer.Contacts[0].Phone"));

            Customer_PhoneNumber.SendKeys("2394437522");



            IWebElement Customer_email = Driver.FindElement(By.Name("Customer.Contacts[0].Email"));
            Customer_email.SendKeys("customermail" + randomint3 + "@gmail.com");

            IWebElement Customer_ClickSelectTerm = Driver.FindElement(By.Id("select2-flatRateItem-container"));
            Customer_ClickSelectTerm.Click();
            //IWebElement Customer_SelectTerm = driver.FindElement(By.CssSelector("#TermsContainer > div > span > span.selection > span > span.select2-selection__arrow > b"));
            //Customer_SelectTerm.Click();
            IWebElement TypeTerm = Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input"));
            TypeTerm.SendKeys("consig");
            //await Task.Delay(2000);
            TypeTerm.SendKeys(Keys.Enter);




            IWebElement Customer_Create = Driver.FindElement(By.CssSelector("#create"));
            Customer_Create.Click();
            await Task.Delay(2000);
            //var wait1 = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
            //IWebElement element1 = wait1.Until(c => c.FindElement(By.CssSelector("body > div.bootbox.modal.fade.custom-bootbox.normal.in > div > div > div.modal-footer > button.btn.success-btn.custom-btn")));


            IWebElement Customer_Assig = Driver.FindElement(By.CssSelector("body > div.bootbox.modal.fade.custom-bootbox.normal.in > div > div > div.modal-footer > button.btn.success-btn.custom-btn"));
            Customer_Assig.Click();


            //Click Customer list "Export" button. 
            //Click AddCustomer
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#sidebar-wrapper > ul > li.side-bar-icon.selected > a > span:nth-child(2)")));

            Driver.FindElement(By.CssSelector("#sidebar-wrapper > ul > li.side-bar-icon.selected > a > span:nth-child(2)")).Click();
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("button.with-icon:nth-child(2)")));
            Driver.FindElement(By.CssSelector("button.with-icon:nth-child(2)")).Click();

            //Try searching, sorting the columns and filtering. 
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.Id("search")));
            IWebElement SearchCustomer1 = Driver.FindElement(By.Id("search"));
            SearchCustomer1.SendKeys("Aberdeen" + Keys.Enter);

            //wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th.sortable.emailed_printed > span:nth-child(1)")));

           /* Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th.sortable.emailed_printed > span.fa.fa-sort-desc")).Click();
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(2)")).Click();
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(3))")).Click();
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(4)")).Click();
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(5)")).Click();
            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > thead > tr > th:nth-child(6)")).Click();*/
        }

        [TearDown]//notation to execute a method after every test.
        public void AfterTest()
        {


            Driver.Quit();


        }


    }
    
}
