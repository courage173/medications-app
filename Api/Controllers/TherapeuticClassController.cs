
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
        public IEnumerable<TherapeuticClassDto> GetAll() => _service.GetAllTherapeuticClasses();

        [HttpGet("{id}")]
        public ActionResult<TherapeuticClassDto> GetById(int id)
        {
            var item = _service.GetTherapeuticClass(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<TherapeuticClassDto> Create([FromBody] CreateUpdateTherapeuticClassDto item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return _service.AddTherapeuticClass(item.Name);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateUpdateTherapeuticClassDto item)
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

            _service.UpdateTherapeuticClass(id, item.Name);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteTherapeuticClass(id);
            return NoContent();
        }
    }
}