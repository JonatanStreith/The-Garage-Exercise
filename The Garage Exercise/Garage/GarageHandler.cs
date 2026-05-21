using System;
using System.Collections;
using System.Collections.Generic;
using The_Garage_Exercise.Enums;
using The_Garage_Exercise.Tools;
using The_Garage_Exercise.Vehicles;

namespace The_Garage_Exercise.Garage
{
    internal class GarageHandler
    {
        private readonly Garage<Vehicle> _garage;
        public GarageHandler(int size, bool populate)
        {
            _garage = new Garage<Vehicle>(size);
            Console.WriteLine("\nA new garage has been erected.");

            if (populate)
            {
                PopulateGarage((size < 5) ? size : 5);
            }
        }

        internal Garage<Vehicle> Garage { get; }
        private void PopulateGarage(int number)
        {
            Console.WriteLine("\nGarage is being populated.");

            Vehicle v1 = new Car("123ABC", "Stefan Sjögall", Color.black, 4, Mobility.land, 45, FuelType.gasoline, 4);
            Vehicle v2 = new Boat("448JXR", "Captain Crunch", Color.brown, 0, Mobility.water, 45, FuelType.gasoline, 1200);
            Vehicle v3 = new Airplane("WSB-8840", "Baloo", Color.red, 0, Mobility.air, 30, 4, FuelType.gasoline, 12, 1800);
            Vehicle v4 = new Motorcycle("FRIENDSHIP", "Kamen Rider Fourze", Color.white, 2, Mobility.land, 45, FuelType.gasoline);
            Vehicle v5 = new Bus("MAGIC", "Mrs Frizzle", Color.yellow, 8, Mobility.land, 45, FuelType.gasoline, 28, 1800);

            Vehicle[] populate = { v1, v2, v3, v4, v5 };

            for (int i = 0; i < number; i++)
            {
                _garage.Add(populate[i]);
            }
        }

        public void ParkVehicle(Vehicle vehicle)       //Return a resultcode?
        {

            if (vehicle == null) 
            { 
                Console.WriteLine("You are trying to park a non-existent vehicle." +
                    "\nThis is not possible.");
                return;
            }
            //If we attempt to find a vehicle with the same license number and
            //it doesn't return null, we have a duplicate.
            if (CheckForDuplicate(vehicle.License))
            {
                Console.WriteLine("\nIllegitimate license number. " +
                    "\nA vehicle with the same number already exist in the garage. " +
                    "\nPolice has been alerted.");
            }
            else
            {
                _garage.Add(vehicle);

                Console.WriteLine($"\nYour {vehicle.GetType().Name}, license number {vehicle.License}, " +
                    $"has been parked. Enjoy your stay.");
            }

        }

        public void RetrieveVehicle(string license)
        {

            Vehicle vehicle = FindVehicleByLicense(license);

            if (vehicle == null)
            {
                Console.WriteLine("\nNo vehicle with that number exists in the garage." +
                "\nDid you input the license number correctly?");
            }
            else
            {
                Console.WriteLine($"\nYour vehicle, a {vehicle.GetType().Name} owned by {vehicle.Owner}, has been located and retrieved." +
                $"\nYou may now leave the garage.");
                _garage.Remove(vehicle);
            }
        }

        public void ListParkedVehicles(string input)
        {
            if (input == "") input = "all";

            Console.WriteLine($"\nListing vehicles of category '{input}':\n");

            List<Vehicle> results = _garage.Where(vehicle =>
            input == "all" ||
            vehicle.GetType().Name.Equals(input, StringComparison.OrdinalIgnoreCase)
            ).OrderBy(vehicle => vehicle.GetType().Name).ToList();

            foreach (Vehicle vehicle in results)
            {
                ListSingleVehicle(vehicle);
            }


            if (input == "all")
                Console.WriteLine($"Total {results.Count} vehicles.");
            else
                Console.WriteLine($"Total {results.Count} {input}s.");
        }

        private void ListSingleVehicle(Vehicle vehicle)
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

        public void MultiFilterVehicle(string input)
        {
            string[] filterValues = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            FilterData data = MultiFilterParse(filterValues);

            List<Vehicle> finalList = PerformFilter(data).ToList();

            PrintListTitle(finalList.Count, data);

            foreach (Vehicle vehicle in finalList)
            {
                ListSingleVehicle(vehicle);
            }
        }

        private Vehicle FindVehicleByLicense(string license)
        {
            return _garage.FirstOrDefault<Vehicle>(x => x.License.Equals(license, StringComparison.OrdinalIgnoreCase), null);
        }
        private IEnumerable<Vehicle> GetVehiclesByMobility(string value, IEnumerable<Vehicle> collection)
        {
            return collection.Where(p => p.Mobility.ToString().Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        private IEnumerable<Vehicle> GetVehiclesByWheels(string value, IEnumerable<Vehicle> collection)
        {
            return collection.Where(p => p.Wheels.ToString().Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        private IEnumerable<Vehicle> GetVehiclesByColor(string value, IEnumerable<Vehicle> collection)
        {
            return collection.Where(p => p.Color.ToString().Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        private IEnumerable<Vehicle> GetVehiclesByType(string value, IEnumerable<Vehicle> collection)
        {
            return collection.Where(p => p.GetType().Name.Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        private void PrintListTitle(int count, FilterData data)
        {

            if (data.IsEmpty())
            {
                Console.WriteLine($"\nNo filters. {count} (all) entires found.");
            }
            else
            {
                Console.Write($"\n{count} entires found matching the search for");

                if (data.ColorFilter != null) { Console.Write($" '{data.ColorFilter}'"); }
                if (data.MobilityFilter != null) { Console.Write($" '{data.MobilityFilter}'"); }
                if (data.TypeFilter != null) { Console.Write($" '{data.TypeFilter}'"); }
                if (data.WheelsFilter != -1) { Console.Write($" '{data.WheelsFilter} wheel(s)'"); }
                Console.WriteLine(".\n");
            }

        }
        private IEnumerable<Vehicle> PerformFilter(FilterData data)
        {

            IEnumerable<Vehicle> collection;

            //If input was for 'vehicle' or no legit type was entered, just give us all vehicles                
            if (data.TypeFilter != null && data.TypeFilter != "vehicle")
                collection = GetVehiclesByType(data.TypeFilter, _garage);
            else collection = _garage;

            //Filter the existing collection step by step
            if (data.MobilityFilter != null)
                collection = GetVehiclesByMobility(data.MobilityFilter, collection);

            if (data.WheelsFilter != -1)
                collection = GetVehiclesByWheels(data.WheelsFilter.ToString(), collection);

            if (data.ColorFilter != null)
                collection = GetVehiclesByColor(data.ColorFilter, collection);

            return collection.OrderBy(vehicle => vehicle.GetType().Name);
        }

        private FilterData MultiFilterParse(string[] input)
        {
            string? typeFilter = null;
            string? mobilityFilter = null;
            string? colorFilter = null;
            int wheelsFilter = -1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == "vehicle" || Enum.IsDefined(typeof(VehicleTypes), input[i]))
                {
                    //This input is a vehicle
                    typeFilter = input[i];
                }

                else if (Enum.IsDefined(typeof(Color), input[i]))
                {
                    //This input is a color
                    colorFilter = input[i];
                }

                else if (Enum.IsDefined(typeof(Mobility), input[i]))
                {
                    //This input is a mobility
                    mobilityFilter = input[i];
                }

                else if (input[i] == "wheels" || input[i] == "wheel")
                {
                    //input i-1 (the preceding one), if not less than 0, should be a number
                    if (i - 1 >= 0)
                    {
                        bool success = int.TryParse(input[i - 1], out int result);
                        if (success) wheelsFilter = result;
                        else wheelsFilter = -1;
                    }
                    else wheelsFilter = -1;
                }
            }

            return new FilterData(typeFilter, mobilityFilter, colorFilter, wheelsFilter);
        }

        internal bool CheckForFreeSpot()
        {
            if (_garage.NumberOfParkingSpots > _garage.CurrentOccupancy)    //Are there more spots than are used?
            {
                return true;
            }
            else return false;
        }

        private bool CheckForDuplicate(string license)
        {
            return FindVehicleByLicense(license) != null;
        }
    }
}
