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


        public static Bicycle RegisterVehicle()
        {
            Console.Write("Please provide the name of the owner and the license number: ");
            string[] ownership = Console.ReadLine().Split(",");

            Console.WriteLine("Please specify the color, number of wheels (number), " +
                "\nand mobility type (land, air, or water).");
            string[] generalInfo = Console.ReadLine().Split(",");

            Console.WriteLine("Please specify technical details: " +
                "\nNumber of  seats (number).");
            string typeInfo = Console.ReadLine();

            bool validInputs = (    //Assessing if all these inputs are valid
                int.TryParse(generalInfo[1], out int numWheels) &
                Mobility.TryParse(generalInfo[2].ToLower(), out Mobility mobility) &
                int.TryParse(typeInfo, out int numSeats)
                );

            if (validInputs)
            {
                Console.WriteLine("Thank you. Generating registry information...");

                return new Bicycle(ownership[1], ownership[0],
                generalInfo[0], numWheels, mobility,
                numSeats
                );
            }

            else
            {
                Console.WriteLine("There were errors and the registration could not be completed." +
                "\nPlease try again later.");
                return null;
            }
        }

    

}
}
