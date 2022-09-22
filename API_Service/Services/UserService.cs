using Api_Domain.Dtos.User;
using Api_Domain.Entities;
using Api_Domain.Interfaces;
using Api_Domain.Interfaces.Services.User;
using Api_Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;
        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity =  await _repository.SelectAsync(id);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
             var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            // Primeiro recebo um dto, converte dto em uma model, 
            var model = _mapper.Map<UserModel>(user);
            // convert uma model em uma entidade
            var entity = _mapper.Map<UserEntity>(model);
            // Passa a entidade para o banco de dados
            var result = await _repository.InsertAsync(entity);
            // recebe o result  do banco de dados e converte essa entidade em um retorno de createresult.
            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            // Primeiro recebo um dto, converte dto em uma model, 
            var model = _mapper.Map<UserModel>(user);
            // convert uma model em uma entidade
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}
