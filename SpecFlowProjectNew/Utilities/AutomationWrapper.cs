
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework.Interfaces;

namespace SpecFlowProjectNew.Utilities
{
    [Binding]
    public class AutomationWrapper
    {

        public ExtentReports extent;
        public ExtentTest test;
        String browserName;

        //public AutomationWrapper driver;
        public static IWebDriver driver;
        //public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [OneTimeSetUp]
        public void Setup() 
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Pranab");
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [SetUp]
        public void StartBrowser()

        {

           
            
            //Configuration
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {
                   browserName = ConfigurationManager.AppSettings["browser"];
            }
            InitBrowser(browserName);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("https://www.amazon.in/");


        }
        public IWebDriver getDriver()

        {
            return driver;
        }


        public void InitBrowser(string browserName)

        {

            switch (browserName)
            {

                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;



                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;


                case "Edge":

                    driver = new EdgeDriver();
                    break;

            }
        }

        [TearDown]
        public void AfterTest()

        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;



            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {

                test.Fail("Test failed", captureScreenShot(driver, fileName));
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);

            }
            else if (status == TestStatus.Passed)
            {

            }

            
            //driver.Quit();
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenShotName)

        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShotName, screenshot).Build();
            
        }


        [AfterScenario]
        public void EndBrowser()
        {
            extent.Flush();
            driver.Quit();
        }


    }
}
