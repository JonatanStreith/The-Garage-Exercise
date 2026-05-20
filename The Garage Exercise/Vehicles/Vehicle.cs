using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Enums;
using The_Garage_Exercise.Tools;

namespace The_Garage_Exercise.Vehicles
{
    internal abstract class Vehicle
    {
        private string _license;
        private string _owner;
        private Color _color;
        private int _wheels;
        private Mobility _mobility;

        public string License { get { return _license; } set { _license = value; } }
        public string Owner { get { return _owner; } set { _owner = value; } }
        public Color Color { get { return _color; } set { _color = value; } }
        public int Wheels { get { return _wheels; } set { _wheels = value; } }
        public Mobility Mobility { get { return _mobility; } set { _mobility = value; } }

        public Vehicle(string license, string owner, Color color, int wheels, Mobility mobility)
        {
            License = license;
            Owner = owner;
            Color = color;
            Wheels = wheels;
            Mobility = mobility;
        }
    }
}
