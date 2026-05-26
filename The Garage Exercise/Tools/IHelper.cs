using System;
using System.Collections.Generic;
using System.Text;

namespace The_Garage_Exercise.Tools
{
    internal interface IHelper
    {
        public abstract string? Output { get; set; }

        public abstract string GetInput(string input);
        public abstract string GetInput();

    }
}
