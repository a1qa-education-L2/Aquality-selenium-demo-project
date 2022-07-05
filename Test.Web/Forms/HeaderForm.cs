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
        private IList<ILabel> ServicesTitlesElements => ElementFactory.FindElements<ILabel>(By.XPath("//div[contains(@class,'menu__dropdown')]//h3"), "Service titles");

        private ILabel LogoLabel => FormElement.FindChildElement<ILabel>(By.XPath("//a[@aria-label='a1qa home page']"), "Logo");

        private IButton ContactUsButton => ElementFactory.GetButton(By.XPath("//div[contains(@class,'header__contact')]"), "Contact Us");       

        private IButton TabButtonByName(string buttonName) => ElementFactory.GetButton(By.XPath($"//nav/ul/li/button[contains(text(),'{buttonName}')]"), $"{buttonName}");

        private IList<ILabel> HeadersTabElements => ElementFactory.GetNotEmptyElementList<ILabel>(By.XPath("(//nav/ul/li/button | //nav/ul/li/a)"), "Header elements");
        
        public HeaderForm() : base(By.TagName("header"), "Header form")
        {
        }

        public bool IsLogoElementDisplayed => LogoLabel.State.IsDisplayed;

        public bool IsContactUsButtonExist => ContactUsButton.State.IsExist;

        public void ClickContactUs() => ContactUsButton.Click();

        public IList<string> GetTextForHeaderNavigationElements => HeadersTabElements.Select(x => x.GetText()).ToList();

        public void MoveToTheTabButton(string buttonName) => TabButtonByName(buttonName).MouseActions.MoveToElement();

        public IList<string> GetTextFromServicesTitlesElements => ServicesTitlesElements.Select(x => x.GetText()).ToList();
    }
}