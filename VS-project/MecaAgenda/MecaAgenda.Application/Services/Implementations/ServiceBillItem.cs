using AutoMapper;
using MecaAgenda.Application.DTOs;
using MecaAgenda.Application.Services.Interfaces;
using MecaAgenda.Infraestructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.Implementations
{
    public class ServiceBillItem : IServiceBillItem
    {
        private readonly IRepositoryBillItem _repository;
        private readonly IMapper _mapper;

        public ServiceBillItem(IRepositoryBillItem repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BillItemDTO> GetAsync(int id)
        {
            var @object = await _repository.GetAsync(id);
            var objectMapped = _mapper.Map<BillItemDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<BillItemDTO>> GetByBillAsync(int idBill)
        {
            var list = await _repository.GetByBillAsync(idBill);
            var collection = _mapper.Map<ICollection<BillItemDTO>>(list);
            return collection;
        }

        public async Task<ICollection<BillItemDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<BillItemDTO>>(list);
            return collection;
        }
    }
}
