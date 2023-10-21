namespace PizzaShop1.Models
{
    public class MenuItems
    {
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
