using The_Garage_Exercise.Garage;

namespace The_Garage_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");

            GarageHandler garageHandler = new GarageHandler();

            Menu.DisplayMenu();

            Menu.MakeChoice(garageHandler);
        }
    }
}
