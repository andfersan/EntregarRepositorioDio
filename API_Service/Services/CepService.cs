using Api_Domain.Dtos.Cep;
using Api_Domain.Entities;
using Api_Domain.Interfaces.Services.Cep;
using Api_Domain.Models;
using Api_Domain.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Service.Services
{
    public class CepService : ICepService
    {
        private ICepRepository _repository;
        private readonly IMapper _mapper;

        public CepService(ICepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CepDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CepDto>(entity);

        }

        public async  Task<CepDto> Get(string cep)
        {
            var entity = await _repository.SelectAsync(cep);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<CepDtoCreateResult> Post(CepDtoCreate cep)
        {
            var model = _mapper.Map<CepModel>(cep);
            var entity = _mapper.Map<CepEntity>(model);
            var result =  await _repository.InsertAsync(entity);

            return _mapper.Map<CepDtoCreateResult>(result);
            
        }

        public async Task<CepDtoUpdateResult> Put(CepDtoUpdate cep)
        {
            var model = _mapper.Map<CepModel>(cep);
            var entity = _mapper.Map<CepEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<CepDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
