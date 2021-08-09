using System;

namespace OnlineShop.Db.Models
{
    public class UserContact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}