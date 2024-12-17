
using Api.DTOs;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class MedicationService
    {
        private readonly IMedicationRepository _medicationRepository;

        public MedicationService(IMedicationRepository repository)
        {
            _medicationRepository = repository;

        }

        public async Task<IEnumerable<MedicationRecordDTO>> GetAllMedications()
        {
            var result = await _medicationRepository.GetAllAsync();
            return result.Select(MedicationRecordDTO.FromMedication);
        }

        public async Task<MedicationRecordDTO> GetMedication(int id)
        {
            var result = await _medicationRepository.GetByIdAsync(id);
            return MedicationRecordDTO.FromMedication(result!);
        }

        public async Task AddMedication(CreateUpdateMedicationRecordDto medicationDto)
        {
            var newMedication = new Medication(medicationDto);
            await _medicationRepository.AddAsync(newMedication);
        }

        public async Task UpdateMedication(int id, CreateUpdateMedicationRecordDto updateMedication)
        {
            var medication = await _medicationRepository.GetByIdAsync(id);
            if (medication != null)
            {
                medication.UpdateMedication(updateMedication);
                await _medicationRepository.UpdateAsync(medication);
            }
        }

        public async Task DeleteMedication(int id) => await _medicationRepository.DeleteAsync(id);

        public IEnumerable<MedicationRecordDTO> GetMedicationsByTherapeuticClass(int therapeuticClassId) => _medicationRepository.GetMedicationsByTherapeuticClass(therapeuticClassId).Select(MedicationRecordDTO.FromMedication);

    }
}