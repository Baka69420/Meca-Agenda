using MecaAgenda.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.Interfaces
{
    public interface IServiceCategory
    {
        Task<int> AddAsync(CategoryDTO categoryDTO);
        Task DeleteAsync(int categoryId);
        Task<ICollection<CategoryDTO>> FindByNameAsync(string categoryName);
        Task<CategoryDTO> GetAsync(int id);
        Task<ICollection<CategoryDTO>> ListAsync();
        Task UpdateAsync(CategoryDTO categoryDTO);
    }
}
