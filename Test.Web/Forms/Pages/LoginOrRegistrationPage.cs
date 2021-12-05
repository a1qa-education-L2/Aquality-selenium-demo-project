using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Test.Web.Forms.Pages
{
    public class LoginOrRegistrationPage : Form
    {
        private TimeSpan timeout = TimeSpan.FromSeconds(5);

        private IButton LoginTabButton => ElementFactory.GetButton(By.Id("loginTab"), "Login tab");

        private IButton LoginInSubmitButton => ElementFactory.GetButton(By.Id("login-submit"), "Login in submit");

        private ITextBox UserNameTextBox => ElementFactory.GetTextBox(By.Id("login-username"), "User name");

        private ITextBox PasswordTextBox => FormElement.FindChildElement<ITextBox>(By.Id("login-password"), "Password");

        private ILabel WarningMessageLabel => ElementFactory.GetLabel(By.XPath("//span[@class='warning-message']"), "Warning message");

        private ILabel HeaderLabel => ElementFactory.GetLabel(By.TagName("header"), "Header");

        private ILabel DefaultPanelFormboxLabel => ElementFactory.GetLabel(By.Id("tmpl-form"), "Default Panel Formbox");

        private ILabel LogInfoLabel => ElementFactory.GetLabel(By.XPath("//div[contains(@class,'col-log-info')]"), "Log Info");

        private ILabel RowPageFooterLabel => ElementFactory.GetLabel(By.XPath("//div[contains(@class,'page-footer')]"), "Row Page Footer");

        public LoginOrRegistrationPage() : base(By.Id("tmpl-form"), "Login or registration page")
        {
        }

        protected override IDictionary<string, IElement> ElementsForVisualization => new Dictionary<string, IElement>()
        {
            {"Header", HeaderLabel },
            {"Default Panel Formbox", DefaultPanelFormboxLabel },
            {"Log Info", LogInfoLabel },
            {"Login or registration page", RowPageFooterLabel },
        };

        public void ClickLoginTabButton() => LoginTabButton.Click();

        public void ClickLoginInButton() => LoginInSubmitButton.Click();

        public void SetUserName(string userName) => UserNameTextBox.ClearAndType(userName);

        public void SetPassword(string userPassword) => PasswordTextBox.ClearAndType(userPassword);

        public bool IsWarningMessagePresent => WarningMessageLabel.State.WaitForDisplayed(timeout);

        public string WarningMessageText => WarningMessageLabel.Text;

        public bool IsHeaderPresent => HeaderLabel.State.WaitForDisplayed(timeout);

        public bool IsDefaultPanelFormboxPresent => DefaultPanelFormboxLabel.State.WaitForDisplayed(timeout);

        public bool IsLogInfoPresent => LogInfoLabel.State.WaitForDisplayed(timeout);

        public bool IsRowPageFooterPresent => RowPageFooterLabel.State.WaitForDisplayed(timeout);
    }
}
