using System.Collections.Generic;
using Api.Models;
using Api.Repositories;

namespace Api.Services
{
    public class ClassificationService
    {
        private readonly ClassificationRepository _repository;

        public ClassificationService(ClassificationRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Classification> GetAllClassifications() => _repository.GetAll();

        public Classification GetClassification(int id) => _repository.GetById(id);

        public void AddClassification(Classification classification) => _repository.Add(classification);

        public void UpdateClassification(int id, string name)
        {
            var classification = _repository.GetById(id);
            if (classification != null)
            {
                classification = new Classification(name);
                _repository.Update(classification);
            }
        }

        public void DeleteClassification(int id) => _repository.Delete(id);
    }
}