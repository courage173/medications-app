using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Interfaces;
using MedicationApp.Models;

namespace Api.Services
{
    public class MedicationService
    {
        private readonly IRepository<Medication> _medicationRepository;

        public MedicationService(IRepository<Medication> repository)
        {
            _medicationRepository = repository;
        }

        public IEnumerable<Medication> GetAllMedications() => _medicationRepository.GetAll();

        public Medication GetMedication(int id) => _medicationRepository.GetById(id);

        public void AddMedication(Medication medication) => _medicationRepository.Add(medication);

        public void UpdateMedication(int id, string name, string therapeuticClass, string classification, string status)
        {
            var medication = _medicationRepository.GetById(id);
            if (medication != null)
            {
                medication.UpdateMedication(name, therapeuticClass, classification, status);
                _medicationRepository.Update(medication);
            }
        }

        public void DeleteMedication(int id) => _medicationRepository.Delete(id);
    }

}