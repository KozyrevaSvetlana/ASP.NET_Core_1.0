using System;

namespace OnlineShopWebApp.Models
{
    public class BaseList
    {
        public static int count = 1;
        public int Id { get; set; }
        public string UserId { get; set; }
        public BaseList()
        {
            Id = count;
            count++;
        }
    }
}
