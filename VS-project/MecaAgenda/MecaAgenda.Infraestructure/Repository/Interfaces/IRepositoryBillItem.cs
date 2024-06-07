using MecaAgenda.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryBillItem
    {
        Task<ICollection<BillItems>> ListAsync();
        Task<ICollection<BillItems>> GetByBillAsync(int idBill);
        Task<BillItems> GetAsync(int id);
    }
}
