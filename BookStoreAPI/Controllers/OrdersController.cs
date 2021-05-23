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
        [HttpPost]
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
