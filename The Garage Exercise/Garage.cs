using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Vehicles;

namespace The_Garage_Exercise
{
    internal class Garage
    {

        Vehicle[] vehicles;

        public Garage(int parkingSpots)
        {
            vehicles = new Vehicle[parkingSpots];
        }

        public int findEmptySpot(out bool spotFound)        //Returns a spot number, and a bool confirming the find
        {
            int emptySpot;
            spotFound = false;

            for (int i = 0; i < vehicles.Length; i++)

            {
                if (vehicles[i] is null)
                {
                    spotFound=true;
                    return i;
                }
            }
            return -1;
            //Vehicle spot = System.Array.Find(vehicles, p => p is null);
        }

    }
}
