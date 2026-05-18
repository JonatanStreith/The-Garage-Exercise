using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Enums;
using The_Garage_Exercise.Vehicles;

namespace The_Garage_Exercise.Garage
{
    internal class GarageHandler
    {
        private Garage<Vehicle> _garage;
        public GarageHandler()
        {
            _garage = new Garage<Vehicle>(SizeGarage());
            Console.WriteLine("\nA new garage has been erected.");

            PopulateOrNot();
        }

        public static int SizeGarage()
        {
            Console.Write("Please specify size of garage (at least 5 is recommended): ");

            while (true)
            {
                bool success = int.TryParse(Console.ReadLine(), out int size);
                if (success)
                    return size;
                else
                    Console.Write("That is not a legitimate number." +
                    "\nPlease specify size of garage: ");
            }

        }

        public void PopulateOrNot()
        {
            Console.Write("Would you like to populate the garage with preexisting vehicles? (Y/N) [N]\n");

            string populateOrNot = Console.ReadLine().ToLower();
            
            switch (populateOrNot)
            {
                case "y":
                    {
                        Console.WriteLine("Okay, the garage will be populated with five vehicles " +
                            "\n(or fewer depending on size).");

                        PopulateGarage((_garage.NumberOfParkingSpots < 5) ? _garage.NumberOfParkingSpots : 5);
                        break;
                    }

                case "n":
                default:
                    {
                        Console.WriteLine("This garage will be empty from the start.");
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
                _garage.Add(populate[i]);
            }
        }



        public void ParkVehicle()       //Return a resultcode?
        {
            Console.WriteLine("You have chosen to park your vehicle.");



            if (_garage.NumberOfParkingSpots <= _garage.CurrentOccupancy)    //Are there not more spots than are used?
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
                _garage.Add(vehicle);

                Console.WriteLine($"Your {vehicle.GetType().Name}, license number {vehicle.License}, " +
                    $"has been parked. Enjoy your stay.");
            }

        }

        public void RetrieveVehicle()
        {
            string license = GetInput("Please provide the license number of the vehicle you wish to retrieve: ");

            Vehicle vehicle = _garage.First<Vehicle>(x => x.License == license);

            if(vehicle == null)
            {
                Console.WriteLine("No vehicle with that number exists in the garage." +
                "\nDid you input the license number correctly?");
            }
            else
            {
                Console.WriteLine($"Your vehicle, a {vehicle.GetType().Name} owned by {vehicle.Owner}, has been located." +
                $"\nYou may now leave the garage.");
                _garage.Remove(vehicle);
            }
        }

        public void ListParkedVehicles()
        {
            string input = GetInput("Please specify category of vehicle (or all): ");

            int counter = 0;


            Console.WriteLine($"Listing vehicles of category '{input}'.");

            foreach (Vehicle vehicle in _garage)
            {
                if (vehicle != null)
                    if ((input == "all") || (input == vehicle.GetType().Name.ToLower()))
                    {
                        counter++;
                        ListSingleVehicle(vehicle);
                    }
            }

            if(input == "all") 
                Console.WriteLine($"Total {counter} vehicles.");
            else 
            Console.WriteLine($"Total {counter} {input}s.");
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



        public Vehicle FindVehicleByLicense(string license)
        {
            foreach (Vehicle vehicle in _garage)
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
            string aspect = GetInput("You may search for vehicles by certain aspects." +
                                    "\nWhich aspect would you like to search on?" +
                                    "\n(Type, color, number (of wheels), mobility)");

            string value = GetInput("And what are you looking for? (E.g. 'brown', 'car', 4, 'water')");

            List<Vehicle> results = FilterVehiclesByAspect(aspect, value);


            Console.WriteLine($"{results.Count} vehicles found.");
            foreach (Vehicle vehicle in results)
            {
                ListSingleVehicle(vehicle);
            }

        }

        public List<Vehicle> FilterVehiclesByAspect(string aspect, string value)
        {
            

            switch (aspect)
            {
                case "type":
                    {
                        return GetVehiclesByType(value);
                    }
                case "color":
                    {
                        return GetVehiclesByColor(value);
                    }
                case "number":
                    {
                        return GetVehiclesByWheels(value);
                    }
                case "mobility":
                    {
                        return GetVehiclesByMobility(value);
                    }



                default:
                    {
                        Console.WriteLine("This is not a known aspect.");
                        return null;
                    }
            }
        }

        private List<Vehicle> GetVehiclesByMobility(string value)
        {
            return _garage.Where(p => p.Mobility.ToString().Equals(value, StringComparison.OrdinalIgnoreCase)).ToList<Vehicle>();
        }

        private List<Vehicle> GetVehiclesByWheels(string value)
        {
            return _garage.Where(p => p.Wheels.ToString().Equals(value, StringComparison.OrdinalIgnoreCase)).ToList<Vehicle>();
        }

        private List<Vehicle> GetVehiclesByColor(string value)
        {
            return _garage.Where(p => p.Color.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList<Vehicle>();
            throw new NotImplementedException();
        }

        private List<Vehicle> GetVehiclesByType(string value)
        {
            return _garage.Where(p => p.GetType().Name.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList<Vehicle>();
        }

        public string GetInput(string message)      //This function is mostly for stubbing
        {
            Console.WriteLine(message);

            return Console.ReadLine().ToLower();
        }
    }
}
