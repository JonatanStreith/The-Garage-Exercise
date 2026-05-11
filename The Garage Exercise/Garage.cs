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
            this.numberOfParkingSpots = numberOfParkingSpots;
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
        }

        public void ParkVehicle()
        {
            Console.WriteLine("You have chosen to park your vehicle.");
            Vehicle vehicle = Vehicle.RegisterVehicle();

            if (vehicle != null)
            {
                ParkVehicle(vehicle);
            }
            else
                Console.WriteLine("Parking aborted.");
        }
        public void ParkVehicle(Vehicle vehicle)
        {
            int parkingSpot = FindEmptySpot(out bool success);

            if (success)
            {
                Console.WriteLine($"Parking spot {parkingSpot} is available.");

                bool duplicate = (FindVehicleByLicense(vehicle.License) != null);
                //If we attempt to find a vehicle with the same license number and
                //it doesn't return null, we have a duplicate.

                if (duplicate)
                {
                    Console.WriteLine("Illegitimate license number. " +
                        "\nA vehicle with the same number already exist in the garage. " +
                        "\nPolice has been alerted.");
                }
                else
                {
                    vehicles[parkingSpot] = vehicle;
                    Console.WriteLine($"Your {vehicle.GetType().Name}, license number {vehicle.License}, " +
                        $"has been parked in spot {parkingSpot}. Enjoy your stay.");
                }

            }
            else
            {
                Console.WriteLine("Apologies, but there are no free parking spots avilable currently. " +
                    "\nPlease try another garage.");
            }
            //Possibly return the message as a string?
        }

        public void RetrieveVehicle()
        {
            Console.Write("Please provide the license number of the vehicle you wish to retrieve: ");
            string license = Console.ReadLine();

            bool vehicleFound = false;

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i].License == license)
                {
                    vehicles[i] = null;
                    vehicleFound = true;
                    break;
                }
            }

            if (vehicleFound == false) {
                Console.WriteLine("No vehicle with that number exists in the garage." +
    "\nDid you input the license number correctly?");

            }
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


        public Vehicle FindVehicleByLicense(string license)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if (
                    (vehicle != null) &&
                    (vehicle.License.Equals(license))
                    )
                { return vehicle; }
            }

            return null;
        }
    }
}
