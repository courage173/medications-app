using Api.DTOs;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class MedicationsController : ControllerBase
    {
        private readonly MedicationService _service;

        public MedicationsController(MedicationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAllMedications());

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_service.GetMedication(id));

        [HttpPost]
        public IActionResult Create([FromBody] MedicationRecordDTO medication)
        {
            _service.AddMedication(medication);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MedicationRecordDTO medication)
        {
            _service.UpdateMedication(id, medication);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteMedication(id);
            return Ok();
        }
    }
}