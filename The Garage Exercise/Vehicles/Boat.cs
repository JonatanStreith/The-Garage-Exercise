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

    }
}
