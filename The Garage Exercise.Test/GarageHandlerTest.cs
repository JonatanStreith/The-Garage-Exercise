using System.Reflection;
using The_Garage_Exercise.Managers;
using The_Garage_Exercise.Garage;
using The_Garage_Exercise.Vehicles;
using The_Garage_Exercise.Enums;
using System.Linq;
using The_Garage_Exercise.Tools;
using System.Collections.Generic;

namespace The_Garage_Exercise.Test
{
    public class GarageHandlerTest
    {

        GarageHandler handler = new Garage.GarageHandler(10, true);

        Vehicle testVehicle = new Car("CSharpRulez", "Steve", Color.red, 4, Mobility.land, 2000, FuelType.gasoline, 5);
        Vehicle badVehicle = new Bicycle("CSharpRulez", "Donny", Color.green, 2, Mobility.land, 1);
        Vehicle nullVehicle = null;



        //Constructor
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

        //Parkvehicle
        [Fact]
        public void CanParkVehicle()
        {

            int initialOccupancy = handler.Garage.Count();

            string result = handler.ParkVehicle(testVehicle);

            Assert.Equal(handler.Garage.Count(), initialOccupancy + 1);
            Assert.Contains(testVehicle, handler.Garage);
            Assert.Equal("Parking of vehicle with license CSharpRulez successful.", result);


        }

        [Fact]
        public void CantParkNullVehicle()
        {
            int initialOccupancy = handler.Garage.Count();

            string result = handler.ParkVehicle(nullVehicle);

            Assert.Equal(handler.Garage.Count(), initialOccupancy);
            Assert.DoesNotContain(nullVehicle, handler.Garage);
            Assert.Equal("Null vehicle.", result);
        }

        [Fact]
        public void CantParkSameLicense()
        {

            handler.ParkVehicle(testVehicle);
            Assert.Contains(testVehicle, handler.Garage);
            int initialOccupancy = handler.Garage.Count();

            string result = handler.ParkVehicle(badVehicle);


            Assert.Equal(handler.Garage.Count(), initialOccupancy);
            Assert.DoesNotContain(badVehicle, handler.Garage);
            Assert.Equal("Duplicate license number.", result);
        }

        //RetrieveVehicle
        [Fact]
        public void CanRetrieveRealLicense()
        {
            handler.ParkVehicle(testVehicle);
            Assert.Contains(testVehicle, handler.Garage);

            string result = handler.RetrieveVehicle("CSharpRulez");
            Assert.DoesNotContain(testVehicle, handler.Garage);
            Assert.Equal("Retrieving of vehicle with license CSharpRulez successful.", result);

        }

        [Fact]
        public void CantRetrieveFakeLicense()
        {
            handler.ParkVehicle(testVehicle);
            Assert.Contains(testVehicle, handler.Garage);

            string result = handler.RetrieveVehicle("FakeLicense");
            Assert.Contains(testVehicle, handler.Garage);
            Assert.Equal("Vehicle with license FakeLicense not found.", result);
        }

        //FindVehicleByLicense
        [Fact]
        public void FindLegitimateLicense()
        {
            handler.ParkVehicle(testVehicle);

            Vehicle find = handler.FindVehicleByLicense(testVehicle.License);

            Assert.NotNull(find);
            Assert.Equal(find, testVehicle);
        }

        [Fact]
        public void DontFindFakeLicense()
        {
            handler.ParkVehicle(testVehicle);

            Vehicle find = handler.FindVehicleByLicense("FAKE");

            Assert.Null(find);
            Assert.NotEqual(find, testVehicle);
        }

        //ListParkedVehicles
        [Fact]
        public void CanListVehicles()
        {
            List<Vehicle> cars = handler.ListParkedVehicles("car");
            List<Vehicle> all = handler.ListParkedVehicles("all");

            Assert.True(cars.All(vehicle => vehicle.GetType() == typeof(Car)));
            Assert.True(cars.All(vehicle => handler.Garage.Contains(vehicle)));

            Assert.True(all.All(vehicle => handler.Garage.Contains(vehicle)));
        }


        //MultiFilterVehicle
        [Fact]
        public void CanFilterFromLegitimateString()
        {
            handler.ParkVehicle(testVehicle);

            (List<Vehicle> results, FilterData data) = handler.MultiFilterVehicle("car 4 wheels red land");

            Assert.Equal("car", data.TypeFilter);
            Assert.Equal("red", data.ColorFilter);
            Assert.Equal("land", data.MobilityFilter);
            Assert.Equal(4, data.WheelsFilter);

            Assert.True(results.All(vehicle => handler.Garage.Contains(vehicle)));
            Assert.True(results.All(vehicle => vehicle.Wheels == 4));
            Assert.True(results.All(vehicle => vehicle.GetType() == typeof(Car)));
            Assert.True(results.All(vehicle => vehicle.Color == Color.red));
            Assert.True(results.All(vehicle => vehicle.Mobility == Mobility.land));
        }

        //MultiFilterParse
        [Fact]
        public void CanCreateFilterDataFromInput()
        {
            FilterData data = handler.MultiFilterParse(new string[] { "black", "land", "car", "4", "wheels" });

            Assert.Equal("car", data.TypeFilter);
            Assert.Equal("black", data.ColorFilter);
            Assert.Equal("land", data.MobilityFilter);
            Assert.Equal(4, data.WheelsFilter);
        }

        [Fact]
        public void CanCreateFilterDataFromInputAnyOrder()
        {
            FilterData data = handler.MultiFilterParse(new string[] { "4", "wheels", "black", "car", "land" });

            Assert.Equal("car", data.TypeFilter);
            Assert.Equal("black", data.ColorFilter);
            Assert.Equal("land", data.MobilityFilter);
            Assert.Equal(4, data.WheelsFilter);
        }


        [Fact]
        public void IgnoresUnknownKeywords()
        {
            FilterData data = handler.MultiFilterParse(new string[] { "fnord", "frog", "space", "4", "doof" });

            Assert.Null(data.TypeFilter);
            Assert.Null(data.ColorFilter);
            Assert.Null(data.MobilityFilter);
            Assert.Equal(-1, data.WheelsFilter);
        }

        //PerformFilter
        [Fact]
        public void CanGetListFromFilter()
        {
            FilterData data = handler.MultiFilterParse(new string[] { "4", "wheels", "black", "car", "land" });

            handler.ParkVehicle(testVehicle);

            var results = handler.PerformFilter(data);

            Assert.True(results.All(vehicle => handler.Garage.Contains(vehicle)));
            Assert.True(results.All(vehicle => vehicle.Wheels == 4));
            Assert.True(results.All(vehicle => vehicle.GetType() == typeof(Car)));
            Assert.True(results.All(vehicle => vehicle.Color == Color.black));
            Assert.True(results.All(vehicle => vehicle.Mobility == Mobility.land));

        }

        //CheckForFreeSpot
        [Fact]
        public void CheckForSpot()
        {
            GarageHandler large = new(10, true);
            GarageHandler small = new(3, true);

            bool resultLarge = large.CheckForFreeSpot();
            bool resultSmall = small.CheckForFreeSpot();

            Assert.True(resultLarge);
            Assert.False(resultSmall);

        }
    }
}
