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
        Task<ICollection<ServiceDTO>> ListAsync();
        Task<ICollection<ServiceDTO>> FindByNameAsync(string serviceName);
        Task<ServiceDTO> GetAsync(int id);
    }
}
