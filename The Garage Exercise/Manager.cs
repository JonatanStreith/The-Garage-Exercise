using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Garage;
using The_Garage_Exercise.Tools;
using The_Garage_Exercise.Vehicles;

namespace The_Garage_Exercise
{
    internal class Manager
    {

        private GarageHandler Handler { get; set; }

        internal void InitializeGarage()
        {
            Handler = new GarageHandler();

            Menu.DisplayMenu();

            Menu.MakeChoice(this);

        }

        internal void ListParkedVehicles()
        {
            string listPrompt = "\nPlease specify category of vehicle (or all): ";

            Handler.ListParkedVehicles(Helper.GetInput(listPrompt));
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





            Handler.MultiFilterVehicle(Helper.GetInput(multiFilterPrompt));
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

            Vehicle vehicle = Vehicle.RegisterVehicle();

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

            Handler.RetrieveVehicle(Helper.GetInput(retrievePrompt));
        }
    }
}
