using Aquality.Selenium.Browsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Web.Base;
using Test.Web.Constants;
using Test.Web.Extensions;
using Test.Web.Forms;

namespace Test.Web.Steps
{
    public class SearchResultFormSteps : BaseSteps
    {
        private readonly SearchResultForm searchResultForm;

        public SearchResultFormSteps()
        {
            searchResultForm = new SearchResultForm();
        }

        public void SearchResultFormIsPresent()
        {
            LogAssertion();
            searchResultForm.AssertIsPresent();
        }

        public void CheckCountOfDispalayedAdMoreThanFive()
        {
            LogAssertion();
            AqualityServices.ConditionalWait.WaitForTrue(() => {
                return searchResultForm.GetAdCounts() > 5 ; },
              TimeSpan.FromSeconds(ProjectConstants.Timeout), TimeSpan.FromSeconds(ProjectConstants.PollingInterval),
                 "The number of displayed ads must be more than 5");
        }
    }
}
