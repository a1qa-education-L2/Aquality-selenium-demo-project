using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Web.Enums;

namespace Test.Web.Forms
{
    public class SearchResultForm : Form 
    {
        private const string Locator = "//div[contains(@class,'resultitem dealerAd')]//span[contains(@class,'u-text-break-word')]";

        private IList<ILabel> AdTitles => FormElement.FindChildElements<ILabel>(By.XPath(Locator), expectedCount : ElementsCount.MoreThenZero);

        public SearchResultForm() : base(By.XPath("//div[contains(@class,'cBox--resultList')]"), "Search result form")
        {
        }

        public IList<string> GetAdTitles()
        {
            var titles = AdTitles;
            return titles.Select(item => item.Text).ToList();
        }

        public int GetAdCounts()
        {
            return AdTitles.Count;
        }
    }
}
