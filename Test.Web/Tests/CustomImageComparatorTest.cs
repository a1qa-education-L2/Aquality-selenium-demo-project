using NUnit.Framework;
using System.Drawing;
using Test.Web.Base;
using Test.Web.Constants;
using Test.Web.Utilities;

namespace Test.Web.Tests
{
    public class CustomImageComparatorTest : BaseTest
    {
        [Test(Description = "TC-0005 Check Custom Image Comparator")]
        public void TC0005_CheckCustomImageComparator()
        {
            CustomImageComparator.Init();

            var firstImage = Image.FromFile(ProjectConstants.FirstTestImage);

            var secondImage = Image.FromFile(ProjectConstants.SecondTestImage);

            var compareResult = CustomImageComparator.Compare(firstImage, secondImage);

            Assert.AreEqual(compareResult, 0, "The images should be the same");
        }
    }
}