using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;

namespace AutomationFramework.Handler
{
    public class ScreenShotHandler
    {
        private static string DirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string TakeScreenShot(IWebDriver driver)
        {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            string imagePath = DirectoryPath + "//img_" + milliseconds + ".png";
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            image.SaveAsFile(imagePath, ScreenshotImageFormat.Png);

            return imagePath;

        }
    }
}