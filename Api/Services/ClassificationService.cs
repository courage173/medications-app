using System.Collections.Generic;
using Api.DTOs;
using Api.Interfaces;
using Api.Models;
using Api.Repositories;
using AutoMapper;

namespace Api.Services
{
    public class ClassificationService
    {

        private readonly IClassificationRepository _repository;

        public ClassificationService(IClassificationRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ClassificationDto> GetAllClassifications() => _repository.GetAll().Select(ClassificationDto.FromClassification);

        public ClassificationDto GetClassification(int id) => ClassificationDto.FromClassification(_repository.GetById(id));

        public ClassificationDto AddClassification(string name)
        {
            var newClassification = new Classification(name);
            var classification = _repository.Add(newClassification);
            return ClassificationDto.FromClassification(classification);
        }

        public void UpdateClassification(int id, string name)
        {
            var classification = _repository.GetById(id);
            if (classification != null)
            {
                classification.UpdateClassification(name);
                _repository.Update(classification);
            }
        }

        public void DeleteClassification(int id) => _repository.Delete(id);
    }
}