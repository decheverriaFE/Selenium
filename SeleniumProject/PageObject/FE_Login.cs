using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageObject
{

    /*
     * Class to represent FE Login page
     */
    class FE_Login
    {
        //Selenium Webdriver
        protected IWebDriver Driver;

        //Locator 

        protected By UserInput = By.Id("LoginEmail");
        protected By Passinput = By.Id("Password");
        protected By LoginButton = By.CssSelector("#login-form > div:nth-child(8) > input");

        //Expection if the title does not FE_Login Page.
        public FE_Login(IWebDriver driver)
        {
            Driver = driver;

            if (!Driver.Title.Equals("FieldEdge"))
                throw new Exception("This is not the login page");

         }

        //Type user
        public void TypeUserName(string user)
        {
            Driver.FindElement(UserInput).SendKeys("de@qalive.com");
        }

        //Type pass
        public void TypePassUser(string password)
        {
            Driver.FindElement(Passinput).SendKeys("qa");
        }
        //Click Login Buttom
        public void ClickLoginr()
        {
            Driver.FindElement(LoginButton).Click();
        }

        public FE_Dashboard LoginAs(String user, string password)
        {
            TypeUserName(user);
            TypePassUser(password);
            ClickLoginr();
            return new FE_Dashboard(Driver);

        }


    }
}
