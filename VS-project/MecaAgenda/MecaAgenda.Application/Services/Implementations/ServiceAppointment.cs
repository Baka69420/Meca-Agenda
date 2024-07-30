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
    public class ServiceAppointment : IServiceAppointment
    {
        private readonly IRepositoryAppointment _repository;
        private readonly IMapper _mapper;

        public ServiceAppointment(IRepositoryAppointment repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AppointmentDTO appointmentDTO)
        {
            var objectMapped = _mapper.Map<Appointments>(appointmentDTO);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task DeleteAsync(int appointmentId)
        {
            await _repository.DeleteAsync(appointmentId);
        }

        public async Task<AppointmentDTO> GetAsync(int id)
        {
            var @object = await _repository.GetAsync(id);
            var objectMapped = _mapper.Map<AppointmentDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<AppointmentDTO>> ListAsync(int? idBranch, int? idClient, DateOnly? appointmentDate)
        {
            var list = await _repository.ListAsync(idBranch, idClient, appointmentDate);
            var collection = _mapper.Map<ICollection<AppointmentDTO>>(list);
            return collection;
        }

        public async Task UpdateAsync(AppointmentDTO appointmentDTO)
        {
            var objectMapped = _mapper.Map<Appointments>(appointmentDTO);
            await _repository.UpdateAsync(objectMapped);
        }
    }
}
