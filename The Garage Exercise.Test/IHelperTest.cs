using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Tools;

namespace The_Garage_Exercise.Test
{
    public class IHelperTest
    {
        [Fact]
        public void TestHelperCanReturnSpoofedData()
        {
            IHelper help = new TestHelper();
            string testmessage = "Sphinx of black quartz, judge my vow";

            help.Output = testmessage;

            string result1 = help.GetInput("This is an input with a message.");

            string result2 = help.GetInput();

            Assert.Equal(testmessage, result1);
            Assert.Equal(testmessage, result2);

        }

        [Fact]
        public void MultiTestHelperCanReturnMultiSpoofedData()
        {
            IHelper help = new MultiTestHelper();
            string testmessage = "Car;Steve 567ABC;red 4 land;2000 diesel 5";

            help.Output = testmessage;

            string result1 = help.GetInput("This is an input with a message.");

            string result2 = help.GetInput();

            string result3 = help.GetInput();

            string result4 = help.GetInput();

            string result5 = help.GetInput();

            Assert.Equal("Car", result1);
            Assert.Equal("Steve 567ABC", result2);
            Assert.Equal("red 4 land", result3);
            Assert.Equal("2000 diesel 5", result4);
            Assert.Equal("Car", result5);

        }


    }
}
