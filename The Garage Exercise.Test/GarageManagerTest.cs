using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using The_Garage_Exercise.Enums;
using The_Garage_Exercise.Garage;
using The_Garage_Exercise.Managers;
using The_Garage_Exercise.Tools;
using The_Garage_Exercise.Vehicles;

namespace The_Garage_Exercise.Test
{
    public class GarageManagerTest
    {

        GarageManager manager = new GarageManager(new TestHelper());

        GarageHandler handler = new GarageHandler(10, true);

        [Fact]
        public void CanSizeGarage()
        {
            manager.Help.Output = "10";

            int result = manager.SizeGarage();

            Assert.Equal(10, result);
        }

        [Fact]
        public void CanListParkedVehicles()
        {
            manager.Handler = handler;

            manager.Help.Output = "all";

            string response = manager.ListParkedVehicles();

            Assert.Equal("Listed 5 'all'.", response);
        }

        [Fact]
        public void CanMultiFilter()
        {
            manager.Handler = handler;

            manager.Help.Output = "black car land 4 wheels";

            FilterData response = manager.MultiFilterVehicle();

            Assert.Equal("black", response.ColorFilter);
            Assert.Equal("car", response.TypeFilter);
            Assert.Equal("land", response.MobilityFilter);
            Assert.Equal(4, response.WheelsFilter);

        }

        [Fact]
    public void CanParkVehicle()
        {
            manager.Handler = handler;
            manager.Help = new MultiTestHelper();

            manager.Help.Output = "Car;Steve, 567ABC;red, 4, land;2000, diesel, 5";

            manager.ParkVehicle();
            Vehicle foundVehicle = handler.FindVehicleByLicense("567ABC");
            Assert.NotNull(foundVehicle);

        }

        [Fact]
        public void CanRetrieveVehicle()
        {
            Vehicle testVehicle = new Car("CSharpRulez", "Steve", Enums.Color.red, 4, Mobility.land, 2000, FuelType.gasoline, 5);


            manager.Handler = handler;

            manager.Help.Output = "csharprulez";

            handler.ParkVehicle(testVehicle);

            string response = manager.RetrieveVehicle();
            string expectedResponse = "Retrieving of vehicle with license csharprulez successful.";
            Assert.Equal(expectedResponse, response);
        }
    }
}
