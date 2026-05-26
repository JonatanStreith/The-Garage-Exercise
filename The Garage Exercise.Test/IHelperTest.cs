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
            TestHelper help = new TestHelper();
            string testmessage = "Sphinx of black quartz, judge my vow";

            help.Output = testmessage;

            string result1 = help.GetInput("This is an input with a message.");

            string result2 = help.GetInput();

            Assert.Equal(testmessage, result1);
            Assert.Equal(testmessage, result2);

        }
    }
}
