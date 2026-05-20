using System;
using System.Collections.Generic;
using System.Text;

namespace The_Garage_Exercise.Tools
{
    public class Helper
    {

        public static string GetInput(string message)
        {
            Console.WriteLine(message);

            return Console.ReadLine().ToLower();
        }


    }
}
