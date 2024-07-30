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
        Task<int> AddAsync(Services service);
        Task DeleteAsync(int serviceId);
        Task<Services> GetAsync(int serviceId);
        Task<ICollection<Services>> ListAsync(string serviceName);
        Task UpdateAsync(Services service);
    }
}
