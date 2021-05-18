using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Data.Interfaces
{
    public interface IBooksRepository
    {
        List<Book> GetAll();
        void Create(Book book);
        Book GetById(int id);
        void Update(Book book);
        void Delete(Book book);
        Book GetByTitle(string title);
        List<Book> GetWithFilters(string title, string author);

    }
}
