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
            try
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
                        ModelState.AddModelError("", response.Message);
                        //return BadRequest(ModelState);
                    }
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var book = _booksService.GetById(id);
                return Ok(book.ToBookDtoModel());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }


        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _booksService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPut]
        public IActionResult Update(BookDto book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _booksService.Update(book.ToModel());
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
    }
}
