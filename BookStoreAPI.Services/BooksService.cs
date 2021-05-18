using BookStoreAPI.Data.Interfaces;
using BookStoreAPI.Models;
using BookStoreAPI.Services.DtoModels;
using BookStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public StatusModel Create(Book book)
        {
            var response = new StatusModel();
            var dbBook = _booksRepository.GetByTitle(book.Title);
            if (dbBook == null)
            {
                _booksRepository.Create(book);
                response.Message = $"The book with title {book.Title} has been successfully created";
                return response;
            }
            else
            {
                response.Message = $"The book with title {book.Title} already exists.";
                response.IsSuccessfull = false;
                return response;
            }
        }

        public void Delete(int id)
        {
            var book = _booksRepository.GetById(id);
            if (book != null)
            {
                _booksRepository.Delete(book);
            }
        }

        public List<Book> GetAll()
        {
            return _booksRepository.GetAll();
        }

        public Book GetById(int id)
        {
            return _booksRepository.GetById(id);
        }

        public List<Book> GetWithFilters(string title, string author)
        {
            return _booksRepository.GetWithFilters(title, author);
        }

        public void Update(Book book)
        {
            var dbBook = _booksRepository.GetById(book.Id);
            if (dbBook != null)
            {
                dbBook.Price = book.Price;
                dbBook.Quantity = book.Quantity;
                dbBook.Title = book.Title;
                dbBook.Genre = book.Genre;
                dbBook.Description = book.Description;
                dbBook.Author = book.Author;

                _booksRepository.Update(dbBook);
            }
        }
    }
}
