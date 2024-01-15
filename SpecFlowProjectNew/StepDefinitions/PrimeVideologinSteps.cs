using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectNew.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectNew.StepDefinitions
{
    [Binding]
    public class PrimeVideologinSteps: AutomationWrapper
    {
        [Then(@"I enter in the search bar as '(.*)'")]
        public void ThenIEnterInTheSearchBarAs(string productname)
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(productname);
        }
        [Then(@"I click on Search Button")]
        public void ThenIClickOnSearchButton()
        {
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
        }
        [Then(@"I click on Prime Video tab")]
        public void ThenIClickOnPrimeVideoTab()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//img[@alt='Prime Video']")).Click();
        }
        [Then(@"I click on Join Prime to Watch tab")]
        public void ThenIClickOnJoinPrimeToWatchTab()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//img[@alt='JoinPrime']")).Click();
        }
        [Then(@"I click on Search Icon")]
        public void ThenIClickOnSearchIcon()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@id='pv-search-nav']")).Click();
        }
        [Then(@"I enter movie name as '(.*)'")]
        public void ThenIEnterMovieNameAs(string moviename)
        {
            driver.FindElement(By.XPath("//input[@id='pv-search-nav']")).SendKeys(moviename);
        }
        [Then(@"I click on SearchButton")]
        public void ThenIClickOnSearch_Button()
        {
            driver.FindElement(By.XPath("//input[@id='pv-search-nav']")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
        }
        [Then(@"I should get confirmation as '(.*)'")]
        public void ThenIShouldGetConfirmationAs(string confirmation)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //Thread.Sleep(3000);
            Assert.AreEqual(confirmation, driver.FindElement(By.XPath("//p[@class='_36qUej']")).Text);
            Thread.Sleep(3000);
           
        }
    }
}
