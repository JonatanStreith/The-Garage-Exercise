using System.Reflection;
using The_Garage_Exercise.Managers;
using The_Garage_Exercise.Garage;

namespace The_Garage_Exercise.Test
{
    public class GarageHandlerTest
    {
        [Fact]
        public void CanCreateHandler()
            //Check that a GarageHandler can be created
            //that it can access a garage
            //that the garage has the number of parking spots it should have
            //that the garage is not empty if populated
        {
            int size1 = 7;
            bool populate1 = true;
            int size2 = 17;
            bool populate2 = false;

            GarageHandler handler1 = new Garage.GarageHandler(size1, populate1);

            Assert.NotNull(handler1);
            Assert.NotNull(handler1.Garage);
            Assert.Equal(handler1.Garage.NumberOfParkingSpots, size1);
            Assert.NotEmpty(handler1.Garage);

            GarageHandler handler2 = new Garage.GarageHandler(size2, populate2);

            Assert.NotNull(handler2);
            Assert.NotNull(handler2.Garage);
            Assert.Equal(handler2.Garage.NumberOfParkingSpots, size2);
            Assert.Empty(handler2.Garage);


        }
    }
}
