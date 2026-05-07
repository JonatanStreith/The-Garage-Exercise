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
                    spotFound = true;
                    return i;
                }
            }
            return -1;
            //Vehicle spot = System.Array.Find(vehicles, p => p is null);
        }

        public void parkVehicle(Vehicle vehicle)
        {
            int parkingSpot = findEmptySpot(out bool success);

            if (success)
            {
                Console.WriteLine($"Parking spot {parkingSpot} is available.");
                vehicles[parkingSpot] = vehicle;
                Console.WriteLine($"Your {vehicle.GetType}, license number {vehicle.License}, " +
                    $"has been parked in spot {parkingSpot}. Enjoy your stay.");
            }
            else
            {
                Console.WriteLine("Apologies, but there are no free parking spots avilable currently. " +
                    "Please try another garage.");
            }
            //Possibly return the message as a string?
        }

    }
}
