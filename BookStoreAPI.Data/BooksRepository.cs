using BookStoreAPI.Data.Interfaces;
using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreAPI.Data
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public BooksRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
        public void Delete(Book book)
        {
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
        public void Update(Book book)
        {
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
        }

        public List<Book> GetAll()
        {
            return _dbContext.Books.ToList();        
        }
        public Book GetById(int id)
        {
            return _dbContext.Books.FirstOrDefault(x => x.Id == id);
        }
        public Book GetByTitle(string title)
        {
            return _dbContext.Books.FirstOrDefault(x => x.Title == title);
        }

        public List<Book> GetWithFilters(string title, string author)
        {
            var books = _dbContext.Books.AsQueryable();

            if(title != null)
            {
                books = books.Where(x => x.Title.ToLower().Contains(title.ToLower()));
            }
            if (author != null)
            {
                books = books.Where(x => x.Author.ToLower().Contains(author.ToLower()));
            }

            return books.ToList();
        }
    }
}
