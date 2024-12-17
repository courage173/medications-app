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
        private readonly IMapper _mapper;

        public ClassificationService(IMapper mapper, ClassificationRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ClassificationDto> GetAllClassifications()
        {
            var classifications = _repository.GetAll();
            var classificationRecords = _mapper.Map<IEnumerable<ClassificationDto>>(classifications);
            return classificationRecords;
        }

        public ClassificationDto GetClassification(int id)
        {
            var classification = _repository.GetById(id);

            var classificationRecord = _mapper.Map<ClassificationDto>(classification);
            return classificationRecord;
        }

        public void AddClassification(ClassificationDto classification)
        {
            var newClassification = _mapper.Map<Classification>(classification);
            _repository.Add(newClassification);
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