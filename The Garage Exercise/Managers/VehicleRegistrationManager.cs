using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Enums;
using The_Garage_Exercise.Vehicles;

namespace The_Garage_Exercise.Managers
{
    internal class VehicleRegistrationManager
    {

        public static Vehicle RegisterVehicle()
        {
            Console.WriteLine("\nYou are required to provide the specifics of your vehicle for the registry." +
                            "\nMultiple inputs must be separated by a comma. Some inputs may be specific types." +
                            "\nFailure to comply may result in failed registration, denied parking, and destruction of vehicle." +
                            "\nAll information is confidential and will be sold to the highest bidder." +
                            "\nPlease ignore the previous sentence.");


            Vehicle? vehicle;

            Console.WriteLine("\nPlease specify your type of vehicle." +
                "\nAvailable options are: Car, bus, motorcycle, bicycle, boat, and airplane.");
            Console.Write("Vehicle type: ");

            string type = Console.ReadLine().ToLower();

            if (!Enum.IsDefined(typeof(VehicleTypes), type))
            {
                Console.WriteLine("That is not an applicable vehicle type.");
                return null;
            }

            Console.Write("Please provide the name of the owner and the license number: ");
            string[] ownership = Console.ReadLine().Split(",").Select(x => x.Trim()).ToArray();

            Console.WriteLine("Please specify the color, number of wheels (number), " +
                "\nand mobility type (land, air, or water).");
            string[] generalInfo = Console.ReadLine().Split(",").Select(x => x.Trim()).ToArray();

            string[] typeInfo;

            switch (type)
            {
                case "car":
                    {
                        Console.WriteLine("Please specify technical details: " +
                            "\nCylinder volume (number), " +
                            "\nfuel type (gasoline or diesel) and number of seats (number).");
                        typeInfo = Console.ReadLine().Split(",").Select(x => x.Trim()).ToArray();

                        return Car.RegisterVehicle(ownership, generalInfo, typeInfo);
                    }

                case "bus":
                    {
                        Console.WriteLine("Please specify technical details: " +
                            "\nCylinder volume (number), " +
                            "\nfuel type (gasoline or diesel), number of seats (number)" +
                            "\nand length (number in centimeters).");
                        typeInfo = Console.ReadLine().Split(",").Select(x => x.Trim()).ToArray();

                        return Bus.RegisterVehicle(ownership, generalInfo, typeInfo);
                    }

                case "motorcycle":
                    {
                        Console.WriteLine("Please specify technical details: " +
                            "\nCylinder volume (number) and fuel type (gasoline or diesel).");
                        typeInfo = Console.ReadLine().Split(",").Select(x => x.Trim()).ToArray();

                        return Motorcycle.RegisterVehicle(ownership, generalInfo, typeInfo);
                    }

                case "bicycle":
                    {
                        Console.WriteLine("Please specify technical details: " +
                            "\nNumber of  seats (number).");
                        typeInfo = Console.ReadLine().Split(",").Select(x => x.Trim()).ToArray();

                        return Bicycle.RegisterVehicle(ownership, generalInfo, typeInfo);
                    }

                case "boat":
                    {
                        Console.WriteLine("Please specify technical details: " +
                            "\nCylinder volume (number), fuel type (gasoline or diesel) " +
                            "\nand length (number in centimeters).");
                        typeInfo = Console.ReadLine().Split(",").Select(x => x.Trim()).ToArray();

                        return Boat.RegisterVehicle(ownership, generalInfo, typeInfo);
                    }

                case "airplane":
                    {
                        Console.WriteLine("Please specify technical details: " +
                            "\nNumber of engines (number), cylinder volume (number), " +
                            "\nfuel type (gasoline or diesel), number of seats (number)" +
                            "\nand length (number in centimeters).");
                        typeInfo = Console.ReadLine().Split(",").Select(x => x.Trim()).ToArray();

                        return Airplane.RegisterVehicle(ownership, generalInfo, typeInfo);
                    }

                default:
                    {
                        Console.WriteLine("Something went wrong.");
                        return null;
                        break;
                    }
            }

            return vehicle;
        }
    }
}
