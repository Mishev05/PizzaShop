namespace PizzaShop1.Services
{
    using PizzaShop1.Data;
    using PizzaShop1.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using PizzaShop1.ViewModel.PizzaShops;
    using PizzaShop1.ViewModel.Shared;

    public class PizzaShopsService
    {
        private AppDbContext context;

        public string AddPizzaShop(string name, double rating, string location)
        {
            StringBuilder sb = new StringBuilder();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(name))
            {
                sb.AppendLine($"Invalid {nameof(name)}!");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(location))
            {
                sb.AppendLine($"Invalid {nameof(location)}!");
                isValid = false;
            }
            if (rating < 2 && rating > 10)
            {
                sb.AppendLine($"Invalid {nameof(rating)}!");
                isValid = false;
            }
            if (isValid)
            {
                PizzaShop pizzaShop = new PizzaShop()
                {
                    Name = name,
                    Rating = rating,
                    Location = location,
                };
                using (context = new AppDbContext())
                {
                    context.PizzaShops.Add(pizzaShop);
                    context.SaveChanges();
                    sb.AppendLine($"PizzaShop {name} located in {location} is added!");
                }
            }
            return sb.ToString().TrimEnd();
        }
        public PizzaShop GetPizzaShopByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid PizzaShop name!");
            }
            using (context = new AppDbContext())
            {
                PizzaShop r = context.PizzaShops.FirstOrDefault(x => x.Name == name);
                return r;
            }
        }
        public PizzaShop GetPizzaShopById(int id)
        {
            using (context = new AppDbContext())
            {
                return context.PizzaShops.Find(id);
            }
        }
        public string UpdatePizzaShopRating(int id, double newRating)
        {
            using (context = new AppDbContext())
            {
                PizzaShop pizzaShop = context.PizzaShops.Find(id);
                if (pizzaShop == null) { return $"{nameof(PizzaShop)} not found!"; }
                if (newRating < 2 || newRating > 10) { return "Invalid new rating!"; }
                pizzaShop.Rating = newRating;
                context.PizzaShops.Update(pizzaShop);
                context.SaveChanges();
                return $"{nameof(PizzaShop)} {pizzaShop.Name} has new rating: {newRating}";
            }
        }
        public List<string> GetPizzaShopBasicInfo(int page = 1, int count = 10)
        {
            List<string> list = null;
            using (context = new AppDbContext())
            {
                list = context.PizzaShops
                    .Skip((page - 1) * count)
                    .Take(count)
                    .Select(x => $"{x.Id} - {x.Name} located in {x.Location} has {x.Rating} rating")
                    .ToList();
            }
            return list;
        }

        public int GetPizzaShopPagesCount(int count = 10)
        {
            using (context = new AppDbContext())
            {
                return (int)Math.Ceiling(context.PizzaShops.Count() / (double)count);
            }
        }
        public string DeletePizzaShopById(int id)
        {
            using (context = new AppDbContext())
            {
                PizzaShop pizzaShop = context.PizzaShops.Find(id);
                if (pizzaShop == null) { return $"{nameof(PizzaShop)} not found!"; }
                context.PizzaShops.Remove(pizzaShop);
                context.SaveChanges();
                return $"{nameof(PizzaShop)} {pizzaShop.Name} in {pizzaShop.Location} was deleted!";
            }
        }
        public PizzaShop GetPizzaShopByLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentException("Invalid PizzaShop location!");
            }
            using (context = new AppDbContext())
            {
                PizzaShop r = context.PizzaShops.FirstOrDefault(x => x.Location == location);
                return r;
            }
        }
        public string GetAllPizzaShopInfo(int page = 1, int count = 10)
        {
            StringBuilder msg = new StringBuilder();
            string firstRow = $"| {"Id",-4} | {"Name",-12} | {"Rating",-10} | {"Location",-3}|";

            string line = $"|{new string('-', firstRow.Length - 2)}|";

            using (context = new AppDbContext())
            {
                List<PizzaShop> pizzaShops = context.PizzaShops
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToList();
                msg.AppendLine(firstRow);
                msg.AppendLine(line);
                foreach (var r in pizzaShops)
                {
                    string info = $"| {r.Id,-4} | {r.Name,-12} | {r.Rating,-10} | {r.Location,-3}|";
                    msg.AppendLine(info);
                    msg.AppendLine(line);
                }
                int pageCount = (int)Math.Ceiling(context.PizzaShops.Count() / (decimal)count);
                msg.AppendLine($"Page: {page} / {pageCount}");
            }
            return msg.ToString().TrimEnd();
        }
        public List<PizzaShopIndexViewModel> GetLowestRatedPizzaShop()
        {
            using (context = new AppDbContext())
            {
                return context.PizzaShops.OrderBy(x => x.Rating)
                .Take(9)
                .Select(x => new PizzaShopIndexViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    Rating = x.Rating
                })
                .ToList();
            }

        }

        public List<PizzaShopIndexViewModel> GetHighestRatedPizzaShop()
        {
            using (context = new AppDbContext())
            {
                return context.PizzaShops.OrderByDescending(x => x.Rating)
                .Take(9)
                .Select(x => new PizzaShopIndexViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    Rating = x.Rating
                })
                .ToList();
            }

        }

        //public PizzaShopsIndexViewModel GetPizzaShop(PizzaShopIndexViewModel model)
        //{
        //    using (context = new AppDbContext())
        //    {
        //        model.PizzaShop = context.PizzaShops
        //        .Skip((model.PageNumber - 1) * model.ItemsPerPage)
        //        .Take(model.ItemsPerPage)
        //        .Select(x => new PizzaShopIndexViewModel()
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //            Location = x.Location,
        //            Rating = x.Rating
        //        })
        //        .ToList();

        //        model.ElementsCount = context.PizzaShops.Count();

        //        return model;
        //    }

        //}

    }
}
