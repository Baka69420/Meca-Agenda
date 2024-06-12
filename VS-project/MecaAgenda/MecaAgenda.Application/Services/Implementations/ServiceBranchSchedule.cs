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
    public class ServiceBranchSchedule : IServiceBranchSchedule
    {
        private readonly IRepositoryBranchSchedule _repository;
        private readonly IMapper _mapper;

        public ServiceBranchSchedule(IRepositoryBranchSchedule repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BranchScheduleDTO> GetAsync(int id)
        {
            var @object = await _repository.GetAsync(id);
            var objectMapped = _mapper.Map<BranchScheduleDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<BranchScheduleDTO>> GetByBranch(int idBranch)
        {
            var list = await _repository.GetByBranch(idBranch);
            var collection = _mapper.Map<ICollection<BranchScheduleDTO>>(list);
            return collection;
        }

        public async Task<ICollection<BranchScheduleDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<BranchScheduleDTO>>(list);
            return collection;
        }
    }
}
