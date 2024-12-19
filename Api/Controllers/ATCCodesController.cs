
using Microsoft.AspNetCore.Mvc;
using Api.Services;
using Api.DTOs;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATCCodesController : ControllerBase
    {
        private readonly ATCCodeService _service;

        public ATCCodesController(ATCCodeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ATCCodeDto>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 15)
        {
            return await _service.GetAllATCCodesAsync(pageNumber, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ATCCodeDto>> GetById(int id)
        {
            var item = await _service.GetATCCodeAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<ATCCodeDto>> Create(CreateUpdateATCCodeDto item)
        {
            Console.WriteLine("Creating ATCCode with code: " + item);
            return await _service.AddATCCodeAsync(item.Code);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateUpdateATCCodeDto item)
        {

            var itemToUpdate = await _service.GetATCCodeAsync(id);

            if (itemToUpdate == null)
            {
                return NotFound();
            }

            await _service.UpdateATCCodeAsync(id, item.Code);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteATCCodeAsync(id);
            return NoContent();
        }
    }
}