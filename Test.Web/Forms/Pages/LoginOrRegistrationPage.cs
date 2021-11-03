using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;

namespace Test.Web.Forms.Pages
{
    public class LoginOrRegistrationPage : Form
    {
        private TimeSpan timeout = TimeSpan.FromSeconds(5);

        private IButton LoginTabButton => ElementFactory.GetButton(By.Id("loginTab"), "Login tab");

        private IButton LoginInSubmitButton => ElementFactory.GetButton(By.Id("loginSubmitButton"), "Login in submit");

        private ITextBox UserNameTextBox => ElementFactory.GetTextBox(By.Id("login-username"), "User name");

        private ITextBox PasswordTextBox => FormElement.FindChildElement<ITextBox>(By.Id("login-password"), "Password");

        private ILabel WarningMessageLabel => ElementFactory.GetLabel(By.XPath("//span[@class='warning-message']"), "Warning message");

        public LoginOrRegistrationPage() : base(By.Id("tmpl-form"), "Login or registration page")
        {
        }

        public void ClickLoginTabButton() => LoginTabButton.Click();

        public void ClickLoginInButton() => LoginInSubmitButton.Click();

        public void SetUserName(string userName) => UserNameTextBox.ClearAndType(userName);

        public void SetPassword(string userPassword) => PasswordTextBox.ClearAndType(userPassword);

        public bool IsWarningMessagePresent => WarningMessageLabel.State.WaitForDisplayed(timeout);

        public string WarningMessageText => WarningMessageLabel.Text;
    }
}
