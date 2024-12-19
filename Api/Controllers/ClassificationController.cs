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
        public async Task<IEnumerable<ClassificationDto>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 15) => await _service.GetAllClassificationsAsync(pageNumber, pageSize);

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassificationDto>> GetById(int id)
        {
            var classification = await _service.GetClassificationAsync(id);
            if (classification == null)
            {
                return NotFound();
            }
            return classification;
        }

        [HttpPost]
        public async Task<ActionResult<ClassificationDto>> Create([FromBody] CreateAndUpdateClassificationDto classification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _service.AddClassificationAsync(classification.Name!);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClassificationDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classification = await _service.GetClassificationAsync(id);

            if (id != classification.Id)
            {
                return BadRequest();
            }

            await _service.UpdateClassificationAsync(id, data.Name!);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteClassificationAsync(id);
            return NoContent();
        }
    }
}