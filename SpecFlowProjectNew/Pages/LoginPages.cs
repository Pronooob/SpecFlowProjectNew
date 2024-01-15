using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowProjectNew.Utilities;

namespace SpecFlowProjectNew.Pages
{
    public class LoginPages
    { 
    
        private IWebDriver driver;
        public LoginPages(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "nav-link-accountList-nav-line-1")]
        private IWebElement SignIn;
        public IWebElement signIn()
        {
            return SignIn;
        }

        [FindsBy(How = How.Name, Using = "//h1[normalize-space()='Sign in")]
        private IWebElement SignInButton;
        public IWebElement signInButton()
        {
             return SignInButton;
        }

        [FindsBy(How = How.XPath, Using = "ap_email")]
        private IWebElement Username;

        public IWebElement username()
        {
            return Username;
        }

    }
}
