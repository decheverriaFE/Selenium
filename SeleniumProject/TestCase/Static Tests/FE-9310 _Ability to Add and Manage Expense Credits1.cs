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

namespace SeleniumProject.TestCase
{
    class Ability_to_Add_and_Manage_Expense_Credits
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
        public async Task ExpenseCredit()

        {
            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(5000);


            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            //Go to Global Settings.Ensure "Add Expenses to Invoice by Default" is selected. Ensure a non - inventory item is selected in "Expense Non-Inventory Item" field.




            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();
            await Task.Delay(2000);
            Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(4) > ul > li:nth-child(1) > a > text")).Click();


            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#expense-non-inventory > div > span > span.selection > span > span.select2-selection__arrow > b")));

            Driver.FindElement(By.CssSelector("#expense-non-inventory > div > span > span.selection > span > span.select2-selection__arrow > b")).Click();
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).Click();
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).SendKeys("non inventory");
            await Task.Delay(2000);
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).SendKeys(Keys.Enter);


            IWebElement CheckboxAddExpense = Driver.FindElement(By.Id("SetExpenseAddNonBillable"));
            if (!CheckboxAddExpense.Selected)
            {
                CheckboxAddExpense.Click();
                Driver.FindElement(By.Id("create")).Click();
            }
            else
            {
                Driver.FindElement(By.Id("create")).Click();
            }
 //Create a work order in the web and assign it to a technician. 

            
            //DotNetSeleniumExtras.WaitHelpers NuGet package needs to be added
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(4) > a")));

            

            Driver.FindElement(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(4) > a")).Click();

            WebDriverWait wait4 = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            //DotNetSeleniumExtras.WaitHelpers NuGet package needs to be added
            wait4.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.Id("search")));

            Driver.FindElement(By.Id("search")).SendKeys("Aberdeen" + Keys.Enter);
            await Task.Delay(5000);


            WebDriverWait wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait2.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr > td:nth-child(1) > div")));

            Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr > td:nth-child(1) > div")).Click();
            await Task.Delay(3000);
            Driver.FindElement(By.CssSelector("#details-navigator > div:nth-child(3) > div.clearfix.section-header > div.icon > img")).Click();
            await Task.Delay(3000);

            Driver.FindElement(By.CssSelector("#details-list-container > div:nth-child(2) > button")).Click();

            WebDriverWait wait7 = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            
            wait7.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#task-details > div.group-field-container.clearfix > manage-business-unit-prop > div > div > span > span.selection > span > span.select2-selection__arrow")));

            IWebElement ClickSelectBU = Driver.FindElement(By.CssSelector("#task-details > div.group-field-container.clearfix > manage-business-unit-prop > div > div > span > span.selection > span > span.select2-selection__arrow"));

            ClickSelectBU.Click();


            IWebElement typeBU = Driver.FindElement(By.ClassName("select2-search__field"));

            IList<IWebElement> options = Driver.FindElements(By.ClassName("select2-results__options"));

            if (options.Any())
                options[0].Click();

            await Task.Delay(2000);
            IWebElement ClickSelectTask = Driver.FindElement(By.CssSelector("#taskdivcontainer > span > span.selection > span > span.select2-selection__arrow"));
            ClickSelectTask.Click();
            IWebElement typeTask = Driver.FindElement(By.ClassName("select2-search__field"));
            typeTask.SendKeys("HVAC");
            typeTask.SendKeys(OpenQA.Selenium.Keys.Enter);
            await Task.Delay(2000);

            IWebElement ClickSelectLeadSource = Driver.FindElement(By.CssSelector("#leadSourceDivContainer > span > span.selection > span > span.select2-selection__arrow"));
            ClickSelectLeadSource.Click();
            IWebElement typeLeadSource = Driver.FindElement(By.ClassName("select2-search__field"));
            typeLeadSource.SendKeys("Google");
            typeLeadSource.SendKeys(Keys.Enter);
            await Task.Delay(2000);

            IWebElement ClickSelectPrimaryTech = Driver.FindElement(By.CssSelector("#select2-primary-tech-dropdown-container"));
            ClickSelectPrimaryTech.Click();
            IWebElement typePrimaryTech = Driver.FindElement(By.ClassName("select2-search__field"));
            typePrimaryTech.SendKeys("Field T");
            typePrimaryTech.SendKeys(OpenQA.Selenium.Keys.Enter);
            await Task.Delay(2000);


            IWebElement setStartDate = Driver.FindElement(By.Id("start-date"));
            setStartDate.SendKeys(DateTime.Now.ToString("M/d/yyyy"));
            await Task.Delay(2000);

            IWebElement setStartHHMM = Driver.FindElement(By.Id("startTime"));
            setStartHHMM.SendKeys(DateTime.Now.ToString("hh:mm"));
            await Task.Delay(2000);

            IWebElement ClickCreateWoButton = Driver.FindElement(By.CssSelector("#AddCustomerCallForm > div:nth-child(10) > button:nth-child(3)"));
            ClickCreateWoButton.Click();
            

            await Task.Delay(5000);

            //Add an inventory item to the invoice.

            WebDriverWait wait6 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait6.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#details-navigator > div:nth-child(4) > div.section-header.clearfix > div.icon > img")));

            Driver.FindElement(By.CssSelector("#details-navigator > div:nth-child(4) > div.section-header.clearfix > div.icon > img")).Click();

            WebDriverWait wait3 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#invoiceTable > tbody > tr > td:nth-child(3) > div:nth-child(1) > span > span.selection > span > span.select2-selection__arrow > b")));

            Driver.FindElement(By.CssSelector("#invoiceTable > tbody > tr > td:nth-child(3) > div:nth-child(1) > span > span.selection > span > span.select2-selection__arrow > b")).Click();
            await Task.Delay(2000);
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).SendKeys("Inventory part"); ;
            await Task.Delay(2000);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            IWebElement ListBoxInvoice = Driver.FindElement(By.ClassName("select2-results__options"));
            await Task.Delay(2000);
            IList<IWebElement> options1 = Driver.FindElements(By.ClassName("select2-results__options"));

            if (options1.Any())
                options1[0].Click();

            //Go to the WO's Purchases tab then click "Expenses."
            WebDriverWait wait5 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait5.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#details-navigator > div:nth-child(3) > div.section-header.clearfix > div.icon > img")));

            Driver.FindElement(By.CssSelector("#details-navigator > div:nth-child(3) > div.section-header.clearfix > div.icon > img")).Click();

            //Add Expense Credit

            WebDriverWait wait8 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait8.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#Tab5 > div.purchases-toggle.clearfix > div:nth-child(2) > text"))); 
            Driver.FindElement(By.CssSelector("#Tab5 > div.purchases-toggle.clearfix > div:nth-child(2) > text")).Click();

            await Task.Delay(3000);
            wait8.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#Tab5 > button:nth-child(5)")));

            Driver.FindElement(By.CssSelector("#Tab5 > button:nth-child(5)")).Click();

            /*WebDriverWait wait9 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait9.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#Tab5 > button:nth-child(5)")));


            Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(5)")).SendKeys(Keys.Tab);
            await Task.Delay(3000);
            Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(5)")).SendKeys(Keys.Enter);*/

            Driver.FindElement(By.CssSelector("#expenseCost")).SendKeys("1.00");
            Driver.FindElement(By.CssSelector("#ExpenseContainer > div:nth-child(2) > div:nth-child(2) > span > span.selection > span > span.select2-selection__arrow > b")).Click();
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).SendKeys("%%%");
            await Task.Delay(3000);
            Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input")).SendKeys(Keys.Enter);
            Driver.FindElement(By.CssSelector("#ExpenseContainer > div.setting-form > div > div.field-container.left > textarea")).SendKeys("Description Automation Testing");
              //uploading pics
            string filePath = @"C:\Users\decheverria\Desktop\pics.jpg";
            Driver.FindElement(By.CssSelector("div.receipt-container:nth-child(1) > div:nth-child(2)")).Click();
            await Task.Delay(2000);
            System.Windows.Forms.SendKeys.SendWait(filePath);
            System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
            await Task.Delay(5000);
            Driver.FindElement(By.CssSelector("#ExpenseContainer > div.setting-form > div > div:nth-child(2) > div > button.custom-btn.success-btn")).Click();

            //Complete, then Finalize the WO as "Work Performed
            await Task.Delay(3000);
            Driver.FindElement(By.CssSelector("#label > div.clearfix > div.button-container > button.custom-btn.success-btn.save-btn")).Click();
            WebDriverWait wait10 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait10.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".list-unstyled")));
            Driver.FindElement(By.Id("Complete")).Click();

            await Task.Delay(3000);
            Driver.FindElement(By.CssSelector("div.chosen-container:nth-child(3) > a:nth-child(1) > span:nth-child(1)")).Click();

            WebDriverWait wait12 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait12.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.chosen-container:nth-child(3) > div:nth-child(2) > ul:nth-child(2)")));

            Driver.FindElement(By.CssSelector("#saveModal > div:nth-child(2) > div:nth-child(1) > ul > li:nth-child(14) > div > div > div > ul > li:nth-child(2)")).Click();
            /*SelectElement selectElement = new SelectElement(Driver.FindElement(By.CssSelector("div.chosen-container:nth-child(3) > div:nth-child(2) > ul:nth-child(2)")));
            selectElement.SelectByIndex(1);*/

            Driver.FindElement(By.CssSelector(".modal-button-container > button:nth-child(1)")).Click();

            //QuickBook pending--------------------------

            //From the Invoice tab, click on the "View Details" button.
            await Task.Delay(5000);
            WebDriverWait wait14 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait14.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#details-navigator > div:nth-child(4) > div.section-header.clearfix > div.label-header")));

            Driver.FindElement(By.CssSelector("#details-navigator > div:nth-child(4) > div.section-header.clearfix > div.label-header")).Click();
            WebDriverWait wait15 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait15.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".button-detail")));
                       
            Driver.FindElement(By.CssSelector(".button-detail")).Click();
            //Verify that the Expense credit is displayed


            WebDriverWait wait18 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait18.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("tr.inline-editable-table-row:nth-child(2) > td:nth-child(1) > div:nth-child(1) > text:nth-child(1)")));

            var CostExpense1 = Driver.FindElement(By.CssSelector("#profit-main-section-container > div:nth-child(2) > div.group-field-container > table > tbody > tr:nth-child(1) > td:nth-child(1) > div > text"));


            if (!string.IsNullOrEmpty(CostExpense1.Text) && CostExpense1.Text == "Inventory Part")

            {

                WebDriverWait wait16 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait16.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("button.custom-btn:nth-child(4)")));

                Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(4)")).Click();
                Driver.FindElement(By.CssSelector("#saveModal > div:nth-child(2) > div.clearfix.modal-button-container > button.custom-btn.success-btn.modal-confirm-button")).Click();


            }

            /* var CostExpense = Driver.FindElement(By.CssSelector("tr.inline-editable-table-row:nth-child(2) > td:nth-child(1) > div:nth-child(1) > text:nth-child(1)"));


            if (!string.IsNullOrEmpty(CostExpense.Text) && CostExpense.Text == "Expenses on Invoice")
                
            {
                
                WebDriverWait wait16 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait16.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("button.custom-btn:nth-child(4)")));

                Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(4)")).Click();
                Driver.FindElement(By.CssSelector("#saveModal > div:nth-child(2) > div.clearfix.modal-button-container > button.custom-btn.success-btn.modal-confirm-button")).Click();
                

            }


            //else
            //{
                
                //WebDriverWait wait17 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
               // wait17.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("button.custom-btn:nth-child(3)")));

               // Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(3)")).Click();


            //}*/






        }

        //Close Window
        public void AfterTest()
        {
            
            
                Driver.Quit();

            
        }
    }
}
