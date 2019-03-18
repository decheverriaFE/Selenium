using OpenQA.Selenium;
using SeleniumProject.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageObject
{
    class FE_Dashboard
    {

        protected IWebDriver Driver;

        //locator 

        protected By WaitDashBoard = By.CssSelector(".top-header > div:nth-child(1) > div:nth-child(1)");
  

        public FE_Dashboard(IWebDriver driver)
        {
            Driver = driver;
             if (!Driver.Title.Equals("FieldEdge"))
                    throw new Exception("This is not the login page");
        }


        public bool DashBoardIsPresent()
        {
            return WaitHandler.ElementIsPresent(Driver, WaitDashBoard);
        }




    }
}
