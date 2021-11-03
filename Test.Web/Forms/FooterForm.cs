using Aquality.Selenium.Core.Forms;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Web.Forms
{
    public class FooterForm : Form 
    {
        public FooterForm() : base(By.Id("footer-container"), "Footer form")
        {
        }
    }
}
