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

            Console.Write("Please provide the name of the owner and the license number: ");
            string[] ownership = Console.ReadLine().Split(",");

            Console.WriteLine("Please specify the color, number of wheels (number), " +
                "\nand mobility type (land, air, or water).");
            string[] generalInfo = Console.ReadLine().Split(",");

            Console.WriteLine("Please specify technical details: " +
                "\nCylinder volume (number), " +
                "\nfuel type (gasoline or dieslel) and number of seats (number).");
            string[] typeInfo = Console.ReadLine().Split(",");

            bool validInputs = (    //Assessing if all these inputs are valid
                int.TryParse(generalInfo[1], out int numWheels) &
                Mobility.TryParse(generalInfo[2].ToLower(), out Mobility mobility) &
                int.TryParse(typeInfo[0], out int cylVolume) &
                FuelType.TryParse(typeInfo[1].ToLower(), out FuelType fuelType) &
                int.TryParse(typeInfo[2], out int numSeats)
                );

            if (validInputs)
            {
                Console.WriteLine("Thank you. Generating registry information...");

                return new Car(ownership[1], ownership[0],
                generalInfo[0], numWheels, mobility,
                cylVolume, fuelType, numSeats
                );
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
