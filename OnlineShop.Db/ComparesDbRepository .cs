using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class ComparesDbRepository : ICompareRepository
    {
        private readonly DatabaseContext databaseContext;
        public ComparesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IEnumerable<Compare> AllCompares
        {
            get
            {
                return databaseContext.Compares.ToList();
            }
        }

        public void Add(Product product, string UserId)
        {
            var userCompareList = TryGetByCompareId(UserId);
            if (userCompareList == null)
            {
                AddNewCompare(product, UserId);
            }
            else
            {
                var userCartItem = userCompareList.Items.FirstOrDefault(x => x.Id == product.Id);
                if (userCartItem == null)
                {
                    userCompareList.Items.Add(product);
                }
            }
            databaseContext.SaveChanges();
        }

        public void Clear(string CompareId)
        {
            var result = TryGetByCompareId(CompareId);
            databaseContext.Remove(result);
            databaseContext.SaveChanges();
        }

        public void DeleteItem(Guid id, string CompareId)
        {
            var compare = TryGetByCompareId(CompareId);
            compare.Items.RemoveAll(x => x.Id == id);
            databaseContext.SaveChanges();
        }

        public Compare TryGetByCompareId(string CompareId)
        {
            return databaseContext.Compares.Include(x => x.Items).FirstOrDefault(x => x.UserId == CompareId);
        }
        private void AddNewCompare(Product product, string userId)
        {
            var newCart = new Compare
            {
                UserId = userId,
                Items = new List<Product>(),
            };
            newCart.Items.Add(product);
            databaseContext.Compares.Add(newCart);
            databaseContext.SaveChanges();
        }
    }
}
