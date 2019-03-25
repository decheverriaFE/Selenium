using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using System;

namespace AutomationFramework.Handler
{
    public sealed class ReportHandler
    {
        private static readonly Lazy<ExtentReports> Lazy = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance { get { return Lazy.Value; } }

        static ReportHandler()
        {
            var htmlReporter = new ExtentHtmlReporter(TestContext.CurrentContext.TestDirectory + "\\Report.html");
            htmlReporter.LoadConfig(TestContext.CurrentContext.TestDirectory + "\\extent-config.xml");
            Instance.AttachReporter(htmlReporter);
        }

        private ReportHandler()
        {
        }
    }
}

