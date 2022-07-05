using NUnit.Framework;
using Test.Web.Base;
using Test.Web.Enums;
using Test.Web.Extensions;
using Test.Web.Forms;

namespace Test.Web.Steps
{
    public class HeaderFormSteps : BaseSteps
    {
        private readonly HeaderForm headerForm;
        private const string ServicesTabItem = "Services";
        private readonly string[] headerTabItems = { "Services", "Approach", "Portfolio", "Blog", "Company" };
        private readonly string[] servicesTitleElements = { "Full-cycle testing services", "Quality engineering", "Complete test coverage", "Systems & platforms" };

        public HeaderFormSteps()
        {
            headerForm = new HeaderForm();
        }

        public void HeaderFormIsPresent()
        {
            LogAssertion();
            headerForm.AssertIsPresent();
        }

        public void ClickContactUs()
        {
            LogStep();
            headerForm.ClickContactUs();
        }

        public void ContactUsButtonIsPresent()
        {
            LogAssertion();
            Assert.IsTrue(headerForm.IsContactUsButtonExist);
        }

        public void CheckThatNavigationElementsAreCorrect()
        {
            LogAssertion();
            var headerNavigationElements = headerForm.GetTextForHeaderNavigationElements;
            CollectionAssert.AreEquivalent(headerTabItems, headerNavigationElements, "Header navigation elements should be correct");
        }

        public void MoveToTheServicesNavigationTab()
        {
            LogStep();
            headerForm.MoveToTheTabButton(ServicesTabItem);
        }

        public void CheckThatServicesTitlesAreDispalayedAndCorrect()
        {
            LogAssertion();
            var servicesTitlesElements = headerForm.GetTextFromServicesTitlesElements;
            CollectionAssert.AreEqual(servicesTitleElements, servicesTitlesElements, "Services title elements should be correct");
        }
    }
}
