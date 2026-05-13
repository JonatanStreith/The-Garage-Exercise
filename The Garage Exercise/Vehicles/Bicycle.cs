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


        public static Bicycle RegisterVehicle(string[] ownership, string[] generalInfo)
        {
            Console.WriteLine("Please specify technical details: " +
                "\nNumber of  seats (number).");
            string[] typeInfo = Console.ReadLine().Split(",").Select(x => x.Trim()).ToArray();



            return CreateBicycleFromInputs(ownership, generalInfo, typeInfo);


        }

        public static Bicycle CreateBicycleFromInputs(string[] ownership, string[] generalInfo, string[] typeInfo)
        {


            if (ownership.Length != 2 || generalInfo.Length != 3 || typeInfo.Length != 1)
            {
                Console.WriteLine("Sorry, incomplete registration.");
                return null;
            }

            bool validInputs = (    //Assessing if all these inputs are valid
                int.TryParse(generalInfo[1], out int numWheels) &
                Mobility.TryParse(generalInfo[2].ToLower(), out Mobility mobility) &
                int.TryParse(typeInfo[0], out int numSeats)
                );

            if (!validInputs)
            {
                Console.WriteLine("There were errors and the registration could not be completed." +
                "\nPlease try again later.");
                return null;
            }

            else
            {
                Console.WriteLine("Thank you. Generating registry information...");

                return new Bicycle(ownership[1], ownership[0],
                generalInfo[0], numWheels, mobility,
                numSeats
                );
            }

        }



    }
}
