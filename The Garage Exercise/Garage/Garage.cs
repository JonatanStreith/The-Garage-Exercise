using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using The_Garage_Exercise.Vehicles;

namespace The_Garage_Exercise.Garage
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private List<T> _content;

        private readonly int _numberOfParkingSpots;
        private int _currentOccupancy;

        public int NumberOfParkingSpots { get { return _numberOfParkingSpots; } }
        public int CurrentOccupancy {  get { return _currentOccupancy; } set { _currentOccupancy = value; }  }

        public Garage(int numberOfParkingSpots)
        {
            _content = new List<T>();
            _numberOfParkingSpots = numberOfParkingSpots;
            _currentOccupancy = 0;
        }

        public void Add(T item)
        {
            _content.Add(item);
            _currentOccupancy++;
        }

        public void Remove(T item)
        {
            _content.Remove(item);
            _currentOccupancy--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _content.OfType<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}