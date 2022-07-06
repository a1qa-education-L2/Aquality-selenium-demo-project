using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Test.Web.Enums;

namespace Test.Web.Forms.Pages
{
    public class ContactsUsForm : Form
    {
        private ILabel TitleLabel => FormElement.FindChildElement<ILabel>(By.XPath("//h2[contains(@class,'blockTitle')]"), "Title");
        
        private IButton SendAMessageButton => ElementFactory.GetButton(By.XPath("//div[contains(@class,'contactsForm__submit')]"), "Send a message");

        private ITextBox ContatcUsTextBox(ContactUsTextFields contactUsTextField) => ElementFactory.GetTextBox(By.Id($"{contactUsTextField.GetId()}"), contactUsTextField.ToString());

        private ILabel TermsLabel => FormElement.FindChildElement<ILabel>(By.XPath("//label[contains(@class, 'checkbox')]"), "Terms");

        private ICheckBox TermsCheckBox => FormElement.FindChildElement<ICheckBox>(By.XPath("//input[@type='checkbox']"), "Terms", null, ElementState.ExistsInAnyState);

        private ILabel WarningEmailMessageLabel => ContatcUsTextBox(ContactUsTextFields.Email).FindChildElement<ILabel>(By.XPath("/parent::*/div[@class='input__error']"), "Warning email message");

        public ContactsUsForm() : base(By.XPath("//section[contains(@class,'contactsForm')]"), "Contacts Us form")
        {
        }

        public bool IsTitleLabelPresent => TitleLabel.State.IsDisplayed;

        public string TitleLabelTextValue => TitleLabel.GetText();

        public bool IsSendAMessageButtonPresent => SendAMessageButton.State.IsDisplayed;

        public void ClickSendAMessageButton() => SendAMessageButton.Click();

        public bool IsContatcUsTextBoxPresent(ContactUsTextFields contactUsTextField) => ContatcUsTextBox(contactUsTextField).State.IsDisplayed;

        public void SetValueForContatcUsTextBox(ContactUsTextFields contactUsTextField, string value) => ContatcUsTextBox(contactUsTextField).ClearAndType(value);

        public bool IsTermsCheckBoxExist => TermsCheckBox.State.IsExist;

        public bool IsTermsLabelPresent => TermsLabel.State.IsDisplayed;

        public void CheckTermsCheckBox() => TermsLabel.Click();

        public bool IsTermsCheckBoxChecked => TermsCheckBox.IsChecked;

        public bool IsWarningEmailMessagePresent => WarningEmailMessageLabel.State.IsDisplayed;

        public string WarningEmailMessageTextValue => WarningEmailMessageLabel.GetText();
    }
}