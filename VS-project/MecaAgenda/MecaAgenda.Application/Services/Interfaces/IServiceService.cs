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
        Task<int> AddAsync(ServiceDTO dto);
        Task DeleteAsync(int serviceId);
        Task<ICollection<ServiceDTO>> FindByNameAsync(string serviceName);
        Task<ServiceDTO> GetAsync(int id);
        Task<ICollection<ServiceDTO>> ListAsync();
        Task UpdateAsync(ServiceDTO dto);
    }
}
