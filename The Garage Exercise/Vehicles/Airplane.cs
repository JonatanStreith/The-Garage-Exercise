using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Enums;
using The_Garage_Exercise.Tools;

namespace The_Garage_Exercise.Vehicles
{
    internal class Airplane : Vehicle, IVehicle
    {
        private int _numberOfEngines;
        private int _cylinderVolume;
        private FuelType _fuelType;
        private int _numberOfSeats;
        private int _length;

        public Airplane(string license, string owner, Color color, int wheels, Mobility mobility,
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

        public static Vehicle RegisterVehicle(string[] ownership, string[] generalInfo, string[] typeInfo)
        {
            if (ownership.Length != 2 || generalInfo.Length != 3 || typeInfo.Length != 5)
            {
                Console.WriteLine("Sorry, incomplete registration.");
                return null;
            }

            bool validInputs = (    //Assessing if all these inputs are valid
                Color.TryParse(generalInfo[0], out Color color) &
                int.TryParse(generalInfo[1], out int numWheels) &
                Mobility.TryParse(generalInfo[2].ToLower(), out Mobility mobility) &
                int.TryParse(typeInfo[0], out int numEngines) &
                int.TryParse(typeInfo[1], out int cylVolume) &
                FuelType.TryParse(typeInfo[2].ToLower(), out FuelType fuelType) &
                int.TryParse(typeInfo[3], out int numSeats) &
                int.TryParse(typeInfo[4], out int length)
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

                return new Airplane(ownership[1], ownership[0],
                color, numWheels, mobility,
                numEngines, cylVolume, fuelType, numSeats, length
                );
            }
        }
    }
}
