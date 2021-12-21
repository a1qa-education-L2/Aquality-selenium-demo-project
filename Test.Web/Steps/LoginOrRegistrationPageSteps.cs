using NUnit.Framework;
using Test.Web.Base;
using Test.Web.Constants;
using Test.Web.Extensions;
using Test.Web.Forms.Pages;
using Test.Web.Models;
using Test.Web.Utilities;

namespace Test.Web.Steps
{
    public class LoginOrRegistrationPageSteps : BaseSteps
    {
        private readonly LoginOrRegistrationPage loginOrRegistrationPage;
        private readonly LoginUser loginUser;

        public LoginOrRegistrationPageSteps()
        {
            loginOrRegistrationPage = new LoginOrRegistrationPage();
            loginUser = FileReader.ReadJsonData<LoginUser>(ProjectConstants.PathToLoginUser);
        }

        public void LoginOrRegistrationPageIsPresent()
        {
            LogAssertion();
            loginOrRegistrationPage.AssertIsPresent();
        }

        public void ClickLoginTabButton()
        {
            LogStep();
            loginOrRegistrationPage.ClickLoginTabButton();
        }

        public void ClickLoginInButton()
        {
            LogStep();
            loginOrRegistrationPage.ClickLoginInButton();
        }

        public void SetUserName(string userName)
        {
            LogStep(nameof(SetUserName) + $"Input user name - [{userName}]");
            loginOrRegistrationPage.SetUserName(userName);
        }

        public void SetPassword(string password)
        {
            LogStep(nameof(SetPassword) + $"Input password - [{password}]");
            loginOrRegistrationPage.SetPassword(password);
        }

        public void InputIncorrectCredentionals()
        {
            SetUserName(loginUser.UserEmail);
            SetPassword(loginUser.Password);
        }

        public void CheckWarningMessageIsPresent()
        {
            LogAssertion();
            Assert.IsTrue(loginOrRegistrationPage.IsWarningMessagePresent, "Warning message should be displayed");
        }

        public void CheckVisualElementsPresent()
        {
            LogAssertion();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(loginOrRegistrationPage.IsHeaderPresent, "Header should be displayed");
                Assert.IsTrue(loginOrRegistrationPage.IsDefaultPanelFormboxPresent, "Default Panel Formbox should be displayed");
                Assert.IsTrue(loginOrRegistrationPage.IsLogInfoPresent, "Log Info should be displayed");
                Assert.IsTrue(loginOrRegistrationPage.IsRowPageFooterPresent, "Row Page Footer should be displayed");
            });
        }

        public void DumpSave()
        {
            loginOrRegistrationPage.Dump.Save();
        }

        public float DumpCompare()
        {
            return loginOrRegistrationPage.Dump.Compare();
        }
    }
}