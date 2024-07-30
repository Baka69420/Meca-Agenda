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
        Task<ProductDTO> GetAsync(int id);
        Task<ICollection<ProductDTO>> ListAsync(int? idCategory, string brandName, string productName);
        Task UpdateAsync(ProductDTO productDTO);
    }
}
