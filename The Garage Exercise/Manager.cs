using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Garage;

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
            Handler.ListParkedVehicles();
        }

        internal void MultiFilterVehicle()
        {
            Handler.MultiFilterVehicle();
        }

        internal void ParkVehicle()
        {
            Handler.ParkVehicle();
        }

        internal void RetrieveVehicle()
        {
            Handler.RetrieveVehicle();
        }
    }
}
