using System.Reflection;
using The_Garage_Exercise.Managers;
using The_Garage_Exercise.Garage;

namespace The_Garage_Exercise.Test
{
    public class GarageHandlerTest
    {
        [Fact]
        public void CanCreateHandler()
        {
            int size = 7;
            bool populate = true;

            GarageHandler handler = new Garage.GarageHandler(size, populate);

            GarageManager manager = new Managers.GarageManager();


        }
    }
}
