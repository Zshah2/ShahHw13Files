using System.Collections.Generic;

namespace CarRepair
{
    public class Car
    {
        public string Make { get; }
        public string Model { get; }
        public int Year { get; }
        public List<Repair> Repairs { get; }

        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
            Repairs = new List<Repair>();
        }

        public override string ToString()
        {
            return $"{Make} {Model} ({Year})";
        }
    }
}




