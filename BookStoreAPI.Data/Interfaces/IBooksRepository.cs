using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Data.Interfaces
{
    public interface IBooksRepository
    {
        /// <summary>
        /// Returns list of all books from DB.
        /// </summary>
        /// <returns></returns>
        List<Book> GetAll();
        /// <summary>
        /// Adds and saves given book in DB.
        /// </summary>
        /// <param name="book"></param>
        void Create(Book book);
        /// <summary>
        /// Returns book from BD by given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Book GetById(int id);
        /// <summary>
        /// Updates and saves given book in DB.
        /// </summary>
        /// <param name="book"></param>
        void Update(Book book);
        /// <summary>
        /// Deletes the given book from BD and saves changes in BD.
        /// </summary>
        /// <param name="book"></param>
        void Delete(Book book);
        /// <summary>
        /// Returns book from BD by given title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        Book GetByTitle(string title);
        /// <summary>
        /// Returns list of books by filters if any parameters. If parameters are null, returns list of all books in DB.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        List<Book> GetWithFilters(string title, string author);

    }
}
