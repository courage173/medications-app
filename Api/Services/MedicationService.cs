using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Interfaces;
using Api.Models;
using Api.Repositories;

namespace Api.Services
{
    public class MedicationService
    {
        private readonly MedicationRepository _medicationRepository;

        public MedicationService(MedicationRepository repository)
        {
            _medicationRepository = repository;
        }

        public IEnumerable<Medication> GetAllMedications() => _medicationRepository.GetAll();

        public Medication GetMedication(int id) => _medicationRepository.GetById(id);

        public void AddMedication(Medication medication) => _medicationRepository.Add(medication);

        public void UpdateMedication(int id, string name, string competentAuthorityStatus, string internalStatus, string unit, int pharmaceuticalFormId, int atcCodeId, int therapeuticClassId, int classificationId)
        {
            var medication = _medicationRepository.GetById(id);
            if (medication != null)
            {
                medication.UpdateMedication(name, competentAuthorityStatus, internalStatus, unit, pharmaceuticalFormId, atcCodeId, therapeuticClassId, classificationId);
                _medicationRepository.Update(medication);
            }
        }

        public void DeleteMedication(int id) => _medicationRepository.Delete(id);

        public IEnumerable<Medication> GetMedicationsByTherapeuticClass(int therapeuticClassId) => _medicationRepository.GetMedicationsByTherapeuticClass(therapeuticClassId);
    }
}