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
        Task<Products> GetAsync(int id);
        Task<ICollection<Products>> ListAsync(int? idCategory, string brandName, string productName);
        Task UpdateAsync(Products product);
    }
}
