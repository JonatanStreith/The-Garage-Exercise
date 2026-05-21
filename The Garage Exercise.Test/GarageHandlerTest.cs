using System.Reflection;
using The_Garage_Exercise.Managers;
using The_Garage_Exercise.Garage;
using The_Garage_Exercise.Vehicles;
using The_Garage_Exercise.Enums;
using System.Linq;

namespace The_Garage_Exercise.Test
{
    public class GarageHandlerTest
    {

        Vehicle testVehicle = new Car("CSharpRulez", "Steve", Color.red, 4, Mobility.land, 2000, FuelType.gasoline, 5);
        Vehicle nullVehicle = null;

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

        [Fact]
        public void CanParkVehicle()
        {

            GarageHandler handler = new Garage.GarageHandler(10, true);
            int initialOccupancy = handler.Garage.Count();

            handler.ParkVehicle(testVehicle);

            Assert.Equal(handler.Garage.Count(), initialOccupancy + 1);
            Assert.Contains(testVehicle, handler.Garage);

        }

        [Fact]
        public void CantParkNullVehicle()
        {
            GarageHandler handler = new Garage.GarageHandler(10, true);
            int initialOccupancy = handler.Garage.Count();

            handler.ParkVehicle(nullVehicle);

            Assert.Equal(handler.Garage.Count(), initialOccupancy);
            Assert.DoesNotContain(nullVehicle, handler.Garage);


        }
    }
}
