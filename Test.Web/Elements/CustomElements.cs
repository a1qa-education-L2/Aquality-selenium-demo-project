using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Web.Elements
{
    public class CustomElements
    {
        public class CustomTextBox : TextBox
        {
            public CustomTextBox(By locator, string name, ElementState state) : base(locator, name, state)
            {
            }

            public new string Text => Value;
        }
    }
}
