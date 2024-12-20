using Api.DTOs;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        private readonly MedicationService _service;

        public MedicationsController(MedicationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 15, [FromQuery] string? searchTerm = null, [FromQuery] string? sortBy = null, [FromQuery] bool ascending = true) => Ok(await _service.GetAllMedications(pageNumber, pageSize, searchTerm, sortBy, ascending));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _service.GetMedication(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUpdateMedicationRecordDto medication)
        {
            Console.WriteLine("Creating medication");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model state is invalid");
                return BadRequest(ModelState);
            }
            await _service.AddMedication(medication);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateUpdateMedicationRecordDto medication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.UpdateMedication(id, medication);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteMedication(id);
            return Ok();
        }
    }
}