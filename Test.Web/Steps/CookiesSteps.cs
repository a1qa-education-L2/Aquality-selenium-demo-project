using System;
using System.Collections.Generic;
using System.Text;
using Test.Web.Base;
using Test.Web.Extensions;
using Test.Web.Forms;

namespace Test.Web.Steps
{
    public class CookiesSteps : BaseSteps
    {
        private readonly CookiesForm cookiesForm;

        public CookiesSteps()
        {
            cookiesForm = new CookiesForm();
        }

        public void CookiesFormIsPresent()
        {
            LogAssertion();
            cookiesForm.AssertIsPresent();
        }

        public void AcceptCookies()
        {
            LogStep();
            cookiesForm.AcceptCookies();
        }
    }
}
