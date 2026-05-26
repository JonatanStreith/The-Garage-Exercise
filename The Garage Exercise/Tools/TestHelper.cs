using System;
using System.Collections.Generic;
using System.Text;

namespace The_Garage_Exercise.Tools
{
    public class TestHelper : IHelper
    {
        public string Output {  get; set; }
        public string GetInput(string message)
        {
            Console.WriteLine(message);

            return Output;
        }

    }
}
