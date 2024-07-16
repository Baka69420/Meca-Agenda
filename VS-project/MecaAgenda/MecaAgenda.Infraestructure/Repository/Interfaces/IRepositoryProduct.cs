using MecaAgenda.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryProduct
    {
        Task<int> AddAsync(Products product);
        Task DeleteAsync(int productId);
        Task<ICollection<Products>> FindByBrandAsync(string brandName);
        Task<ICollection<Products>> FindByNameAsync(string productName);
        Task<Products> GetAsync(int id);
        Task<ICollection<Products>> GetByCategoryAsync(int idCategory);
        Task<ICollection<Products>> ListAsync();
        Task UpdateAsync(Products product);
    }
}
