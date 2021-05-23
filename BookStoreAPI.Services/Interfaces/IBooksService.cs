using BookStoreAPI.Models;
using BookStoreAPI.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Services.Interfaces
{
    public interface IBooksService
    {
        /// <summary>
        /// Returns list of all books.
        /// </summary>
        /// <returns></returns>
        List<Book> GetAll();
        /// <summary>
        /// Creates new book with data from given one and returns status model.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        StatusModel Create(Book book);
        /// <summary>
        /// Deletes book by given ID.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
        /// <summary>
        /// Updates given book.
        /// </summary>
        /// <param name="book"></param>
        void Update(Book book);
        /// <summary>
        /// Gets a book by given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Book GetById(int id);
        /// <summary>
        /// Returns list of books filtered by given parameters. If parameters are null returns all books.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        List<Book> GetWithFilters(string title, string author);
    }
}
