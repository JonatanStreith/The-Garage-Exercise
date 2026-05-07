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

        public Airplane(string license, string owner, string color, int wheels, Mobility mobility, int numberOfEngines, int cylinderVolume, FuelType fuelType, int numberOfSeats, int length) : base(license, owner, color, wheels, mobility)
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

    }
}
