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
    public class DemoTest : BaseTest
    {
        private const string FullPageSizeJS = "return document.body.scrollHeight";

        private readonly HeaderFormSteps headerFormSteps = new HeaderFormSteps();
        private readonly CookiesFormSteps cookiesSteps = new CookiesFormSteps();
        private readonly ContactUsFormSteps contactUsFormSteps = new ContactUsFormSteps();
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

        [TearDown]
        public void AfterEach()
        {
            AqualityServices.Browser.Quit();
        }


        [Test(Description = "TC-0002 Check all navigation panel elements are present")]
        public void TC0002_CheckThePossibilityToChangeTheLanguageFromGermanToEnglish()
        {
            headerFormSteps.HeaderFormIsPresent();
            headerFormSteps.ContactUsButtonIsPresent();
            headerFormSteps.CheckThatNavigationElementsAreCorrect();
            headerFormSteps.MoveToTheServicesNavigationTab();
            headerFormSteps.CheckThatServicesTitlesAreDispalayedAndCorrect();
        }

        [Test(Description = "TC-0003 Check how the Contact Us form works with an incorrect email")]
        public void TC0003_CheckHowTheContactUsFormWorksWithAnIncorrectEmail()
        {
            headerFormSteps.HeaderFormIsPresent();
            headerFormSteps.ClickContactUs();
            contactUsFormSteps.ContactUsFormIsPresent();
            contactUsFormSteps.CheckThatTheContactUsFormElementsAreDisplayed();
            contactUsFormSteps.CheckThanContactUsTitleIsCorrect();
            contactUsFormSteps.SetDataForTheAllTextFields();
            contactUsFormSteps.CheckTermCheckBoxIsCheckedOrNot();
            contactUsFormSteps.CheckTermCheckBox();
            contactUsFormSteps.CheckTermCheckBoxIsCheckedOrNot(true);
            contactUsFormSteps.CheckThatWarningEmailMessageisPresentOrNot();
            contactUsFormSteps.ClickSendAMessageButton();
            contactUsFormSteps.CheckThatWarningEmailMessageisPresentOrNot(true);
            contactUsFormSteps.CheckThatWarningEmailMessageIsCorrect();
        }

        [Test(Description = "TC-0004 Check the footer form is correct with visual testing")]
        public void TC0004_CheckTheFooterFormIsCorrectWithVisualTesting()
        {
            headerFormSteps.HeaderFormIsPresent();
            var fullPageHeight = (int)(long)BrowserUtils.ExecuteScript(FullPageSizeJS);
            BrowserUtils.ScrollWindowBy(0, fullPageHeight);
            footerFormSteps.FooterFormIsPresent();
            footerFormSteps.CheckVisualElementsPresent();
            //footerFormSteps.DumpSave(); // - this method is used locally, only to fill the image dump.
            var compareResult = footerFormSteps.DumpCompare();
            Assert.AreEqual(compareResult, 0, "The footer form should contain the correct visual elements");
        }
    }
}