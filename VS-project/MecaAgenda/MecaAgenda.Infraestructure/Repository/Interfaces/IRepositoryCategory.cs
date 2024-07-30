using MecaAgenda.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryCategory
    {
        Task<int> AddAsync(Categories category);
        Task DeleteAsync(int categoryId);
        Task<Categories> GetAsync(int id);
        Task<ICollection<Categories>> ListAsync(string categoryName);
        Task UpdateAsync(Categories category);
    }
}
