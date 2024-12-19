
using Microsoft.AspNetCore.Mvc;
using Api.Services;
using Api.DTOs;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveIngredientController : ControllerBase
    {
        private readonly ActiveIngredientService _service;

        public ActiveIngredientController(ActiveIngredientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ActiveIngredientDto>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 15)
        {
            return await _service.GetAllActiveIngredientsAsync(pageNumber, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActiveIngredientDto>> GetById(int id)
        {
            var item = await _service.GetActiveIngredientAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<ActiveIngredientDto>> Create(CreateUpdateActiveIngredientDto item)
        {
            Console.WriteLine("Creating ATCCode with code: " + item);
            return await _service.AddActiveIngredientAsync(item.Name);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateUpdateActiveIngredientDto item)
        {

            var itemToUpdate = await _service.GetActiveIngredientAsync(id);

            if (itemToUpdate == null)
            {
                return NotFound();
            }

            await _service.UpdateActiveIngredientAsync(id, item.Name);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteActiveIngredientAsync(id);
            return NoContent();
        }
    }
}