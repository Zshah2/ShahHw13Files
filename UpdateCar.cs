using System;
using System.Collections.Generic;

namespace CarRepair
{
    public class UpdateCar
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

        public void AddRepair(Repair repair)
        {
            Repairs.Add(repair);
        }

        public decimal GetTotalRepairCost()
        {
            decimal totalCost = 0;
            foreach (Repair repair in Repairs)
            {
                totalCost += repair.Amount;
            }
            return totalCost;
        }
    }
}
