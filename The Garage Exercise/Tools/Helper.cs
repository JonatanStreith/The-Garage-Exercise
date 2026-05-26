using System;
using System.Collections.Generic;
using System.Text;

namespace The_Garage_Exercise.Tools
{
    public class Helper : IHelper
    {
        public string? Output { get; set; }

        public string GetInput(string message)
        {
            Console.WriteLine(message);

            return Console.ReadLine().ToLower();
        }
        public string GetInput()
        {
            return Console.ReadLine().ToLower();
        }
    }
}