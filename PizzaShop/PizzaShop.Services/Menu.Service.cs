namespace PizzaShop1.Services
{
    using PizzaShop1.Data;
    using PizzaShop1.Models;
    public class MenuService
    {
        private AppDbContext context;

        public string CreateMenu(int restaurantId)
        {
            using (context = new AppDbContext())
            {
                Menu menu = new Menu()
                {
                    PizzaShopId = restaurantId
                };
                context.Menus.Add(menu);
                context.SaveChanges();
                return "Menu is added!";
            }
        }
        public Menu GetMenuById(int id)
        {
            using (context = new AppDbContext())
            {
                return context.Menus.Find(id);
            }
        }
    }
}
