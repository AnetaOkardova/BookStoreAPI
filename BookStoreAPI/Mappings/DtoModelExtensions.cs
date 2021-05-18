using BookStoreAPI.DtoModels;
using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Mappings
{
    public static class DtoModelExtensions
    {
        public static Book ToModel(this BookDto entity)
        {
            return new Book
            {
                Id = entity.Id,
                Author = entity.Author,
                Description = entity.Description,
                Genre = entity.Genre,
                Price = entity.Price,
                Quantity = entity.Quantity,
                Title = entity.Title
            };

        }
    }
}
