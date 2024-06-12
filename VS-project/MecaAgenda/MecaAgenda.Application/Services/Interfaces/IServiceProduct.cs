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
        Task<ICollection<ProductDTO>> ListAsync();
        Task<ICollection<ProductDTO>> GetByCategoryAsync(int idCategory);
        Task<ICollection<ProductDTO>> FindByNameAsync(string productName);
        Task<ICollection<ProductDTO>> FindByBrandAsync(string brandName);
        Task<ProductDTO> GetAsync(int id);
    }
}
