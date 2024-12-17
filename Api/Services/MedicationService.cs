
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

        public IEnumerable<MedicationRecordDTO> GetAllMedications() => _medicationRepository.GetAll().Select(MedicationRecordDTO.FromMedication);

        public MedicationRecordDTO GetMedication(int id) => MedicationRecordDTO.FromMedication(_medicationRepository.GetById(id));

        public void AddMedication(CreateUpdateMedicationRecordDto medicationDto)
        {
            var newMedication = new Medication(medicationDto);
            _medicationRepository.Add(newMedication);
        }

        public void UpdateMedication(int id, CreateUpdateMedicationRecordDto updateMedication)
        {
            var medication = _medicationRepository.GetById(id);
            if (medication != null)
            {
                medication.UpdateMedication(updateMedication);
                _medicationRepository.Update(medication);
            }
        }

        public void DeleteMedication(int id) => _medicationRepository.Delete(id);

        public IEnumerable<MedicationRecordDTO> GetMedicationsByTherapeuticClass(int therapeuticClassId) => _medicationRepository.GetMedicationsByTherapeuticClass(therapeuticClassId).Select(MedicationRecordDTO.FromMedication);

    }
}