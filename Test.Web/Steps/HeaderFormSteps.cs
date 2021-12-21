using NUnit.Framework;
using Test.Web.Base;
using Test.Web.Enums;
using Test.Web.Extensions;
using Test.Web.Forms;

namespace Test.Web.Steps
{
    public class HeaderFormSteps : BaseSteps
    {
        private readonly HeaderForm headerForm;

        public HeaderFormSteps()
        {
            headerForm = new HeaderForm();
        }

        public void HeaderFormIsPresent()
        {
            LogAssertion();
            headerForm.AssertIsPresent();
        }

        public void ClickLogin()
        {
            LogStep();
            headerForm.ClickLogin();
        }

        public void ClickLanguageSelection()
        {
            LogStep();
            headerForm.ClickLanguageSelection();
        }

        public string GetTitleText()
        {
            LogStep();
            return headerForm.TitleText;
        }

        public void SetCountryLanguage(Country country)
        {
            LogStep(nameof(SetCountryLanguage) + $"Set country language - [{country}]");
            headerForm.SetCountryLanguage(country);
        }

        public void CheckLanguages(Country country)
        {
            LogStep(nameof(CheckLanguages) + $"Check country language - [{country}]");
            Assert.AreEqual(headerForm.SelectedLanguage, country.GetEnumDescription());
        }
    }
}
