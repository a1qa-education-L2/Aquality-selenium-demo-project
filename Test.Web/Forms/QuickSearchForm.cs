using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Test.Web.Constants;
using Test.Web.Enums;
using Test.Web.Extensions;
using static Test.Web.Elements.CustomElements;

namespace Test.Web.Forms
{
    public class QuickSearchForm : Form
    {
        private IButton SearchButton => ElementFactory.GetButton(By.Id("qssub"), "Search");

        private IComboBox MakeComboBox => ElementFactory.GetComboBox(By.Id("qsmakeBuy"), "Make");

        private IComboBox ModelComboBox => ElementFactory.GetComboBox(By.Id("qsmodelBuy"), "Model");

        private IComboBox FirstRegistrationFromComboBox => ElementFactory.GetComboBox(By.Id("qsfrg"), "First registration from");

        private IRadioButton PaymentRadioButton(PaymentType paymentType) =>
            ElementFactory.GetRadioButton(By.Id($"{paymentType.GetId()}"), paymentType.ToString(), ElementState.ExistsInAnyState);

        private CustomTextBox CityOrZIPCodeCustomElement => ElementFactory.GetCustomTextBox(By.Id("ambit-search-location"), "City or ZIP code");

        public QuickSearchForm() : base(By.Id("quicksearchBuy"), "Quick Search form")
        {
        }

        public void ClickSearchButton() => SearchButton.JsActions.Click();

        public string GetTextFromCityOrZIPCode => CityOrZIPCodeCustomElement.Text;

        public void SetTextToCityOrZIPCode(string randomText) => CityOrZIPCodeCustomElement.ClearAndType(randomText);

        public bool IsPaymentRadioButtonChecked(PaymentType paymentType) => PaymentRadioButton(paymentType).IsChecked;

        public void ClickPaymentType(PaymentType paymentType) => PaymentRadioButton(paymentType).Click();

        public bool IsModelComboBoxDisplayed => ModelComboBox.State.WaitForDisplayed();

        public bool IsMakeComboBoxDisplayed => MakeComboBox.State.WaitForDisplayed();

        public void SetValueModelComboBox(string text) => ModelComboBox.SelectByText(text);

        public void SetValueMakeComboBox(string text) => MakeComboBox.SelectByText(text);

        public void SetValueFirstRegistrationFromComboBox(string text) => FirstRegistrationFromComboBox.SelectByText(text);
    }
}