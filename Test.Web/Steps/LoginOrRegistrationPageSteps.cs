using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Web.Base;
using Test.Web.Constants;
using Test.Web.Extensions;
using Test.Web.Forms.Pages;
using Test.Web.Models;

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
            Assert.IsTrue(loginOrRegistrationPage.IsWarningMessagePresent, "Warning message should be displayed");
        }
    }
}
