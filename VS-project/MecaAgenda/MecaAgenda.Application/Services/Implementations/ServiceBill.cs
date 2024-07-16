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

        public async Task<ICollection<BillDTO>> GetByBranchAndClientAsync(int idBranch, int idClient)
        {
            var list = await _repository.GetByBranchAndClientAsync(idBranch, idClient);
            var collection = _mapper.Map<ICollection<BillDTO>>(list);
            return collection;
        }

        public async Task<ICollection<BillDTO>> GetByBranchAndDateAsync(int idBranch, DateOnly billDate)
        {
            var list = await _repository.GetByBranchAndDateAsync(idBranch, billDate);
            var collection = _mapper.Map<ICollection<BillDTO>>(list);
            return collection;
        }

        public async Task<ICollection<BillDTO>> GetByBranchAsync(int idBranch)
        {
            var list = await _repository.GetByBranchAsync(idBranch);
            var collection = _mapper.Map<ICollection<BillDTO>>(list);
            return collection;
        }

        public async Task<ICollection<BillDTO>> GetByClientAndDateAsync(int idClient, DateOnly billDate)
        {
            var list = await _repository.GetByClientAndDateAsync(idClient, billDate);
            var collection = _mapper.Map<ICollection<BillDTO>>(list);
            return collection;
        }

        public async Task<ICollection<BillDTO>> GetByClientAsync(int idClient)
        {
            var list = await _repository.GetByClientAsync(idClient);
            var collection = _mapper.Map<ICollection<BillDTO>>(list);
            return collection;
        }

        public async Task<ICollection<BillDTO>> GetByDateAsync(DateOnly billDate)
        {
            var list = await _repository.GetByDateAsync(billDate);
            var collection = _mapper.Map<ICollection<BillDTO>>(list);
            return collection;
        }

        public async Task<ICollection<BillDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
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
