using BookStoreAPI.DtoModels;
using BookStoreAPI.Mappings;
using BookStoreAPI.Models;
using BookStoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{

    [Route("api/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        [HttpGet]
        public IActionResult Get(string title, string author)
        {
            var books = _booksService.GetWithFilters(title, author);
            var dtoModels = books.Select(x => x.ToBookDtoModel()).ToList();
            return Ok(dtoModels);
        }

        [HttpPost]
        public IActionResult Create(BookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                var response = _booksService.Create(bookDto.ToModel());

                if (response.IsSuccessfull)
                {
                    return Ok(response.Message);
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _booksService.GetById(id);
            return Ok(book.ToBookDtoModel());

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _booksService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(BookDto book)
        {
            _booksService.Update(book.ToModel());
            return Ok();
        }
    }
}
