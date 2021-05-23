using BookStoreAPI.Models;
using BookStoreAPI.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Services.Interfaces
{
    public interface IOrdersService
    {
        /// <summary>
        /// Creates new order from data from given one and returns status model.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        StatusModel Create(Order order);
    }
}
