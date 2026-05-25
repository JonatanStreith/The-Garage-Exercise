using System;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Enums;
using The_Garage_Exercise.Tools;
using The_Garage_Exercise.Vehicles;

namespace The_Garage_Exercise.Managers
{
    internal class VehicleRegistrationManager
    {
        public static Vehicle RegisterVehicle()
        {
            string registerMessage = "\nYou are required to provide the specifics of your vehicle for the registry." +
                            "\nMultiple inputs must be separated by a comma. Some inputs may be specific types." +
                            "\nFailure to comply may result in failed registration, denied parking, and destruction of vehicle." +
                            "\nAll information is confidential and will be sold to the highest bidder." +
                            "\nPlease ignore the previous sentence.";
            string specTypePrompt = "\nPlease specify your type of vehicle." +
                "\nAvailable options are: Car, bus, motorcycle, bicycle, boat, and airplane.";

            string ownershipPrompt = "Please provide the name of the owner and the license number:";
            string generalInfoPrompt = "Please specify the color, number of wheels (number), " +
                "\nand mobility type (land, air, or water).";

            string carTypePrompt = "Please specify technical details: " +
                "\nCylinder volume (number), " +
                "\nfuel type (gasoline or diesel) and number of seats (number).";
            string busTypePrompt = "Please specify technical details: " +
                            "\nCylinder volume (number), " +
                            "\nfuel type (gasoline or diesel), number of seats (number)" +
                            "\nand length (number in centimeters).";
            string airplaneTypePrompt = "Please specify technical details: " +
                        "\nNumber of engines (number), cylinder volume (number), " +
                        "\nfuel type (gasoline or diesel), number of seats (number)" +
                        "\nand length (number in centimeters).";
            string boatTypePrompt = "Please specify technical details: " +
                        "\nCylinder volume (number), fuel type (gasoline or diesel) " +
                        "\nand length (number in centimeters).";
            string motorcycleTypePrompt = "Please specify technical details: " +
                        "\nCylinder volume (number) and fuel type (gasoline or diesel).";
            string bicycleTypePrompt = "Please specify technical details: " +
                        "\nNumber of  seats (number).";

            string invalidType = "That is not an applicable vehicle type.";
            string defaultError = "Something went wrong.";

            Console.WriteLine(registerMessage);

            Vehicle? vehicle;

            string type = Helper.GetInput(specTypePrompt);

            if (!Enum.IsDefined(typeof(VehicleTypes), type))
            {
                Console.WriteLine(invalidType);
                return null;
            }

            string[] ownership = Helper.GetInput(ownershipPrompt)
                .Split(",").Select(x => x.Trim()).ToArray();

            string[] generalInfo = Helper.GetInput(generalInfoPrompt)
                .Split(",").Select(x => x.Trim()).ToArray();

            string[] typeInfo;

            switch (type)
            {
                case "car":
                    {
                        typeInfo = Helper.GetInput(carTypePrompt)
                            .Split(",").Select(x => x.Trim()).ToArray();

                        return Car.RegisterVehicle(ownership, generalInfo, typeInfo);
                    }

                case "bus":
                    {
                        typeInfo = Helper.GetInput(busTypePrompt).Split(",").Select(x => x.Trim()).ToArray();

                        return Bus.RegisterVehicle(ownership, generalInfo, typeInfo);
                    }

                case "motorcycle":
                    {
                        typeInfo = Helper.GetInput(motorcycleTypePrompt).Split(",").Select(x => x.Trim()).ToArray();

                        return Motorcycle.RegisterVehicle(ownership, generalInfo, typeInfo);
                    }

                case "bicycle":
                    {
                        typeInfo = Helper.GetInput(bicycleTypePrompt).Split(",").Select(x => x.Trim()).ToArray();

                        return Bicycle.RegisterVehicle(ownership, generalInfo, typeInfo);
                    }

                case "boat":
                    {
                        typeInfo = Helper.GetInput(boatTypePrompt).Split(",").Select(x => x.Trim()).ToArray();

                        return Boat.RegisterVehicle(ownership, generalInfo, typeInfo);
                    }

                case "airplane":
                    {
                        typeInfo = Helper.GetInput(airplaneTypePrompt).Split(",").Select(x => x.Trim()).ToArray();

                        return Airplane.RegisterVehicle(ownership, generalInfo, typeInfo);
                    }
                default:
                    {
                        Console.WriteLine(defaultError);
                        return null;
                    }
            }
        }
    }
}
