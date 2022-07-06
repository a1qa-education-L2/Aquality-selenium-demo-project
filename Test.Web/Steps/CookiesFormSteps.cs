using Aquality.Selenium.Browsers;
using NUnit.Framework;
using System;
using Test.Web.Base;
using Test.Web.Constants;
using Test.Web.Extensions;
using Test.Web.Forms;

namespace Test.Web.Steps
{
    public class CookiesFormSteps : BaseSteps
    {
        private readonly CookiesForm cookiesForm;

        public CookiesFormSteps()
        {
            cookiesForm = new CookiesForm();
        }

        public void CookiesFormIsPresent()
        {
            LogAssertion();
            cookiesForm.AssertIsPresent();
        }


        public void AcceptCookiesButtonIsDisplayed()
        {
            LogAssertion();
            Assert.IsTrue(cookiesForm.IsAcceptCookiesButtonDisplayed, "Accept cookies button should be displayed");
        }

        public void AcceptCookiesButtonIsNotDisplayed()
        {
            LogAssertion();
            AqualityServices.ConditionalWait.WaitForTrue(() => {
                return cookiesForm.IsAcceptCookiesButtonDisplayed;
            },
             TimeSpan.FromSeconds(ProjectConstants.Timeout), TimeSpan.FromSeconds(ProjectConstants.PollingInterval),
                "Accept cookies button should not be displayed");
        }

        public void CookiesFormIsNotDisplayed()
        {
            LogAssertion();
            cookiesForm.AssertIsNotPresent();
        }

        public void AcceptCookies()
        {
            LogStep();
            cookiesForm.AcceptCookies();
        }
    }
}