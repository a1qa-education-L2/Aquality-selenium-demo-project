using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Test.Web.Enums;
using Test.Web.Extensions;

namespace Test.Web.Forms
{
    public class HeaderForm : Form
    {
        private By LanguageCountrysLocator => By.XPath($"//ul[contains(@class,'header-meta-action-dropdown')]/li/a");

        private By LanguageCountryLocator(Country country) => By.XPath($"//ul[contains(@class,'header-meta-action-dropdown')]/li/a[text()=\"{country.GetEnumDescription()}\"]");

        private ILabel TitleLabel => ElementFactory.GetLabel(By.XPath("//span[contains(@class,'mde-react-header__claim')]"), "Title");

        private ILabel LanguageSelectionLabel => ElementFactory.GetLabel(By.XPath("//span[contains(@data-se,'language')]"), "Language selection");

        private IList<ILink> LanguageCountryLinks => ElementFactory.GetNotEmptyElementList<ILink>(LanguageCountrysLocator, "Language countrys");

        private ILink LanguageCountryLink(Country country) => ElementFactory.GetLink(LanguageCountryLocator(country), "Language country");

        private ILink LoginLink => ElementFactory.GetLink(By.Id("hdmylogin"), "Login");

        public HeaderForm() : base(By.TagName("header"), "Header form")
        {
        }

        public string TitleText => TitleLabel.Text;

        public string SelectedLanguage => LanguageSelectionLabel.GetAttribute("data-selected");

        public void ClickLanguageSelection() => LanguageSelectionLabel.Click();

        public void ClickLogin() => LoginLink.Click();

        public IList<string> GetLanguageCountries()
        {
            var tempList = LanguageCountryLinks;
            return LanguageCountryLinks.Select(item => item.Text).ToList();
        }

        public void SetCountryLanguage(Country country)
        {
            LanguageCountryLink(country).Click();
        }
    }
}