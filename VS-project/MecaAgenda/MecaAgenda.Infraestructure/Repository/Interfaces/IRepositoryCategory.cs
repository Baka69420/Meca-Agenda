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
        Task<ICollection<Categories>> ListAsync();
        Task<ICollection<Categories>> FindByNameAsync(string categoryName);
        Task<Categories> GetAsync(int id);
    }
}
