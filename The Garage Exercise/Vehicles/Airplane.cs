using System;
using System.Collections.Generic;
using System.Text;

namespace The_Garage_Exercise.Vehicles
{
    internal class Airplane : Vehicle
    {
        private int _numberOfEngines;
        private int _cylinderVolume;
        private FuelType _fuelType;
        private int _numberOfSeats;
        private int _length;

        public Airplane(string license, string owner, string color, int wheels, Mobility mobility,
            int numberOfEngines, int cylinderVolume, FuelType fuelType, int numberOfSeats, int length)
            : base(license, owner, color, wheels, mobility)
        {
            NumberOfEngines = numberOfEngines;
            CylinderVolume = cylinderVolume;
            FuelType = fuelType;
            NumberOfSeats = numberOfSeats;
            Length = length;
        }

        public int NumberOfEngines { get { return _numberOfEngines; } set { _numberOfEngines = value; } }
        public int CylinderVolume { get { return _cylinderVolume; } set { _cylinderVolume = value; } }
        public FuelType FuelType { get { return _fuelType; } set { _fuelType = value; } }
        public int NumberOfSeats { get { return _numberOfSeats; } set { _numberOfSeats = value; } }
        public int Length { get { return _length; } set { _length = value; } }



        public static Airplane RegisterVehicle()
        {

            Console.Write("Please provide the name of the owner and the license number: ");
            string[] ownership = Console.ReadLine().Split(",");

            Console.WriteLine("Please specify the color, number of wheels (number), " +
                "\nand mobility type (land, air, or water).");
            string[] generalInfo = Console.ReadLine().Split(",");

            Console.WriteLine("Please specify technical details: " +
                "\nNumber of engines (number), cylinder volume (number), " +
                "\nfuel type (gasoline or dieslel), number of seats (number)" +
                "\nand length (number in centimeters).");
            string[] typeInfo = Console.ReadLine().Split(",");

            bool validInputs = (    //Assessing if all these inputs are valid
                int.TryParse(generalInfo[1], out int numWheels) &
                Mobility.TryParse(generalInfo[2].ToLower(), out Mobility mobility) &
                int.TryParse(typeInfo[0], out int numEngines) &
                int.TryParse(typeInfo[1], out int cylVolume) &
                FuelType.TryParse(typeInfo[2].ToLower(), out FuelType fuelType) &
                int.TryParse(typeInfo[3], out int numSeats) &
                int.TryParse(typeInfo[4], out int length)
                );

            if (validInputs)
            {
                Console.WriteLine("Thank you. Generating registry information...");

                return new Airplane(ownership[1], ownership[0],
                generalInfo[0], numWheels, mobility,
                numEngines, cylVolume, fuelType, numSeats, length
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
