using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Web.Base;
using Test.Web.Constants;
using Test.Web.Enums;
using Test.Web.Extensions;
using Test.Web.Forms;

namespace Test.Web.Steps
{
    public class QuickSearchFormSteps : BaseSteps
    {
        private readonly QuickSearchForm quickSearchForm;

        public QuickSearchFormSteps()
        {
            quickSearchForm = new QuickSearchForm();
        }

        public void QuickSearchFormIsPresent()
        {
            LogAssertion();
            quickSearchForm.AssertIsPresent();
        }

        public void ClickSearchButton()
        {
            LogStep();
            quickSearchForm.ClickSearchButton();
        }

        public void ClickPaymentType(PaymentType paymentType)
        {
            LogStep(nameof(ClickPaymentType) + $"PaymentType - [{paymentType}]");
            quickSearchForm.ClickPaymentType(paymentType);
        }

        public void ModelComboBoxIsDisplayed()
        {
            LogAssertion();
            Assert.IsTrue(quickSearchForm.IsModelComboBoxDisplayed, "Model ComboBox should be displayed");
        }

        public void MakeComboBoxIsDisplayed()
        {
            LogAssertion();
            Assert.IsTrue(quickSearchForm.IsMakeComboBoxDisplayed, "Make ComboBox should be displayed");
        }

        public void SetModel(string model)
        {
            LogStep(nameof(SetModel) + $"Model - [{model}]");
            quickSearchForm.SetValueModelComboBox(model);
        }

        public void SetMake(string make)
        {
            LogStep(nameof(SetMake) + $"Make - [{make}]");
            quickSearchForm.SetValueMakeComboBox(make);
        }

        public void ChecPaymentType(PaymentType paymentType)
        {
            LogAssertion(nameof(ChecPaymentType) + $"Payment type - [{paymentType}]");
            Assert.IsTrue(quickSearchForm.IsPaymentRadioButtonChecked(paymentType), $"Payment type - [{paymentType}] should be checked");
        }

        public void InputTextToCityOrZIPCodeAndCheckIt()
        {
            quickSearchForm.SetTextToCityOrZIPCode(ProjectConstants.ConstantText);
            var textFromCustomElement = quickSearchForm.GetTextFromCityOrZIPCode;
            Assert.AreEqual(ProjectConstants.ConstantText, textFromCustomElement, "Text should be same");
        }
    }
}
