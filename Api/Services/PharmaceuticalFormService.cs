using System.Collections.Generic;
using Api.DTOs;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class PharmaceuticalFormService
    {
        private readonly IPharmaceuticalFormRepository _repository;

        public PharmaceuticalFormService(IPharmaceuticalFormRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<PharmaceuticalFormDto> GetAllPharmaceuticalForms() => _repository.GetAll().Select(PharmaceuticalFormDto.FromPharmaceuticalForm);

        public PharmaceuticalFormDto GetPharmaceuticalForm(int id) => PharmaceuticalFormDto.FromPharmaceuticalForm(_repository.GetById(id));

        public PharmaceuticalFormDto AddPharmaceuticalForm(string form)
        {
            var pharmaceuticalForm = new PharmaceuticalForm(form);
            var response = _repository.Add(pharmaceuticalForm);
            return PharmaceuticalFormDto.FromPharmaceuticalForm(response);
        }

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