using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Services;

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
        public IEnumerable<Classification> GetAll() => _service.GetAllClassifications();

        [HttpGet("{id}")]
        public ActionResult<Classification> GetById(int id)
        {
            var classification = _service.GetClassification(id);
            if (classification == null)
            {
                return NotFound();
            }
            return classification;
        }

        [HttpPost]
        public ActionResult<Classification> Create(Classification classification)
        {
            _service.AddClassification(classification);
            return CreatedAtAction(nameof(GetById), new { id = classification.Id }, classification);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Classification classification)
        {
            if (id != classification.Id)
            {
                return BadRequest();
            }

            _service.UpdateClassification(id, classification.Name);
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