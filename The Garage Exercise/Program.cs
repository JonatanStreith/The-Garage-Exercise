namespace The_Garage_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size;
            bool success;
            Console.Write("Welcome! Please specify size of garage (at least 5 is recommended): ");

            do
            {
                success = int.TryParse(Console.ReadLine(), out size);
                if(!success) Console.Write("That is not a legitimate number." +
                    "\nPlease specify size of garage: ");
            } while (!success);

            Garage garage = new(size);

            Console.WriteLine("\nA new garage has been erected.");
            Console.Write("Would you like to populate the garage with preexisting vehicles? (Y/N) [N]\n");

            string populateOrNot = Console.ReadLine().ToLower();

            switch (populateOrNot) 
            {
                case "y":
                    {
                        Console.WriteLine("Okay, the garage will be populated with five vehicles " +
                            "\n(or fewer depending on size).");
                        garage.PopulateGarage((size<5) ? size : 5);
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
