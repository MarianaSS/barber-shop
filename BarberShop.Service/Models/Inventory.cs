namespace BarberShop.Service.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public Shop ShopId { get; set; }
        public Equipment EquipmentId { get; set; }
        public Tool ToolId { get; set; }
        public CashOffice CashOfficeId { get; set; }
    }
}