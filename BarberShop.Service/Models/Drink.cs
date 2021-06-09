namespace BarberShop.Service.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public Bar IdBar { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}