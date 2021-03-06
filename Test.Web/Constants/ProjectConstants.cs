using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Web.Constants
{
    public class ProjectConstants
    {
        public const int PollingInterval = 3;
        public const int Timeout = 3;
        public const string ConstantText = "random text to test";
        public const string PathToLoginUser = @"Resources\TestData\LoginUser.json";
        public const string PathToTestData = @"Resources\TestData\TestData.json";
        public const string FirstTestImage = @"Resources\ImagesForCustomImageComparator\first_test_image.jpg";
        public const string SecondTestImage = @"Resources\ImagesForCustomImageComparator\second_test_image.jpg";
    }
}