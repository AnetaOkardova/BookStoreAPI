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

        /// <summary>
        /// Returns all books with filter if any.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        /// <response code="200">Returns list of all books</response>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(string title, string author)
        {
            var books = _booksService.GetWithFilters(title, author);
            var dtoModels = books.Select(x => x.ToBookDtoModel()).ToList();
            return Ok(dtoModels);
        }
        /// <summary>
        /// Creates new book from valid inputs.
        /// </summary>
        /// <param name="createBookDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(CreateBookDto createBookDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = _booksService.Create(createBookDto.ToModel());

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
        /// <summary>
        /// Returns book for given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">No data</response>
        /// <response code="500">If there is an exception caused by server error</response>    
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                var book = _booksService.GetById(id);
                if(book == null)
                {
                    return BadRequest();
                }
                return Ok(book.ToBookDtoModel());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Deletes book for given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">No data</response>
        /// <response code="500">If there is an exception caused by server error</response>    
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        /// <summary>
        /// Updates given book.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        /// <response code="200">No data</response>
        /// <response code="400">If request data is not valid</response>    
        /// <response code="500">If there is an exception caused by server error</response>    
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

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
