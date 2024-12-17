using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Api.Services;
using Api.DTOs;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationController : ControllerBase
    {
        private readonly ClassificationService _service;

        public ClassificationController(ClassificationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ClassificationDto> GetAll() => _service.GetAllClassifications();

        [HttpGet("{id}")]
        public ActionResult<ClassificationDto> GetById(int id)
        {
            var classification = _service.GetClassification(id);
            if (classification == null)
            {
                return NotFound();
            }
            return classification;
        }

        [HttpPost]
        public ActionResult<ClassificationDto> Create(CreateAndUpdateClassificationDto classification)
        {
            return _service.AddClassification(classification.Name);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ClassificationDto data)
        {
            var classification = _service.GetClassification(id);

            if (id != classification.Id)
            {
                return BadRequest();
            }

            _service.UpdateClassification(id, data.Name);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteClassification(id);
            return NoContent();
        }
    }
}