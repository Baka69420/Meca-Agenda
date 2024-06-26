﻿using AutoMapper;
using MecaAgenda.Application.DTOs;
using MecaAgenda.Application.Services.Interfaces;
using MecaAgenda.Infraestructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IRepositoryService _repository;
        private readonly IMapper _mapper;

        public ServiceService(IRepositoryService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<ServiceDTO>> FindByNameAsync(string serviceName)
        {
            var list = await _repository.FindByNameAsync(serviceName);
            var collection = _mapper.Map<ICollection<ServiceDTO>>(list);
            return collection;
        }

        public async Task<ServiceDTO> GetAsync(int id)
        {
            var @object = await _repository.GetAsync(id);
            var objectMapped = _mapper.Map<ServiceDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<ServiceDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<ServiceDTO>>(list);
            return collection;
        }
    }
}
