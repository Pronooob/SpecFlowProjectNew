using SpecFlowProjectNew.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;


namespace SpecFlowProjectNew.StepDefinitions
{
    [Binding]
    public class AddAddressSteps : AutomationWrapper
    {
        [Then(@"I click on Your Addresses")]
        public void ThenIClickOnYourAddresses()
        {
            driver.FindElement(By.XPath("//h2[normalize-space()='Your Addresses']")).Click();
        }

        [Then(@"I click on Plus symbol to add new address")]
        public void ThenIClickOnPlusSymbolToAddNewAddress()
        {
            driver.FindElement(By.Id("ya-myab-plus-address-icon")).Click();
        }

        [Then(@"I fill address details")]
        public void ThenIFillAddressDetails(Table table)
        {

            driver.FindElement(By.Id("address-ui-widgets-enterAddressFullName")).SendKeys(table.Rows[0]["fullname"]);

            driver.FindElement(By.Name("address-ui-widgets-enterAddressPhoneNumber")).SendKeys(table.Rows[0]["mobno"]);

            driver.FindElement(By.Id("address-ui-widgets-enterAddressPostalCode")).SendKeys(table.Rows[0]["pin"]);

            driver.FindElement(By.Id("address-ui-widgets-enterAddressLine1")).SendKeys(table.Rows[0]["flat"]);

            driver.FindElement(By.Id("address-ui-widgets-enterAddressLine2")).SendKeys(table.Rows[0]["area"]);

            driver.FindElement(By.Id("address-ui-widgets-landmark")).SendKeys(table.Rows[0]["landmark"]);

            driver.FindElement(By.XPath("//span[@id='address-ui-widgets-addr-details-address-type-and-business-hours']//span[@role='button']")).Click();

            driver.FindElement(By.XPath("//a[@id='dropdown1_1']")).Click();



        }

        [Then(@"I click on add address")]
        public void ThenIClickOnAddAddress()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 600)");
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//input[@aria-labelledby='address-ui-widgets-form-submit-button-announce']")).Click();
        }

        [Then(@"I should get the new Address with name '(.*)'")]
        public void ThenIShouldGetTheNewAddressWithName(string addressname)
        {
            Assert.AreEqual(addressname, driver.FindElement(By.XPath("//div[@id='ya-myab-display-address-block-2']//span[@id='address-ui-widgets-FullName']")).Text);
        }
    }
}
