using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using The_Garage_Exercise.Garage;
using The_Garage_Exercise.Tools;
using The_Garage_Exercise.Vehicles;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace The_Garage_Exercise.Managers
{
    internal class GarageManager
    {

        private GarageHandler Handler { get; set; }


        private IHelper Help { get; set; }

        internal void InitializeGarage()
        {
            Handler = new GarageHandler(SizeGarage(), PopulateOrNot());

            Help = new Helper();

            Menu.DisplayMenu();

            Menu.MakeChoice(this);

        }



        public static int SizeGarage()
        {
            Console.Write("\nPlease specify size of garage (at least 5 is recommended): ");

            while (true)
            {
                bool success = int.TryParse(Console.ReadLine(), out int size);
                if (success)
                    return size;
                else
                    Console.Write("\nThat is not a legitimate number." +
                    "\nPlease specify size of garage: ");
            }
        }

        public bool PopulateOrNot()
        {
            Console.Write("\nWould you like to populate the garage with preexisting vehicles? (Y/N) [N]\n");

            string populateOrNot = Console.ReadLine().ToLower();

            switch (populateOrNot)
            {
                case "y":
                    {
                        Console.WriteLine("\nOkay, the garage will be populated with five vehicles " +
                            "\n(or fewer depending on size).");
                        return true;
                        //PopulateGarage((_garage.NumberOfParkingSpots < 5) ? _garage.NumberOfParkingSpots : 5);
                    }

                case "n":
                default:
                    {
                        Console.WriteLine("\nThis garage will be empty from the start.");
                        return false;
                    }
            }
        }

        internal void ListParkedVehicles()
        {
            string listPrompt = "\nPlease specify category of vehicle (or all): ";

            string input = Help.GetInput(listPrompt);

            if (input == "") input = "all";

            List<Vehicle> results = Handler.ListParkedVehicles(input);

            Console.WriteLine($"\nListing vehicles of category '{input}':\n");

            foreach (Vehicle vehicle in results)
            {
                ListSingleVehicle(vehicle);
            }


            if (input == "all")
                Console.WriteLine($"Total {results.Count} vehicles.");
            else
                Console.WriteLine($"Total {results.Count} {input}s.");

        }

        internal void MultiFilterVehicle()
        {
            string multiFilterPrompt = "\nYou may filter the vehicle list by specific key words." +
    "\nSpecify [color] [mobility] [type] [n wheels] as desired in any order." +
    "\nExample: 'red land car 4 wheels', 'air bicycle 1 wheel', 'blue 5 wheels vehicle water'." +
    "\n'Vehicle' may be used to categorize any and all vehicle types and will be default if not specified. " +
    "\nNumericals for wheels only. Illegitimate key words will be ignored." +
    "\nIn case of conflicting inputs ('red green air land boat bicycle'), last entry will apply." +
    "\n\nPlease type in what vehicle(s) you are looking for. ";





            (List<Vehicle> finalList, FilterData data) = Handler.MultiFilterVehicle(Help.GetInput(multiFilterPrompt));

            PrintListTitle(finalList.Count, data);

            foreach (Vehicle vehicle in finalList)
            {
                ListSingleVehicle(vehicle);
            }


        }

        internal void ParkVehicle()
        {
            Console.WriteLine("\nYou have chosen to park your vehicle.");

            bool freeSpot = Handler.CheckForFreeSpot();

            if (!freeSpot)
            {
                Console.WriteLine("\nApologies, but there are no free parking spots avilable currently. " +
                    "\nPlease try another garage.");
                return;
            }

            Console.WriteLine($"\nA parking spot is available.");

            Vehicle vehicle = VehicleRegistrationManager.RegisterVehicle(Help);

            if (vehicle == null)
            {
                Console.WriteLine("\nRegistration failed.");
                return;
            }

            Handler.ParkVehicle(vehicle);
        }

        internal void RetrieveVehicle()
        {
            string retrievePrompt = "\nPlease provide the license number of the vehicle you wish to retrieve: ";

            Handler.RetrieveVehicle(Help.GetInput(retrievePrompt));
        }


        private string ListSingleVehicle(Vehicle vehicle)
        {
            Console.WriteLine($"License number: {vehicle.License}, Owner: {vehicle.Owner}, Type: {vehicle.GetType().Name}." +
                $"\nColor: {vehicle.Color}, Number of wheels: {vehicle.Wheels}, Mobility type: {vehicle.Mobility}.");
            switch (vehicle.GetType().Name)
            {
                case "Car":
                    {
                        Console.WriteLine($"Cylinder volume: {(vehicle as Car).CylinderVolume}, Fuel type: {(vehicle as Car).FuelType}. " +
$"Number of seats: {(vehicle as Car).NumberOfSeats}.\n");

                        return "Listed single car.";
                    }
                case "Boat":
                    {
                        Console.WriteLine($"Cylinder volume: {(vehicle as Boat).CylinderVolume}, Fuel type: {(vehicle as Boat).FuelType}. " +
$"Length: {(vehicle as Boat).Length}.\n");

                        return "Listed single boat.";
                    }
                case "Motorcycle":
                    {
                        Console.WriteLine($"Cylinder volume: {(vehicle as Motorcycle).CylinderVolume}, Fuel type: {(vehicle as Motorcycle).FuelType}. \n");
                        return "Listed single motorcycle.";
                    }
                case "Bicycle":
                    {
                        Console.WriteLine($"Number of seats: {(vehicle as Bicycle).NumberOfSeats}.\n");
                        return "Listed single bicycle.";
                    }
                case "Bus":
                    {
                        Console.WriteLine($"Cylinder volume: {(vehicle as Bus).CylinderVolume}, Fuel type: {(vehicle as Bus).FuelType}." +
$"Number of seats: {(vehicle as Bus).NumberOfSeats}, Length: {(vehicle as Bus).Length}.\n");

                        return "Listed single bus.";
                    }
                case "Airplane":
                    {
                        Console.WriteLine($"Number of engines: {(vehicle as Airplane).NumberOfEngines}, Cylinder volume: {(vehicle as Airplane).CylinderVolume}, Fuel type: {(vehicle as Airplane).FuelType}. " +
                            $"Number of seats: {(vehicle as Airplane).NumberOfSeats}, Length: {(vehicle as Airplane).Length}.\n");
                        return "Listed single airplane.";
                    }

                default:
                    {
                        Console.WriteLine("If you can read this, something has gone wrong.\n");
                        return "Default error. Vehicle type not recognized.";
                    }
            }
        }

        private string PrintListTitle(int count, FilterData data)
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
            return "Successful print list title.";
        }


    }
}
