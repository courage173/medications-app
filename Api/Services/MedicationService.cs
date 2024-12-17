
using Api.DTOs;
using Api.Interfaces;
using Api.Models;
using AutoMapper;

namespace Api.Services
{
    public class MedicationService
    {
        private readonly IMedicationRepository _medicationRepository;
        private readonly IMapper _mapper;

        public MedicationService(IMapper mapper, IMedicationRepository repository)
        {
            _medicationRepository = repository;
            _mapper = mapper;
        }

        public IEnumerable<MedicationRecordDTO> GetAllMedications()
        {
            var medications = _medicationRepository.GetAll();
            var medicationRecords = _mapper.Map<IEnumerable<MedicationRecordDTO>>(medications);
            return medicationRecords;
        }

        public MedicationRecordDTO GetMedication(int id)
        {
            var medication = _medicationRepository.GetById(id);

            var medicationRecord = _mapper.Map<MedicationRecordDTO>(medication);
            return medicationRecord;
        }

        public void AddMedication(MedicationRecordDTO medication)
        {
            var newMedication = _mapper.Map<Medication>(medication);
            _medicationRepository.Add(newMedication);
        }

        public void UpdateMedication(int id, MedicationRecordDTO updateMedication)
        {
            var medication = _medicationRepository.GetById(id);
            if (medication != null)
            {
                medication.UpdateMedication(updateMedication);
                _medicationRepository.Update(medication);
            }
        }

        public void DeleteMedication(int id) => _medicationRepository.Delete(id);

        public IEnumerable<MedicationRecordDTO> GetMedicationsByTherapeuticClass(int therapeuticClassId)
        {
            var medications = _medicationRepository.GetMedicationsByTherapeuticClass(therapeuticClassId);
            var medicationRecords = _mapper.Map<IEnumerable<MedicationRecordDTO>>(medications);
            return medicationRecords;
        }
    }
}