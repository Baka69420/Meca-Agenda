using MecaAgenda.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.Interfaces
{
    public interface IServiceService
    {
        Task<int> AddAsync(ServiceDTO serviceDTO);
        Task DeleteAsync(int serviceId);
        Task<ServiceDTO> GetAsync(int id);
        Task<ICollection<ServiceDTO>> ListAsync(string serviceName);
        Task UpdateAsync(ServiceDTO serviceDTO);
    }
}
