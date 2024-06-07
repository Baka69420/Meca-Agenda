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
        Task<ICollection<Products>> ListAsync();
        Task<ICollection<Products>> GetByCategoryAsync(int idCategory);
        Task<ICollection<Products>> FindByNameAsync(string productName);
        Task<ICollection<Products>> FindByBrandAsync(string brandName);
        Task<Products> GetAsync(int id);
    }
}
