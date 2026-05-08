using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Vehicles;

namespace The_Garage_Exercise
{
    internal class Garage
    {
        public readonly int numberOfParkingSpots;
        private Vehicle[] vehicles;

        public Garage(int numberOfParkingSpots)
        {
            vehicles = new Vehicle[numberOfParkingSpots];
            this.numberOfParkingSpots =numberOfParkingSpots;
        }

        public int FindEmptySpot(out bool spotFound)        //Returns a spot number, and a bool confirming the find
        {
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

        public void ParkVehicle(Vehicle vehicle)
        {
            int parkingSpot = FindEmptySpot(out bool success);

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

        public void RemoveVehicle(Vehicle vehicle)
        {
            Console.WriteLine("Vehicle will be removed.");

        }

        public void DestroyVehicle(Vehicle vehicle)
        {
            Console.WriteLine("Preparing wrecking crew...");

        }

        public void DestroyGarage()
        {
            Console.WriteLine("Garage is slated for destruction.");
        }

        public void ListParkedVehicles()
        {
            Console.WriteLine("Listing vehicles.");
        }

        public void PopulateGarage(int number)
        {
            Console.WriteLine("Garage is being populated, probably.");
        }
    }
}
