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
        private IButton AcceptCookiesButton => FormElement.FindChildElement<IButton>(By.XPath("//button[contains(text(),'Accept')]"), "Accept cookies");

        public CookiesForm() : base(By.XPath("//div[contains(@class,'eGEIRm')]"), "Cookies")
        {
        }

        public void AcceptCookies() => AcceptCookiesButton.MouseActions.Click();
    }
}