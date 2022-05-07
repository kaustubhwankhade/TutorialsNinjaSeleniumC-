using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsNinja.PageObjects
{
    
    public class LoginPage
    {
        public IWebDriver driver;

        public By emailAddressField = By.Id("input-email");
        public By passwordField = By.Id("input-password");
        public By loginButton = By.CssSelector("input[value='Login']");


        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterEmailAddress(string emailText)
        {
            driver.FindElement(emailAddressField).SendKeys(emailText);
        }

        public void EnterPassword(string passwordText)
        {
            driver.FindElement(passwordField).SendKeys(passwordText);
        }

       
        public AccountPage ClickOnLoginButton()
        {
            driver.FindElement(loginButton).Click();
            return new AccountPage(driver);
        }
    }
}
