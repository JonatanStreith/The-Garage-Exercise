namespace The_Garage_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");


            Garage garage = new(SizeGarage());

            Console.WriteLine("\nA new garage has been erected.");

            PopulateOrNot(garage);
        }

        public static int SizeGarage()
        {
            Console.Write("Please specify size of garage (at least 5 is recommended): ");

            while (true)
            {
                bool success = int.TryParse(Console.ReadLine(), out int size);
                if (success) 
                    return size;
                else 
                    Console.Write("That is not a legitimate number." +
                    "\nPlease specify size of garage: ");
            }

        }

        public static void PopulateOrNot(Garage garage)
        {
            Console.Write("Would you like to populate the garage with preexisting vehicles? (Y/N) [N]\n");

            string populateOrNot = Console.ReadLine().ToLower();

            switch (populateOrNot)
            {
                case "y":
                    {
                        Console.WriteLine("Okay, the garage will be populated with five vehicles " +
                            "\n(or fewer depending on size).");
                        garage.PopulateGarage((garage.numberOfParkingSpots < 5) ? garage.numberOfParkingSpots : 5);
                        break;
                    }

                case "n":
                default:
                    {
                        Console.WriteLine("This garage will be empty from the start.");
                        break;
                    }

            }

        }
    }
}
