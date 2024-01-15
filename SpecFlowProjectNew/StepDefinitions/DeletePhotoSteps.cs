using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectNew.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectNew.StepDefinitions
{
    [Binding]
    public class DeletePhotoSteps: AutomationWrapper
    {
        [Then(@"I click on Account and Lists button")]
        public void ThenIClickOnAccountAndListsButton()
        {
            driver.FindElement(By.XPath("//span[@id='nav-link-accountList-nav-line-1']")).Click();
        }

        [Then(@"I click on Profile tab")]
        public void ThenIClickOnProfileTab()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 1500)");
            driver.FindElement(By.XPath("//a[normalize-space()='Profile']")).Click();
        }


        [Then(@"I should get a page with '(.*)'")]
        public void ThenIShouldGetAPageWith(string message)
        {
            Thread.Sleep(3000);
            Assert.AreEqual(message, driver.FindElement(By.XPath("//span[@class='alert-message']")).Text);
        }

        [Then(@"I click on Profile Photo")]
        public void ThenIClickOnProfilePhoto()
        {
            driver.FindElement(By.Id("avatar-image")).Click();
        }

        [Then(@"I Delete the profile photo")]
        public void ThenIDeleteTheProfilePhoto()
        {

            driver.FindElement(By.XPath("//span[@class='a-size-small a-color-base desktop delete-photo']")).Click();
            driver.FindElement(By.XPath("//div[@id='a-popover-content-2']//span[@class='a-button a-button-primary desktop delete-button-delete-modal']//input[@type='submit']")).Click();
            Thread.Sleep(3000);
        }
    }
}
