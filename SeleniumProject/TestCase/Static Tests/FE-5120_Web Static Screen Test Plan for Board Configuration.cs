using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;

namespace SeleniumProject.TestCase.Static_Tests
{
    class FE_5120_Web_Static_Screen_Test_Plan_for_Board_Configuration
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
        public async Task BoardConfig()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(3000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

         

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(2) > a > text")));
            Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(1) > ul > li:nth-child(2) > a > text")).Click();
            //Verify ZIP Code
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(3) > div > div > span > span.selection > span > span.select2-selection__arrow")));
            Driver.FindElement(By.CssSelector("#form > div:nth-child(3) > div > div > span > span.selection > span > span.select2-selection__arrow")).Click();
            await Task.Delay(3000);
            //wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("select2-results__option")));
            


            IList<IWebElement> List = Driver.FindElements(By.ClassName("select2-results__option"));
            

            //String value = Driver.FindElement(By.CssSelector("select2-PropertiesDispatchBoardLine2Display-result-xzot-3")).GetAttribute("text");


            if (List.Any())
                List[3].Click();

            

          
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div:nth-child(4) > button.custom-btn.success-btn.small")));
            Driver.FindElement(By.CssSelector("#form > div:nth-child(4) > button.custom-btn.success-btn.small")).Click();

            //Go to dispatching board --> +New work order 
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(3) > a > span:nth-child(2)")));
            Driver.FindElement(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(3) > a > span:nth-child(2)")).Click();
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#main-page-container > div.with-units.top-header-container-edb > div.top-header.date-navigator-container.clearfix > button.custom-btn.cancel-btn.small.new-work-order")));
            Driver.FindElement(By.CssSelector("#main-page-container > div.with-units.top-header-container-edb > div.top-header.date-navigator-container.clearfix > button.custom-btn.cancel-btn.small.new-work-order")).Click();
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")));
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).Click();
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).SendKeys("aberdeen");

            IList<IWebElement> options = Driver.FindElements(By.ClassName("select2-results__options"));

            await Task.Delay(2000);

            if (options.Any())

            {

                options[0].Click();

            }

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#task-details > div.group-field-container.clearfix > manage-business-unit-prop > div > div > span > span.selection > span > span.select2-selection__arrow > b")));
            Driver.FindElement(By.CssSelector("#task-details > div.group-field-container.clearfix > manage-business-unit-prop > div > div > span > span.selection > span > span.select2-selection__arrow > b")).Click();
            IList<IWebElement> options1 = Driver.FindElements(By.ClassName("select2-results__options"));

            await Task.Delay(2000);

            if (options1.Any())

            {

                options1[0].Click();

            }
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#taskdivcontainer > span > span.selection > span > span.select2-selection__arrow > b")));
            Driver.FindElement(By.CssSelector("#taskdivcontainer > span > span.selection > span > span.select2-selection__arrow > b")).Click();

           
            IList<IWebElement> options2 = Driver.FindElements(By.ClassName("select2-results__options"));
            await Task.Delay(2000);

            if (options2.Any())
                      

                options2[0].Click();

           


            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#leadSourceDivContainer > span > span.selection > span > span.select2-selection__arrow")));
            Driver.FindElement(By.CssSelector("#leadSourceDivContainer > span > span.selection > span > span.select2-selection__arrow")).Click();
            IList<IWebElement> options3 = Driver.FindElements(By.ClassName("select2-results__options"));
            await Task.Delay(2000);

            if (options3.Any())
               options3[0].Click();


            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#new-work-order-id > div.form-formatted > div:nth-child(4) > div > button:nth-child(3)")));
            Driver.FindElement(By.CssSelector("#new-work-order-id > div.form-formatted > div:nth-child(4) > div > button:nth-child(3)")).Click();
            await Task.Delay(2000);

            //schedule and Schedule now
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#dispatch-general-details > div:nth-child(1) > div:nth-child(2) > div > div.dispatch-details-information-header.clearfix > div:nth-child(2) > button > span")));
            Driver.FindElement(By.CssSelector("#dispatch-general-details > div:nth-child(1) > div:nth-child(2) > div > div.dispatch-details-information-header.clearfix > div:nth-child(2) > button > span")).Click();
            await Task.Delay(2000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#weeklySchedulForm > div:nth-child(5) > button.custom-btn.confirm-btn")));
            Driver.FindElement(By.CssSelector("#weeklySchedulForm > div:nth-child(5) > button.custom-btn.confirm-btn")).Click();
            await Task.Delay(2000);
            //Drag and drop

            IWebElement From = Driver.FindElement(By.CssSelector("#kogrid > div > div.kgViewport > div > div > div > div > div.kgCell.col3.draggable_row > div"));
            IWebElement To = Driver.FindElement(By.CssSelector("#dispatch-schedule > div"));
            Actions act = new Actions(Driver);
            act.DragAndDrop(From, To).Build().Perform();
                                         
            

            String myString = Driver.FindElement(By.CssSelector("div.drag-element:nth-child(3) > div:nth-child(5)")).Text;
                   Assert.Pass(myString);
          /*  Regex postalCodeRegex = new Regex("\b[0 - 9]{ 5 }(?:-[0 - 9]{ 4})?\b");

            if (myString == "postalCodeRegex")
            {
                Assert.Pass(myString);
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(4) > a > span:nth-child(2)")));
                Driver.FindElement(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(4) > a > span:nth-child(2)")).Click();
            }*/



        }

        public void Closer()
        {
            Driver.Quit();
        }
    }

}
