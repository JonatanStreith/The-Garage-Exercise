using System;
using System.Collections.Generic;
using System.Text;

namespace The_Garage_Exercise.Vehicles
{
    internal class Car : Vehicle
    {
        private int _cylinderVolume;
        private FuelType _fuelType;
        private int _numberOfSeats;

        public Car(string license, string owner, string color, int wheels, Mobility mobility, int cylinderVolume, FuelType fuelType, int numberOfSeats) : base(license, owner, color, wheels, mobility)
        {
            CylinderVolume = cylinderVolume;
            FuelType = fuelType;
            NumberOfSeats = numberOfSeats;

        }

        public int CylinderVolume { get { return _cylinderVolume; } set { _cylinderVolume = value; } }
        public FuelType FuelType { get { return _fuelType; } set { _fuelType = value; } }
        public int NumberOfSeats { get { return _numberOfSeats; } set { _numberOfSeats = value; } }


        public static Car RegisterVehicle()
        {

            Console.WriteLine("Please provide the name of the owner and the license number.");
            string[] ownership = Console.ReadLine().Split(",");

            Console.WriteLine("Please specify the color, number of wheels (number), " +
                "\nand mobility type (land, air, or water).");
            string[] generalInfo = Console.ReadLine().Split(",");

            Console.WriteLine("Please specify technical details: " +
                "\nCylinder volume (number), " +
                "\nfuel type (gasoline or dieslel) and number of seats (number).");
            string[] typeInfo = Console.ReadLine().Split(",");

            //Check so the arrays are properly filled out

            bool completeInputs = (
                ownership.Length == 2 ||
                generalInfo.Length == 3 ||
                typeInfo.Length == 3
                );


            if (completeInputs)
            {
                Car car = CreateCarFromInputs(ownership, generalInfo, typeInfo);
                Console.WriteLine("The car has been registered.");
                return car;
            }
            else
                return null;

        }

        public static Car CreateCarFromInputs(string[] ownership, string[] generalInfo, string[] typeInfo)
        {
            bool validInputs = (
                int.TryParse(generalInfo[1], out int numWheels) &
                Mobility.TryParse(generalInfo[2].ToLower(), out Mobility mobility) &
                int.TryParse(typeInfo[0], out int cylVolume) &
                FuelType.TryParse(typeInfo[1].ToLower(), out FuelType fuelType) &
                int.TryParse(typeInfo[2], out int numSeats)
            );

            if (validInputs)
            {
                Console.WriteLine("Thank you. Generating registry information...");


                Car car = new Car(ownership[1], ownership[0],
                generalInfo[0], numWheels, mobility,
                cylVolume, fuelType, numSeats
                );

                Console.WriteLine($"Owner: {car.Owner}, License: {car.License}, Color: {car.Color}," +
                    $"\nNumber of wheels: {car.Wheels}, Number of seats: {car.NumberOfSeats}, Cylinder volume: {car.CylinderVolume}," +
                    $"\nMobility: {car.Mobility}, Fuel type: {car.FuelType}");

                return car;
            }

            else
            {
                Console.WriteLine("There were errors and the registration could not be completed." +
                "\nPlease try again later.");
                return null;
            }
        }

    }
}
