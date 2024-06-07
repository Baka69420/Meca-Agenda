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
        Task<ICollection<Services>> ListAsync();
        Task<ICollection<Services>> FindByNameAsync(string serviceName);
        Task<Services> GetAsync(int id);
    }
}
