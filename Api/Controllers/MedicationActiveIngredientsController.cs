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
        public async Task<IEnumerable<MedicationActiveIngredientsResponseDto>> GetAll() => await _service.GetAllMedicationActiveIngredients();

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicationActiveIngredientsResponseDto>> GetById(int id)
        {
            var item = await _service.GetMedicationActiveIngredient(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<MedicationActiveIngredientsResponseDto>> Create(CreateUpdateMedicationActiveIngredientsDto item)
        {
            return await _service.AddMedicationActiveIngredient(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateUpdateMedicationActiveIngredientsDto item)
        {

            var itemToUpdate = await _service.GetMedicationActiveIngredient(id);

            if (itemToUpdate == null)
            {
                return NotFound();
            }

            await _service.UpdateMedicationActiveIngredient(id, item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteMedicationActiveIngredient(id);
            return NoContent();
        }
    }
}