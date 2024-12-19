using Api.DTOs;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class ATCCodeService
    {
        private readonly IATCCodepository _repository;

        public ATCCodeService(IATCCodepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ATCCodeDto>> GetAllATCCodesAsync(int pageNumber, int pageSize)
        {
            var atcCodes = await _repository.GetAllAsync(pageNumber, pageSize);
            return atcCodes.Select(ATCCodeDto.FromATCCode).ToList();
        }

        public async Task<ATCCodeDto> GetATCCodeAsync(int id)
        {
            var atcCode = await _repository.GetByIdAsync(id);
            return ATCCodeDto.FromATCCode(atcCode!);
        }

        public async Task<ATCCodeDto> AddATCCodeAsync(string code)
        {
            var newATCCode = new ATCCodes(code);
            var atcCode = await _repository.AddAsync(newATCCode);
            return ATCCodeDto.FromATCCode(atcCode);
        }

        public async Task UpdateATCCodeAsync(int id, string code)
        {
            var atcCode = await _repository.GetByIdAsync(id);
            if (atcCode != null)
            {
                atcCode = new ATCCodes(code);
                await _repository.UpdateAsync(atcCode);
            }
        }

        public async Task DeleteATCCodeAsync(int id) => await _repository.DeleteAsync(id);
    }
}