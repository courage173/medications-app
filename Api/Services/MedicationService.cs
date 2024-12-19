
using Api.DTOs;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class MedicationService
    {
        private readonly IMedicationRepository _medicationRepository;
        private readonly MedicationActiveIngredientsService _activeIngredientService;

        public MedicationService(IMedicationRepository repository, MedicationActiveIngredientsService activeIngredientService)
        {
            _medicationRepository = repository;
            _activeIngredientService = activeIngredientService;

        }

        public async Task<IEnumerable<MedicationListResponseDto>> GetAllMedications(int pageNumber, int pageSize)
        {
            var result = await _medicationRepository.GetMedicationsAsync(pageNumber, pageSize);
            return result.Select(MedicationListResponseDto.FromMedication);
        }

        public async Task<MedicationRecordDTO> GetMedication(int id)
        {
            var result = await _medicationRepository.GetMedicationByIdAsync(id);
            return MedicationRecordDTO.FromMedication(result!);
        }

        public async Task AddMedication(CreateUpdateMedicationRecordDto medicationDto)
        {
            var newMedication = new Medication(medicationDto);
            var result = await _medicationRepository.AddAsync(newMedication);

            foreach (var activeIngredient in medicationDto.ActiveIngredients)
            {
                var medicationActiveIngredient = new CreateUpdateMedicationActiveIngredientsDto
                {
                    ActiveIngredientId = activeIngredient.ActiveIngredientId,
                    dosage = activeIngredient.dosage,
                    MedicationId = result.Id
                };
                await _activeIngredientService.AddMedicationActiveIngredient(medicationActiveIngredient);
            }
        }

        public async Task UpdateMedication(int id, CreateUpdateMedicationRecordDto updateMedication)
        {
            var medication = await _medicationRepository.GetByIdAsync(id);
            if (medication != null)
            {
                medication.UpdateMedication(updateMedication);
                await _medicationRepository.UpdateAsync(medication);

                // Delete existing active ingredients
                await _activeIngredientService.DeleteByMedicationId(medication.Id);

                // Recreate active ingredients
                foreach (var activeIngredient in updateMedication.ActiveIngredients)
                {
                    var medicationActiveIngredient = new CreateUpdateMedicationActiveIngredientsDto
                    {
                        ActiveIngredientId = activeIngredient.ActiveIngredientId,
                        dosage = activeIngredient.dosage,
                        MedicationId = medication.Id
                    };
                    await _activeIngredientService.AddMedicationActiveIngredient(medicationActiveIngredient);
                }
            }
        }

        public async Task DeleteMedication(int id) => await _medicationRepository.DeleteAsync(id);

        public IEnumerable<MedicationRecordDTO> GetMedicationsByTherapeuticClass(int therapeuticClassId) => _medicationRepository.GetMedicationsByTherapeuticClass(therapeuticClassId).Select(MedicationRecordDTO.FromMedication);

    }
}