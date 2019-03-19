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
    class SmokeTestingWeb_Clearent
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

            await Task.Delay(8000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme1 = Driver.FindElement(By.CssSelector("#wm-shoutout-144685 > div.wm-close-button.walkme-x-button"));
            CloseWalkme1.Click();
            await Task.Delay(5000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#wm-shoutout-146340 > div.wm-close-button.walkme-x-button")));
            IWebElement CloseWalkme2 = Driver.FindElement(By.CssSelector("#wm-shoutout-146340 > div.wm-close-button.walkme-x-button"));
            CloseWalkme2.Click();



            //Select Customer Menu ---OK
            IWebElement ClickCustomer = Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(4) > a:nth-child(1) > span:nth-child(2)"));
            ClickCustomer.Click();

            WebDriverWait wait3 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.Id("search")));
            IWebElement SearchCustomer = Driver.FindElement(By.Id("search"));
            SearchCustomer.SendKeys("Aberdeen" + Keys.Enter);




            //Select the First Element
           
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
                      
            await Task.Delay(2000);

            if (options5.Any() && options5.Count() <= 20)

            {

                options5[0].Click();

            }

            else
            {
                IWebElement typeBU = Driver.FindElement(By.ClassName("select2-search__field"));
                typeBU.SendKeys("Global");
                typeBU.SendKeys(Keys.Enter);

            }


            


                   
                    IWebElement ClickSelectTask = Driver.FindElement(By.CssSelector("#taskdivcontainer > span > span.selection > span > span.select2-selection__arrow"));
                    ClickSelectTask.Click();
                    IWebElement typeTask = Driver.FindElement(By.ClassName("select2-search__field"));
                    typeTask.SendKeys("HVAC");
                    typeTask.SendKeys(Keys.Enter);

                    IWebElement ClickSelectLeadSource = Driver.FindElement(By.CssSelector("#leadSourceDivContainer > span > span.selection > span > span.select2-selection__arrow"));
                    ClickSelectLeadSource.Click();
                    IWebElement typeLeadSource = Driver.FindElement(By.ClassName("select2-search__field"));
                    typeLeadSource.SendKeys("Google");
                    typeLeadSource.SendKeys(Keys.Enter);

                    IWebElement ClickSelectPrimaryTech = Driver.FindElement(By.CssSelector("#select2-primary-tech-dropdown-container"));
                    ClickSelectPrimaryTech.Click();
                    IWebElement typePrimaryTech = Driver.FindElement(By.ClassName("select2-search__field"));
                    typePrimaryTech.SendKeys("Field T");
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
                    typeinvoice.SendKeys("non inventory");

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

            //-------------------------------------------------------------------------------------//
            //Go to Setting and verify Clearent Payment.






            //Clearent Payment
            
                    
            wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.header-information > div.payment-info")));


         


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


                    await Task.Delay(3000);


            //Go to FE WebAppp
            wait3.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#label > div.clearfix > div.button-container > button.custom-btn.success-btn.save-btn")));

            IWebElement ClickOnSaveButtonWO = Driver.FindElement(By.CssSelector("#label > div.clearfix > div.button-container > button.custom-btn.success-btn.save-btn"));
                    ClickOnSaveButtonWO.Click();

                    await Task.Delay(5000);
                           

                    IWebElement ClickOnConfirrmButtonWO = Driver.FindElement(By.CssSelector("#saveModal > div:nth-child(2) > div.clearfix.modal-button-container > button.custom-btn.success-btn.modal-confirm-button"));
                    ClickOnConfirrmButtonWO.Click();

                    /*await Task.Delay(2000);
                          var wait12 = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
                         IWebElement element12 = wait12.Until(c => c.FindElement(By.CssSelector("#dispatch-general-details > div:nth-child(1) > div:nth-child(1) > div > div.setting-form > div > div > div:nth-child(1) > div:nth-child(2) > div:nth-child(5) > text")));

                    IWebElement ShowmoreLink = Driver.FindElement(By.CssSelector("#dispatch-general-details > div:nth-child(1) > div:nth-child(1) > div > div.setting-form > div > div > div:nth-child(1) > div:nth-child(2) > div:nth-child(5) > text"));
                    ShowmoreLink.Click();


                    await Task.Delay(2000);
                              IWebElement PrintButtonWO = Driver.FindElement(By.CssSelector("custom-btn cancel-btn print-button x-small"));
                               PrintButtonWO.Click();*/






            /*await Task.Delay(5000);
                 var wait13 = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
                 IWebElement element13 = wait13.Until(c => c.FindElement(By.CssSelector("#contactArea > div > div.clearfix.print-btn-containers > button.custom-btn.success-btn")));

            IWebElement SendEmailButtonWO = Driver.FindElement(By.CssSelector("#contactArea > div > div.clearfix.print-btn-containers > button.custom-btn.success-btn"));
            SendEmailButtonWO.Click();*/

            /*Schedule Now option
            IWebElement ClickScheduleNow = Driver.FindElement(By.CssSelector(".confirm-btn"));
            ClickScheduleNow.Click();

            IWebElement WONumber = Driver.FindElement(By.CssSelector("#kogrid > div > div.kgViewport > div > div > div:nth-child(1) > div > div.kgCell.col1.draggable_row > div > a"));
            WONumber.Click();

            IWebElement LinkGotoDetails = Driver.FindElement(By.ClassName("navigate-lnk"));
            LinkGotoDetails.Click();*/







        }


     
        

        private void WaitForElementVisible(By by1, object by2, int v, object timeOutInSeconds)
        {
            throw new NotImplementedException();
        }


        [TearDown]//notation to execute a method after every test.
        public void AfterTest()
        {


            Driver.Quit();


        }
    }

        
        
    }

