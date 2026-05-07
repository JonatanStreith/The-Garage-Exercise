using System;
using System.Collections.Generic;
using System.Text;

namespace The_Garage_Exercise.Vehicles
{
    internal class Bicycle : Vehicle
    {
        private int _numberOfSeats;

        public Bicycle(string license, string owner, string color, int wheels, Mobility mobility, int numberOfSeats) : base(license, owner, color, wheels, mobility)
        {
            NumberOfSeats = numberOfSeats;
        }

        public int NumberOfSeats { get { return _numberOfSeats; } set { _numberOfSeats = value; } }
    }
}
