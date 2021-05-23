using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Data.Interfaces
{
    public interface IOrdersRepository
    {
        /// <summary>
        /// Adds and saves given order in DB.
        /// </summary>
        /// <param name="order"></param>
        void Create(Order order);
    }
}
