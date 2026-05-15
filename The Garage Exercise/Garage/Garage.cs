using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Vehicles;

namespace The_Garage_Exercise.Garage
{
    internal class Garage
    {
        internal readonly int numberOfParkingSpots;
        internal List<Vehicle> vehicles;
        internal int currentOccupancy;

        public Garage(int numberOfParkingSpots)
        {
            vehicles = new List<Vehicle>();
            this.numberOfParkingSpots = numberOfParkingSpots;
            currentOccupancy = 0;
        }
    }
}