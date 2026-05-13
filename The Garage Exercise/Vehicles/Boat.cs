using System;
using System.Collections.Generic;
using System.Text;

namespace The_Garage_Exercise.Vehicles
{
    internal class Boat : Vehicle
    {
        private int _cylinderVolume;
        private FuelType _fuelType;
        private int _length;

        public Boat(string license, string owner, string color, int wheels, Mobility mobility, int cylinderVolume, FuelType fuelType, int length) : base(license, owner, color, wheels, mobility)
        {
            CylinderVolume = cylinderVolume;
            FuelType = fuelType;
            Length = length;
        }

        public int CylinderVolume { get { return _cylinderVolume; } set { _cylinderVolume = value; } }
        public FuelType FuelType { get { return _fuelType; } set { _fuelType = value; } }
        public int Length { get { return _length; } set { _length = value; } }

        public static Boat RegisterVehicle()
        {

            Console.Write("Please provide the name of the owner and the license number: ");
            string[] ownership = Console.ReadLine().Split(",");

            Console.WriteLine("Please specify the color, number of wheels (number), " +
                "\nand mobility type (land, air, or water).");
            string[] generalInfo = Console.ReadLine().Split(",");

            Console.WriteLine("Please specify technical details: " +
                "\nCylinder volume (number), fuel type (gasoline or diesel) " +
                "\nand length (number in centimeters).");
            string[] typeInfo = Console.ReadLine().Split(",");

            bool completeInputs = (
ownership.Length == 2 &&
generalInfo.Length == 3 &&
typeInfo.Length == 3
);


            if (completeInputs)
            {
                Boat boat = CreateBoatFromInputs(ownership, generalInfo, typeInfo);
                Console.WriteLine("The boat has been registered.");
                return boat;
            }
            else
                return null;


        }

        public static Boat CreateBoatFromInputs(string[] ownership, string[] generalInfo, string[] typeInfo)
        {


            bool validInputs = (    //Assessing if all these inputs are valid
                int.TryParse(generalInfo[1], out int numWheels) &
                Mobility.TryParse(generalInfo[2].ToLower(), out Mobility mobility) &
                int.TryParse(typeInfo[0], out int cylVolume) &
                FuelType.TryParse(typeInfo[1].ToLower(), out FuelType fuelType) &
                int.TryParse(typeInfo[2], out int length)
                );

            if (validInputs)
            {
                Console.WriteLine("Thank you. Generating registry information...");

                return new Boat(ownership[1], ownership[0],
                generalInfo[0], numWheels, mobility,
                cylVolume, fuelType, length
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
