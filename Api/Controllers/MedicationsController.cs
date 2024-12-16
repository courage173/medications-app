using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Services;
using MedicationApp.Models;
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

        [HttpPost]
        public IActionResult Create([FromBody] Medication medication)
        {
            _service.AddMedication(medication);
            return Ok();
        }

        // Add other endpoints similarly
    }
}