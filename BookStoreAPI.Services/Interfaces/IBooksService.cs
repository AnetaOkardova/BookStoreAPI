using BookStoreAPI.Models;
using BookStoreAPI.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Services.Interfaces
{
    public interface IBooksService
    {
        List<Book> GetAll();
        StatusModel Create(Book book);
        void Delete(int id);
        void Update(Book book);
        Book GetById(int id);
        List<Book> GetWithFilters(string title, string author);
    }
}
