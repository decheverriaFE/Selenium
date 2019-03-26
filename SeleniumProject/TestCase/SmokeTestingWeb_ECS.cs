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

namespace SeleniumProject.TestCase
{
    class SmokeTestingWeb_ECS
    {
        //Selenium Driver
        protected IWebDriver Driver;

        public object SeleniumExtras { get; private set; }

        [SetUp]  //Nunit - Anotation to execute a method before every test.
        //Start Chrome and goto URL.
        public void BeforeTest()
        {
            Driver = new ChromeDriver();

        }

        [Test]//Nunit - Anotation to mark a method as a Automated TestCase 
        public async Task SmoketestingwithPayment()

        {
            HomePage home = new HomePage(Driver);
            home.gotoPage();


            await Task.Delay(1000);


            //Select Customer Menu ---OK
            IWebElement ClickCustomer = Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(4) > a:nth-child(1) > span:nth-child(2)"));
            ClickCustomer.Click();

            WebDriverWait wait3 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

           /* wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.Id("search")));
            IWebElement SearchCustomer = Driver.FindElement(By.Id("search"));
            SearchCustomer.SendKeys("Subway" + Keys.Enter);




            //Select the First Element
            //loginFE wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(1) > div:nth-child(1)")));

            //loginFE Driver.FindElement(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(1) > div:nth-child(1)")).Click();

            wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(1) > div:nth-child(1)")));

            Driver.FindElement(By.CssSelector(".fixed-body > tr:nth-child(1) > td:nth-child(1) > div:nth-child(1)")).Click();


            //clic on WO tab on Curstomer screen
            wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#details-navigator > div:nth-child(3) > div:nth-child(1) > div:nth-child(1)")));

            Driver.FindElement(By.CssSelector("#details-navigator > div:nth-child(3) > div:nth-child(1) > div:nth-child(1)")).Click();


            // Add a new WO Clic on the button
            wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#details-list-container > div:nth-child(2) > button")));

            Driver.FindElement(By.CssSelector("#details-list-container > div:nth-child(2) > button")).Click();




            //Select BU-Task-LeadSource

            wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#additionalInfo > div:nth-child(2) > span.trim-text.bold")));


            Driver.FindElement(By.CssSelector("#task-details > div.group-field-container.clearfix > manage-business-unit-prop > div > div > span > span.selection > span > span.select2-selection__arrow")).Click();

            IList<IWebElement> options5 = Driver.FindElements(By.ClassName("select2-results__options"));

            await Task.Delay(5000);

            if (options5.Any() && options5.Count() <= 20)

            {

                options5[0].Click();

            }

            else
            {
                IWebElement typeBU = Driver.FindElement(By.ClassName("select2-search__field"));
                typeBU.SendKeys("Fort Myers");
                typeBU.SendKeys(Keys.Enter);

            }






            IWebElement ClickSelectTask = Driver.FindElement(By.CssSelector("#taskdivcontainer > span > span.selection > span > span.select2-selection__arrow"));
            ClickSelectTask.Click();
            IWebElement typeTask = Driver.FindElement(By.ClassName("select2-search__field"));
            typeTask.SendKeys("100");
            typeTask.SendKeys(Keys.Enter);

            IWebElement ClickSelectLeadSource = Driver.FindElement(By.CssSelector("#leadSourceDivContainer > span > span.selection > span > span.select2-selection__arrow"));
            ClickSelectLeadSource.Click();
            IWebElement typeLeadSource = Driver.FindElement(By.ClassName("select2-search__field"));
            typeLeadSource.SendKeys("11-30");
            typeLeadSource.SendKeys(Keys.Enter);

            IWebElement ClickSelectPrimaryTech = Driver.FindElement(By.CssSelector("#select2-primary-tech-dropdown-container"));
            ClickSelectPrimaryTech.Click();
            IWebElement typePrimaryTech = Driver.FindElement(By.ClassName("select2-search__field"));
            typePrimaryTech.SendKeys("tech 7s");
            typePrimaryTech.SendKeys(Keys.Enter);


            IWebElement setStartDate = Driver.FindElement(By.Id("start-date"));
            setStartDate.SendKeys(DateTime.Now.ToString("M/d/yyyy"));

            IWebElement setStartHHMM = Driver.FindElement(By.Id("startTime"));
            setStartHHMM.SendKeys(DateTime.Now.ToString("hh:mm"));

            IWebElement ClickCreateWoButton = Driver.FindElement(By.CssSelector("#AddCustomerCallForm > div:nth-child(10) > button:nth-child(3)"));
            ClickCreateWoButton.Click();

            await Task.Delay(2000);

            //Select TimeLine Tab

            wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#details-navigator > div.selected > div.clearfix.section-header > div.label-header")));
            Driver.FindElement(By.CssSelector("#details-navigator > div.selected > div.clearfix.section-header > div.label-header")).Click();

            await Task.Delay(2000);

            IWebElement CreateNote = Driver.FindElement(By.CssSelector("#newNote"));
            CreateNote.SendKeys("Note from Web / Automation Testing");

            IWebElement AddNoteButton = Driver.FindElement(By.CssSelector("#TimelineSection > div.add-note-button-container > div.note-button-container > button"));
            AddNoteButton.Click();

            //Select Invoicee Tab

            wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#details-navigator > div:nth-child(4) > div.section-header.clearfix > div.label-header")));
            IWebElement SelectInvoiceTab = Driver.FindElement(By.CssSelector("#details-navigator > div:nth-child(4) > div.section-header.clearfix > div.label-header"));
            SelectInvoiceTab.Click();

            wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#invoiceTable > tbody > tr > td:nth-child(3) > div:nth-child(1) > span > span.selection > span > span.select2-selection__arrow > b")));
            IWebElement ClickSelectInvoice = Driver.FindElement(By.CssSelector("#invoiceTable > tbody > tr > td:nth-child(3) > div:nth-child(1) > span > span.selection > span > span.select2-selection__arrow > b"));
            ClickSelectInvoice.Click();

            wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")));
            IWebElement typeinvoice = Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input"));
            typeinvoice.SendKeys("Asm Sub Item");

            await Task.Delay(2000);


            IWebElement ListBoxInvoice = Driver.FindElement(By.ClassName("select2-results__options"));
            await Task.Delay(2000);
            IList<IWebElement> options = Driver.FindElements(By.ClassName("select2-results__options"));

            if (options.Any())
                options[0].Click();

            IWebElement SelectPaymentTab = Driver.FindElement(By.CssSelector("#details-navigator > div:nth-child(6) > div.section-header.clearfix > div.label-header"));
            SelectPaymentTab.Click();

            wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#PaymentTableContent > tr > td:nth-child(1) > div:nth-child(2) > span > span.selection > span > span.select2-selection__arrow > b")));

            IWebElement ClickPayment = Driver.FindElement(By.CssSelector("#PaymentTableContent > tr > td:nth-child(1) > div:nth-child(2) > span > span.selection > span > span.select2-selection__arrow > b"));
            ClickPayment.Click();

            wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")));

            IWebElement typePayment = Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input"));
            typePayment.SendKeys("Discover");
            typePayment.SendKeys(Keys.Enter);

            IWebElement addAmount = Driver.FindElement(By.Id("amount"));
            addAmount.Clear();
            addAmount.SendKeys("1");

            IWebElement clickEnterManually = Driver.FindElement(By.ClassName("enter-manually-label"));
            clickEnterManually.Click();
            await Task.Delay(2000);


            //Payment ECS
           


            /*wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#ekashu_header_collect_data")));
            wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#ekashu_card_number")));
            IWebElement ClickCardNumber = Driver.FindElement(By.CssSelector("#ekashu_card_number"));
            ClickCardNumber.Click();
            ClickCardNumber.SendKeys("41111111111111111");
            ClickCardNumber.SendKeys(Keys.Tab + "11" + Keys.Tab + "2020");/*

           
            /*IWebElement DateExpmonth = Driver.FindElement(By.Id("ekashu_input_expires_end_month"));
            ClickCardNumber.Click();
            Driver.FindElement(By.Id("#ekashu_input_expires_end_month > option:nth-child(12))")).Click();
          

            IWebElement DateExpyear = Driver.FindElement(By.CssSelector("#ekashu_input_expires_end_month > option:nth-child(12)"));
            ClickCardNumber.Click();
            ClickCardNumber.SendKeys("2021");
            */
        }
    }
}
