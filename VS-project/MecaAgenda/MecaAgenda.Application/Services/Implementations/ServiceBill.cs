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
    public class ServiceBill : IServiceBill
    {
        private readonly IRepositoryBill _repository;
        private readonly IMapper _mapper;

        public ServiceBill(IRepositoryBill repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(BillDTO billDTO)
        {
            var objectMapped = _mapper.Map<Bills>(billDTO);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task DeleteAsync(int billId)
        {
            await _repository.DeleteAsync(billId);
        }

        public async Task<BillDTO> GetAsync(int id)
        {
            var @object = await _repository.GetAsync(id);
            var objectMapped = _mapper.Map<BillDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<BillDTO>> ListAsync(int? idBranch, int? idClient, DateOnly? billStartDate, DateOnly? billEndDate)
        {
            var list = await _repository.ListAsync(idBranch, idClient, billStartDate, billEndDate);
            var collection = _mapper.Map<ICollection<BillDTO>>(list);
            return collection;
        }

        public async Task UpdateAsync(BillDTO billDTO)
        {
            var objectMapped = _mapper.Map<Bills>(billDTO);
            await _repository.UpdateAsync(objectMapped);
        }
    }
}
