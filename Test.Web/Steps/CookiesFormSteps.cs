using Test.Web.Base;
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

        public void AcceptCookies()
        {
            LogStep();
            cookiesForm.AcceptCookies();
        }
    }
}