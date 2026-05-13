using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Vehicles;

namespace The_Garage_Exercise
{
    public interface IVehicle
    {


        public string License { get; set; }
        public string Owner { get; set; }
        public string Color { get; set; }
        public int Wheels { get; set; }
        public Mobility Mobility { get; set; }

        internal static abstract Vehicle RegisterVehicle();

    }
}
