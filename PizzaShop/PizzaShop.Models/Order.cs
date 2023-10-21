namespace PizzaShop1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    public class Order
    {
            public int Id { get; set; }
            public DateTime Date { get; set; } = DateTime.UtcNow;
            public int PizzaShopId { get; set; }
            [NotMapped]
            public decimal TotalPrice { get => OrderItems.Sum(x => x.Item.Id); }
            public int CustomerId { get; set; }
            public virtual PizzaShop PizzaShop { get; set; }
            public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
