using MecaAgenda.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryService
    {
        Task<int> AddAsync(Services entity);
        Task DeleteAsync(int serviceId);
        Task<ICollection<Services>> FindByNameAsync(string serviceName);
        Task<Services> GetAsync(int id);
        Task<ICollection<Services>> ListAsync();
        Task UpdateAsync(Services entity);
    }
}
