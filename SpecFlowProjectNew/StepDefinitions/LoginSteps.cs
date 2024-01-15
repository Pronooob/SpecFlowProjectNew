using SpecFlowProjectNew.Pages;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using SpecFlowProjectNew.Utilities;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProjectNew.StepDefinitions
{
    [Binding]
    public class LoginSteps: AutomationWrapper
    {
        //public IWebDriver driver;

        LoginPages loginPage = new LoginPages(getDriver());


        [Given(@"I have browser with Amazon homepage open")]
        public void GivenIHaveBrowserWithAmazonHomepageOpen()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            IWebElement first_rev = driver.FindElement(By.XPath("//a[@id='nav-logo-sprites']"));
            String aria_label = first_rev.GetAttribute("aria-label");
            if (aria_label != "Amazon.in")
            {
                Console.WriteLine("You are in a different page");
            }
        }

        

        [When(@"I click on Signin button")]
        public void WhenIClickOnSigninButton()
        {
            loginPage.signIn().Click();
        }

        [Then(@"signin page opens up")]
        public void ThenSigninPageOpensUp()
        {
            
            Assert.AreEqual("Sign in", loginPage.signInButton().Text);
            
        }

        [Then(@"I enter username as '(.*)'")]
        public void ThenIEnterUsernameAs(string username)
        {
            loginPage.username().SendKeys(username);
        }

        [Then(@"I click on username continue button")]
        public void ThenIClickOnUsernameContinueButton()
        {
            driver.FindElement(By.Id("continue")).Click();
        }

        [Then(@"I enter password as '(.*)'")]
        public void ThenIEnterPasswordAs(string password)
        {
            driver.FindElement(By.Id("ap_password")).SendKeys(password);
        }

        [Then(@"I click on password continue button")]
        public void ThenIClickOnPasswordContinueButton()
        {
            driver.FindElement(By.Id("signInSubmit")).Click();
        }

        [Then(@"I should get access to the homepage with text as '(.*)'")]
        public void ThenIShouldGetAccessToTheHomepageWithTextAs(string expected)
        {
            Assert.AreEqual(expected, driver.FindElement(By.XPath("//span[@id='nav-link-accountList-nav-line-1']")).Text);
        }

        [Then(@"I should get the username error message as '(.*)'")]
        public void ThenIShouldGetTheUsernameErrorMessageAs(string expected)
        {
            Assert.AreEqual(expected, driver.FindElement(By.XPath("//span[@class='a-list-item']")).Text);
            
        }

        [Then(@"I should get the password error message as '(.*)'")]
        public void ThenIShouldGetThePasswordErrorMessageAs(string expected)
        {
            Assert.AreEqual(expected, driver.FindElement(By.XPath("//span[@class='a-list-item']")).Text);
            
        }
        
    }
}
