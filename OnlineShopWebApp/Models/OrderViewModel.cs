using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public int Number { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public List<CartItemViewModel> Products { get; set; }
        public UserContactViewModel User { get; set; }
        public InfoStatusOrderViewModel InfoStatus { get; set; }

        public OrderViewModel()
        {
            Products = new List<CartItemViewModel>();
            User = new UserContactViewModel();
            InfoStatus = new InfoStatusOrderViewModel(DateTime.Now);
        }

        public void AddContacts(string userId, UserContactViewModel user, InfoStatusOrderViewModel infoStatus, string comment)
        {
            UserId = userId;
            User = user;
            InfoStatus= infoStatus;
            Comment = comment;
        }

        public decimal Cost
        {
            get
            {
                return Products?.Sum(x => x.Cost) ?? 0;
            }
        }

    }
}
