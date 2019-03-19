using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageObject
{
    class FE_Login
    {

        IWebDriver Driver;


        public FE_Login() //Class methods
        {
            StartBrowser();

        } 

        public FE_Login(IWebDriver driver) //Create Driver
        {
            Driver = driver;
        }

        public void StartBrowser() //Go to FieldEdge Login, and sign in
        {
            Driver = new ChromeDriver();
            Driver.Url = "http://fieldedgesiteea-staging.azurewebsites.net";


            Driver.FindElement(By.CssSelector("#LoginEmail")).SendKeys("auto01@fieldedge.com");
            Driver.FindElement(By.CssSelector("#Password")).SendKeys("qa2019");
            Driver.FindElement(By.CssSelector("#login-form > div:nth-child(8) > input")).Click();


        } 


    }
}
