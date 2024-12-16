using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaceuticalFormController : ControllerBase
    {
        private readonly PharmaceuticalFormService _service;

        public PharmaceuticalFormController(PharmaceuticalFormService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<PharmaceuticalForm> GetAll() => _service.GetAllPharmaceuticalForms();

        [HttpGet("{id}")]
        public ActionResult<PharmaceuticalForm> GetById(int id)
        {
            var item = _service.GetPharmaceuticalForm(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<PharmaceuticalForm> Create(PharmaceuticalForm item)
        {
            _service.AddPharmaceuticalForm(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PharmaceuticalForm item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _service.UpdatePharmaceuticalForm(id, item.Form);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeletePharmaceuticalForm(id);
            return NoContent();
        }
    }
}