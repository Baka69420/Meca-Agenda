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
    public class ServiceProduct : IServiceProduct
    {
        private readonly IRepositoryProduct _repository;
        private readonly IMapper _mapper;

        public ServiceProduct(IRepositoryProduct repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ProductDTO productDTO)
        {
            var objectMapped = _mapper.Map<Products>(productDTO);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task DeleteAsync(int productId)
        {
            await _repository.DeleteAsync(productId);
        }

        public async Task<ICollection<ProductDTO>> FindByBrandAsync(string brandName)
        {
            var list = await _repository.FindByBrandAsync(brandName);
            var collection = _mapper.Map<ICollection<ProductDTO>>(list);
            return collection;
        }

        public async Task<ICollection<ProductDTO>> FindByNameAsync(string productName)
        {
            var list = await _repository.FindByNameAsync(productName);
            var collection = _mapper.Map<ICollection<ProductDTO>>(list);
            return collection;
        }

        public async Task<ProductDTO> GetAsync(int id)
        {
            var @object = await _repository.GetAsync(id);
            var objectMapped = _mapper.Map<ProductDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<ProductDTO>> GetByCategoryAsync(int idCategory)
        {
            var list = await _repository.GetByCategoryAsync(idCategory);
            var collection = _mapper.Map<ICollection<ProductDTO>>(list);
            return collection;
        }

        public async Task<ICollection<ProductDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<ProductDTO>>(list);
            return collection;
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            var objectMapped = _mapper.Map<Products>(productDTO);
            await _repository.UpdateAsync(objectMapped);
        }
    }
}
