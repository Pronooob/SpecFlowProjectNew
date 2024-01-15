using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectNew.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectNew.StepDefinitions
{
    [Binding]
    public class AddToCartSteps : AutomationWrapper
    {
        [Then(@"I enter product name in search bar as '(.*)'")]
        public void ThenIEnterProductNameInSearchBarAs(string productname)
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(productname);
        }

        [Then(@"I click on Search symbol")]
        public void ThenIClickOnSearchSymbol()
        {
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
        }


        [Then(@"I select the respective product")]
        public void ThenISelectTheRespectiveProduct()
        {
            driver.FindElement(By.XPath("//div[@class='rush-component s-featured-result-item ']//span[@class='a-size-medium a-color-base a-text-normal'][normalize-space()='Apple iPhone 13 Pro (128GB) - Sierra Blue']")).Click();
        }

        [Then(@"I should redirect to new Tab")]
        public void ThenIShouldRedirectToNewTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
        }

        [Then(@"I should get the product name as '(.*)'")]
        public void ThenIShouldGetTheProductNameAs(string productname)
        {
            Assert.AreEqual(productname, driver.FindElement(By.XPath("//span[@id='productTitle']")).Text);
        }

        [Then(@"I should get the availability of product as '(.*)'")]
        public void ThenIShouldGetTheAvailabilityOfProductAs(string availability)
        {
            Assert.AreEqual(availability, driver.FindElement(By.XPath("//span[@class='a-size-medium a-color-state']")).Text);
        }

        [Then(@"I click on Add to Cart button")]
        public void ThenIClickOnAddToCartButton()
        {
            driver.FindElement(By.Id("add-to-cart-button")).Click();
        }

        [Then(@"I should get Cart Addition Confirmation as '(.*)'")]
        public void ThenIShouldGetCartAdditionConfirmationAs(string confirmation)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Thread.Sleep(3000);
            Assert.AreEqual(confirmation, driver.FindElement(By.XPath("//span[@class='a-size-medium-plus a-color-base sw-atc-text a-text-bold']")).Text);
            Thread.Sleep(3000);
        }
    }
}
