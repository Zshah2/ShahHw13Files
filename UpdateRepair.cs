namespace CarRepair
{
    public class UpdateRepair
    {
        public string Description { get; }
        public decimal Amount { get; }

        public Repair(string description, decimal amount)
        {
            Description = description;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Description}, ${Amount}";
        }
    }
}
