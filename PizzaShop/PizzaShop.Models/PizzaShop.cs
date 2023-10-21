namespace PizzaShop1.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class PizzaShop
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public double Rating { get; set; }
        public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
