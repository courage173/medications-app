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
        public IEnumerable<PharmaceuticalFormDto> GetAll() => _service.GetAllPharmaceuticalForms();

        [HttpGet("{id}")]
        public ActionResult<PharmaceuticalFormDto> GetById(int id)
        {
            var item = _service.GetPharmaceuticalForm(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<PharmaceuticalFormDto> Create(CreateUpdatePharmaceuticalForm item)
        {
            return _service.AddPharmaceuticalForm(item.Form);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateUpdatePharmaceuticalForm item)
        {
            var pharmaceuticalForm = _service.GetPharmaceuticalForm(id);

            if (pharmaceuticalForm == null)
            {
                return NotFound();
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