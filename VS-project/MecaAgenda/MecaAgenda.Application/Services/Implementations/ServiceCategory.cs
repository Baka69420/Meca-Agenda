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
    public class ServiceCategory : IServiceCategory
    {
        private readonly IRepositoryCategory _repository;
        private readonly IMapper _mapper;

        public ServiceCategory(IRepositoryCategory repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<CategoryDTO>> FindByNameAsync(string categoryName)
        {
            var list = await _repository.FindByNameAsync(categoryName);
            var collection = _mapper.Map<ICollection<CategoryDTO>>(list);
            return collection;
        }

        public async Task<CategoryDTO> GetAsync(int id)
        {
            var @object = await _repository.GetAsync(id);
            var objectMapped = _mapper.Map<CategoryDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<CategoryDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<CategoryDTO>>(list);
            return collection;
        }
    }
}
