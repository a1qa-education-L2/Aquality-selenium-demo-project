using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Web.Forms
{
    public class CookiesForm : Form
    {
        private IButton AcceptCookiesButton => 
            FormElement.FindChildElement<IButton>(By.XPath("//button[contains(text(),'Einverstanden')]"), "Accept cookies");

        public CookiesForm() : base(By.Id("mde-consent-modal-container"), "Cookies")
        {
        }

        public void AcceptCookies() => AcceptCookiesButton.MouseActions.Click();
    }
}
