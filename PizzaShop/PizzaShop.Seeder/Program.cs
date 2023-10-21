namespace PizzaShop.Seeder
{
    using System;
    using System.Collections.Generic;
    using PizzaShop1.Services;
    public class Program
    {
        private static PizzaShopsService pizzaShopsService = new PizzaShopsService();
        private static ItemsService itemsService = new ItemsService();
        private static MenuService menuService = new MenuService();
        private static CustomerService customerService = new CustomerService();
        public static void Main()
        {
            SeedPizzaShops();
            SeedItems();
            SeedMenus();
            SeedCustomers();
        }
        public static void SeedPizzaShops()
        {
            List<string> name = new List<string>() { "Pizza Paradise", "Slice of Heaven Pizzeria", "Crispy Crust Pizza Co.", "Mamma Mia Pizzeria", "Pizzarella Express", "Doughlicious Pizza Hut", "The Pizza Palate", "OvenFresh Pizza Haven", "Pepperoni Pizzazz", "Pizzamania", "SliceItUp Pizzas", "Cheesy Delights Pizza", "Pizza Perfection", "UrbanSlice Pizzeria", "Pizza Haven Express", "Woodfired Pizza Villa", "Pizza Picasso", "Bella Napoli Pizzeria", "Pizzazz Fusion", "Rustic Oven Pizzas", "SliceMaster Pizzeria", "Pizzaroma", "PizzaPronto Express", "Crust & Cravings", "Slice Sensation Pizzas", "Gourmet Pie Co.", "Pizzalicious Bites", "The Pizza Station", "Sizzle Slice Pizzeria", "Dough Delights", "Artisanal Pie House", "Pizza Fusion", "Slice of Elegance", "Pizzaville Delights", "CrispyBite Pizzeria", "Pizzaria Bella", "SliceStar Pizzas", "The Pizza Palette", "Pizza Passion", "CrustCrafters Pizzeria" };
            List<string> location = new List<string>() { "Sofia", "Plovdiv", "Varna", "Burgas", "Ruse", "Stara Zagora", "Pleven", "Sliven", "Dobrich", "Shumen", "Haskovo", "Blagoevgrad", "Gabrovo", "Vratsa", "Vidin", "Montana", "Lovech", "Yambol", "Razgrad", "Silistra" };
            Random random = new Random();
            for (int i = 0; i < 50; i++)
            {
                int pizzaShopName = random.Next(0, name.Count);
                int pizzaShopLocation = random.Next(0, location.Count);
                double rating = Math.Round(random.NextDouble() * 8 + 2, 1);
                Console.WriteLine($"{pizzaShopsService.AddPizzaShop(name[pizzaShopName], rating, location[pizzaShopLocation])}");
            }
        }
        public static void SeedItems()
        {
            List<string> name = new List<string>() { "Supreme Delight Pizza", "Margherita Magic", "BBQ Chicken Bliss", "Veggie Fiesta Pizza", "Pepperoni Perfection", "Hawaiian Paradise Pie", "Mediterranean Marvel Pizza", "Pesto Passion Pie", "Meat Lover's Dream", "Four Cheese Fantasy", "Buffalo Wing Wonder Pizza", "Spinach and Feta Sensation", "White Garlic Elegance", "Taco Tornado Pizza", "Seafood Splendor Pie", "Sweet and Spicy Thai Delight", "The Works Extravaganza", "Roasted Veggie Medley Pizza", "Bacon and Egg Breakfast Pie", "Truffle Trifecta Delight" };
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int itemName = random.Next(0, name.Count);
                decimal price = (decimal)Math.Round(random.NextDouble() * random.Next(20, 30), 2);
                Console.WriteLine(itemsService.AddItem(name[itemName], price));
            }
        }
        public static void SeedMenus()
        {
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                int restaurantId = random.Next(1, 50);
                Console.WriteLine(menuService.CreateMenu(restaurantId));
            }
        }
        public static void SeedCustomers()
        {
            List<string> names = new List<string>() { "Ivaylo Ivanov", "Mariya Petrova", "Stefan Dimitrov", "Elena Georgieva", "Aleksandar Marinov", "Tanya Ivanova", "Georgi Nikolov", "Magdalena Petrova", "Dimitar Popov", "Silvia Hristova", "Kiril Dimitrov", "Daniela Stoyanova", "Hristo Petrov", "Radka Koleva", "Rosen Angelov", "Nadezhda Yordanova", "Radoslav Todorov", "Emilia Ivanova", "Vasil Georgiev", "Milena Hristova", "Anton Stefanov", "Kalina Vasileva", "Lyubomir Petrov", "Snezhana Dimitrova", "Todor Gospodinov", "Ekaterina Petrova", "Plamen Marinov", "Reneta Yaneva", "Ivo Ivanov", "Simona Stoycheva", "Borislav Borisov", "Gabriela Todorova", "Ivan Yankov", "Veselina Georgieva", "Boyan Petrov", "Elena Hristova", "Hristofor Ivanov", "Gergana Stoyanova", "Rosen Rusev", "Viktoriya Yordanova" };
            List<string> adresses = new List<string> { "12 Sofia Street, Sofia, 1000", "5 Vardar Boulevard, Plovdiv, 4000", "18 Cherni Vrah Street, Varna, 9000", "25 Khan Asparuh Street, Burgas, 8000", "7 Alexandrovska Street, Ruse, 7000", "14 Ivan Vazov Street, Stara Zagora, 6000", "3 Dragan Tsankov Boulevard, Pleven, 5800", "10 Hristo Petrov Street, Sliven, 8800", "33 General Gurko Street, Dobrich, 9300", "25 Khan Krum Street, Shumen, 9700", "4 Dimitar Blagoev Street, Haskovo, 6300", "22 Gotse Delchev Street, Blagoevgrad, 2700", "12 Vasil Levski Street, Gabrovo, 5300", "15 Hristo Botev Street, Vratsa, 3000", "8 Dimitar Hadzhikotsev Street, Vidin, 3700", "2 Osam Street, Montana, 3400", "17 Slavyanska Street, Lovech, 5500", "3 Velcho Atanasov Street, Yambol, 8600", "6 Vasil Aprilov Street, Razgrad, 7200", "1 Osvobozhdenie Street, Silistra, 7500", "11 Vasil Levski Street, Pazardzhik, 4400", "19 Yavor Street, Smolyan, 4700", "30 Tsar Osvoboditel Boulevard, Gorna Oryahovitsa, 5100", "20 Yane Sandanski Street, Slivnitsa, 2200", "5 Todor Kablenshkov Street, Kyustendil, 2500", "13 Tsar Boris III Street, Pernik, 2300", "1 Tsar Simeon Boulevard, Kazanlak, 6100", "7 Hristo Maximov Street, Shabla, 9680", "2 General Dundakov Street, Karlovo, 4300", "8 Vasil Aprilov Street, Gorna Malina, 2077", "11 Geo Milev Street, Sandanski, 2800", "9 Geo Milev Street, Troyan, 5600", "6 Dimitar Petkov Street, Dupnitsa, 2600", "3 Stara Planina Street, Kostenets, 2050", "18 Tsar Osvoboditel Street, Momchilgrad, 6800", "14 Petko Yavorov Street, Gotse Delchev, 2900", "25 Nikola Vaptsarov Street, Svilengrad, 6500", "23 Vasil Levski Street, Teteven, 5700", "19 Dimitar Popov Street, Kresna, 2840", "7 Orlov Most Street, Yakoruda, 2770" };
            List<string> phoneNumbers = new List<string> { "0888123456", "0899234567", "0877345678", "0889456789", "0898567890", "0876678901", "0887789012", "0896890123", "0875901234", "0886012345", "0895123456", "0874234567", "0883345678", "0892456789", "0871567890", "0880678901", "0899789012", "0878890123", "0887001234", "0896112345", "0875223456", "0884334567", "0893445678", "0872556789", "0881667890", "0890778901", "0879889012", "0888990123", "0897001234", "0876112345" };
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                int customerName = random.Next(0, names.Count);
                int customerAdress = random.Next(0, adresses.Count);
                int customerPhoneNumber = random.Next(0, phoneNumbers.Count);
                Console.WriteLine(customerService.AddCustomer(names[customerName], adresses[customerAdress], phoneNumbers[customerPhoneNumber]));
            }
        }
    }
}
