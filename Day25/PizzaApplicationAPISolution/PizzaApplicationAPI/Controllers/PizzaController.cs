using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using PizzaApplicationAPI.Exceptions;
using PizzaApplicationAPI.Models;
using PizzaApplicationAPI.Services;

namespace PizzaApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _PizzaService;
        public PizzaController(IPizzaService PizzaService) 
        {
            _PizzaService = PizzaService;
        }


        [Route("GetAllPizzasInStock")]
        [HttpGet]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(Error))]
        public async Task<ActionResult<List<Pizza>>> GetAllPizzasInStock()
        {
            try
            {
                var pizzas = await _PizzaService.GetAllPizzasInStock();
                return Ok(pizzas.ToList());
            }
            catch(NoPizzasFoundException npfr)
            {
                return NotFound(new Error(404, npfr.Message));
            }
            catch(NoPizzaInStockException npis)
            {
                return NotFound(new Error(404, npis.Message));
            }
        }

        [Route("AddPizza")]
        [HttpPost]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(Error))]
        public async Task<ActionResult<Pizza>> AddPizza(Pizza pizza)
        {
            var inserted_pizza = await _PizzaService.AddPizza(pizza);
            return Ok(inserted_pizza);
        }
    }
}
