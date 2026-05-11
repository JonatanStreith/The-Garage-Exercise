using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace The_Garage_Exercise.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        private int _cylinderVolume;
        private FuelType _fuelType;

        public Motorcycle(string license, string owner, string color, int wheels, Mobility mobility, int cylinderVolume, FuelType fuelType) : base(license, owner, color, wheels, mobility)
        {
            CylinderVolume = cylinderVolume;
            FuelType = fuelType;
        }

        public int CylinderVolume { get { return _cylinderVolume; } set { _cylinderVolume = value; } }
        public FuelType FuelType { get { return _fuelType; } set { _fuelType = value; } }

        public static Motorcycle RegisterVehicle()
        {

            Console.WriteLine("Please provide the name of the owner and the license number.");
            string[] ownership = Console.ReadLine().Split(",");

            Console.WriteLine("Please specify the color, number of wheels (number), " +
                "\nand mobility type (land, air, or water).");
            string[] generalInfo = Console.ReadLine().Split(",");

            Console.WriteLine("Please specify technical details: " +
                "\nCylinder volume (number) and fuel type (gasoline or dieslel).");
            string[] typeInfo = Console.ReadLine().Split(",");

            bool completeInputs = (
    ownership.Length == 2 ||
    generalInfo.Length == 3 ||
    typeInfo.Length == 2
    );

            if (completeInputs)
            {
                Motorcycle cycle = CreateMotorcycleFromInputs(ownership, generalInfo, typeInfo);
                Console.WriteLine("The motorcycle has been registered.");
                return cycle;
            }
            else
                return null;

        }

        public static Motorcycle CreateMotorcycleFromInputs(string[] ownership, string[] generalInfo, string[] typeInfo)
        {

            bool validInputs = (    //Assessing if all these inputs are valid
                int.TryParse(generalInfo[1], out int numWheels) &
                Mobility.TryParse(generalInfo[2].ToLower(), out Mobility mobility) &
                int.TryParse(typeInfo[0], out int cylVolume) &
                FuelType.TryParse(typeInfo[1].ToLower(), out FuelType fuelType)
                );

            if (validInputs)
            {
                Console.WriteLine("Thank you. Generating registry information...");

                return new Motorcycle(ownership[1], ownership[0],
                generalInfo[0], numWheels, mobility,
                cylVolume, fuelType
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
