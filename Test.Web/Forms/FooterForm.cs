using Aquality.Selenium.Core.Forms;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Web.Constants;

namespace Test.Web.Forms
{
    public class FooterForm : Form
    {
        private ILabel LogoLabel => FormElement.FindChildElement<ILabel>(By.XPath("//a[contains(@class,'footer__logo')]"), "Logo");

        private ILabel ContactsLabel => FormElement.FindChildElement<ILabel>(By.XPath("//div[contains(@class,'footer__contacts')]"), "Contacts");

        private ILabel SubscribeLabel => FormElement.FindChildElement<ILabel>(By.XPath("//div[contains(@class,'footer__subscribe')]"), "Subscribe");

        public FooterForm() : base(By.TagName("footer"), "Footer form")
        {
        }

        public bool IsLogoPresent => LogoLabel.State.WaitForDisplayed(ProjectConstants.ShortTimeout);

        public bool IsContactsPresent => ContactsLabel.State.WaitForDisplayed(ProjectConstants.ShortTimeout);

        public bool IsSubscribePresent => SubscribeLabel.State.WaitForDisplayed(ProjectConstants.ShortTimeout);

        protected override IDictionary<string, IElement> ElementsForVisualization => new Dictionary<string, IElement>()
        {
            {"Footer logo", LogoLabel },
            {"Footer contacts", ContactsLabel },
            {"Footer subscribe", SubscribeLabel },
        };
    }
}