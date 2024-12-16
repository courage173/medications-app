using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Services;

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
        public IEnumerable<TherapeuticClass> GetAll() => _service.GetAllTherapeuticClasses();

        [HttpGet("{id}")]
        public ActionResult<TherapeuticClass> GetById(int id)
        {
            var item = _service.GetTherapeuticClass(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<TherapeuticClass> Create(TherapeuticClass item)
        {
            _service.AddTherapeuticClass(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TherapeuticClass item)
        {
            if (id != item.Id)
            {
                return BadRequest();
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