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
    public class ServiceScheduleException : IServiceScheduleException
    {
        private readonly IRepositoryScheduleException _repository;
        private readonly IMapper _mapper;

        public ServiceScheduleException(IRepositoryScheduleException repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ScheduleExceptionDTO scheduleExceptionDTO)
        {
            var objectMapped = _mapper.Map<ScheduleExceptions>(scheduleExceptionDTO);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task DeleteAsync(int scheduleExceptionId)
        {
            await _repository.DeleteAsync(scheduleExceptionId);
        }

        public async Task<ScheduleExceptionDTO> GetAsync(int id)
        {
            var @object = await _repository.GetAsync(id);
            var objectMapped = _mapper.Map<ScheduleExceptionDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<ScheduleExceptionDTO>> ListAsync(int? idBranch, DateOnly? exceptionDate)
        {
            var list = await _repository.ListAsync(idBranch, exceptionDate);
            var collection = _mapper.Map<ICollection<ScheduleExceptionDTO>>(list);
            return collection;
        }

        public async Task UpdateAsync(ScheduleExceptionDTO scheduleExceptionDTO)
        {
            var objectMapped = _mapper.Map<ScheduleExceptions>(scheduleExceptionDTO);
            await _repository.UpdateAsync(objectMapped);
        }
    }
}
