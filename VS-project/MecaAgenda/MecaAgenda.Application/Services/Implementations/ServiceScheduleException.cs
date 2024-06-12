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
    public class ServiceScheduleException : IServiceScheduleException
    {
        private readonly IRepositoryScheduleException _repository;
        private readonly IMapper _mapper;

        public ServiceScheduleException(IRepositoryScheduleException repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ScheduleExceptionDTO> GetAsync(int id)
        {
            var @object = await _repository.GetAsync(id);
            var objectMapped = _mapper.Map<ScheduleExceptionDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<ScheduleExceptionDTO>> GetByBranchAndDateAsync(int idBranch, DateOnly exceptionDate)
        {
            var list = await _repository.GetByBranchAndDateAsync(idBranch, exceptionDate);
            var collection = _mapper.Map<ICollection<ScheduleExceptionDTO>>(list);
            return collection;
        }

        public async Task<ICollection<ScheduleExceptionDTO>> GetByBranchAsync(int idBranch)
        {
            var list = await _repository.GetByBranchAsync(idBranch);
            var collection = _mapper.Map<ICollection<ScheduleExceptionDTO>>(list);
            return collection;
        }

        public async Task<ICollection<ScheduleExceptionDTO>> GetByDateAsync(DateOnly exceptionDate)
        {
            var list = await _repository.GetByDateAsync(exceptionDate);
            var collection = _mapper.Map<ICollection<ScheduleExceptionDTO>>(list);
            return collection;
        }

        public async Task<ICollection<ScheduleExceptionDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<ScheduleExceptionDTO>>(list);
            return collection;
        }
    }
}
