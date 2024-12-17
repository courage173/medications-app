using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Api.Services;
using Api.DTOs;

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
        public IEnumerable<MedicationActiveIngredientsResponseDto> GetAll() => _service.GetAllMedicationActiveIngredients();

        [HttpGet("{id}")]
        public ActionResult<MedicationActiveIngredientsResponseDto> GetById(int id)
        {
            var item = _service.GetMedicationActiveIngredient(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<MedicationActiveIngredientsResponseDto> Create(CreateUpdateMedicationActiveIngredientsDto item)
        {
            return _service.AddMedicationActiveIngredient(item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateUpdateMedicationActiveIngredientsDto item)
        {

            var itemToUpdate = _service.GetMedicationActiveIngredient(id);

            if (itemToUpdate == null)
            {
                return NotFound();
            }

            _service.UpdateMedicationActiveIngredient(id, item);
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