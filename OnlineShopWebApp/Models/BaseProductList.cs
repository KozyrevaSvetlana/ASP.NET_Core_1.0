
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class BaseProductList: BaseList
    {
        public List<ProductViewModel> Items { get; set; }
    }
}
