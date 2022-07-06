using NUnit.Framework;
using System;
using Aquality.Selenium.Browsers;
using Test.Web.Base;
using Test.Web.Constants;
using Test.Web.Enums;
using Test.Web.Extensions;
using Test.Web.Forms.Pages;
using Test.Web.Models;
using Test.Web.Utilities;

namespace Test.Web.Steps
{
    public class ContactUsFormSteps : BaseSteps
    {
        private readonly ContactsUsForm сontactsUsForm;
        private readonly ContactUser contactUser;
        const string TitleLabelText = "We are glad to hear from you!";

        public ContactUsFormSteps()
        {
            сontactsUsForm = new ContactsUsForm();
            contactUser = FileReader.ReadJsonData<ContactUser>(ProjectConstants.PathToContactUserWithInvalidEmail);
        }

        public void ContactUsFormIsPresent()
        {
            LogAssertion();
            сontactsUsForm.AssertIsPresent();
        }

        public void CheckThatTheContactUsFormElementsAreDisplayed()
        {
            LogAssertion();
            Assert.Multiple(() =>
            {
                foreach(ContactUsTextFields name in Enum.GetValues(typeof(ContactUsTextFields)))
                {
                    Assert.IsTrue(сontactsUsForm.IsContatcUsTextBoxPresent(name), $"Text field {name} should be displayed");
                }
                Assert.IsTrue(сontactsUsForm.IsTermsCheckBoxExist, "Terms checkBox should be exist");
                Assert.IsTrue(сontactsUsForm.IsTermsLabelPresent, "Terms label should be displayed");
                Assert.IsTrue(сontactsUsForm.IsSendAMessageButtonPresent, "Send a message button should be displayed");
                Assert.IsTrue(сontactsUsForm.IsTitleLabelPresent, "Title should be displayed");
            });
        }

        public void CheckThanContactUsTitleIsCorrect()
        {
            LogAssertion();
            Assert.AreEqual(сontactsUsForm.TitleLabelTextValue, TitleLabelText, "Title text should be same.");
        }

        public void ClickSendAMessageButton()
        {
            LogStep();
            сontactsUsForm.ClickSendAMessageButton();
        }

        public void CheckTermCheckBox()
        {
            LogStep();
            сontactsUsForm.CheckTermsCheckBox();
        }

        public void CheckTermCheckBoxIsCheckedOrNot(bool isChecked = false)
        {
            LogStep(nameof(CheckTermCheckBoxIsCheckedOrNot) + $"isChecked status - [{isChecked}]");
            var expectedStatus = isChecked ? "checked" : "not checked";
            Assert.AreEqual(сontactsUsForm.IsTermsCheckBoxChecked, isChecked, $"Term CheckBox should be {expectedStatus}");
        }

        public void SetValueForTheTextField(ContactUsTextFields textField, string value)
        {
            LogStep(nameof(SetValueForTheTextField) + $"Input user name - [{textField}]");
            сontactsUsForm.SetValueForContatcUsTextBox(textField, value);
        }

        public void SetDataForTheAllTextFields()
        {
            LogStep();
            SetValueForTheTextField(ContactUsTextFields.Name, contactUser.UserName);
            SetValueForTheTextField(ContactUsTextFields.Email, contactUser.UserEmail);
            SetValueForTheTextField(ContactUsTextFields.Company, contactUser.Company);
            SetValueForTheTextField(ContactUsTextFields.ProjectDescription, contactUser.ProjectDescription);
        }

        public void CheckThatWarningEmailMessageisPresentOrNot(bool isChecked = false)
        {
            LogAssertion(nameof(CheckThatWarningEmailMessageisPresentOrNot) + $"isChecked status - [{isChecked}]");
            var expectedStatus = isChecked ? "displayed" : "not displayed";
            AqualityServices.ConditionalWait.WaitForTrue(() => {
                return сontactsUsForm.IsWarningEmailMessagePresent == isChecked;
            },
             TimeSpan.FromSeconds(ProjectConstants.Timeout), TimeSpan.FromSeconds(ProjectConstants.PollingInterval),
                $"Warning email message should be {expectedStatus}.");
        }

        public void CheckThatWarningEmailMessageIsCorrect()
        {
            LogStep();
            Assert.AreEqual(сontactsUsForm.WarningEmailMessageTextValue, ContactUsTextFields.Email.GetEnumDescription(), "Warning email message should be correct.");
        }
    }
}