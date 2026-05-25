using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Tools;

namespace The_Garage_Exercise.Test
{
    public class FilterDataTest
    {
        FilterData testData = new FilterData("bicycle", "air", "green", 2);
        FilterData nullData = new FilterData(null, null, null, -1);

        [Fact]
        public void CanCreateFilterData()
        {
            Assert.NotNull(testData);
            Assert.IsType<FilterData>(testData);
            Assert.Equal("bicycle", testData.TypeFilter);
            Assert.Equal("air", testData.MobilityFilter);
            Assert.Equal("green", testData.ColorFilter);
            Assert.Equal(2, testData.WheelsFilter);
        }

        [Fact]
        public void CanCreateNullableData()
        {
            Assert.NotNull(nullData);
            Assert.IsType<FilterData>(nullData);
            Assert.Equal(null, nullData.TypeFilter);
            Assert.Equal(null, nullData.MobilityFilter);
            Assert.Equal(null, nullData.ColorFilter);
            Assert.Equal(-1, nullData.WheelsFilter);
        }

        [Fact]
        public void IsEmptyFunctions()
        {
            Assert.False(testData.IsEmpty());
            Assert.True(nullData.IsEmpty());
        }


    }
}
