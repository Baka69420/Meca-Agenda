using MecaAgenda.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.Interfaces
{
    public interface IServiceProduct
    {
        Task<int> AddAsync(ProductDTO productDTO);
        Task DeleteAsync(int productId);
        Task<ICollection<ProductDTO>> FindByBrandAsync(string brandName);
        Task<ICollection<ProductDTO>> FindByNameAsync(string productName);
        Task<ProductDTO> GetAsync(int id);
        Task<ICollection<ProductDTO>> GetByCategoryAsync(int idCategory);
        Task<ICollection<ProductDTO>> ListAsync();
        Task UpdateAsync(ProductDTO productDTO);
    }
}
