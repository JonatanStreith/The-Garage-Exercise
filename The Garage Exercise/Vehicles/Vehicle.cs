using System;
using System.Collections.Generic;
using System.Text;

namespace The_Garage_Exercise.Vehicles
{
    internal abstract class Vehicle
    {
        private string _license;
        private string _owner;
        private string _color;
        private int _wheels;
        private Mobility _mobility;

        public string License { get { return _license; } set { _license = value; } }
        public string Owner { get { return _owner; } set { _owner = value; } }
        public string Color { get { return _color; } set { _color = value; } }
        public int Wheels { get { return _wheels; } set { _wheels = value; } }
        public Mobility Mobility { get { return _mobility; } set { _mobility = value; } }

        public Vehicle(string license, string owner, string color, int wheels, Mobility mobility)
        {
            License = license;
            Owner = owner;
            Color = color;
            Wheels = wheels;
            Mobility = mobility;
        }


        public static Vehicle RegisterVehicle()
        {
            Console.WriteLine("You are required to provide the specifics of your vehicle for the registry." +
                            "\nMultiple inputs must be separated by a comma. Some inputs may be specific types." +
                            "\nFailure to comply may result in failed registration, denied parking, and destruction of vehicle." +
                            "\nAll information is confidential and will be sold to the highest bidder." +
                            "\nPlease ignore the previous sentence." +
                            "\n");


            Vehicle? vehicle;

            Console.WriteLine("Please specify your type of vehicle." +
                "\nAvailable options are: Car, bus, motorcycle, bicycle, boat, and airplane.");
            Console.Write("Vehicle type: ");

            string type = Console.ReadLine().ToLower();

            switch (type)
            {
                case "car":
                    {
                        Console.WriteLine("Your vehicle is identified as a car.");
                        vehicle = Car.RegisterVehicle();
                        break;
                    }

                case "bus":
                    {
                        Console.WriteLine("Your vehicle is identified as a bus.");
                        vehicle = Bus.RegisterVehicle();
                        break;
                    }

                case "motorcycle":
                    {
                        Console.WriteLine("Your vehicle is identified as a motorcycle.");
                        vehicle = Motorcycle.RegisterVehicle();
                        break;
                    }

                case "bicycle":
                    {
                        Console.WriteLine("Your vehicle is identified as a bicycle.");
                        vehicle = Bicycle.RegisterVehicle();
                        break;
                    }

                case "boat":
                    {
                        Console.WriteLine("Your vehicle is identified as a boat.");
                        vehicle = Boat.RegisterVehicle();
                        break;
                    }

                case "airplane":
                    {
                        Console.WriteLine("Your vehicle is identified as an airplane.");
                        vehicle = Airplane.RegisterVehicle();
                        break;
                    }


                default:
                    {
                        Console.WriteLine("That is not an applicable vehicle type.");
                        vehicle = null;
                        break;
                    }
            }

            return vehicle;

        }
    }
}
