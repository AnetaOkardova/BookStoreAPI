using BookStoreAPI.Data.Interfaces;
using BookStoreAPI.Models;
using BookStoreAPI.Services.DtoModels;
using BookStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IBooksRepository _booksRepository;

        public OrdersService(IOrdersRepository ordersRepository, IBooksRepository booksRepository)
        {
            _ordersRepository = ordersRepository;
            _booksRepository = booksRepository;
        }
       
        public StatusModel Create(Order order)
        {
            var response = new StatusModel();
            var booksOrdered = order.Books;
            decimal fullPrice = 0;
            foreach (var bookOrder in booksOrdered)
            {
                var book = _booksRepository.GetById(bookOrder.BookId);
                if(book.Quantity < 1)
                {
                    response.IsSuccessfull = false;
                    response.Message = $"There are no copies of the book {book.Title} currently in stock.";
                    return response;
                }
                else
                {
                    book.Quantity--;
                    fullPrice += book.Price;
                    continue;
                }
            }
            order.DateCreated = DateTime.Now;
            order.FullPrice = fullPrice;
            _ordersRepository.Create(order);
            response.Message = "The order has been successfully completed";
            return response;
        }
    }
}
