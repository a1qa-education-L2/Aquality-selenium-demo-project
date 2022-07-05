using Aquality.Selenium.Browsers;
using NUnit.Framework;
using Test.Web.Base;
using Test.Web.Constants;
using Test.Web.Enums;
using Test.Web.Models;
using Test.Web.Steps;
using Test.Web.Utilities;

namespace Test.Web.Tests
{
    public class CookiesDemoTest : BaseTest
    {
        private readonly HeaderFormSteps headerFormSteps = new HeaderFormSteps();
        private readonly CookiesFormSteps cookiesSteps = new CookiesFormSteps();
        private readonly TestData testData = FileReader.ReadJsonData<TestData>(ProjectConstants.PathToTestData);

        [SetUp]
        public void Setup()
        {
            GoToPage(testData.Url);
            SetScreenExpansionMaximize();
        }

        [TearDown]
        public void AfterEach()
        {
            AqualityServices.Browser.Quit();
        }

        [Test(Description = "TC-0001 Check the cookie form")]
        public void TC0001_CheckTheCookieForm()
        {
            cookiesSteps.CookiesFormIsPresent();
            cookiesSteps.AcceptCookiesButtonIsDisplayed();
            cookiesSteps.AcceptCookies();
            cookiesSteps.AcceptCookiesButtonIsNotDisplayed();
            cookiesSteps.CookiesFormIsNotDisplayed();
        }
    }
}