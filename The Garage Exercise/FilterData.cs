using System;
using System.Collections.Generic;
using System.Text;

namespace The_Garage_Exercise
{
    internal struct FilterData
    {
        internal FilterData(string? typeFilter, string? mobilityFilter, string? colorFilter, int? wheelsFilter)
        {
            TypeFilter = typeFilter;
            MobilityFilter = mobilityFilter;
            ColorFilter = colorFilter;
            WheelsFilter = wheelsFilter;
        }

        internal string TypeFilter { get; }
        internal string MobilityFilter { get; }
        internal string ColorFilter { get; }
        internal int WheelsFilter { get; }


    }
}
