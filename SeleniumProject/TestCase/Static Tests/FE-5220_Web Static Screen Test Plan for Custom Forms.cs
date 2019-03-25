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
using System.Threading.Tasks;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;

namespace SeleniumProject.TestCase
{
    class FE_5220__Web_Static_Screen_Test_Plan_for_Custom_Forms
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
        public async Task CustomForm_TestPlan()
        {

            HomePage home = new HomePage(Driver);
            home.gotoPage();

            await Task.Delay(3000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));


           
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#setting-link-container > ul > li > a")));
            Driver.FindElement(By.CssSelector("#setting-link-container > ul > li > a")).Click();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#application-menu > div:nth-child(4) > ul > li:nth-child(9) > a > text")));
            Driver.FindElement(By.CssSelector("#application-menu > div:nth-child(4) > ul > li:nth-child(9) > a > text")).Click();
            //Add a new Form
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#label > div > div.button-container > button")));
            Driver.FindElement(By.CssSelector("#label > div > div.button-container > button")).Click();
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(1000000);
            Driver.FindElement(By.CssSelector("#Name")).SendKeys("AutomationForm" + randomInt);
            Driver.FindElement(By.CssSelector("#form > div > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > input")).SendKeys("Automation Description");
            
            //Drag and Drop

            IWebElement From = Driver.FindElement(By.CssSelector("#form > div > div:nth-child(4) > div > div > div > ul.source.draggable.drop-zone > li:nth-child(2)"));
            IWebElement To = Driver.FindElement(By.CssSelector("#dropZoneTarget"));
            Actions act = new Actions(Driver);
            act.DragAndDrop(From, To).Build().Perform();

            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#id0 > div > div.field-area.verticalFlex > input")));
            Driver.FindElement(By.CssSelector("#id0 > div > div.field-area.verticalFlex > input")).SendKeys("FieldName Form");

            await Task.Delay(3000);
            IWebElement From1 = Driver.FindElement(By.CssSelector("#form > div > div:nth-child(4) > div > div > div > ul.source.draggable.drop-zone > li:nth-child(10)"));
            IWebElement To1 = Driver.FindElement(By.CssSelector("#dropZoneTarget"));
            Actions act1 = new Actions(Driver);
            act1.DragAndDrop(From1, To1).Build().Perform();
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#id0 > div > div.field-area.verticalFlex > textarea.form-control.field")));
            Driver.FindElement(By.CssSelector("#id0 > div > div.field-area.verticalFlex > textarea.form-control.field")).SendKeys("FieldMultipleChoise Form");
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div > div:nth-child(5) > div > label")));
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div > div:nth-child(5) > div > div > div:nth-child(1) > div:nth-child(4) > div")));
            Driver.FindElement(By.CssSelector("#form > div > div:nth-child(5) > div > div > div:nth-child(1) > div:nth-child(4) > div")).Click();

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div > div:nth-child(6) > div > div > div.checkbox.checkbox-success.field-checkbox")));
            Driver.FindElement(By.CssSelector("#form > div > div:nth-child(6) > div > div > div.checkbox.checkbox-success.field-checkbox")).Click();

                                          

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#label > div > div.button-container > button.custom-btn.success-btn.save-btn")));
            Driver.FindElement(By.CssSelector("#label > div > div.button-container > button.custom-btn.success-btn.save-btn")).Click();

            await Task.Delay(3000);

            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#search")));
            Driver.FindElement(By.CssSelector("#search")).SendKeys("AutomationForm" + Keys.Enter);
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div > div.main-content.clearfix > table > tbody > tr:nth-child(1) > td:nth-child(1) > div")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div > div.main-content.clearfix > table > tbody > tr:nth-child(1) > td:nth-child(1) > div")).Click();
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > input")));
            Driver.FindElement(By.CssSelector("#form > div > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > input")).SendKeys("Automation Description Edited");
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#form > div > div:nth-child(2) > div:nth-child(1) > div:nth-child(3) > div > div")));
            Driver.FindElement(By.CssSelector("#form > div > div:nth-child(2) > div:nth-child(1) > div:nth-child(3) > div > div")).Click();
                       
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#label > div > div.button-container > button.custom-btn.success-btn.save-btn")));
            Driver.FindElement(By.CssSelector("#label > div > div.button-container > button.custom-btn.success-btn.save-btn")).Click();
            await Task.Delay(3000);
            wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#settings-information-container > div > div.main-content.clearfix > table > thead > tr > th:nth-child(1)")));
            Driver.FindElement(By.CssSelector("#settings-information-container > div > div.main-content.clearfix > table > thead > tr > th:nth-child(1)")).Click();


        }
    }
}
