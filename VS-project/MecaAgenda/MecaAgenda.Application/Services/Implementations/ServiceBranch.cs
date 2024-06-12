using AutoMapper;
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
    public class ServiceBranch : IServiceBranch
    {
        private readonly IRepositoryBranch _repository;
        private readonly IMapper _mapper;

        public ServiceBranch(IRepositoryBranch repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<BranchDTO>> FindByNameAsync(string branchName)
        {
            var list = await _repository.FindByNameAsync(branchName);
            var collection = _mapper.Map<ICollection<BranchDTO>>(list);
            return collection;
        }

        public async Task<BranchDTO> GetAsync(int id)
        {
            var @object = await _repository.GetAsync(id);
            var objectMapped = _mapper.Map<BranchDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<BranchDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<BranchDTO>>(list);
            return collection;
        }
    }
}
