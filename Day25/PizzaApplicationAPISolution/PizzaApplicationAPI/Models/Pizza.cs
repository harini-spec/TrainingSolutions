namespace PizzaApplicationAPI.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DiameterInches { get; set; }
        public bool IsVegetarian { get; set; }
        public float UnitPrice { get; set; }
        public bool Availability { get; set; }
        public int InStock { get; set; }
    }
}
