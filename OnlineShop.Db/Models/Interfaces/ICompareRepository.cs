using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface ICompareRepository
    {
        IEnumerable<Compare> AllCompares { get; }
        Compare TryGetByCompareId(string CompareId);
        void Add(Product product, string CompareId);
        void DeleteItem(Guid id, string CompareId);
        void Clear(string CompareId);
    }
}