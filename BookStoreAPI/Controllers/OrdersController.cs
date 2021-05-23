using BookStoreAPI.DtoModels;
using BookStoreAPI.Mappings;
using BookStoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        /// <summary>
        /// Creates new order from valid inputs.
        /// </summary>
        /// <param name="createOrderDto"></param>
        /// <returns></returns>
        /// <response code="200">No data</response>
        /// <response code="400">If request data is not valid</response>    
        /// <response code="500">If there is an exception caused by server error</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create(CreateOrderDto createOrderDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = _ordersService.Create(createOrderDto.ToModel());

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
    }
}
