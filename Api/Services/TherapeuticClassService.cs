using System.Collections.Generic;
using Api.DTOs;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class TherapeuticClassService
    {
        private readonly ITherapeuticClassRepository _repository;

        public TherapeuticClassService(ITherapeuticClassRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TherapeuticClassDto> GetAllTherapeuticClasses() => _repository.GetAll().Select(TherapeuticClassDto.FromTherapeuticClass);

        public TherapeuticClassDto GetTherapeuticClass(int id) => TherapeuticClassDto.FromTherapeuticClass(_repository.GetById(id));

        public TherapeuticClassDto AddTherapeuticClass(string name)
        {
            var therapeuticClass = new TherapeuticClass(name);
            var response = _repository.Add(therapeuticClass);
            return TherapeuticClassDto.FromTherapeuticClass(response);
        }

        public void UpdateTherapeuticClass(int id, string name)
        {
            var item = _repository.GetById(id);
            if (item != null)
            {
                item = new TherapeuticClass(name);
                _repository.Update(item);
            }
        }

        public void DeleteTherapeuticClass(int id) => _repository.Delete(id);
    }
}