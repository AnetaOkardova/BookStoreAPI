using BookStoreAPI.Models;
using BookStoreAPI.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Services.Interfaces
{
    public interface IOrdersService
    {
        StatusModel Create(Order order);
    }
}
