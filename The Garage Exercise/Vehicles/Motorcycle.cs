using System;
using System.Collections.Generic;
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

    }
}
