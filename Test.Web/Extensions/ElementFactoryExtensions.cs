using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Core.Elements.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using static Test.Web.Elements.CustomElements;

namespace Test.Web.Extensions
{
    public static class ElementFactoryExtensions
    {
        public static IList<T> GetNotEmptyElementList<T>(this IElementFactory elementFactory, By by, string itemName) where T : IElement
        {
            try
            {
                return elementFactory.FindElements<T>(by, expectedCount: ElementsCount.MoreThenZero);
            }
            catch (TimeoutException e)
            {
                throw new TimeoutException($"Elements [{itemName}] were not found by locator [{by}]", e);
            }
        }

        public static CustomTextBox GetCustomTextBox(this IElementFactory elementFactory, By locator, string name, ElementState state = ElementState.ExistsInAnyState)
        {
            return new CustomTextBox(locator, name, state);
        }
    }
}
