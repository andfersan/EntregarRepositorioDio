﻿using Api_Domain.Dtos.Municipio;
using Api_Domain.Entities;
using Api_Domain.Interfaces.Services.Municpio;
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
    public class MunicipioService : IMunicipioService
    {
        private IMunicipioRepository _repository;
        private readonly IMapper _mapper;

        public MunicipioService(IMunicipioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<MunicipioDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<MunicipioDto>(entity);
        }

        public async Task<IEnumerable<MunicipioDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<MunicipioDto>>(listEntity);

        }

        public async Task<MunicipioDtoCompleto> GetCompleteByIBGE(int codIBGE)
        {
            var entity = await _repository.GetCompleteByIBGE(codIBGE);
            return _mapper.Map<MunicipioDtoCompleto>(entity);
        }

        public async Task<MunicipioDtoCompleto> GetCompleteById(Guid id)
        {
            var entity = await _repository.GetCompleteById(id);
            return _mapper.Map<MunicipioDtoCompleto>(entity);
        }

        public async  Task<MunicipioDtoCreateResult> Post(MunicipioDtoCreate municipio)
        {
            var model = _mapper.Map<MunicipioModel>(municipio);
            var entity = _mapper.Map<MunicipioEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<MunicipioDtoCreateResult>(result);
        }

        public async  Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipio)
        {
            var model = _mapper.Map<MunicipioModel>(municipio);
            var entity = _mapper.Map<MunicipioEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<MunicipioDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
