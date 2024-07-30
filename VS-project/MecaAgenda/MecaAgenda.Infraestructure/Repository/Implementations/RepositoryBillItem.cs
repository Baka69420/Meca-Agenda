using MecaAgenda.Infraestructure.Data;
using MecaAgenda.Infraestructure.Models;
using MecaAgenda.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Implementations
{
    public class RepositoryBillItem : IRepositoryBillItem
    {
        private readonly MecaAgendaContext _context;

        public RepositoryBillItem(MecaAgendaContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(BillItems item)
        {
            await _context.Set<BillItems>().AddAsync(item);
            await _context.SaveChangesAsync();
            return item.BillItemId;
        }

        public async Task DeleteAsync(int billItemId)
        {
            var billItemToDelete = await GetAsync(billItemId);

            if (billItemToDelete != null)
            {
                _context.Set<BillItems>().Remove(billItemToDelete);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Bill Item with ID {billItemId} does not exist.");
            }
        }

        public async Task DeleteBillItemsAsync(int billId)
        {
            var billItemsToDelete = await ListAsync(billId);

            if (billItemsToDelete.Any())
            {
                _context.Set<BillItems>().RemoveRange(billItemsToDelete);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Bill with ID {billId} does not exist.");
            }
        }

        public async Task<BillItems> GetAsync(int id)
        {
            var @object = await _context.Set<BillItems>()
                .Where(x => x.BillItemId == id)
                .OrderBy(x => x.BillItemId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<BillItems>> ListAsync(int? idBill)
        {
            var collection = await _context.Set<BillItems>()
                .OrderBy(x => x.BillItemId)
                .AsNoTracking()
                .ToListAsync();

            if (idBill.HasValue)
                collection = collection.Where(x => x.BillId == idBill.Value).ToList();

            return collection;
        }

        public async Task UpdateAsync(BillItems item)
        {
            var billItemToUpdate = await GetAsync(item.BillItemId);

            if (billItemToUpdate != null)
            {
                billItemToUpdate.ProductId = item.ProductId;
                billItemToUpdate.Quantity = item.Quantity;
                billItemToUpdate.ProductPrice = item.ProductPrice;
                billItemToUpdate.Price = item.Price;

                _context.Entry(billItemToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Bill Item with ID {item.BillItemId} does not exist.");
            }
        }
    }
}
