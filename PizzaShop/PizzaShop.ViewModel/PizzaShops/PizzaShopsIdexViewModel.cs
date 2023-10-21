using System.Collections.Generic;
using PizzaShop1.ViewModel.Shared;

namespace PizzaShop1.ViewModel.PizzaShops
{
    public class PizzaShopsIndexViewModel:PagingViewModel
    {
        public List<PizzaShopIndexViewModel> PizzaShops;

        public PizzaShopsIndexViewModel()
        {
            this.PizzaShops = new List<PizzaShopIndexViewModel>();
        }
    }
}
