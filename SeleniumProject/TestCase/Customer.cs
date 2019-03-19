using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.TestCase
{
    class Customer
    {
        //Selenium Driver
        protected IWebDriver Driver;
        

        public object SeleniumExtras { get; private set; }

        [SetUp]  //Nunit - Anotation to execute a method before every test.
        //Start Chrome and goto URL.
        public void BeforeTest15()
        {
          
            Driver = new ChromeDriver();
            
        }

        [Test]//Nunit - Anotation to mark a method as a Automated TestCase 
        public async Task CreateCustomer()

          {
            HomePage home = new HomePage(Driver);
            home.gotoPage();
    
         
            await Task.Delay(2000);

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
                typeBU.SendKeys("Fort Myers");
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
            await Task.Delay(3000);
            //Close Popups WalkMe and wait 30s
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //DotNetSeleniumExtras.WaitHelpers NuGet package needs to be added
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme1 = Driver.FindElement(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button"));
            CloseWalkme1.Click();
            await Task.Delay(2000);
            //Close Popups WalkMe and wait 30s
           
            //DotNetSeleniumExtras.WaitHelpers NuGet package needs to be added
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme2 = Driver.FindElement(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button"));
            CloseWalkme2.Click();
            await Task.Delay(2000);
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


            
            

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#create")));
            IWebElement Customer_Create = Driver.FindElement(By.CssSelector("#create"));
            Customer_Create.Click();

            

            await Task.Delay(2000);
            //var wait1 = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
            //IWebElement element1 = wait1.Until(c => c.FindElement(By.CssSelector("body > div.bootbox.modal.fade.custom-bootbox.normal.in > div > div > div.modal-footer > button.btn.success-btn.custom-btn")));


            IWebElement Customer_Assig = Driver.FindElement(By.CssSelector("body > div.bootbox.modal.fade.custom-bootbox.normal.in > div > div > div.modal-footer > button.btn.success-btn.custom-btn"));
            Customer_Assig.Click();

            

        }

        [TearDown]//notation to execute a method after every test.
        //Close Window
        
        public void AfterTest()
        {


            Driver.Quit();


        }
    }
    
}
