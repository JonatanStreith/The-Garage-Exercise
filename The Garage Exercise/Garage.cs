using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Vehicles;

namespace The_Garage_Exercise
{
    internal class Garage
    {
        public readonly int numberOfParkingSpots;
        public List<Vehicle> vehicles;
        public int currentOccupancy;

        public Garage(int numberOfParkingSpots)
        {
            vehicles = new List<Vehicle>();
            this.numberOfParkingSpots = numberOfParkingSpots;
            currentOccupancy = 0;
        }

        public void ParkVehicle()       //Return a resultcode?
        {
            Console.WriteLine("You have chosen to park your vehicle.");



            if(numberOfParkingSpots <= currentOccupancy)    //Are there not more spots than are used?
            {
                Console.WriteLine("Apologies, but there are no free parking spots avilable currently. " +
                                    "\nPlease try another garage.");
                return;
            }


            Vehicle vehicle = Vehicle.RegisterVehicle();

            if (vehicle == null)
            {
                Console.WriteLine("Vehicle cannot be parked due to non-existence.");
                return;
            }


                Console.WriteLine($"A parking spot is available.");

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
                    vehicles.Add(vehicle);
                    currentOccupancy++;

                    Console.WriteLine($"Your {vehicle.GetType().Name}, license number {vehicle.License}, " +
                        $"has been parked. Enjoy your stay.");
                }

        }

        public void RetrieveVehicle()
        {
            Console.Write("Please provide the license number of the vehicle you wish to retrieve: ");
            string license = Console.ReadLine();

            bool vehicleFound = false;

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.License.Equals(license, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Your vehicle, a {vehicle.GetType().Name} owned by {vehicle.Owner}, has been located." +
                        $"\nYou may now leave the garage.");
                    vehicles.Remove(vehicle);
                    vehicleFound = true;
                    currentOccupancy--;
                    break;
                }
            }

            if (vehicleFound == false)
            {
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
            Console.Write("Please specify category of vehicle (or all): ");

            string input = Console.ReadLine().ToLower();

            int counter = 0;


            Console.WriteLine($"Listing vehicles of category '{input}'.");

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle != null)
                    if ((input == "all") || (input == vehicle.GetType().Name.ToLower()))
                    {
                        counter++;
                        ListSingleVehicle(vehicle);
                    }
            }

            Console.WriteLine($"Total  {counter} {input}s.");
        }

        public void ListSingleVehicle(Vehicle vehicle)
        {
            Console.WriteLine($"License number: {vehicle.License}, Owner: {vehicle.Owner}, Type: {vehicle.GetType().Name}." +
                $"\nColor: {vehicle.Color}, Number of wheels: {vehicle.Wheels}, Mobility type: {vehicle.Mobility}.");
            switch (vehicle.GetType().Name)
            {
                case "Car":
                    {
                        Console.WriteLine($"Cylinder volume: {(vehicle as Car).CylinderVolume}, Fuel type: {(vehicle as Car).FuelType}. " +
$"Number of seats: {(vehicle as Car).NumberOfSeats}.\n");

                        break;
                    }
                case "Boat":
                    {
                        Console.WriteLine($"Cylinder volume: {(vehicle as Boat).CylinderVolume}, Fuel type: {(vehicle as Boat).FuelType}. " +
$"Length: {(vehicle as Boat).Length}.\n");

                        break;
                    }
                case "Motorcycle":
                    {
                        Console.WriteLine($"Cylinder volume: {(vehicle as Motorcycle).CylinderVolume}, Fuel type: {(vehicle as Motorcycle).FuelType}. \n");
                        break;
                    }
                case "Bicycle":
                    {
                        Console.WriteLine($"Number of seats: {(vehicle as Bicycle).NumberOfSeats}.\n");
                        break;
                    }
                case "Bus":
                    {
                        Console.WriteLine($"Cylinder volume: {(vehicle as Bus).CylinderVolume}, Fuel type: {(vehicle as Bus).FuelType}." +
$"Number of seats: {(vehicle as Bus).NumberOfSeats}, Length: {(vehicle as Bus).Length}.\n");

                        break;
                    }
                case "Airplane":
                    {
                        Console.WriteLine($"Number of engines: {(vehicle as Airplane).NumberOfEngines}, Cylinder volume: {(vehicle as Airplane).CylinderVolume}, Fuel type: {(vehicle as Airplane).FuelType}. " +
                            $"Number of seats: {(vehicle as Airplane).NumberOfSeats}, Length: {(vehicle as Airplane).Length}.\n");
                        break;
                    }

                default:
                    {
                        Console.WriteLine("If you can read this, something has gone wrong.\n");
                        break;
                    }
            }

        }

        public void PopulateGarage(int number)
        {
            Console.WriteLine("Garage is being populated, probably.");


            Vehicle v1 = new Car("123ABC", "Stefan Sjögall", "black", 4, Mobility.land, 45, FuelType.gasoline, 4);
            Vehicle v2 = new Boat("448JXR", "Captain Crunch", "brown", 0, Mobility.water, 45, FuelType.gasoline, 1200);
            Vehicle v3 = new Airplane("WSB-8840", "Baloo", "red", 0, Mobility.air, 30, 4, FuelType.gasoline, 12, 1800);
            Vehicle v4 = new Motorcycle("FRIENDSHIP", "Kamen Rider Fourze", "white", 2, Mobility.land, 45, FuelType.gasoline);
            Vehicle v5 = new Bus("MAGIC", "Mrs Frizzle", "yellow", 8, Mobility.land, 45, FuelType.gasoline, 28, 1800);

            Vehicle[] populate = { v1, v2, v3, v4, v5 };

            for (int i = 0; i < number; i++)
            {
                vehicles.Add(populate[i]);
                currentOccupancy++;
            }
        }


        public Vehicle FindVehicleByLicense(string license)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if (
                    (vehicle != null) &&
                    vehicle.License.Equals(license, StringComparison.OrdinalIgnoreCase)
                    )
                { return vehicle; }
            }

            return null;
        }

    public void FilterVehicle()
        {
            Console.WriteLine("You may search for vehicles by certain aspects.");
            Console.WriteLine("\nWhich aspect would you like to search on? " +
                "\n(Type, color, number (of wheels), mobility)");
            string aspect = Console.ReadLine();

            Console.WriteLine("And what are you looking for? (E.g. 'brown', 'car', 4, 'water')");
            string value = Console.ReadLine().ToLower();

            Vehicle[] results = FilterVehiclesByAspect(aspect, value);


            Console.WriteLine($"{results.Length} vehicles found.");
            foreach (Vehicle vehicle in results)
            {
                ListSingleVehicle(vehicle);
            }

        }

        public Vehicle[] FilterVehiclesByAspect(string aspect, string value)
        {
            Vehicle[] filteredVehicles = null;

            switch (aspect)
            {
                case "type":
                    {
                        return GetVehiclesByType(value);
                        break;
                    }
                case "color":
                    {
                        return GetVehiclesByColor(value);
                        break;
                    }
                case "number":
                    {
                        return GetVehiclesByWheels(value);
                        break;
                    }
                case "mobility":
                    {
                        return GetVehiclesByMobility(value);
                        break;
                    }



                default:
                    {
                        Console.WriteLine("This is not a known aspect.");
                        return null;
                        break;
                    }
            }
        }

        private Vehicle[] GetVehiclesByMobility(string value)
        {
            return vehicles.Where(p => p.Mobility.ToString().Equals(value, StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        private Vehicle[] GetVehiclesByWheels(string value)
        {
            return vehicles.Where(p => p.Wheels.ToString().Equals(value, StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        private Vehicle[] GetVehiclesByColor(string value)
        {
            return vehicles.Where(p => p.Color.Equals(value, StringComparison.OrdinalIgnoreCase)).ToArray();
            throw new NotImplementedException();
        }

        private Vehicle[] GetVehiclesByType(string value)
        {
            return vehicles.Where(p => p.GetType().Name.Equals(value, StringComparison.OrdinalIgnoreCase)).ToArray();
        }
    }
}