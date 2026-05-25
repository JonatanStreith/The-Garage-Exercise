using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Enums;
using The_Garage_Exercise.Vehicles;

namespace The_Garage_Exercise.Test
{
    public class VehicleTest
    {
        string[] ownership = new string[] { "Steve", "123ABC" };
        string[] generalInfo = new string[] { "red", "4", "land" };
        string[] carInfo = new string[] { "2000", "gasoline", "4" };
        string[] busInfo = new string[] { "2000", "gasoline", "4", "2000" };
        string[] boatInfo = new string[] { "2000", "gasoline", "2000" };
        string[] airplaneInfo = new string[] { "2", "2000", "gasoline", "4", "2000" };
        string[] motorcycleInfo = new string[] { "2000", "gasoline" };
        string[] bicycleInfo = new string[] { "1" };


        [Fact]
        public void CanRegisterCar()
        {
            Vehicle testVehicle = Car.RegisterVehicle(ownership, generalInfo, carInfo);

            Car result = (Car)testVehicle;

            Assert.NotNull(result);
            Assert.Equal("Steve", result.Owner);
            Assert.Equal("123ABC", result.License);
            Assert.Equal(Color.red, result.Color);
            Assert.Equal(4, result.Wheels);
            Assert.Equal(2000, result.CylinderVolume);
            Assert.Equal(FuelType.gasoline, result.FuelType);
            Assert.Equal(4, result.NumberOfSeats);
        }

        [Fact]
        public void CanRegisterBus()
        {
            Vehicle testVehicle = Bus.RegisterVehicle(ownership, generalInfo, busInfo);

            Bus result = (Bus)testVehicle;

            Assert.NotNull(result);
            Assert.Equal("Steve", result.Owner);
            Assert.Equal("123ABC", result.License);
            Assert.Equal(Color.red, result.Color);
            Assert.Equal(4, result.Wheels);
            Assert.Equal(2000, result.CylinderVolume);
            Assert.Equal(FuelType.gasoline, result.FuelType);
            Assert.Equal(4, result.NumberOfSeats);
            Assert.Equal(2000, result.Length);
        }

        [Fact]
        public void CanRegisterAirplane()
        {
            Vehicle testVehicle = Airplane.RegisterVehicle(ownership, generalInfo, airplaneInfo);

            Airplane result = (Airplane)testVehicle;

            Assert.NotNull(result);
            Assert.Equal("Steve", result.Owner);
            Assert.Equal("123ABC", result.License);
            Assert.Equal(Color.red, result.Color);
            Assert.Equal(4, result.Wheels);
            Assert.Equal(2,result.NumberOfEngines);
            Assert.Equal(2000, result.CylinderVolume);
            Assert.Equal(FuelType.gasoline, result.FuelType);
            Assert.Equal(4, result.NumberOfSeats);
            Assert.Equal(2000, result.Length);
        }

        [Fact]
        public void CanRegisterBoat()
        {
            Vehicle testVehicle = Boat.RegisterVehicle(ownership, generalInfo, boatInfo);

            Boat result = (Boat)testVehicle;

            Assert.NotNull(result);
            Assert.Equal("Steve", result.Owner);
            Assert.Equal("123ABC", result.License);
            Assert.Equal(Color.red, result.Color);
            Assert.Equal(4, result.Wheels);
            Assert.Equal(2000, result.CylinderVolume);
            Assert.Equal(FuelType.gasoline, result.FuelType);
            Assert.Equal(2000, result.Length);
        }

        [Fact]
        public void CanRegisterMotorCycle()
        {
            Vehicle testVehicle = Motorcycle.RegisterVehicle(ownership, generalInfo, motorcycleInfo);

            Motorcycle result = (Motorcycle)testVehicle;

            Assert.NotNull(result);
            Assert.Equal("Steve", result.Owner);
            Assert.Equal("123ABC", result.License);
            Assert.Equal(Color.red, result.Color);
            Assert.Equal(4, result.Wheels);
            Assert.Equal(2000, result.CylinderVolume);
            Assert.Equal(FuelType.gasoline, result.FuelType);
        }

        [Fact]
        public void CanRegisterBicycle()
        {
            Vehicle testVehicle = Bicycle.RegisterVehicle(ownership, generalInfo, bicycleInfo);

            Bicycle result = (Bicycle)testVehicle;

            Assert.NotNull(result);
            Assert.Equal("Steve", result.Owner);
            Assert.Equal("123ABC", result.License);
            Assert.Equal(Color.red, result.Color);
            Assert.Equal(4, result.Wheels);
            Assert.Equal(1, result.NumberOfSeats);
        }

        //TODO: Test with faulty inputs
    }
}