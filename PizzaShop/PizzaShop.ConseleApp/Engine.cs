namespace PizzaShop.ConseleApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using PizzaShop1.Services;
    public class Engine
    {
        private PizzaShopsService pizzaShopsService;
        private ItemsService itemsService;
        private OrderService orderService;
        public Engine()
        {
            pizzaShopsService = new PizzaShopsService();
            itemsService = new ItemsService();
            orderService = new OrderService();
            Run();
        }
        public void Run()
        {
            Console.WriteLine("Welcome to Pizzeria Vel!");
            while (true)
            {
                try
                {
                    Console.Clear();
                    Menu();
                    Console.Write("Enter your choice: ");
                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "0":
                            return;
                        case "1":
                            GetPizzaShopByName();
                            break;
                        case "2":
                            GetPizzaShopById();
                            break;
                        case "3":
                            GetPizzaShopByLocation();
                            break;
                        case "4":
                            AddPizzaShop();
                            break;
                        case "5":
                            CreateOrder();
                            break;
                        case "6":
                            AllPizzaShopsInfo();
                            break;
                        case "7":
                            AllItemsInfo();
                            break;
                        case "8":
                            AddItem();
                            break;
                        case "9":
                            GetItemById();
                            break;
                        case "10":
                            GetItemByName();
                            break;
                        case "11":
                            UpdateItemPrice();
                            break;
                        case "12":
                            RemoveItemByName();
                            break;
                        case "13":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid input! Please try again.");
                            PressKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    PressKey();
                }

            }
        }
        private void RemoveItemByName()
        {
            Console.Write("Enter item name to remove: ");
            string itemNameToRemove = Console.ReadLine();
            Console.WriteLine(itemsService.RemoveItemByName(itemNameToRemove));
            PressKey();
        }
        private void UpdateItemPrice()
        {
            Console.Write("Enter item id: ");
            int itemId = int.Parse(Console.ReadLine());
            Console.Write("Enter new price: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine(itemsService.UpdateItemPrice(itemId, newPrice));
            PressKey();
        }
        private void GetItemByName()
        {
            Console.Write("Enter item name: ");
            string itemNameToSearch = Console.ReadLine();
            var itemName = itemsService.GetItemByName(itemNameToSearch);
            Console.WriteLine($"Item {itemName.Name} has price {itemName.Price}");
            PressKey();
        }
        private void CreateOrder()
        {
            Console.Write("Enter pizzaShop Id in the range 1-50: ");
            int restaurantId = int.Parse(Console.ReadLine());
            Console.Write("Enter customer id int the range 1-20: ");
            int customerId = int.Parse(Console.ReadLine());
            Console.Write("Enter item id's in the range 1-100 separated by interval: ");
            List<int> items = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            Console.WriteLine(orderService.CreateOrder(restaurantId, customerId, items));
            PressKey();
        }
        private void GetItemById()
        {
            Console.Write("Enter item ID: ");
            int itemID = int.Parse(Console.ReadLine());
            var item = itemsService.GetItemById(itemID);
            Console.WriteLine($"Item with this id is {item.Name} and cost {item.Price}.");
            PressKey();
        }
        private void AddItem()
        {
            Console.Write("Enter item name: ");
            string itemName = Console.ReadLine();
            Console.Write("Enter item price: ");
            decimal itemPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine(itemsService.AddItem(itemName, itemPrice));
            PressKey();
        }
        private void AllItemsInfo()
        {
            int currentPage = 1;
            int pageCount = itemsService.GetItemsPagesCount();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Items list: ");
                string info = itemsService.GetAllItemsInfo(currentPage);
                Console.WriteLine(info);
                Console.WriteLine("Commands: 0:Back, 1:Previous page, 2:Next page ");
                Console.Write("Enter command: ");
                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "0":
                        return;
                    case "1":
                        if (currentPage > 1) { currentPage--; }
                        break;
                    case "2":
                        if (currentPage < pageCount) { currentPage++; }
                        break;
                }
            }
        }
        private void AllPizzaShopsInfo()
        {
            int currentPage = 1;
            int pageCount = pizzaShopsService.GetPizzaShopPagesCount();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Items list: ");
                string info = pizzaShopsService.GetAllPizzaShopInfo(currentPage);
                Console.WriteLine(info);
                Console.WriteLine("Commands: 0:Back, 1:Previous page, 2:Next page ");
                Console.Write("Enter command: ");
                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "0":
                        return;
                    case "1":
                        if (currentPage > 1) { currentPage--; }
                        break;
                    case "2":
                        if (currentPage < pageCount) { currentPage++; }
                        break;
                }
            }
        }
        private void AddPizzaShop()
        {
            Console.Write("Enter restaurant name: ");
            string restaurantName = Console.ReadLine();
            Console.Write("Enter restaurant rating: ");
            double rating = double.Parse(Console.ReadLine());
            Console.Write("Enter restaurant location: ");
            string restaurantLocation = Console.ReadLine();
            Console.WriteLine(pizzaShopsService.AddPizzaShop(restaurantName, rating, restaurantLocation));
            PressKey();
        }
        private void GetPizzaShopByLocation()
        {
            Console.Write("Enter restaurant location: ");
            string location = Console.ReadLine();
            var restaurantByLocation = pizzaShopsService.GetPizzaShopByLocation(location);
            Console.WriteLine($"{restaurantByLocation.Name} located in {location} has {restaurantByLocation.Rating} rating.");
            PressKey();
        }
        private void GetPizzaShopById()
        {
            Console.Write("Enter restaurant ID: ");
            int id = int.Parse(Console.ReadLine());
            var item = pizzaShopsService.GetPizzaShopById(id);
            Console.WriteLine($"Restaurant with Id {item.Id} is {item.Name}");
            PressKey();
        }
        private static void PressKey()
        {
            Console.WriteLine($"Press any key to continue...");
            Console.ReadKey();
        }
        private void GetPizzaShopByName()
        {
            Console.Write("Enter restaurant name: ");
            string name = Console.ReadLine();
            var nameToFind = pizzaShopsService.GetPizzaShopByName(name);
            Console.WriteLine($"Restaurant {nameToFind.Name} has id {nameToFind.Id}, located in {nameToFind.Location}");
            PressKey();
        }
        public void Menu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Menu:");
            sb.AppendLine($"\t0: Back");
            sb.AppendLine($"\t1: Get PizzaShop by Name");
            sb.AppendLine($"\t2: Get PizzaShop by ID");
            sb.AppendLine($"\t3: Get PizzaShop by Location");
            sb.AppendLine($"\t4: Add PizzaShop");
            sb.AppendLine($"\t5: Create Order");
            sb.AppendLine($"\t6: Get All PizzaShops Info");
            sb.AppendLine($"\t7: Get All Items Info");
            sb.AppendLine($"\t8: Add Item");
            sb.AppendLine($"\t9: Get Item by ID");
            sb.AppendLine($"\t10: Get Item by Name");
            sb.AppendLine($"\t11: Update Item Price");
            sb.AppendLine($"\t12: Remove Item by Name");
            sb.AppendLine($"\t13: Exit");
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
