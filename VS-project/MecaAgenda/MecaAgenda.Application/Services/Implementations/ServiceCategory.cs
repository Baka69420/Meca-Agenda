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
    public class ServiceCategory : IServiceCategory
    {
        private readonly IRepositoryCategory _repository;
        private readonly IMapper _mapper;

        public ServiceCategory(IRepositoryCategory repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(CategoryDTO categoryDTO)
        {
            var objectMapped = _mapper.Map<Categories>(categoryDTO);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task DeleteAsync(int categoryId)
        {
            await _repository.DeleteAsync(categoryId);
        }

        public async Task<CategoryDTO> GetAsync(int id)
        {
            var @object = await _repository.GetAsync(id);
            var objectMapped = _mapper.Map<CategoryDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<CategoryDTO>> ListAsync(string categoryName)
        {
            var list = await _repository.ListAsync(categoryName);
            var collection = _mapper.Map<ICollection<CategoryDTO>>(list);
            return collection;
        }

        public async Task UpdateAsync(CategoryDTO categoryDTO)
        {
            var objectMapped = _mapper.Map<Categories>(categoryDTO);
            await _repository.UpdateAsync(objectMapped);
        }
    }
}
