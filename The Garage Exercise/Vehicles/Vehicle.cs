using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Enums;

namespace The_Garage_Exercise.Vehicles
{
    internal abstract class Vehicle : IVehicle
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
            //Move this to GarageHandler?
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

           if( !Enum.IsDefined(typeof(VehicleTypes), type)){
                Console.WriteLine("That is not an applicable vehicle type.");
                return null;
            }


            Console.Write("Please provide the name of the owner and the license number: ");
            string[] ownership = Console.ReadLine().Split(",").Select(x => x.Trim()).ToArray();

            Console.WriteLine("Please specify the color, number of wheels (number), " +
                "\nand mobility type (land, air, or water).");
            string[] generalInfo = Console.ReadLine().Split(",").Select(x => x.Trim()).ToArray();




            switch (type)
            {
                case "car":
                    {
                        vehicle = Car.RegisterVehicle(ownership, generalInfo);
                        break;
                    }

                case "bus":
                    {
                        vehicle = Bus.RegisterVehicle(ownership, generalInfo);
                        break;
                    }

                case "motorcycle":
                    {
                        vehicle = Motorcycle.RegisterVehicle(ownership, generalInfo);
                        break;
                    }

                case "bicycle":
                    {
                        vehicle = Bicycle.RegisterVehicle(ownership, generalInfo);
                        break;
                    }

                case "boat":
                    {
                        vehicle = Boat.RegisterVehicle(ownership, generalInfo);
                        break;
                    }

                case "airplane":
                    {
                        vehicle = Airplane.RegisterVehicle(ownership, generalInfo);
                        break;
                    }


                default:
                    {
                        Console.WriteLine("Something went wrong.");
                        vehicle = null;
                        break;
                    }
            }

            return vehicle;

        }
    }
}
