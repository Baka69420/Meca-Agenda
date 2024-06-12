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
    public class ServiceAppointment : IServiceAppointment
    {
        private readonly IRepositoryAppointment _repository;
        private readonly IMapper _mapper;

        public ServiceAppointment(IRepositoryAppointment repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AppointmentDTO> GetAsync(int id)
        {
            var @object = await _repository.GetAsync(id);
            var objectMapped = _mapper.Map<AppointmentDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<AppointmentDTO>> GetByBranchAndClientAsync(int idBranch, int idClient)
        {
            var list = await _repository.GetByBranchAndClientAsync(idBranch, idClient);
            var collection = _mapper.Map<ICollection<AppointmentDTO>>(list);
            return collection;
        }

        public async Task<ICollection<AppointmentDTO>> GetByBranchAndDateAsync(int idBranch, DateOnly appointmentDate)
        {
            var list = await _repository.GetByBranchAndDateAsync(idBranch, appointmentDate);
            var collection = _mapper.Map<ICollection<AppointmentDTO>>(list);
            return collection;
        }

        public async Task<ICollection<AppointmentDTO>> GetByBranchAsync(int idBranch)
        {
            var list = await _repository.GetByBranchAsync(idBranch);
            var collection = _mapper.Map<ICollection<AppointmentDTO>>(list);
            return collection;
        }

        public async Task<ICollection<AppointmentDTO>> GetByClientAndDateAsync(int idClient, DateOnly appointmentDate)
        {
            var list = await _repository.GetByClientAndDateAsync(idClient, appointmentDate);
            var collection = _mapper.Map<ICollection<AppointmentDTO>>(list);
            return collection;
        }

        public async Task<ICollection<AppointmentDTO>> GetByClientAsync(int idClient)
        {
            var list = await _repository.GetByClientAsync(idClient);
            var collection = _mapper.Map<ICollection<AppointmentDTO>>(list);
            return collection;
        }

        public async Task<ICollection<AppointmentDTO>> GetByDateAsync(DateOnly appointmentDate)
        {
            var list = await _repository.GetByDateAsync(appointmentDate);
            var collection = _mapper.Map<ICollection<AppointmentDTO>>(list);
            return collection;
        }

        public async Task<ICollection<AppointmentDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<AppointmentDTO>>(list);
            return collection;
        }
    }
}
