using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace The_Garage_Exercise.Tools
{
    internal struct FilterData
    {
        internal FilterData(string? typeFilter, string? mobilityFilter, string? colorFilter, int wheelsFilter)
        {
            TypeFilter = typeFilter;
            MobilityFilter = mobilityFilter;
            ColorFilter = colorFilter;
            WheelsFilter = wheelsFilter;
        }

        internal readonly string TypeFilter { get; }
        internal readonly string MobilityFilter { get; }
        internal readonly string ColorFilter { get; }
        internal readonly int WheelsFilter { get; }

        internal bool IsEmpty()
        {
            if(
                TypeFilter == null && 
                MobilityFilter == null && 
                ColorFilter == null && 
                WheelsFilter == -1
                ) return true;
            else return false;
        }
    }
}
