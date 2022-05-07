using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TutorialsNinja.Hooks;
using TutorialsNinja.PageObjects;

namespace TutorialsNinja.StepDefinations
{
    [Binding]
    public class LoginSteps
    {
        public IWebDriver driver = WebHooks.driver;
        public LoginPage loginPage = null;
        public AccountPage accountPage = null;





        [Given(@"I visit to website as a non-registred user")]
        public void GivenIVisitToWebsiteAsANon_RegistredUser()
        {
            driver.Url = "http://tutorialsninja.com/demo";
        }

        [Given(@"I navigate to Login Page")]
        public void GivenINavigateToLoginPage()
        {
            HomePage homePage = new HomePage();
            homePage.ClickOnMyAccountDropMenu();
            loginPage = homePage.SelectLoginOption();
        }

        [When(@"I enter (.*) username and (.*) password")]
        public void WhenIEnterUsernameAndPassword(string username, dynamic password)
        {
            loginPage.EnterEmailAddress(username);
            loginPage.EnterPassword(password.ToString());

        }

        [When(@"I click on Login button")]
        public void WhenIClickOnLoginButton()
        {
            accountPage = loginPage.ClickOnLoginButton();
        }

        [Then(@"I should get logged in")]
        public void ThenIShouldGetLoggedIn()
        {
            Assert.IsTrue(accountPage.IsUserLoggedIn());
            
        }


    }
}
