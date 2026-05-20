using The_Garage_Exercise.Garage;
using The_Garage_Exercise.Managers;

namespace The_Garage_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the garage!");

            GarageManager manager = new GarageManager();

            manager.InitializeGarage();

            //GarageHandler garageHandler = new GarageHandler();

            //Menu.DisplayMenu();

            //Menu.MakeChoice(garageHandler);
        }
    }
}
