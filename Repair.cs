namespace CarRepair
{
    public class Repair
    {
        public string Description { get; set; }
        public decimal Cost { get; set; }

        public Repair(string description, decimal cost)
        {
            Description = description;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"Description: {Description}, Cost: {Cost:C}";
        }
    }
}
