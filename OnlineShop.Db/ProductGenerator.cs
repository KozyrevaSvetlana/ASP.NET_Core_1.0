using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public static class ProductGenerator
    {
        private static Random random = new Random();
        private static string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit," +
            " sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim " +
            "ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip " +
            "ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate " +
            "velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat " +
            "cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum";
        public static Product GeneradeRandomProduct(List<Image> images)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = names[random.Next(0, 21)],
                Cost = random.Next(1, 100001),
                Description = lorem.Substring(0, random.Next(10, lorem.Length)),
                Images = images
            };
            return product;
        }

        private static List<string> names = new List<string>
        {
            "Мишка", "Кукла", "Конструктор", "Памперсы", "Детская смесь", "Ползунки", "Пирамидка",
            "Чашка", "Ложка", "Вилка", "Соска", "Пистолетик", "Распашонка", "Пелёнка", "Трусы", "Детское пюре",
            "Крем", "Мячик", "Журнал", "Настольная игра", "Шапка"
        };
    }
}

