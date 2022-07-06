using NUnit.Framework;
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

        public void CheckVisualElementsPresent()
        {
            LogAssertion();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(footerForm.IsLogoPresent, "Logo should be displayed");
                Assert.IsTrue(footerForm.IsContactsPresent, "Contacts section should be displayed");
                Assert.IsTrue(footerForm.IsSubscribePresent, "Subscribe section should be displayed");
            });
        }

        public void DumpSave()
        {
            footerForm.Dump.Save();
        }

        public float DumpCompare()
        {
            return footerForm.Dump.Compare();
        }
    }
}
