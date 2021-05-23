using BookStoreAPI.Data.Interfaces;
using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Data
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public OrdersRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
    }
}
