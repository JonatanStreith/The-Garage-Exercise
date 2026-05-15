using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Enums;

namespace The_Garage_Exercise.Vehicles
{
    internal class Boat : Vehicle, IVehicle
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

        public static Boat RegisterVehicle(string[] ownership, string[] generalInfo)
        {

            Console.WriteLine("Please specify technical details: " +
                "\nCylinder volume (number), fuel type (gasoline or diesel) " +
                "\nand length (number in centimeters).");
            string[] typeInfo = Console.ReadLine().Split(",").Select(x => x.Trim()).ToArray();


                return CreateBoatFromInputs(ownership, generalInfo, typeInfo);

        }

        public static Boat CreateBoatFromInputs(string[] ownership, string[] generalInfo, string[] typeInfo)
        {

            if (ownership.Length != 2 || generalInfo.Length != 3 || typeInfo.Length != 3)
            {
                Console.WriteLine("Sorry, incomplete registration.");
                return null;
            }


            bool validInputs = (    //Assessing if all these inputs are valid
                int.TryParse(generalInfo[1], out int numWheels) &
                Mobility.TryParse(generalInfo[2].ToLower(), out Mobility mobility) &
                int.TryParse(typeInfo[0], out int cylVolume) &
                FuelType.TryParse(typeInfo[1].ToLower(), out FuelType fuelType) &
                int.TryParse(typeInfo[2], out int length)
                );

            if (!validInputs)
            {
                Console.WriteLine("There were errors and the registration could not be completed." +
                "\nPlease try again later.");
                return null;
            }

            else
            {
                Console.WriteLine("Thank you. Generating registry information...");

                return new Boat(ownership[1], ownership[0],
                generalInfo[0], numWheels, mobility,
                cylVolume, fuelType, length
                );
            }
        }

    }
}
