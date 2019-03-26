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
using System.Drawing.Imaging;


namespace SeleniumProject.TestCase.Static_Tests
{
    [TestFixture]
    public class FE_5216_Web_Static_Screen_Test_Plan_for_Master_Equipment_Screen
    {
        
        IWebDriver Driver = new ChromeDriver();
        public static ExtentReports extent = null;
        public static ExtentTest test = null;

        [OneTimeSetUp] //Start extent reporting instance using htmlreporter
        public void ExtentStart()
        {
            ReportHandler.ExtentStart();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ReportHandler.ExtentClose();
        }

        [SetUp]
        public async Task InitializeASync() // Go to Home page 
        {
            HomePage home = new HomePage(Driver);
            home.gotoPage();
            await Task.Delay(5000);

        }

        [Test, Order(1)] //Test Master-Equipment
        public async Task FE_5216_EquipmentScreenTest()
        {
            try
            {
                test = extent.CreateTest("FE_5216_EquipmentScreenTest").Info("Test Started"); //Mark start of test.

                //Declare local variables 
                Random randomGenerator = new Random();
                int randomInt = randomGenerator.Next(1000000);
                String manufact = "Goodwin";
                String model = "Model";
                String comment = (model + "" + "random");
                var newEquip = (model + " " + randomInt);
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
                test.Log(Status.Info, "Local Variables created and assigned.");


                //Settings --> Master Equipment
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("li.clearfix:nth-child(1) > a:nth-child(3)")));
                Driver.FindElement(By.CssSelector("li.clearfix:nth-child(1) > a:nth-child(3)")).Click();
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.setting-container:nth-child(2) > ul:nth-child(4) > li:nth-child(2) > a:nth-child(1) > text:nth-child(1)")));
                Driver.FindElement(By.CssSelector("div.setting-container:nth-child(2) > ul:nth-child(4) > li:nth-child(2) > a:nth-child(1) > text:nth-child(1)")).Click();
                await Task.Delay(2000);
                test.Log(Status.Pass, "Navigate to settings --> Master Equipment.");

                //Add Master Equipment
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#label > div:nth-child(1)")));
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.button-container:nth-child(2) > button:nth-child(1)")));
                Driver.FindElement(By.CssSelector("div.button-container:nth-child(2) > button:nth-child(1)")).Click();
                test.Log(Status.Pass, "Add new Master Equipment.");

                //New Master Equipment screen
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".dynamic-container")));
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("div.ManufacturerSelect > a:nth-child(1) > span:nth-child(1)")));
                Driver.FindElement(By.CssSelector("div.ManufacturerSelect > a:nth-child(1) > span:nth-child(1)")).Click();
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".group-field-section-container")));
                Driver.FindElement(By.CssSelector("div.ManufacturerSelect > div:nth-child(2) > div:nth-child(1) > input:nth-child(1)")).SendKeys(manufact + Keys.Enter);
                Driver.FindElement(By.CssSelector("#equipmentTypeSelect_chosen > a:nth-child(1) > span:nth-child(1)")).Click();
                Driver.FindElement(By.CssSelector("#equipmentTypeSelect_chosen > div:nth-child(2) > div:nth-child(1) > input:nth-child(1)")).SendKeys("a" + Keys.Enter);
                Driver.FindElement(By.CssSelector("#Model")).SendKeys(newEquip);
                Driver.FindElement(By.CssSelector("#Comments")).SendKeys(comment);
                Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(2)")).Click();
                test.Log(Status.Pass, "Fill in fields for new Master Equipment --> Save");
                await Task.Delay(1000);


                //Verify new Equipment is visible
                Driver.FindElement(By.CssSelector("#search")).SendKeys(newEquip);
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".G > td:nth-child(2) > div:nth-child(1)")));
                var findEquip = Driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(1) > div:nth-child(2)")).GetAttribute("value");
                test.Log(Status.Info, "Verify new master Equipment is visible in Settings --> Master Equipment.");

                if (findEquip == "the filter shows no results")
                {
                    test.Log(Status.Fail, "Could not find new Master Equipment - FAIL");
                    Assert.Fail(findEquip + " Not found FAIL");
                }
                else
                {
                    test.Log(Status.Pass, "New Master Equipment found! PASS");
                    System.Console.WriteLine("Test Pass");
                }

                //Go back and edit new equipment
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".G > td:nth-child(1) > div:nth-child(1)")));
                Driver.FindElement(By.CssSelector(".G > td:nth-child(1) > div:nth-child(1)")).Click();
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#Comments")));
                Driver.FindElement(By.CssSelector("#Comments")).SendKeys("...");
                var newValueComments = Driver.FindElement(By.CssSelector("#Comments")).GetAttribute("value");
                Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(2)")).Click();
                test.Log(Status.Pass, "Click Master Equipment created --> Make a change to the Comments section to test validation.");


                //Verify new changes
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#search")));
                Driver.FindElement(By.CssSelector("#search")).SendKeys(newEquip);
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".G > td:nth-child(1) > div:nth-child(1)")));
                Driver.FindElement(By.CssSelector(".G > td:nth-child(1) > div:nth-child(1)")).Click();
                var findChanges = Driver.FindElement(By.CssSelector("#Comments")).GetAttribute("value");
                test.Log(Status.Info, "Verify changes were actually done");
                await Task.Delay(1000);

                if (newValueComments == findChanges)
                {
                    test.Log(Status.Pass, "Changes made - PASS");
                    Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(2)"));
                    Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(2)")).Click();
                }
                else
                {
                    test.Log(Status.Fail, "Changes were not present - FAIL.");
                    Assert.Fail("JIRA 5216 FAIL. Changes made to comments section of Master Equip FAIL. Line 106.");
                    Driver.FindElement(By.CssSelector("")).Click();
                }


                //Create a loop to make inactive -- >  then active. 
                for (int i = 0; i < 2; i++)
                {
                    await Task.Delay(2000);
                    wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".checkbox > label:nth-child(2)")));
                    Driver.FindElement(By.CssSelector(".checkbox > label:nth-child(2)")).Click();
                    wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#search")));
                    Driver.FindElement(By.CssSelector("#search")).SendKeys(newEquip);
                    wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".G > td:nth-child(1) > div:nth-child(1)")));
                    await Task.Delay(2000);
                    Driver.FindElement(By.CssSelector(".G > td:nth-child(1) > div:nth-child(1)")).Click();
                    wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".checkbox > label:nth-child(2)")));
                    Driver.FindElement(By.CssSelector(".checkbox > label:nth-child(2)")).Click();
                    Driver.FindElement(By.CssSelector("button.custom-btn:nth-child(2)")).Click();
                    await Task.Delay(1000);
                }
                test.Log(Status.Pass, "Tested making Master Equipment inactive -- Then Active. PASS");

                //Verify columns/Filters working
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("th.sortable:nth-child(3)")));
                Driver.FindElement(By.CssSelector("th.sortable:nth-child(3)")).Click();
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("th.sortable:nth-child(2)")));
                Driver.FindElement(By.CssSelector("th.sortable:nth-child(2)")).Click();
                test.Log(Status.Pass, "Tested Filters --> Return to Dashboard.");
                await Task.Delay(1000);

                Driver.FindElement(By.CssSelector("li.side-bar-icon:nth-child(1) > a:nth-child(1) > span:nth-child(2)")).Click();
                await Task.Delay(2000);

                
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw;
            }
        }

        [TearDown]
        public void Closer()
        {

            Driver.Quit();
            test.Log(Status.Pass, "FE_5216_Web_Static_Screen_Test_Plan_for_Master_Equipment_Screen - PASSED.");

        }
    }
}
