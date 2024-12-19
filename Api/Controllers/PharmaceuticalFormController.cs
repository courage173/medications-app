using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Api.Services;
using Api.DTOs;

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
        public async Task<IEnumerable<PharmaceuticalFormDto>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 15) => await _service.GetAllPharmaceuticalForms(pageNumber, pageSize);

        [HttpGet("{id}")]
        public async Task<ActionResult<PharmaceuticalFormDto>> GetById(int id)
        {
            var item = await _service.GetPharmaceuticalForm(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<PharmaceuticalFormDto>> Create([FromBody] CreateUpdatePharmaceuticalFormDto item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _service.AddPharmaceuticalForm(item.Form);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateUpdatePharmaceuticalFormDto item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pharmaceuticalForm = _service.GetPharmaceuticalForm(id);

            if (pharmaceuticalForm == null)
            {
                return NotFound();
            }

            await _service.UpdatePharmaceuticalForm(id, item.Form!);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePharmaceuticalForm(id);
            return NoContent();
        }
    }
}