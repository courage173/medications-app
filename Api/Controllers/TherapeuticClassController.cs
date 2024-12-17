
using Microsoft.AspNetCore.Mvc;
using Api.Services;
using Api.DTOs;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TherapeuticClassController : ControllerBase
    {
        private readonly TherapeuticClassService _service;

        public TherapeuticClassController(TherapeuticClassService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<TherapeuticClassDto>> GetAll() => await _service.GetAllTherapeuticClasses();

        [HttpGet("{id}")]
        public async Task<ActionResult<TherapeuticClassDto>> GetById(int id)
        {
            var item = await _service.GetTherapeuticClass(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<TherapeuticClassDto>> Create([FromBody] CreateUpdateTherapeuticClassDto item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _service.AddTherapeuticClass(item.Name!);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateUpdateTherapeuticClassDto item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var therapeuticClass = _service.GetTherapeuticClass(id);

            if (therapeuticClass == null)
            {
                return NotFound();
            }

            await _service.UpdateTherapeuticClass(id, item.Name!);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteTherapeuticClass(id);
            return NoContent();
        }
    }
}