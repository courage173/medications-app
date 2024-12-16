using System.Collections.Generic;
using Api.Models;
using Api.Repositories;

namespace Api.Services
{
    public class PharmaceuticalFormService
    {
        private readonly PharmaceuticalFormRepository _repository;

        public PharmaceuticalFormService(PharmaceuticalFormRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<PharmaceuticalForm> GetAllPharmaceuticalForms() => _repository.GetAll();

        public PharmaceuticalForm GetPharmaceuticalForm(int id) => _repository.GetById(id);

        public void AddPharmaceuticalForm(PharmaceuticalForm item) => _repository.Add(item);

        public void UpdatePharmaceuticalForm(int id, string form)
        {
            var item = _repository.GetById(id);
            if (item != null)
            {
                item = new PharmaceuticalForm(form);
                _repository.Update(item);
            }
        }

        public void DeletePharmaceuticalForm(int id) => _repository.Delete(id);
    }
}