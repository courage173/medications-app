using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationActiveIngredientsController : ControllerBase
    {
        private readonly MedicationActiveIngredientsService _service;

        public MedicationActiveIngredientsController(MedicationActiveIngredientsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<MedicationActiveIngredients> GetAll() => _service.GetAllMedicationActiveIngredients();

        [HttpGet("{id}")]
        public ActionResult<MedicationActiveIngredients> GetById(int id)
        {
            var item = _service.GetMedicationActiveIngredient(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<MedicationActiveIngredients> Create(MedicationActiveIngredients item)
        {
            _service.AddMedicationActiveIngredient(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MedicationActiveIngredients item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _service.UpdateMedicationActiveIngredient(id, item.MedicationId, item.ActiveIngredientId, item.dosage);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteMedicationActiveIngredient(id);
            return NoContent();
        }
    }
}