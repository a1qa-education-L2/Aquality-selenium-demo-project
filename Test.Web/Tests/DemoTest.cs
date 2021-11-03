using NUnit.Framework;
using TASMU.Autotests.Web.Utils;
using Test.Web.Base;
using Test.Web.Constants;
using Test.Web.Enums;
using Test.Web.Models;
using Test.Web.Steps;

namespace Test.Web.Tests
{
    public class DemoTest : BaseTest
    {
        private readonly HeaderFormSteps headerFormSteps = new HeaderFormSteps();
        private readonly CookiesSteps cookiesSteps = new CookiesSteps();
        private readonly LoginOrRegistrationPageSteps loginOrRegistrationPageSteps = new LoginOrRegistrationPageSteps();
        private readonly QuickSearchFormSteps quickSearchFormSteps = new QuickSearchFormSteps();
        private readonly SearchResultFormSteps searchResultFormSteps = new SearchResultFormSteps();
        private readonly FooterFormSteps footerFormSteps = new FooterFormSteps();

        private readonly TestData testData = FileReader.ReadJsonData<TestData>(ProjectConstants.PathToTestData);

        [SetUp]
        public void Setup()
        {
            GoToPage(testData.Url);
            SetScreenExpansionMaximize();
            cookiesSteps.CookiesFormIsPresent();
            cookiesSteps.AcceptCookies();
        }

        [Test(Description = "TC-0001 Check the possibility to change the language from German to English")]
        public void TC0001_CheckThePossibilityToChangeTheLanguageFromGermanToEnglish()
        {
            headerFormSteps.HeaderFormIsPresent();
            headerFormSteps.CheckLanguages(Country.Germany);
            headerFormSteps.ClickLanguageSelection();
            headerFormSteps.SetCountryLanguage(Country.English);
            headerFormSteps.CheckLanguages(Country.English);
        }

        [Test(Description = "TC-0002 Try logging in with the wrong email and password")]
        public void TC0002_TryToLogInUnderTheWrongEmailAndPassword()
        {
            headerFormSteps.HeaderFormIsPresent();
            headerFormSteps.CheckLanguages(Country.Germany);
            headerFormSteps.ClickLogin();
            loginOrRegistrationPageSteps.LoginOrRegistrationPageIsPresent();
            loginOrRegistrationPageSteps.InputIncorrectCredentionals();
            loginOrRegistrationPageSteps.ClickLoginInButton();
            loginOrRegistrationPageSteps.LoginOrRegistrationPageIsPresent();
            loginOrRegistrationPageSteps.CheckWarningMessageIsPresent();
        }

        [Test(Description = "TC-0003 Enter the model and make of the car in the search and make sure that the search works")]
        public void TC0003_EnterTheModelAndMakeOfTheCarInTheSearchAndMakeSurethatTheSearchWorks()
        {
            headerFormSteps.HeaderFormIsPresent();
            quickSearchFormSteps.QuickSearchFormIsPresent();
            Assert.Multiple(()=> {
                quickSearchFormSteps.ClickPaymentType(PaymentType.Price);
                quickSearchFormSteps.ChecPaymentType(PaymentType.Price);
                quickSearchFormSteps.SetMake(testData.Make);
                quickSearchFormSteps.SetModel(testData.Model);
                quickSearchFormSteps.InputTextToCityOrZIPCodeAndCheckIt();
                quickSearchFormSteps.ClickSearchButton();
            });
            searchResultFormSteps.SearchResultFormIsPresent();
            searchResultFormSteps.CheckCountOfDispalayedAdMoreThanFive();
            var pageHeight = (int)(long)BrowserUtils.ExecuteScript("return document.body.scrollHeight");
            BrowserUtils.ScrollWindowBy(0, pageHeight);
            footerFormSteps.FooterFormIsPresent();
        }
    }
}