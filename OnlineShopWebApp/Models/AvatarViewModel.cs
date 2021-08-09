using Microsoft.AspNetCore.Http;
using System;

namespace OnlineShopWebApp.Models
{
    public class AvatarViewModel
    {
        public Guid Id { get; set; }
        public IFormFile File { get; set; }

    }
}
