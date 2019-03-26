using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;

namespace SeleniumProject.handler
{
    class WaitHandler
    {
        

        public static bool ElementIsPresent(IWebDriver driver, By Locator)
        {
            try
            {
                //DotNetSeleniumExtras.WaitHelpers NuGet package needs to be added
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(Locator));

                                
                
                return true;
                ;
            }
            catch
            { }
            return false;



        }


    }
}
