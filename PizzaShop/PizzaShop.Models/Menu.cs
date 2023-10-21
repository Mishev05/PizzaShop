namespace PizzaShop1.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Menu
    {
        public int Id { get; set; }
        [Required]
        public int PizzaShopId { get; set; }
        public virtual PizzaShop PizzaShop { get; set; }
        public virtual ICollection<MenuItems> MenuItems { get; set; } = new List<MenuItems>();
    }
}
