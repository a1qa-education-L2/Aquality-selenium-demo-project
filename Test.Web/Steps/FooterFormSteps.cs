using System;
using System.Collections.Generic;
using System.Text;
using Test.Web.Base;
using Test.Web.Extensions;
using Test.Web.Forms;

namespace Test.Web.Steps
{
    public class FooterFormSteps : BaseSteps
    {
        private readonly FooterForm footerForm;

        public FooterFormSteps()
        {
            footerForm = new FooterForm();
        }

        public void FooterFormIsPresent()
        {
            LogAssertion();
            footerForm.AssertIsPresent();
        }
    }
}
