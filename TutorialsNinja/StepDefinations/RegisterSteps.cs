using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TutorialsNinja.Hooks;
using TutorialsNinja.PageObjects;

namespace TutorialsNinja.StepDefinations
{
    [Binding]
    public class RegisterSteps
    {
        public IWebDriver driver = WebHooks.driver;
        public RegisterAccountPage registerAccountPage = null;
        public AccountSuccessPage accountSuccesspage = null;



       [Given(@"I visit to website")]
        public void GivenIVisitToWebsite()
        {
            driver.Url = "http://tutorialsninja.com/demo/";
        }

        [Given(@"I navigate to register account page")]
        public void GivenINavigateToRegisterAccountPage()
        {
            HomePage homepage = new HomePage();
            homepage.ClickOnMyAccountDropMenu();
            registerAccountPage  = homepage.SelectRegisterOption();
        }

        [When(@"I enter valid details into the fields")]
        public void WhenIEnterValidDetailsIntiAllTheFields(Table table)
        {
            dynamic details = table.CreateDynamicInstance();

            registerAccountPage.EnterFirstName(details.firstname);                                   
            registerAccountPage.EnterLastName(details.lastname);
            registerAccountPage.EnterEmail("kaustubhwan25"+GenerateTimeStamp()+"@gmail.com");
            registerAccountPage.EnterTelephoneNumber(details.telephone);
            registerAccountPage.EnterPassword(details.password);
            registerAccountPage.EnterPasswordConfirm(details.password);


        }

        [When(@"I select yes for subscription")]
        public void WhenISelectYesForSubscription()
        {
            registerAccountPage.SelectYesNewsLetterOption();
        }

        [When(@"I select Privacy Policy")]
        public void WhenISelectPrivacyPolicy()
        {
            registerAccountPage.SelectPrivacyPolicyOption();
        }

        [When(@"I click on Continue button")]
        public void WhenIClickOnContinueButton()
        {
           accountSuccesspage = registerAccountPage.ClickOnContinueButton();
        }

        [Then(@"Account should be created")]
        public void ThenAccountShouldBeCreated()
        {
           
            Thread.Sleep(3000);
        }

        public string GenerateTimeStamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");

        }
        
        [Then(@"Account should not be created")]
        public void ThenAccountShouldNotBeCreated()
        {
            Assert.IsTrue(registerAccountPage.IsAccountNotCreated());
        }

        [Then(@"Proper warning messages shouls be displayed")]
        public void ThenProperWarningMessagesShoulsBeDisplayed()
        {
            Assert.IsTrue(registerAccountPage.AreAllWarningMessagesDisplayed());
        }



    }
}
