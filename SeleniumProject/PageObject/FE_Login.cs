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
        public FE_Login() //Class methods
        {


        } 

        public void StartBrowser() //Go to FieldEdge Login, and sign in
        {
           IWebDriver Driver = new ChromeDriver();
            Driver.Url = "http://fieldedgesiteea-staging.azurewebsites.net";
            Driver.Manage().Window.Maximize();

            Driver.FindElement(By.CssSelector("#LoginEmail")).SendKeys("auto01@fieldedge.com");
            Driver.FindElement(By.CssSelector("#Password")).SendKeys("qa2019");
            Driver.FindElement(By.CssSelector("#login-form > div:nth-child(8) > input")).Click();


        } 


    }
}
