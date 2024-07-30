using AutoMapper;
using MecaAgenda.Application.DTOs;
using MecaAgenda.Application.Services.Interfaces;
using MecaAgenda.Infraestructure.Models;
using MecaAgenda.Infraestructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.Implementations
{
    public class ServiceUser : IServiceUser
    {
        private readonly IRepositoryUser _repository;
        private readonly IMapper _mapper;

        public ServiceUser(IRepositoryUser repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(UserDTO userDTO)
        {
            var objectMapped = _mapper.Map<Users>(userDTO);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task DeleteAsync(int userId)
        {
            await _repository.DeleteAsync(userId);
        }

        public async Task<UserDTO> GetAsync(int id)
        {
            var @object = await _repository.GetAsync(id);
            var objectMapped = _mapper.Map<UserDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<UserDTO>> ListAsync(string role, string userName)
        {
            var list = await _repository.ListAsync(role, userName);
            var collection = _mapper.Map<ICollection<UserDTO>>(list);
            return collection;
        }

        public async Task UpdateAsync(UserDTO userDTO)
        {
            var objectMapped = _mapper.Map<Users>(userDTO);
            await _repository.UpdateAsync(objectMapped);
        }
    }
}
