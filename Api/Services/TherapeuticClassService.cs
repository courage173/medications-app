using System.Collections.Generic;
using Api.Models;
using Api.Repositories;

namespace Api.Services
{
    public class TherapeuticClassService
    {
        private readonly TherapeuticClassRepository _repository;

        public TherapeuticClassService(TherapeuticClassRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TherapeuticClass> GetAllTherapeuticClasses() => _repository.GetAll();

        public TherapeuticClass GetTherapeuticClass(int id) => _repository.GetById(id);

        public void AddTherapeuticClass(TherapeuticClass item) => _repository.Add(item);

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