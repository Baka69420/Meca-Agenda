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
        Task<int> AddAsync(BillItems item);
        Task DeleteAsync(int billItemId);
        Task DeleteBillItemsAsync(int billId);
        Task<BillItems> GetAsync(int id);
        Task<ICollection<BillItems>> ListAsync(int? idBill);
        Task UpdateAsync(BillItems item);
    }
}
