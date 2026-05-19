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

            Vehicle vehicle = FindVehicleByLicense(license);

            if (vehicle == null)
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

            Console.WriteLine($"Listing vehicles of category '{input}'.");

            List<Vehicle> results = _garage.Where(vehicle =>
            input == "all" ||
            vehicle.GetType().Name.Equals(input, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            foreach (Vehicle vehicle in results)
            {
                ListSingleVehicle(vehicle);
            }


            if(input == "all")
                Console.WriteLine($"Total {results.Count} vehicles.");
            else
                Console.WriteLine($"Total {results.Count} {input}s.");
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
            return _garage.First<Vehicle>(x => x.License.Equals(license, StringComparison.OrdinalIgnoreCase));
        }

        public void FilterVehicle()
        {
            string aspect = GetInput("You may search for vehicles by certain aspects." +
                                    "\nWhich aspect would you like to search on?" +
                                    "\n(Type, color, number (of wheels), mobility)");

            string value = GetInput("And what are you looking for? (E.g. 'brown', 'car', 4, 'water')");

            List<Vehicle> results = FilterVehiclesByAspect(aspect, value, _garage).ToList();


            Console.WriteLine($"{results.Count} vehicles found.");
            foreach (Vehicle vehicle in results)
            {
                ListSingleVehicle(vehicle);
            }

        }

        public IEnumerable<Vehicle> FilterVehiclesByAspect(string aspect, string value, IEnumerable<Vehicle> collection)
        {


            switch (aspect)
            {
                case "type":
                    {
                        return GetVehiclesByType(value, collection);
                    }
                case "color":
                    {
                        return GetVehiclesByColor(value, collection);
                    }
                case "number":
                    {
                        return GetVehiclesByWheels(value, collection);
                    }
                case "mobility":
                    {
                        return GetVehiclesByMobility(value, collection);
                    }



                default:
                    {
                        Console.WriteLine("This is not a known aspect.");
                        return null;
                    }
            }
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
            return collection.Where(p => p.Color.Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        private IEnumerable<Vehicle> GetVehiclesByType(string value, IEnumerable<Vehicle> collection)
        {
            return collection.Where(p => p.GetType().Name.Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        public string GetInput(string message)      //This function is mostly for stubbing
        {
            Console.WriteLine(message);

            return Console.ReadLine().ToLower();
        }











        public void MultiFilterVehicle()
        {
            Console.WriteLine("This is an experimental feature and may not work properly with faulty inputs." +
                "\nThe proper query format is: [color] [mobility] type [with number wheels] ([] indicate optional inputs)" +
                "\n'Vehicle' may be used to categorize any and all vehicle types. Numericals for wheels only." +
                "\nExample: 'red land car with 4 wheels', 'air bicycle with 1 wheel', 'blue vehicle'." +
                "\n\nPlease type in what vehicle(s) you are looking for. ");

            string[] input = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);


            FilterData data = MultiFilterParse(input);


            List<Vehicle> finalList = PerformFilter(data).ToList();

            foreach (Vehicle vehicle in finalList) 
            {
                ListSingleVehicle(vehicle);

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

            return collection;


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
                        bool success = int.TryParse(input[i-1], out int result);
                        if (success) wheelsFilter = result;
                        else wheelsFilter = -1;
                    }
                    else wheelsFilter = -1;
                }

                else if (i == 0)
                {
                    //If it's the first word and isn't a vehicle or mobility, it's a color
                    colorFilter = input[i];
                }
            }

            return new FilterData(typeFilter, mobilityFilter, colorFilter, wheelsFilter);

        }
    }
}
